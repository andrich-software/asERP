using asERP.Domain.Constants;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Sales.Queries;

// Customer number range for this class: 920–929.
public class SalesReadyToShipListTests : TenantIsolatedTestBase
{
    private async Task<PaginatedResult<SalesReadyToShipListDto>> GetListAsync(string queryString = "")
    {
        var response = await Client.GetAsync($"/api/v1/Saless/ready-to-ship{queryString}");
        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<SalesReadyToShipListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        return result;
    }

    [Fact]
    public async Task ReadyToShip_ReturnsOnlySalesWithOpenItems()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);

        var openSales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 920, itemCount: 2);

        var shippedSales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 921, itemCount: 2);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, shippedSales, provider, rate);
        foreach (var item in shippedSales.SalesItems)
        {
            item.ShippingId = shipping.Id;
        }
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync();

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(openSales.Id, result.Data[0].Id);
        TestAssertions.AssertEqual(2, result.Data[0].OpenItemCount);
        TestAssertions.AssertEqual("Germany", result.Data[0].DeliveryAddressCountry);
    }

    [Fact]
    public async Task ReadyToShip_ExcludesTerminalAndOnHoldStatuses()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var included = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 922);
        included.Status = SalesStatus.Pending;
        var cancelled = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 923);
        cancelled.Status = SalesStatus.Cancelled;
        var completed = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 924);
        completed.Status = SalesStatus.Completed;
        var onHold = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 925);
        onHold.Status = SalesStatus.OnHold;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync();

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(included.Id, result.Data[0].Id);
    }

    [Fact]
    public async Task ReadyToShip_PartiallyShippedSales_ReturnsOpenItemCountOnly()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 926, itemCount: 3);
        sales.Status = SalesStatus.PartiallyDelivered;
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        sales.SalesItems.First().ShippingId = shipping.Id;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync();

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(2, result.Data[0].OpenItemCount);
    }

    [Fact]
    public async Task ReadyToShip_AllItemsInStock_ReflectsAggregatedStock()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        // Sufficient stock: one product, two lines of one piece each, stock 2.
        var inStockSales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 927, itemCount: 2);
        var stockedProduct = ShippingTestDataSeeder.AddProduct(
            DbContext, TenantConstants.TestTenant1Id, "SKU-927", warehouseStocks: new double[] { 1, 1 });
        foreach (var item in inStockSales.SalesItems)
        {
            item.ProductId = stockedProduct.Id;
        }

        // Same shape but stock only covers one of the two lines — demand is aggregated per product.
        var shortSales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 928, itemCount: 2);
        var shortProduct = ShippingTestDataSeeder.AddProduct(
            DbContext, TenantConstants.TestTenant1Id, "SKU-928", warehouseStocks: new double[] { 1 });
        foreach (var item in shortSales.SalesItems)
        {
            item.ProductId = shortProduct.Id;
        }

        // Items whose product row no longer exists count as not in stock.
        var missingProductSales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 929, itemCount: 1);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync();

        TestAssertions.AssertEqual(3, result.Data.Count);
        var byId = result.Data.ToDictionary(d => d.Id);
        TestAssertions.AssertTrue(byId[inStockSales.Id].AllItemsInStock);
        TestAssertions.AssertFalse(byId[shortSales.Id].AllItemsInStock);
        TestAssertions.AssertFalse(byId[missingProductSales.Id].AllItemsInStock);
    }

    [Fact]
    public async Task ReadyToShip_ZeroBasedPagination_ReturnsPagesAndTotalCount()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        for (var i = 0; i < 3; i++)
        {
            ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 920 + i);
        }
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var page0 = await GetListAsync("?pageNumber=0&pageSize=2");
        var page1 = await GetListAsync("?pageNumber=1&pageSize=2");

        TestAssertions.AssertEqual(2, page0.Data.Count);
        TestAssertions.AssertEqual(3, page0.TotalCount);
        TestAssertions.AssertEqual(1, page1.Data.Count);
        TestAssertions.AssertEqual(3, page1.TotalCount);
    }

    [Fact]
    public async Task ReadyToShip_TenantIsolation_DoesNotReturnOtherTenantSales()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var tenant1Sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 920);
        var tenant2Sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant2Id, 921);
        await DbContext.SaveChangesAsync();

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var tenant1Result = await GetListAsync();
        TestAssertions.AssertEqual(1, tenant1Result.Data.Count);
        TestAssertions.AssertEqual(tenant1Sales.Id, tenant1Result.Data[0].Id);

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var tenant2Result = await GetListAsync();
        TestAssertions.AssertEqual(1, tenant2Result.Data.Count);
        TestAssertions.AssertEqual(tenant2Sales.Id, tenant2Result.Data[0].Id);
    }
}
