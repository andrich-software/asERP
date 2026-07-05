using asERP.Domain.Constants;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Sales.Queries;

/// <summary>
/// Tests for GET /api/v1/Saless/{id}/returnable-items: only physically shipped lines appear
/// and quantities already claimed by non-cancelled returns are subtracted.
/// Customer-number range: 995–999.
/// </summary>
public class SalesReturnableItemsTests : TenantIsolatedTestBase
{
    private async Task<(Domain.Entities.Sales Sales, Domain.Entities.Shipping Shipping)> SeedAsync(
        int customerNumber,
        ShippingStatus shippingStatus = ShippingStatus.Shipped,
        DateTime? shippedAt = null,
        double itemQuantity = 1)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, customerNumber);

        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            status: shippingStatus, shippedAt: shippedAt);

        foreach (var item in sales.SalesItems)
        {
            item.Quantity = itemQuantity;
            item.ShippingId = shipping.Id;
        }

        await DbContext.SaveChangesAsync();
        return (sales, shipping);
    }

    private async Task<List<ReturnableSalesItemDto>> GetReturnableItemsAsync(Guid salesId)
    {
        var response = await Client.GetAsync($"/api/v1/Saless/{salesId}/returnable-items");
        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<List<ReturnableSalesItemDto>>>(response);
        return result.Data ?? new List<ReturnableSalesItemDto>();
    }

    [Fact]
    public async Task ReturnableItems_ShouldContainOnlyShippedLines()
    {
        var (sales, _) = await SeedAsync(995, shippedAt: DateTime.UtcNow.AddDays(-1));
        var unshipped = sales.SalesItems.Last();
        unshipped.ShippingId = null;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var items = await GetReturnableItemsAsync(sales.Id);

        TestAssertions.AssertEqual(1, items.Count);
        TestAssertions.AssertEqual(sales.SalesItems.First().Id, items[0].SalesItemId);
        TestAssertions.AssertEqual(1, items[0].ReturnableQuantity);
    }

    [Fact]
    public async Task ReturnableItems_WithUnshippedParcel_ShouldBeEmpty()
    {
        // Parcel exists but never physically shipped (Open, no ShippedAt).
        var (sales, _) = await SeedAsync(996, shippingStatus: ShippingStatus.Open, shippedAt: null);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var items = await GetReturnableItemsAsync(sales.Id);

        TestAssertions.AssertEqual(0, items.Count);
    }

    [Fact]
    public async Task ReturnableItems_ShouldSubtractAlreadyReturnedQuantities()
    {
        var (sales, _) = await SeedAsync(997, shippedAt: DateTime.UtcNow.AddDays(-1), itemQuantity: 3);
        var item = sales.SalesItems.First();
        ShippingTestDataSeeder.AddReturnShipment(DbContext, sales, items: (item.Id, 2));
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var items = await GetReturnableItemsAsync(sales.Id);

        var row = items.FirstOrDefault(i => i.SalesItemId == item.Id);
        TestAssertions.AssertNotNull(row);
        TestAssertions.AssertEqual(3, row!.ShippedQuantity);
        TestAssertions.AssertEqual(2, row.AlreadyReturnedQuantity);
        TestAssertions.AssertEqual(1, row.ReturnableQuantity);
    }

    [Fact]
    public async Task ReturnableItems_FullyReturnedLine_ShouldDisappear()
    {
        var (sales, _) = await SeedAsync(998, shippedAt: DateTime.UtcNow.AddDays(-1));
        foreach (var item in sales.SalesItems)
        {
            ShippingTestDataSeeder.AddReturnShipment(DbContext, sales, items: (item.Id, item.Quantity));
        }
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var items = await GetReturnableItemsAsync(sales.Id);

        TestAssertions.AssertEqual(0, items.Count);
    }

    [Fact]
    public async Task ReturnableItems_CancelledReturn_ShouldNotConsumeQuantity()
    {
        var (sales, _) = await SeedAsync(999, shippedAt: DateTime.UtcNow.AddDays(-1), itemQuantity: 3);
        var item = sales.SalesItems.First();
        ShippingTestDataSeeder.AddReturnShipment(DbContext, sales,
            status: ReturnShipmentStatus.Cancelled, items: (item.Id, 2));
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var items = await GetReturnableItemsAsync(sales.Id);

        var row = items.First(i => i.SalesItemId == item.Id);
        TestAssertions.AssertEqual(0, row.AlreadyReturnedQuantity);
        TestAssertions.AssertEqual(3, row.ReturnableQuantity);
    }

    [Fact]
    public async Task ReturnableItems_CrossTenant_ShouldReturnNotFound()
    {
        var (sales, _) = await SeedAsync(995, shippedAt: DateTime.UtcNow.AddDays(-1));
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Saless/{sales.Id}/returnable-items");

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}
