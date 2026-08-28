using asERP.Domain.Constants;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Statistic;

// Customer number range for this class: 700-719.
public class DashboardTodosTests : TenantIsolatedTestBase
{
    private async Task<Result<DashboardTodosDto>> GetTodosAsync()
    {
        var response = await Client.GetAsync("/api/v1/Statistics/DashboardTodos");
        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<DashboardTodosDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        return result;
    }

    private void AddLowStockProduct(Guid tenantId, string sku, double stock, double stockMin)
    {
        var product = new asERP.Domain.Entities.Product
        {
            Id = Guid.NewGuid(),
            Sku = sku,
            Name = $"Product {sku}",
            TaxClassId = Guid.NewGuid(),
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
    }

    private async Task SeedOneTodoPerBucketAsync(Guid tenantId)
    {
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, tenantId);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);

        // Ready to ship: paid + processing + unshipped items (seeder defaults).
        ShippingTestDataSeeder.AddSales(DbContext, tenantId, 700, itemCount: 2);

        // Payment overdue: unpaid and ordered 8 days ago (not ready to ship because unpaid).
        var overdue = ShippingTestDataSeeder.AddSales(DbContext, tenantId, 701);
        overdue.PaymentStatus = PaymentStatus.Invoiced;
        overdue.DateSalesed = DateTime.UtcNow.AddDays(-8);

        // Shipping problem: lost shipment; its items are assigned so the sale is not ready to ship.
        var problemSales = ShippingTestDataSeeder.AddSales(DbContext, tenantId, 702, itemCount: 1);
        var lostShipping = ShippingTestDataSeeder.AddShipping(
            DbContext, problemSales, provider, rate, ShippingStatus.Lost);
        foreach (var item in problemSales.SalesItems)
        {
            item.ShippingId = lostShipping.Id;
        }

        // Product to reorder: below configured minimum; a product without minimum does not count.
        AddLowStockProduct(tenantId, "TODO-700", stock: 1, stockMin: 5);

        await DbContext.SaveChangesAsync();
    }

    [Fact]
    public async Task DashboardTodos_CountsEachBucket()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        await SeedOneTodoPerBucketAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetTodosAsync();

        TestAssertions.AssertEqual(1, result.Data.SalessReadyToShip);
        TestAssertions.AssertEqual(1, result.Data.SalessPaymentOverdue);
        TestAssertions.AssertEqual(1, result.Data.ShippingProblems);
        TestAssertions.AssertEqual(1, result.Data.ProductsToReorder);
    }

    [Fact]
    public async Task DashboardTodos_RecentUnpaidSales_NotCountedAsOverdue()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var recentUnpaid = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 703);
        recentUnpaid.PaymentStatus = PaymentStatus.Invoiced;
        recentUnpaid.DateSalesed = DateTime.UtcNow.AddDays(-2);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetTodosAsync();

        TestAssertions.AssertEqual(0, result.Data.SalessPaymentOverdue);
    }

    [Fact]
    public async Task DashboardTodos_TenantIsolation_ReturnsZerosForOtherTenant()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        await SeedOneTodoPerBucketAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var result = await GetTodosAsync();

        TestAssertions.AssertEqual(0, result.Data.SalessReadyToShip);
        TestAssertions.AssertEqual(0, result.Data.SalessPaymentOverdue);
        TestAssertions.AssertEqual(0, result.Data.ShippingProblems);
        TestAssertions.AssertEqual(0, result.Data.ProductsToReorder);
    }
}
