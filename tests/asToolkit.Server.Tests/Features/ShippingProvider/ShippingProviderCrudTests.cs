using System.Net;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.ShippingProvider;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.ShippingProvider;

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
}
