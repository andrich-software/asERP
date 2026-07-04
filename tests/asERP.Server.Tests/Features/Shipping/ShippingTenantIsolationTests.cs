using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Shipping;

/// <summary>
/// Cross-tenant access prevention for the shipping feature: providers, rates and shipments of
/// tenant 1 must be invisible to tenant 2.
/// </summary>
public class ShippingTenantIsolationTests : TenantIsolatedTestBase
{
    private async Task<(asERP.Domain.Entities.ShippingProvider Provider,
        asERP.Domain.Entities.ShippingProviderRate Rate,
        asERP.Domain.Entities.Sales Sales,
        asERP.Domain.Entities.Shipping Shipping)> SeedTenant1DataAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
            name: "Tenant1 DHL");
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 851);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        return (provider, rate, sales, shipping);
    }

    [Fact]
    public async Task GetProviderDetail_FromOtherTenant_ShouldReturnNotFound()
    {
        var (provider, _, _, _) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/ShippingProviders/{provider.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task UpdateProvider_FromOtherTenant_ShouldReturnNotFound()
    {
        var (provider, _, _, _) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var updateDto = new ShippingProviderUpdateDto
        {
            Name = "Hijacked Provider",
            Type = ShippingProviderType.Dhl,
            IsEnabled = true,
            UseSandbox = true,
            Username = "attacker",
            TrackingPollIntervalSeconds = 3600
        };
        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}", updateDto);

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeleteProvider_FromOtherTenant_ShouldReturnNotFound()
    {
        var (provider, _, _, _) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.DeleteAsync($"/api/v1/ShippingProviders/{provider.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetRateDetail_FromOtherTenant_ShouldReturnNotFound()
    {
        var (provider, rate, _, _) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/ShippingProviders/{provider.Id}/rates/{rate.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeleteRate_FromOtherTenant_ShouldReturnNotFound()
    {
        var (provider, rate, _, _) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.DeleteAsync($"/api/v1/ShippingProviders/{provider.Id}/rates/{rate.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetShippingDetail_FromOtherTenant_ShouldReturnNotFound()
    {
        var (_, _, _, shipping) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task UpdateShipping_FromOtherTenant_ShouldReturnNotFound()
    {
        var (_, _, _, shipping) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await PutAsJsonAsync($"/api/v1/Shippings/{shipping.Id}",
            new { Id = shipping.Id, TrackingNumber = "HIJACKED" });

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeleteShipping_FromOtherTenant_ShouldReturnNotFound()
    {
        var (_, _, _, shipping) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.DeleteAsync($"/api/v1/Shippings/{shipping.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CancelShipping_FromOtherTenant_ShouldReturnNotFound()
    {
        var (_, _, _, shipping) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.PostAsync($"/api/v1/Shippings/{shipping.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task ProviderList_UnderTenant2_ShouldNotContainTenant1Providers()
    {
        await SeedTenant1DataAsync();
        ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant2Id, name: "Tenant2 GLS",
            type: ShippingProviderType.Gls);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync("/api/v1/ShippingProviders");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ShippingProviderListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        var names = result.Data.Select(p => p.Name).ToList();
        TestAssertions.AssertContains("Tenant2 GLS", names);
        TestAssertions.AssertDoesNotContain("Tenant1 DHL", names);
    }

    [Fact]
    public async Task ListShippingsBySales_FromOtherTenant_ShouldReturnEmptyList()
    {
        var (_, _, sales, _) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Shippings?salesId={sales.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ShipmentListItemDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEmpty(result.Data);
        TestAssertions.AssertEqual(0, result.TotalCount);
    }

    [Fact]
    public async Task CreateShipping_ReferencingOtherTenantSalesAndRate_ShouldBeRejected()
    {
        var (_, rate, sales, _) = await SeedTenant1DataAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var dto = new ShippingInputDto
        {
            SalesId = sales.Id,
            ShippingProviderRateId = rate.Id,
            RequestLabel = false
        };
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertTrue(
            response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.NotFound,
            $"Expected 400 or 404 but got {response.StatusCode}.");
    }

    [Fact]
    public async Task GetProviderDetail_WithoutTenantHeader_ShouldReturnNotFound()
    {
        var (provider, _, _, _) = await SeedTenant1DataAsync();
        RemoveTenantHeader();

        var response = await Client.GetAsync($"/api/v1/ShippingProviders/{provider.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetProviderDetail_WithMalformedTenantHeader_ShouldReturnUnauthorized()
    {
        var (provider, _, _, _) = await SeedTenant1DataAsync();
        SetInvalidTenantHeaderValue("not-a-guid");

        var response = await Client.GetAsync($"/api/v1/ShippingProviders/{provider.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetProviderDetail_WithNonExistentTenant_ShouldReturnNotFound()
    {
        var (provider, _, _, _) = await SeedTenant1DataAsync();
        SetInvalidTenantHeader();

        var response = await Client.GetAsync($"/api/v1/ShippingProviders/{provider.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
