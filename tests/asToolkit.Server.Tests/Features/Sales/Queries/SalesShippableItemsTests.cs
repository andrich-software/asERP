using System.Net;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Xunit;

namespace asToolkit.Server.Tests.Features.Sales.Queries;

public class SalesShippableItemsTests : TenantIsolatedTestBase
{
    private async Task<Result<List<ShippableSalesItemDto>>> GetShippableItemsAsync(Guid salesId)
    {
        var response = await Client.GetAsync($"/api/v1/Saless/{salesId}/shippable-items");
        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<List<ShippableSalesItemDto>>>(response);
        TestAssertions.AssertNotNull(result.Data);
        return result;
    }

    [Fact]
    public async Task ShippableItems_ReturnsOnlyUnassignedItems()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 890);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        var assignedItem = sales.SalesItems.First();
        assignedItem.ShippingId = shipping.Id;
        var openItem = sales.SalesItems.Last();
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetShippableItemsAsync(sales.Id);

        TestAssertions.AssertEqual(1, result.Data!.Count);
        TestAssertions.AssertEqual(openItem.Id, result.Data[0].SalesItemId);
        TestAssertions.AssertEqual(openItem.Quantity, result.Data[0].OpenQuantity);
        TestAssertions.AssertEqual(openItem.Price, result.Data[0].Price);
    }

    [Fact]
    public async Task ShippableItems_SumsStockAcrossWarehouses()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 891,
            itemCount: 1);
        var product = ShippingTestDataSeeder.AddProduct(DbContext, TenantConstants.TestTenant1Id,
            sku: "SKU-891", weight: 1.5m, width: 20m, height: 10m, depth: 30m,
            warehouseStocks: new double[] { 3, 4.5 });
        sales.SalesItems.First().ProductId = product.Id;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetShippableItemsAsync(sales.Id);

        TestAssertions.AssertEqual(1, result.Data!.Count);
        var item = result.Data[0];
        TestAssertions.AssertEqual(7.5, item.StockAvailable);
        TestAssertions.AssertEqual("SKU-891", item.Sku);
        TestAssertions.AssertEqual(1.5m, item.ProductWeight);
        TestAssertions.AssertEqual(20m, item.ProductWidth);
        TestAssertions.AssertEqual(10m, item.ProductHeight);
        TestAssertions.AssertEqual(30m, item.ProductDepth);
    }

    [Fact]
    public async Task ShippableItems_MissingProduct_UsesMissingSkuAndZeroes()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 892,
            itemCount: 1);
        var item = sales.SalesItems.First();
        // ProductId points nowhere — the product was never imported.
        item.MissingProductSku = "MISSING-892";
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetShippableItemsAsync(sales.Id);

        TestAssertions.AssertEqual(1, result.Data!.Count);
        var dto = result.Data[0];
        TestAssertions.AssertEqual("MISSING-892", dto.Sku);
        TestAssertions.AssertEqual(0d, dto.StockAvailable);
        TestAssertions.AssertEqual(0m, dto.ProductWeight);
        TestAssertions.AssertEqual(0m, dto.ProductWidth);
        TestAssertions.AssertEqual(0m, dto.ProductHeight);
        TestAssertions.AssertEqual(0m, dto.ProductDepth);
    }

    [Fact]
    public async Task ShippableItems_WithSerialNumbers_SetsHasSerialNumbers()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 893);
        var serialItem = sales.SalesItems.First();
        ShippingTestDataSeeder.AddSerialNumber(DbContext, serialItem, "SN-0001");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetShippableItemsAsync(sales.Id);

        TestAssertions.AssertEqual(2, result.Data!.Count);
        var serialDto = result.Data.Single(i => i.SalesItemId == serialItem.Id);
        var plainDto = result.Data.Single(i => i.SalesItemId != serialItem.Id);
        TestAssertions.AssertTrue(serialDto.HasSerialNumbers);
        TestAssertions.AssertFalse(plainDto.HasSerialNumbers);
    }

    [Fact]
    public async Task ShippableItems_WithUnknownId_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Saless/{Guid.NewGuid()}/shippable-items");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task ShippableItems_FromOtherTenant_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 894);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Saless/{sales.Id}/shippable-items");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
