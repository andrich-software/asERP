using System.Net;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Xunit;

namespace asToolkit.Server.Tests.Features.Shipping.Queries;

public class ShippingOptionsForSalesTests : TenantIsolatedTestBase
{
    private async Task<Result<List<ApplicableShippingRateDto>>> GetOptionsAsync(Guid salesId)
    {
        var response = await Client.GetAsync($"/api/v1/Saless/{salesId}/shipping-options");
        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<List<ApplicableShippingRateDto>>>(response);
        TestAssertions.AssertNotNull(result.Data);
        return result;
    }

    [Fact]
    public async Task Options_FiltersByDeliveryCountry()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var germanyRate = ShippingTestDataSeeder.AddRate(DbContext, provider, name: "DE only",
            allowedCountryIds: ShippingTestDataSeeder.GermanyCountryId);
        var austriaRate = ShippingTestDataSeeder.AddRate(DbContext, provider, name: "AT only",
            allowedCountryIds: ShippingTestDataSeeder.AustriaCountryId);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 900,
            deliveryCountry: "Austria");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetOptionsAsync(sales.Id);

        TestAssertions.AssertEqual(1, result.Data!.Count);
        TestAssertions.AssertEqual(austriaRate.Id, result.Data[0].RateId);
        TestAssertions.AssertDoesNotContain(germanyRate.Id, result.Data.Select(r => r.RateId));
    }

    [Fact]
    public async Task Options_AreSortedByPriceAscending()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var expensive = ShippingTestDataSeeder.AddRate(DbContext, provider, name: "Express",
            price: 12.99m);
        var cheap = ShippingTestDataSeeder.AddRate(DbContext, provider, name: "Economy",
            price: 3.49m);
        var middle = ShippingTestDataSeeder.AddRate(DbContext, provider, name: "Standard",
            price: 5.99m);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 901);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetOptionsAsync(sales.Id);

        TestAssertions.AssertEqual(3, result.Data!.Count);
        TestAssertions.AssertEqual(cheap.Id, result.Data[0].RateId);
        TestAssertions.AssertEqual(middle.Id, result.Data[1].RateId);
        TestAssertions.AssertEqual(expensive.Id, result.Data[2].RateId);
    }

    [Fact]
    public async Task Options_ExcludeDisabledProviders()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var enabledProvider = ShippingTestDataSeeder.AddProvider(DbContext,
            TenantConstants.TestTenant1Id, name: "Enabled DHL");
        var enabledRate = ShippingTestDataSeeder.AddRate(DbContext, enabledProvider);
        var disabledProvider = ShippingTestDataSeeder.AddProvider(DbContext,
            TenantConstants.TestTenant1Id, name: "Disabled DPD", isEnabled: false);
        var disabledRate = ShippingTestDataSeeder.AddRate(DbContext, disabledProvider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 902);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetOptionsAsync(sales.Id);

        TestAssertions.AssertEqual(1, result.Data!.Count);
        TestAssertions.AssertEqual(enabledRate.Id, result.Data[0].RateId);
        TestAssertions.AssertDoesNotContain(disabledRate.Id, result.Data.Select(r => r.RateId));
        TestAssertions.AssertEqual("Enabled DHL", result.Data[0].ProviderName);
    }

    [Fact]
    public async Task Options_UnresolvableCountry_ReturnsOkWithEmptyListAndMessage()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 903,
            deliveryCountry: "Atlantis");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetOptionsAsync(sales.Id);

        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertEmpty(result.Data!);
        TestAssertions.AssertNotEmpty(result.Messages);
        TestAssertions.AssertContains(
            "The delivery country 'Atlantis' could not be resolved to a known country.",
            result.Messages);
    }

    [Fact]
    public async Task Options_WithUnknownId_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Saless/{Guid.NewGuid()}/shipping-options");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Options_FromOtherTenant_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 904);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Saless/{sales.Id}/shipping-options");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
