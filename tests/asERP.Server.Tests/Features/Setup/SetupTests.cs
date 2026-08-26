using System.Net;
using System.Net.Http.Json;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.ServerInfo;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using asERP.Server.Tests.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Features.Setup;

/// <summary>
/// Tests for the initial server setup: /server-info exposes SetupRequired while the
/// database is empty, POST /setup creates the first Superadmin + tenant exactly once,
/// and the door closes as soon as the setup completed or any user exists.
/// </summary>
public class SetupTests : IDisposable
{
    private readonly TestWebApplicationFactory<Program> _factory = new();
    private readonly HttpClient _client;

    public SetupTests()
    {
        // Earlier test classes leave their TEST_DB_NAME behind (process-wide env var), which
        // would make this factory silently share their database — and any user in there closes
        // the setup window. Pin a fresh name so every test starts from a genuinely empty DB.
        Environment.SetEnvironmentVariable("TEST_DB_NAME", "SetupTestDb_" + Guid.NewGuid());
        _client = _factory.CreateClient();
    }

    private static object ValidSetupPayload(string email = "admin@setup-test.com", string tenantName = "Setup Tenant") => new
    {
        Email = email,
        Password = "P@ssword1",
        Firstname = "Super",
        Lastname = "Admin",
        TenantName = tenantName,
        TenantDescription = "Created by the initial setup"
    };

    [Fact]
    public async Task ServerInfo_OnEmptyDatabase_ReportsSetupRequired()
    {
        var response = await _client.GetAsync("/api/v1/server-info");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var dto = await response.Content.ReadFromJsonAsync<ServerInfoResponseDto>();
        Assert.NotNull(dto);
        Assert.True(dto.SetupRequired);
    }

    [Fact]
    public async Task Setup_CreatesSuperadminWithFirstTenant()
    {
        var response = await _client.PostAsJsonAsync("/api/v1/setup", ValidSetupPayload());

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        using var scope = _factory.Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var superadmin = await userManager.FindByEmailAsync("admin@setup-test.com");
        Assert.NotNull(superadmin);
        Assert.True(await userManager.IsInRoleAsync(superadmin, "Superadmin"));

        var tenant = await dbContext.Tenant.FirstOrDefaultAsync(t => t.Name == "Setup Tenant");
        Assert.NotNull(tenant);

        // UserTenant carries a tenant query filter; the test scope has no tenant context.
        var userTenant = await dbContext.UserTenant
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(ut => ut.UserId == superadmin.Id && ut.TenantId == tenant.Id);
        Assert.NotNull(userTenant);
        Assert.True(userTenant.IsDefault);
        Assert.True(userTenant.RoleManageUser);
        Assert.True(userTenant.RoleManageTenant);

        var flag = await dbContext.Setting.FirstOrDefaultAsync(s => s.Key == SettingKeys.SetupCompleted);
        Assert.NotNull(flag);
        Assert.Equal("True", flag.Value);
    }

    [Fact]
    public async Task ServerInfo_AfterCompletedSetup_ReportsSetupNotRequired()
    {
        var setupResponse = await _client.PostAsJsonAsync("/api/v1/setup", ValidSetupPayload());
        Assert.Equal(HttpStatusCode.Created, setupResponse.StatusCode);

        var response = await _client.GetAsync("/api/v1/server-info");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var dto = await response.Content.ReadFromJsonAsync<ServerInfoResponseDto>();
        Assert.NotNull(dto);
        Assert.False(dto.SetupRequired);
    }

    [Fact]
    public async Task Setup_SecondAttempt_IsRejected()
    {
        var firstResponse = await _client.PostAsJsonAsync("/api/v1/setup", ValidSetupPayload());
        Assert.Equal(HttpStatusCode.Created, firstResponse.StatusCode);

        var secondResponse = await _client.PostAsJsonAsync("/api/v1/setup",
            ValidSetupPayload(email: "second@setup-test.com", tenantName: "Second Tenant"));

        Assert.Equal(HttpStatusCode.Forbidden, secondResponse.StatusCode);

        using var scope = _factory.Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        Assert.Null(await userManager.FindByEmailAsync("second@setup-test.com"));
    }

    [Fact]
    public async Task Setup_AfterCompletion_DoesNotLeakWhetherEmailExists()
    {
        var firstResponse = await _client.PostAsJsonAsync("/api/v1/setup", ValidSetupPayload());
        Assert.Equal(HttpStatusCode.Created, firstResponse.StatusCode);

        // Same email as the existing Superadmin: the guard must answer before validation,
        // otherwise "email already exists" would let anyone probe accounts anonymously.
        var probeResponse = await _client.PostAsJsonAsync("/api/v1/setup", ValidSetupPayload());

        Assert.Equal(HttpStatusCode.Forbidden, probeResponse.StatusCode);
        var body = await probeResponse.Content.ReadAsStringAsync();
        Assert.DoesNotContain("already exists", body);
    }

    [Fact]
    public async Task Setup_WhenAnyUserAlreadyExists_IsRejected()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var existingUser = new ApplicationUser
            {
                UserName = "existing@setup-test.com",
                Email = "existing@setup-test.com",
                Firstname = "Existing",
                Lastname = "User"
            };
            var createResult = await userManager.CreateAsync(existingUser, "P@ssword1");
            Assert.True(createResult.Succeeded);
        }

        var response = await _client.PostAsJsonAsync("/api/v1/setup", ValidSetupPayload());

        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);

        var infoResponse = await _client.GetAsync("/api/v1/server-info");
        var dto = await infoResponse.Content.ReadFromJsonAsync<ServerInfoResponseDto>();
        Assert.NotNull(dto);
        Assert.False(dto.SetupRequired);
    }

    [Fact]
    public async Task Setup_WithMissingTenantName_ReturnsBadRequest()
    {
        var response = await _client.PostAsJsonAsync("/api/v1/setup", new
        {
            Email = "admin@setup-test.com",
            Password = "P@ssword1",
            Firstname = "Super",
            Lastname = "Admin",
            TenantName = ""
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        using var scope = _factory.Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        Assert.Null(await userManager.FindByEmailAsync("admin@setup-test.com"));
    }

    [Fact]
    public async Task Setup_WithInvalidEmail_ReturnsBadRequest()
    {
        var response = await _client.PostAsJsonAsync("/api/v1/setup", new
        {
            Email = "not-an-email",
            Password = "P@ssword1",
            Firstname = "Super",
            Lastname = "Admin",
            TenantName = "Setup Tenant"
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    public void Dispose()
    {
        _factory.Dispose();
        GC.SuppressFinalize(this);
    }
}
