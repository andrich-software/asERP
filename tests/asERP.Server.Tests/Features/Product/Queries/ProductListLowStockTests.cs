using asERP.Domain.Constants;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Product.Queries;

public class ProductListLowStockTests : TenantIsolatedTestBase
{
    private asERP.Domain.Entities.Product AddProductWithStock(string sku, double stock, double stockMin)
        => AddProductWithStock(TenantConstants.TestTenant1Id, sku, stock, stockMin);

    private asERP.Domain.Entities.Product AddProductWithStock(Guid tenantId, string sku, double stock, double stockMin)
    {
        // The product list includes the (required) TaxClass navigation — a dangling TaxClassId
        // would filter the row out, so every product gets a real tax class row.
        var taxClass = new asERP.Domain.Entities.TaxClass
        {
            Id = Guid.NewGuid(),
            TaxRate = 19.0,
            TenantId = tenantId
        };
        DbContext.TaxClass.Add(taxClass);

        var product = new asERP.Domain.Entities.Product
        {
            Id = Guid.NewGuid(),
            Sku = sku,
            Name = $"Product {sku}",
            TaxClassId = taxClass.Id,
            ProductType = ProductType.Standard,
            TenantId = tenantId
        };

        DbContext.Product.Add(product);
        DbContext.ProductStock.Add(new ProductStock
        {
            Id = Guid.NewGuid(),
            ProductId = product.Id,
            WarehouseId = Guid.NewGuid(),
            Stock = stock,
            StockMin = stockMin,
            TenantId = tenantId
        });

        return product;
    }

    private async Task<PaginatedResult<ProductListDto>> GetListAsync(string queryString = "")
    {
        var response = await Client.GetAsync($"/api/v1/Products{queryString}");
        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ProductListDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        return result;
    }

    [Fact]
    public async Task LowStockOnly_ReturnsOnlyProductsBelowConfiguredMinimum()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var belowMin = AddProductWithStock("LOW-001", stock: 2, stockMin: 5);
        var zeroStock = AddProductWithStock("LOW-002", stock: 0, stockMin: 3);
        AddProductWithStock("LOW-003", stock: 0, stockMin: 0);
        AddProductWithStock("LOW-004", stock: 10, stockMin: 5);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync("?lowStockOnly=true");

        TestAssertions.AssertEqual(2, result.Data.Count);
        var ids = result.Data.Select(d => d.Id).ToList();
        TestAssertions.AssertTrue(ids.Contains(belowMin.Id));
        TestAssertions.AssertTrue(ids.Contains(zeroStock.Id));
    }

    [Fact]
    public async Task LowStockOnly_NotSet_ReturnsAllProducts()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        AddProductWithStock("LOW-011", stock: 2, stockMin: 5);
        AddProductWithStock("LOW-012", stock: 10, stockMin: 5);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync();

        TestAssertions.AssertEqual(2, result.Data.Count);
    }

    [Fact]
    public async Task LowStockOnly_TenantIsolation_DoesNotCountOtherTenantProducts()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var tenant1Product = AddProductWithStock("LOW-021", stock: 1, stockMin: 5);
        AddProductWithStock(TenantConstants.TestTenant2Id, "LOW-022", stock: 1, stockMin: 5);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync("?lowStockOnly=true");

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(tenant1Product.Id, result.Data[0].Id);
    }
}
