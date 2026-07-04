using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Search;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Xunit;

namespace asToolkit.Server.Tests.Features.Search;

public class GlobalSearchQueryTests : TenantIsolatedTestBase
{
    private async Task SeedSearchTestDataAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        DbContext.Customer.AddRange(
            new asToolkit.Domain.Entities.Customer
            {
                Id = Guid.Parse("50000001-0001-0001-0001-000000000001"),
                CustomerId = 1001,
                Firstname = "Alice",
                Lastname = "Schneider",
                CompanyName = "Alpha GmbH",
                CustomerStatus = CustomerStatus.Active,
                DateEnrollment = DateTimeOffset.UtcNow.AddDays(-10),
                TenantId = TenantConstants.TestTenant1Id
            },
            new asToolkit.Domain.Entities.Customer
            {
                Id = Guid.Parse("50000002-0002-0002-0002-000000000002"),
                CustomerId = 2001,
                Firstname = "Bob",
                Lastname = "Schneider",
                CompanyName = "Beta AG",
                CustomerStatus = CustomerStatus.Active,
                DateEnrollment = DateTimeOffset.UtcNow.AddDays(-5),
                TenantId = TenantConstants.TestTenant2Id
            });

        DbContext.Product.Add(new asToolkit.Domain.Entities.Product
        {
            Id = Guid.Parse("50000010-0010-0010-0010-000000000010"),
            Sku = "FABRIC-RED-01",
            Name = "Roter Baumwollstoff",
            Ean = "4001234567890",
            TaxClassId = Guid.NewGuid(),
            ProductType = ProductType.Standard,
            TenantId = TenantConstants.TestTenant1Id
        });

        DbContext.Invoice.Add(new asToolkit.Domain.Entities.Invoice
        {
            Id = Guid.Parse("50000020-0020-0020-0020-000000000020"),
            InvoiceNumber = "RE-2026-0042",
            InvoiceDate = DateTime.UtcNow,
            CustomerId = 1001,
            InvoiceAddressFirstName = "Alice",
            InvoiceAddressLastName = "Schneider",
            TenantId = TenantConstants.TestTenant1Id
        });

        await DbContext.SaveChangesAsync();
    }

    private async Task<(asToolkit.Domain.Entities.Shipping Tenant1Shipping,
        asToolkit.Domain.Entities.Shipping Tenant2Shipping)> SeedShippingSearchDataAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var provider1 = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
            name: "DHL Tenant1");
        var rate1 = ShippingTestDataSeeder.AddRate(DbContext, provider1);
        var sales1 = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 910);
        var shipping1 = ShippingTestDataSeeder.AddShipping(DbContext, sales1, provider1, rate1,
            trackingNumber: "TRACK-SEARCH-4711");

        var provider2 = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant2Id,
            name: "GLS Tenant2");
        var rate2 = ShippingTestDataSeeder.AddRate(DbContext, provider2);
        var sales2 = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant2Id, 911);
        var shipping2 = ShippingTestDataSeeder.AddShipping(DbContext, sales2, provider2, rate2,
            trackingNumber: "TRACK-SEARCH-9922");

        await DbContext.SaveChangesAsync();
        return (shipping1, shipping2);
    }

    [Fact]
    public async Task Search_MatchesShippingByTrackingNumber_ReturnsHit()
    {
        var (tenant1Shipping, _) = await SeedShippingSearchDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=SEARCH-4711&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Shippings.Count);
        var hit = result.Data.Shippings[0];
        TestAssertions.AssertEqual(tenant1Shipping.Id, hit.Id);
        TestAssertions.AssertEqual(SearchEntityType.Shipping, hit.Type);
        TestAssertions.AssertEqual("TRACK-SEARCH-4711", hit.Title);
        TestAssertions.AssertEqual("#30910 · DHL Tenant1", hit.Subtitle);
    }

    [Fact]
    public async Task Search_ShippingHit_IsIncludedInTotalCount()
    {
        await SeedShippingSearchDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=TRACK-SEARCH&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Shippings.Count);
        TestAssertions.AssertEqual(1, result.Data.TotalCount);
    }

    [Fact]
    public async Task Search_ShippingTenantIsolation_DoesNotReturnOtherTenantShipments()
    {
        var (tenant1Shipping, tenant2Shipping) = await SeedShippingSearchDataAsync();

        // Both tracking numbers share the "TRACK-SEARCH" prefix — each tenant only sees its own.
        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await Client.GetAsync("/api/v1/Search?searchString=TRACK-SEARCH&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Shippings.Count);
        TestAssertions.AssertEqual(tenant2Shipping.Id, result.Data.Shippings[0].Id);
        TestAssertions.AssertDoesNotContain(tenant1Shipping.Id,
            result.Data.Shippings.Select(h => h.Id));
    }

    [Fact]
    public async Task Search_ShippingBelowThreshold_ReturnsEmpty()
    {
        await SeedShippingSearchDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=TR&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(0, result.Data!.Shippings.Count);
        TestAssertions.AssertEqual(0, result.Data.TotalCount);
    }

    [Fact]
    public async Task Search_MatchesCustomerByLastname_ReturnsHit()
    {
        await SeedSearchTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=Schneider&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Customers.Count);
        TestAssertions.AssertEqual(SearchEntityType.Customer, result.Data.Customers[0].Type);
    }

    [Fact]
    public async Task Search_MatchesProductByEan_ReturnsHit()
    {
        await SeedSearchTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=400123&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Products.Count);
        TestAssertions.AssertEqual("Roter Baumwollstoff", result.Data.Products[0].Title);
    }

    [Fact]
    public async Task Search_MatchesInvoiceByNumber_ReturnsHit()
    {
        await SeedSearchTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=RE-2026&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Invoices.Count);
        TestAssertions.AssertEqual("RE-2026-0042", result.Data.Invoices[0].Title);
    }

    [Fact]
    public async Task Search_TenantIsolation_DoesNotReturnOtherTenantData()
    {
        await SeedSearchTestDataAsync();

        // Tenant 2 has its own "Schneider" customer and must not see tenant 1's.
        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await Client.GetAsync("/api/v1/Search?searchString=Schneider&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Customers.Count);
        TestAssertions.AssertEqual(Guid.Parse("50000002-0002-0002-0002-000000000002"), result.Data.Customers[0].Id);
        // Tenant 1's product/invoice must not leak.
        TestAssertions.AssertEqual(0, result.Data.Products.Count);
        TestAssertions.AssertEqual(0, result.Data.Invoices.Count);
    }

    [Fact]
    public async Task Search_BelowThreshold_ReturnsEmpty()
    {
        await SeedSearchTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=Sc&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(0, result.Data!.TotalCount);
    }

    [Fact]
    public async Task Search_WithoutTenantHeader_ReturnsEmpty()
    {
        await SeedSearchTestDataAsync();
        RemoveTenantHeader();

        var response = await Client.GetAsync("/api/v1/Search?searchString=Schneider&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(0, result.Data!.TotalCount);
    }
}
