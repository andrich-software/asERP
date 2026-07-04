using System.Net;
using asERP.Application.Contracts.Services;
using asERP.Domain.Constants;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Features.Shipping.Queries;

// Customer number range for this class: 940–959.
public class ShippingDocumentQueriesTests : TenantIsolatedTestBase
{
    private static void AssertPdf(byte[] body)
    {
        TestAssertions.AssertTrue(body.Length > 500);
        var header = System.Text.Encoding.ASCII.GetString(body, 0, 4);
        TestAssertions.AssertEqual("%PDF", header);
    }

    private static string GetFileName(HttpResponseMessage response)
    {
        return response.Content.Headers.ContentDisposition?.FileNameStar
            ?? response.Content.Headers.ContentDisposition?.FileName
            ?? string.Empty;
    }

    [Fact]
    public async Task GetPackingSlip_WithItemsSerialsAndUmlauts_ShouldReturnPdf()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 940, itemCount: 3);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            trackingNumber: "TRACK-PACK-1");

        var items = sales.SalesItems.ToList();
        items[0].Name = "Kabelträger Größe L";
        var product = ShippingTestDataSeeder.AddProduct(DbContext, TenantConstants.TestTenant1Id, "SKU-940");
        items[0].ProductId = product.Id;
        items[1].MissingProductSku = "MISS-940";
        ShippingTestDataSeeder.AddSerialNumber(DbContext, items[2], "SN-940-1");
        foreach (var item in items)
        {
            item.ShippingId = shipping.Id;
        }
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}/packing-slip");

        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertEqual("application/pdf", response.Content.Headers.ContentType?.MediaType);
        AssertPdf(await response.Content.ReadAsByteArrayAsync());
        TestAssertions.AssertTrue(GetFileName(response).StartsWith("packliste-"));
    }

    [Fact]
    public async Task GetPackingSlip_WithUnknownId_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{Guid.NewGuid()}/packing-slip");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetPackingSlip_CrossTenant_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 941);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}/packing-slip");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetPackingSlip_WithoutAssignedItems_ShouldReturnPdf()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 942);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}/packing-slip");

        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertEqual("application/pdf", response.Content.Headers.ContentType?.MediaType);
        AssertPdf(await response.Content.ReadAsByteArrayAsync());
    }

    [Fact]
    public async Task GetPickList_WithStorageLocations_ShouldReturnPdf()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 943);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);

        var warehouse = await DbContext.Warehouse
            .IgnoreQueryFilters()
            .FirstAsync(w => w.TenantId == TenantConstants.TestTenant1Id);
        var product = ShippingTestDataSeeder.AddProduct(DbContext, TenantConstants.TestTenant1Id, "SKU-943");
        DbContext.ProductStock.Add(new asERP.Domain.Entities.ProductStock
        {
            Id = Guid.NewGuid(),
            ProductId = product.Id,
            WarehouseId = warehouse.Id,
            Stock = 10,
            StorageLocation = 12.5,
            TenantId = TenantConstants.TestTenant1Id
        });

        var item = sales.SalesItems.First();
        item.ProductId = product.Id;
        item.ShippingId = shipping.Id;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}/pick-list");

        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertEqual("application/pdf", response.Content.Headers.ContentType?.MediaType);
        AssertPdf(await response.Content.ReadAsByteArrayAsync());
        TestAssertions.AssertTrue(GetFileName(response).StartsWith("pickliste-"));
    }

    [Fact]
    public async Task GetPickList_WithUnknownId_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{Guid.NewGuid()}/pick-list");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetPickList_CrossTenant_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 944);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}/pick-list");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    // --- Data-collection level (IShippingDocumentDataService) ---

    private IShippingDocumentDataService GetDocumentDataService()
    {
        return Scope.ServiceProvider.GetRequiredService<IShippingDocumentDataService>();
    }

    [Fact]
    public async Task PackingSlipData_WithTwoShipments_ShouldContainPackageIndexAndCount()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 945);
        var shippingA = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        var shippingB = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        var service = GetDocumentDataService();
        var dataA = await service.GetPackingSlipDataAsync(shippingA.Id);
        var dataB = await service.GetPackingSlipDataAsync(shippingB.Id);

        TestAssertions.AssertNotNull(dataA);
        TestAssertions.AssertNotNull(dataB);
        TestAssertions.AssertEqual(2, dataA!.PackageCount);
        TestAssertions.AssertEqual(2, dataB!.PackageCount);
        var indexes = new[] { dataA.PackageIndex, dataB.PackageIndex }.OrderBy(i => i).ToArray();
        TestAssertions.AssertEqual(1, indexes[0]);
        TestAssertions.AssertEqual(2, indexes[1]);
        TestAssertions.AssertEqual(sales.SalesId, dataA.SalesNumber);
    }

    [Fact]
    public async Task PackingSlipData_ShouldFallBackToMissingProductSkuAndMapSerials()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 946, itemCount: 2);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);

        var items = sales.SalesItems.ToList();
        var product = ShippingTestDataSeeder.AddProduct(DbContext, TenantConstants.TestTenant1Id, "SKU-946");
        items[0].ProductId = product.Id;
        ShippingTestDataSeeder.AddSerialNumber(DbContext, items[0], "SN-946-1");
        ShippingTestDataSeeder.AddSerialNumber(DbContext, items[0], "SN-946-2");
        items[1].MissingProductSku = "MISS-946";
        foreach (var item in items)
        {
            item.ShippingId = shipping.Id;
        }
        await DbContext.SaveChangesAsync();
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        var data = await GetDocumentDataService().GetPackingSlipDataAsync(shipping.Id);

        TestAssertions.AssertNotNull(data);
        TestAssertions.AssertEqual(2, data!.Items.Count);
        var productItem = data.Items.Single(i => i.Sku == "SKU-946");
        TestAssertions.AssertEqual(2, productItem.SerialNumbers.Count);
        TestAssertions.AssertContains("SN-946-1", productItem.SerialNumbers);
        var missingItem = data.Items.Single(i => i.Sku == "MISS-946");
        TestAssertions.AssertEmpty(missingItem.SerialNumbers);
    }

    [Fact]
    public async Task PackingSlipData_ShowPrices_ShouldMirrorTenantFlag()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 947);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        var service = GetDocumentDataService();
        var withoutPrices = await service.GetPackingSlipDataAsync(shipping.Id);

        var tenant = await DbContext.Tenant
            .IgnoreQueryFilters()
            .FirstAsync(t => t.Id == TenantConstants.TestTenant1Id);
        tenant.PackingSlipShowPrices = true;
        await DbContext.SaveChangesAsync();

        var withPrices = await service.GetPackingSlipDataAsync(shipping.Id);

        TestAssertions.AssertNotNull(withoutPrices);
        TestAssertions.AssertNotNull(withPrices);
        TestAssertions.AssertFalse(withoutPrices!.ShowPrices);
        TestAssertions.AssertTrue(withPrices!.ShowPrices);
    }

    [Fact]
    public async Task PickListData_ShouldSortByStorageLocation_MissingProductsLast()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 948, itemCount: 3);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);

        var warehouse = await DbContext.Warehouse
            .IgnoreQueryFilters()
            .FirstAsync(w => w.TenantId == TenantConstants.TestTenant1Id);
        var productHigh = ShippingTestDataSeeder.AddProduct(DbContext, TenantConstants.TestTenant1Id, "SKU-948-HIGH");
        var productLow = ShippingTestDataSeeder.AddProduct(DbContext, TenantConstants.TestTenant1Id, "SKU-948-LOW");
        DbContext.ProductStock.Add(new asERP.Domain.Entities.ProductStock
        {
            Id = Guid.NewGuid(),
            ProductId = productHigh.Id,
            WarehouseId = warehouse.Id,
            Stock = 5,
            StorageLocation = 50,
            TenantId = TenantConstants.TestTenant1Id
        });
        DbContext.ProductStock.Add(new asERP.Domain.Entities.ProductStock
        {
            Id = Guid.NewGuid(),
            ProductId = productLow.Id,
            WarehouseId = warehouse.Id,
            Stock = 5,
            StorageLocation = 2,
            TenantId = TenantConstants.TestTenant1Id
        });

        var items = sales.SalesItems.ToList();
        items[0].ProductId = productHigh.Id;
        items[1].ProductId = productLow.Id;
        items[2].MissingProductSku = "MISS-948";
        foreach (var item in items)
        {
            item.ShippingId = shipping.Id;
        }
        await DbContext.SaveChangesAsync();
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        var data = await GetDocumentDataService().GetPickListDataAsync(new[] { shipping.Id });

        TestAssertions.AssertNotNull(data);
        TestAssertions.AssertEqual(3, data!.Items.Count);
        TestAssertions.AssertEqual("SKU-948-LOW", data.Items[0].Sku);
        TestAssertions.AssertEqual(2d, data.Items[0].StorageLocation!.Value);
        TestAssertions.AssertEqual(warehouse.Name, data.Items[0].WarehouseName);
        TestAssertions.AssertEqual("SKU-948-HIGH", data.Items[1].Sku);
        TestAssertions.AssertEqual("MISS-948", data.Items[2].Sku);
        TestAssertions.AssertNull(data.Items[2].StorageLocation);
        TestAssertions.AssertContains(sales.SalesId, data.SalesNumbers);
    }
}
