using System.Net;
using System.Text.Json.Nodes;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.ShippingProvider;

public class ShippingProviderCrudTests : TenantIsolatedTestBase
{
    private ShippingProviderCreateDto CreateValidProviderDto(string name = "DHL Main")
    {
        return new ShippingProviderCreateDto
        {
            Name = name,
            Type = ShippingProviderType.Dhl,
            IsEnabled = true,
            UseSandbox = true,
            Username = "dhl-user",
            Password = "TopSecretPassword123",
            ApiKey = "TopSecretApiKey456",
            ApiSecret = "TopSecretApiSecret789",
            AccountNumber = "3333333333",
            TrackingPollIntervalSeconds = 3600
        };
    }

    [Fact]
    public async Task CreateProvider_WithValidData_ShouldReturnCreatedAndPersist()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/ShippingProviders", CreateValidProviderDto());

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertTrue(result.Data != Guid.Empty);

        DbContext.ChangeTracker.Clear();
        var created = await DbContext.ShippingProvider.FirstOrDefaultAsync(p => p.Id == result.Data);
        TestAssertions.AssertNotNull(created);
        TestAssertions.AssertEqual("DHL Main", created!.Name);
        TestAssertions.AssertEqual(ShippingProviderType.Dhl, created.Type);
        TestAssertions.AssertEqual(TenantConstants.TestTenant1Id, created.TenantId);
    }

    [Fact]
    public async Task CreateProvider_WithDuplicateNameInSameTenant_ShouldReturnBadRequest()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id, name: "DHL Main");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/ShippingProviders", CreateValidProviderDto("DHL Main"));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateProvider_TypeChange_ShouldReturnBadRequest()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
            type: ShippingProviderType.Dhl);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var updateDto = new ShippingProviderUpdateDto
        {
            Name = provider.Name,
            Type = ShippingProviderType.Ups,
            IsEnabled = true,
            UseSandbox = true,
            Username = "dhl-user",
            TrackingPollIntervalSeconds = 3600
        };
        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}", updateDto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateProvider_WithEmptyPassword_ShouldKeepStoredSecret()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
            password: "keep-me-secret", apiKey: "keep-me-api-key");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var updateDto = new ShippingProviderUpdateDto
        {
            Name = "Renamed Provider",
            Type = ShippingProviderType.Dhl,
            IsEnabled = true,
            UseSandbox = true,
            Username = "new-user",
            Password = "",
            ApiKey = "",
            TrackingPollIntervalSeconds = 3600
        };
        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}", updateDto);

        TestAssertions.AssertHttpSuccess(response);
        DbContext.ChangeTracker.Clear();
        var updated = await DbContext.ShippingProvider.FirstAsync(p => p.Id == provider.Id);
        TestAssertions.AssertEqual("Renamed Provider", updated.Name);
        TestAssertions.AssertEqual("keep-me-secret", updated.Password);
        TestAssertions.AssertEqual("keep-me-api-key", updated.ApiKey);
    }

    [Fact]
    public async Task UpdateProvider_WithNewPassword_ShouldReplaceStoredSecret()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
            password: "old-secret");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var updateDto = new ShippingProviderUpdateDto
        {
            Name = provider.Name,
            Type = ShippingProviderType.Dhl,
            IsEnabled = true,
            UseSandbox = true,
            Username = "test-user",
            Password = "new-secret",
            TrackingPollIntervalSeconds = 3600
        };
        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}", updateDto);

        TestAssertions.AssertHttpSuccess(response);
        DbContext.ChangeTracker.Clear();
        var updated = await DbContext.ShippingProvider.FirstAsync(p => p.Id == provider.Id);
        TestAssertions.AssertEqual("new-secret", updated.Password);
    }

    [Fact]
    public async Task DeleteProvider_WithRates_ShouldDeleteRatesAndJoinRows()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider,
            allowedCountryIds: new[] { ShippingTestDataSeeder.GermanyCountryId, ShippingTestDataSeeder.AustriaCountryId });
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/ShippingProviders/{provider.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NoContent, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var providerExists = await DbContext.ShippingProvider.AnyAsync(p => p.Id == provider.Id);
        var rateExists = await DbContext.ShippingProviderRate.AnyAsync(r => r.Id == rate.Id);
        var joinRowsExist = await DbContext.ShippingProviderRateCountry.AnyAsync(c => c.ShippingProviderRateId == rate.Id);
        TestAssertions.AssertFalse(providerExists);
        TestAssertions.AssertFalse(rateExists);
        TestAssertions.AssertFalse(joinRowsExist);
    }

    [Fact]
    public async Task DeleteProvider_ReferencedByShipping_ShouldReturnBadRequest()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 601);
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/ShippingProviders/{provider.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var providerExists = await DbContext.ShippingProvider.AnyAsync(p => p.Id == provider.Id);
        TestAssertions.AssertTrue(providerExists);
    }

    [Fact]
    public async Task GetProviderDetail_ShouldNotLeakSecrets()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
            password: "TopSecretPassword123", apiKey: "TopSecretApiKey456", apiSecret: "TopSecretApiSecret789");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/ShippingProviders/{provider.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var raw = await ReadResponseStringAsync(response);
        TestAssertions.AssertFalse(raw.Contains("TopSecretPassword123", StringComparison.OrdinalIgnoreCase),
            "Detail response must not contain the plaintext password.");
        TestAssertions.AssertFalse(raw.Contains("TopSecretApiKey456", StringComparison.OrdinalIgnoreCase),
            "Detail response must not contain the plaintext API key.");
        TestAssertions.AssertFalse(raw.Contains("TopSecretApiSecret789", StringComparison.OrdinalIgnoreCase),
            "Detail response must not contain the plaintext API secret.");

        var result = await ReadResponseAsync<Result<ShippingProviderDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertTrue(result.Data!.HasPassword);
        TestAssertions.AssertTrue(result.Data.HasApiKey);
        TestAssertions.AssertTrue(result.Data.HasApiSecret);
    }

    [Fact]
    public async Task GetProviderDetail_WithRates_ShouldReturnRateList()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider, name: "Paket S");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/ShippingProviders/{provider.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<ShippingProviderDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Rates.Count);
        TestAssertions.AssertEqual(rate.Id, result.Data.Rates[0].Id);
        TestAssertions.AssertEqual(1, result.Data.Rates[0].AllowedCountryCount);
    }
    // --- Carrier config blob: secrets are redacted on read and merged back on write ---

    private const string CarrierConfigWithSecret =
        """{"Procedure":"01","TrackingApiKey":"live-dhl-tracking-key","Sender":{"Name":"ACME"}}""";

    private static ShippingProviderUpdateDto ConfigUpdateDto(string name, string? configJson) => new()
    {
        Name = name,
        Type = ShippingProviderType.Dhl,
        IsEnabled = true,
        UseSandbox = true,
        Username = "test-user",
        AdditionalConfigJson = configJson,
        TrackingPollIntervalSeconds = 3600
    };

    private async Task<Guid> SeedProviderWithCarrierConfigAsync(string? configJson = CarrierConfigWithSecret)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        provider.AdditionalConfigJson = configJson;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        return provider.Id;
    }

    private async Task<JsonObject> StoredCarrierConfigAsync(Guid providerId)
    {
        DbContext.ChangeTracker.Clear();
        var stored = await DbContext.ShippingProvider.FirstAsync(p => p.Id == providerId);
        return JsonNode.Parse(stored.AdditionalConfigJson!)!.AsObject();
    }

    [Fact]
    public async Task GetProviderDetail_ShouldRedactCarrierConfigSecrets()
    {
        var providerId = await SeedProviderWithCarrierConfigAsync();

        var response = await Client.GetAsync($"/api/v1/ShippingProviders/{providerId}");

        TestAssertions.AssertHttpSuccess(response);
        var raw = await ReadResponseStringAsync(response);
        TestAssertions.AssertFalse(raw.Contains("live-dhl-tracking-key", StringComparison.OrdinalIgnoreCase),
            "Detail response must not contain the carrier tracking API key.");

        var result = await ReadResponseAsync<Result<ShippingProviderDetailDto>>(response);
        var config = JsonNode.Parse(result.Data!.AdditionalConfigJson!)!.AsObject();
        TestAssertions.AssertEqual("********", config["TrackingApiKey"]!.GetValue<string>());
        TestAssertions.AssertEqual("01", config["Procedure"]!.GetValue<string>());
    }

    [Fact]
    public async Task UpdateProvider_WithRedactedCarrierConfigSecret_ShouldKeepStoredSecret()
    {
        var providerId = await SeedProviderWithCarrierConfigAsync();

        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{providerId}",
            ConfigUpdateDto("Renamed Provider", """{"Procedure":"02","TrackingApiKey":"********"}"""));

        TestAssertions.AssertHttpSuccess(response);
        var config = await StoredCarrierConfigAsync(providerId);
        TestAssertions.AssertEqual("live-dhl-tracking-key", config["TrackingApiKey"]!.GetValue<string>());
        TestAssertions.AssertEqual("02", config["Procedure"]!.GetValue<string>());
    }

    [Fact]
    public async Task UpdateProvider_WithDifferentlyCasedRedactedSecret_ShouldKeepStoredSecret()
    {
        var providerId = await SeedProviderWithCarrierConfigAsync();

        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{providerId}",
            ConfigUpdateDto("Renamed Provider", """{"trackingapikey":"********"}"""));

        TestAssertions.AssertHttpSuccess(response);
        var config = await StoredCarrierConfigAsync(providerId);
        TestAssertions.AssertEqual("live-dhl-tracking-key", config["trackingapikey"]!.GetValue<string>());
    }

    [Fact]
    public async Task UpdateProvider_WithoutCarrierConfigSecret_ShouldClearStoredSecret()
    {
        var providerId = await SeedProviderWithCarrierConfigAsync();

        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{providerId}",
            ConfigUpdateDto("Renamed Provider", """{"Procedure":"02"}"""));

        TestAssertions.AssertHttpSuccess(response);
        var config = await StoredCarrierConfigAsync(providerId);
        TestAssertions.AssertFalse(config.ContainsKey("TrackingApiKey"),
            "A key the user removed must be cleared, not restored.");
    }

    [Fact]
    public async Task UpdateProvider_WithNewCarrierConfigSecret_ShouldReplaceStoredSecret()
    {
        var providerId = await SeedProviderWithCarrierConfigAsync();

        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{providerId}",
            ConfigUpdateDto("Renamed Provider", """{"TrackingApiKey":"rotated-key"}"""));

        TestAssertions.AssertHttpSuccess(response);
        var config = await StoredCarrierConfigAsync(providerId);
        TestAssertions.AssertEqual("rotated-key", config["TrackingApiKey"]!.GetValue<string>());
    }

    [Fact]
    public async Task UpdateProvider_WithMalformedCarrierConfig_ShouldNotFail()
    {
        var providerId = await SeedProviderWithCarrierConfigAsync();

        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{providerId}",
            ConfigUpdateDto("Renamed Provider", "not json at all"));

        TestAssertions.AssertHttpSuccess(response);
        DbContext.ChangeTracker.Clear();
        var stored = await DbContext.ShippingProvider.FirstAsync(p => p.Id == providerId);
        TestAssertions.AssertEqual("not json at all", stored.AdditionalConfigJson);
    }

    [Fact]
    public async Task CreateProvider_WithRedactedCarrierConfigSecret_ShouldNotStoreThePlaceholder()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var createDto = CreateValidProviderDto("DHL Fresh");
        createDto.AdditionalConfigJson = """{"Procedure":"01","TrackingApiKey":"********"}""";
        var response = await PostAsJsonAsync("/api/v1/ShippingProviders", createDto);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        var config = await StoredCarrierConfigAsync(result.Data);
        TestAssertions.AssertFalse(config.ContainsKey("TrackingApiKey"),
            "The redaction placeholder must never become a stored credential.");
        TestAssertions.AssertEqual("01", config["Procedure"]!.GetValue<string>());
    }
}
