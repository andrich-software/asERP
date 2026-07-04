using System.Net;
using asToolkit.Domain.Dtos.GlobalSettings;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.GlobalSettings;

// Inside the namespace so it shadows the sibling test namespace Features.Setting.
using Setting = asToolkit.Domain.Entities.Setting;

public class GlobalSettingsCrudTest : TenantIsolatedTestBase
{
    private const string Url = "/api/v1/superadmin/global-settings";

    private void SetSuperadminAuthentication()
    {
        SimulateAuthenticatedRequest();
        SetTestUserRoles("Superadmin");
    }

    /// <summary>Upsert-style arrange — the startup initializer may already have seeded the key.</summary>
    private async Task EnsureSettingAsync(string key, string value, bool isEncrypted = false)
    {
        var existing = await DbContext.Setting.FirstOrDefaultAsync(s => s.Key == key);
        if (existing is null)
        {
            DbContext.Setting.Add(new Setting { Key = key, Value = value, IsEncrypted = isEncrypted });
        }
        else
        {
            existing.Value = value;
            existing.IsEncrypted = isEncrypted;
        }
        await DbContext.SaveChangesAsync();
    }

    private async Task<Setting?> GetStoredAsync(string key) =>
        await DbContext.Setting.AsNoTracking().FirstOrDefaultAsync(s => s.Key == key);

    private static GlobalSettingsUpdateInputDto Input(params (string Key, string? Value)[] entries) => new()
    {
        Settings = entries.Select(e => new GlobalSettingValueInputDto { Key = e.Key, Value = e.Value }).ToList(),
    };

    [Fact]
    public async Task GetAll_ReturnsSettings_WithPlainValues()
    {
        await EnsureSettingAsync("Email.SmtpHost", "smtp.example.com");
        SetSuperadminAuthentication();

        var response = await Client.GetAsync(Url);

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.OK);
        var result = await ReadResponseAsync<Result<List<GlobalSettingDto>>>(response);
        TestAssertions.AssertTrue(result.Succeeded);
        var host = result.Data!.FirstOrDefault(s => s.Key == "Email.SmtpHost");
        TestAssertions.AssertNotNull(host);
        Assert.Equal("smtp.example.com", host!.Value);
        Assert.False(host.IsSecret);
        Assert.True(host.HasValue);
    }

    [Fact]
    public async Task GetAll_MasksSecrets_ButReportsTheirPresence()
    {
        await EnsureSettingAsync("Email.SmtpPassword", "super-secret");
        SetSuperadminAuthentication();

        var response = await Client.GetAsync(Url);

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.OK);
        var result = await ReadResponseAsync<Result<List<GlobalSettingDto>>>(response);
        var password = result.Data!.FirstOrDefault(s => s.Key == "Email.SmtpPassword");
        TestAssertions.AssertNotNull(password);
        Assert.True(password!.IsSecret);
        Assert.True(password.HasValue);
        Assert.Equal(string.Empty, password.Value);
    }

    [Fact]
    public async Task GetAll_ExcludesJwtKeyAndOAuthRows()
    {
        await EnsureSettingAsync("Jwt.Key", "generated-signing-key");
        await EnsureSettingAsync("OAuth.Ebay.ClientId", "ebay-client-id");
        SetSuperadminAuthentication();

        var response = await Client.GetAsync(Url);

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.OK);
        var result = await ReadResponseAsync<Result<List<GlobalSettingDto>>>(response);
        Assert.DoesNotContain(result.Data!, s => s.Key == "Jwt.Key");
        Assert.DoesNotContain(result.Data!, s => s.Key.StartsWith("OAuth."));
    }

    [Fact]
    public async Task Update_ChangesValue()
    {
        await EnsureSettingAsync("Email.SmtpHost", "old.example.com");
        SetSuperadminAuthentication();

        var response = await PutAsJsonAsync(Url, Input(("Email.SmtpHost", "new.example.com")));

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.NoContent);
        var stored = await GetStoredAsync("Email.SmtpHost");
        Assert.Equal("new.example.com", stored!.Value);
    }

    [Fact]
    public async Task Update_Secret_IsStoredEncrypted()
    {
        await EnsureSettingAsync("Email.SmtpPassword", "");
        SetSuperadminAuthentication();

        var response = await PutAsJsonAsync(Url, Input(("Email.SmtpPassword", "new-secret")));

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.NoContent);
        var stored = await GetStoredAsync("Email.SmtpPassword");
        TestAssertions.AssertNotNull(stored);
        Assert.True(stored!.IsEncrypted);
        Assert.NotEqual(string.Empty, stored.Value);
    }

    [Fact]
    public async Task Update_Secret_KeptWhenEmpty()
    {
        await EnsureSettingAsync("Email.SmtpPassword", "existing-secret");
        SetSuperadminAuthentication();

        var response = await PutAsJsonAsync(Url, Input(("Email.SmtpPassword", "")));

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.NoContent);
        var stored = await GetStoredAsync("Email.SmtpPassword");
        Assert.Equal("existing-secret", stored!.Value);
    }

    [Fact]
    public async Task Update_UnknownKey_ReturnsBadRequest_AndWritesNothing()
    {
        await EnsureSettingAsync("Email.SmtpHost", "keep.example.com");
        SetSuperadminAuthentication();

        var response = await PutAsJsonAsync(Url, Input(
            ("Email.SmtpHost", "changed.example.com"),
            ("Does.NotExist", "value")));

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.BadRequest);
        var stored = await GetStoredAsync("Email.SmtpHost");
        Assert.Equal("keep.example.com", stored!.Value);
    }

    [Fact]
    public async Task Update_HiddenKey_ReturnsBadRequest()
    {
        await EnsureSettingAsync("Jwt.Key", "generated-signing-key");
        SetSuperadminAuthentication();

        var response = await PutAsJsonAsync(Url, Input(("Jwt.Key", "attacker-controlled")));

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.BadRequest);
        var stored = await GetStoredAsync("Jwt.Key");
        Assert.Equal("generated-signing-key", stored!.Value);
    }

    [Fact]
    public async Task GetAll_NonSuperadmin_ReturnsForbidden()
    {
        SetTestUserRoles("RoleManageUser");

        var response = await Client.GetAsync(Url);

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task Update_NonSuperadmin_ReturnsForbidden()
    {
        await EnsureSettingAsync("Email.SmtpHost", "keep.example.com");
        SetTestUserRoles("RoleManageUser");

        var response = await PutAsJsonAsync(Url, Input(("Email.SmtpHost", "changed.example.com")));

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.Forbidden);
        var stored = await GetStoredAsync("Email.SmtpHost");
        Assert.Equal("keep.example.com", stored!.Value);
    }

    [Fact]
    public async Task GetAll_Unauthenticated_IsRejected()
    {
        SimulateUnauthenticatedRequest();

        var response = await Client.GetAsync(Url);

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.Unauthorized);
    }
}
