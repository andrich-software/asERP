using System.Net;
using System.Net.Http.Json;
using asERP.Application.Contracts.Services;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.ServerInfo;
using asERP.Server.Tests.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace asERP.Server.Tests.Features.ServerInfo;

/// <summary>
/// Tests for the minimum-client-version enforcement: /server-info exposes the configured
/// minimum, and ClientVersionMiddleware rejects requests whose X-Client-Version header is
/// below it with 426 Upgrade Required — while callers without the header stay unaffected.
/// </summary>
public class ClientVersionEnforcementTests : IDisposable
{
    private const string MinimumVersion = "2026.6.1.100";

    private sealed class StubServerInfoService(Version? minimumClientVersion) : IServerInfoService
    {
        public bool IsRegistrationEnabled => false;
        public string Version => "2099.1.1.1";
        public Version? MinimumClientVersion { get; } = minimumClientVersion;
    }

    private readonly TestWebApplicationFactory<Program> _factory = new();

    private HttpClient CreateClientWithMinimum(string? minimumClientVersion)
    {
        var customized = _factory.WithWebHostBuilder(builder =>
            builder.ConfigureServices(services =>
            {
                services.RemoveAll<IServerInfoService>();
                services.AddSingleton<IServerInfoService>(new StubServerInfoService(
                    minimumClientVersion is null ? null : Version.Parse(minimumClientVersion)));
            }));
        return customized.CreateClient();
    }

    [Fact]
    public async Task ServerInfo_ExposesMinimumClientVersion()
    {
        var client = CreateClientWithMinimum(MinimumVersion);

        var response = await client.GetAsync("/api/v1/server-info");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var dto = await response.Content.ReadFromJsonAsync<ServerInfoResponseDto>();
        Assert.NotNull(dto);
        Assert.Equal(MinimumVersion, dto.MinimumClientVersion);
    }

    [Fact]
    public async Task ServerInfo_WithoutConfiguredMinimum_ReturnsNull()
    {
        var client = CreateClientWithMinimum(null);

        var response = await client.GetAsync("/api/v1/server-info");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var dto = await response.Content.ReadFromJsonAsync<ServerInfoResponseDto>();
        Assert.NotNull(dto);
        Assert.Null(dto.MinimumClientVersion);
    }

    [Fact]
    public async Task ApiRequest_WithOutdatedClientVersion_Returns426WithProblemDetails()
    {
        var client = CreateClientWithMinimum(MinimumVersion);
        client.DefaultRequestHeaders.Add(ApiHeaders.ClientVersion, "2025.1.1.1");

        var response = await client.GetAsync("/api/v1/Customers");

        Assert.Equal(HttpStatusCode.UpgradeRequired, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains(MinimumVersion, body);
    }

    [Fact]
    public async Task ApiRequest_WithExactMinimumClientVersion_IsNotRejected()
    {
        var client = CreateClientWithMinimum(MinimumVersion);
        client.DefaultRequestHeaders.Add(ApiHeaders.ClientVersion, MinimumVersion);

        var response = await client.GetAsync("/api/v1/Customers");

        Assert.NotEqual(HttpStatusCode.UpgradeRequired, response.StatusCode);
    }

    [Fact]
    public async Task ApiRequest_WithNewerClientVersion_IsNotRejected()
    {
        var client = CreateClientWithMinimum(MinimumVersion);
        client.DefaultRequestHeaders.Add(ApiHeaders.ClientVersion, "2027.1.1.1");

        var response = await client.GetAsync("/api/v1/Customers");

        Assert.NotEqual(HttpStatusCode.UpgradeRequired, response.StatusCode);
    }

    [Fact]
    public async Task ApiRequest_WithoutVersionHeader_IsNotRejected()
    {
        var client = CreateClientWithMinimum(MinimumVersion);

        var response = await client.GetAsync("/api/v1/Customers");

        Assert.NotEqual(HttpStatusCode.UpgradeRequired, response.StatusCode);
    }

    [Fact]
    public async Task ApiRequest_WithUnparseableVersionHeader_IsNotRejected()
    {
        var client = CreateClientWithMinimum(MinimumVersion);
        client.DefaultRequestHeaders.Add(ApiHeaders.ClientVersion, "not-a-version");

        var response = await client.GetAsync("/api/v1/Customers");

        Assert.NotEqual(HttpStatusCode.UpgradeRequired, response.StatusCode);
    }

    [Fact]
    public async Task ApiRequest_WithoutConfiguredMinimum_OldClientIsNotRejected()
    {
        var client = CreateClientWithMinimum(null);
        client.DefaultRequestHeaders.Add(ApiHeaders.ClientVersion, "2020.1.1.1");

        var response = await client.GetAsync("/api/v1/Customers");

        Assert.NotEqual(HttpStatusCode.UpgradeRequired, response.StatusCode);
    }

    [Fact]
    public async Task ServerInfoEndpoint_StaysReachableForOutdatedClients()
    {
        var client = CreateClientWithMinimum(MinimumVersion);
        client.DefaultRequestHeaders.Add(ApiHeaders.ClientVersion, "2020.1.1.1");

        var response = await client.GetAsync("/api/v1/server-info");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    public void Dispose()
    {
        _factory.Dispose();
        GC.SuppressFinalize(this);
    }
}
