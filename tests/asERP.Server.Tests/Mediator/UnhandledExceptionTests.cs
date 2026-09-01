using System.Net;
using System.Net.Http.Json;
using asERP.Application.Contracts.Services;
using asERP.Server.Tests.Infrastructure;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Mediator;

/// <summary>
/// Handlers no longer wrap themselves in a broad try/catch; an unexpected exception is expected to
/// travel all the way to <c>GlobalExceptionHandler</c>. These tests pin what the caller then sees:
/// a generic 500 that never carries the exception text.
/// </summary>
public class UnhandledExceptionTests : IDisposable
{
    private const string SecretDetail = @"Server=db;Password=hunter2;File=C:\secret\path.txt";

    private sealed class ThrowingSetupStatusService : ISetupStatusService
    {
        public Task<bool> IsSetupRequiredAsync() => throw new InvalidOperationException(SecretDetail);
    }

    private readonly TestWebApplicationFactory<Program> _factory = new();

    public UnhandledExceptionTests()
    {
        // Same reason as SetupTests: TEST_DB_NAME leaks between test classes.
        Environment.SetEnvironmentVariable("TEST_DB_NAME", "UnhandledExceptionTestDb_" + Guid.NewGuid());
    }

    private HttpClient CreateThrowingClient() =>
        _factory.WithWebHostBuilder(builder =>
            builder.ConfigureTestServices(services =>
                services.AddScoped<ISetupStatusService, ThrowingSetupStatusService>()))
            .CreateClient();

    [Fact]
    public async Task HandlerException_IsReportedAsGenericServerError()
    {
        using var client = CreateThrowingClient();

        var response = await client.PostAsJsonAsync("/api/v1/setup", new
        {
            Email = "admin@throwing-test.com",
            Password = "P@ssword1",
            Firstname = "Super",
            Lastname = "Admin",
            TenantName = "Throwing Tenant",
            TenantDescription = "never created"
        });

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.InternalServerError);
    }

    [Fact]
    public async Task HandlerException_DoesNotLeakExceptionTextToTheClient()
    {
        using var client = CreateThrowingClient();

        var response = await client.PostAsJsonAsync("/api/v1/setup", new
        {
            Email = "admin@throwing-test.com",
            Password = "P@ssword1",
            Firstname = "Super",
            Lastname = "Admin",
            TenantName = "Throwing Tenant",
            TenantDescription = "never created"
        });

        var body = await response.Content.ReadAsStringAsync();

        TestAssertions.AssertFalse(body.Contains("hunter2", StringComparison.Ordinal),
            $"Response leaked exception detail: {body}");
        TestAssertions.AssertFalse(body.Contains(@"C:\secret", StringComparison.Ordinal),
            $"Response leaked a file path: {body}");
        TestAssertions.AssertFalse(body.Contains(nameof(InvalidOperationException), StringComparison.Ordinal),
            $"Response leaked the exception type: {body}");
    }

    /// <summary>
    /// The setup handler holds a process-wide semaphore while it runs. Now that exceptions bubble
    /// instead of being swallowed, its <c>finally</c> is the only thing releasing that lock — if it
    /// were lost, a second request would hang forever rather than fail.
    /// </summary>
    [Fact]
    public async Task ThrowingHandler_StillReleasesItsLock()
    {
        using var client = CreateThrowingClient();
        var payload = new
        {
            Email = "admin@throwing-test.com",
            Password = "P@ssword1",
            Firstname = "Super",
            Lastname = "Admin",
            TenantName = "Throwing Tenant",
            TenantDescription = "never created"
        };

        await client.PostAsJsonAsync("/api/v1/setup", payload);

        var second = client.PostAsJsonAsync("/api/v1/setup", payload);
        var finished = await Task.WhenAny(second, Task.Delay(TimeSpan.FromSeconds(10)));

        TestAssertions.AssertTrue(ReferenceEquals(finished, second),
            "The second setup request never completed — the setup lock was not released.");
        TestAssertions.AssertHttpStatusCode(await second, HttpStatusCode.InternalServerError);
    }

    public void Dispose() => _factory.Dispose();
}
