using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Sales.Commands;

public class SalesCancelTests : TenantIsolatedTestBase
{
    private async Task<(asERP.Domain.Entities.ShippingProvider Provider,
        asERP.Domain.Entities.ShippingProviderRate Rate,
        asERP.Domain.Entities.Sales Sales)> SeedSetupAsync(
        int customerNumber, Guid? tenantId = null)
    {
        var tenant = tenantId ?? TenantConstants.TestTenant1Id;
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, tenant);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, tenant, customerNumber);
        await DbContext.SaveChangesAsync();
        return (provider, rate, sales);
    }

    [Fact]
    public async Task CancelOrder_WithOpenShipment_ShouldCancelOrderAndShipment()
    {
        var (provider, rate, sales) = await SeedSetupAsync(850);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        foreach (var item in sales.SalesItems)
        {
            item.ShippingId = shipping.Id;
        }
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        DbContext.ChangeTracker.Clear();

        var order = await DbContext.Sales.FirstAsync(s => s.Id == sales.Id);
        TestAssertions.AssertEqual(SalesStatus.Cancelled, order.Status);

        var parcel = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertEqual(ShippingStatus.Cancelled, parcel.Status);

        var items = await DbContext.SalesItem.Where(i => i.SalesId == sales.Id).ToListAsync();
        TestAssertions.AssertTrue(items.All(i => i.ShippingId == null));
    }

    [Fact]
    public async Task CancelOrder_ShouldWriteOrderAndShipmentHistoryRows()
    {
        var (provider, rate, sales) = await SeedSetupAsync(851);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        DbContext.ChangeTracker.Clear();

        var orderRow = await DbContext.SalesHistory.FirstOrDefaultAsync(h =>
            h.SalesId == sales.Id && h.SalesStatusNew == SalesStatus.Cancelled);
        TestAssertions.AssertNotNull(orderRow);
        TestAssertions.AssertNull(orderRow!.ShippingId);

        var shipmentRow = await DbContext.SalesHistory.FirstOrDefaultAsync(h =>
            h.SalesId == sales.Id && h.ShippingStatusNew == "Cancelled");
        TestAssertions.AssertNotNull(shipmentRow);
        TestAssertions.AssertEqual<Guid?>(shipping.Id, shipmentRow!.ShippingId);
    }

    [Theory]
    [InlineData(ShippingStatus.Shipped)]
    [InlineData(ShippingStatus.InTransit)]
    [InlineData(ShippingStatus.OutForDelivery)]
    [InlineData(ShippingStatus.Delivered)]
    public async Task CancelOrder_WithShippedParcel_ShouldReturnBadRequest(ShippingStatus shippedStatus)
    {
        var (provider, rate, sales) = await SeedSetupAsync(852);
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate, status: shippedStatus);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var order = await DbContext.Sales.FirstAsync(s => s.Id == sales.Id);
        TestAssertions.AssertEqual(SalesStatus.Processing, order.Status);
    }

    [Fact]
    public async Task CancelOrder_WithShippedAtButEarlyStatus_ShouldReturnBadRequest()
    {
        var (provider, rate, sales) = await SeedSetupAsync(853);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            status: ShippingStatus.LabelCreated);
        shipping.ShippedAt = DateTime.UtcNow.AddHours(-2);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Theory]
    [InlineData(SalesStatus.Completed)]
    [InlineData(SalesStatus.Cancelled)]
    [InlineData(SalesStatus.Returned)]
    [InlineData(SalesStatus.Refunded)]
    public async Task CancelOrder_InTerminalStatus_ShouldReturnBadRequest(SalesStatus status)
    {
        var (_, _, sales) = await SeedSetupAsync(854);
        sales.Status = status;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CancelOrder_UnknownId_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{Guid.NewGuid()}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CancelOrder_CrossTenant_ShouldReturnNotFound()
    {
        var (_, _, sales) = await SeedSetupAsync(855, TenantConstants.TestTenant2Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var order = await DbContext.Sales.IgnoreQueryFilters().FirstAsync(s => s.Id == sales.Id);
        TestAssertions.AssertEqual(SalesStatus.Processing, order.Status);
    }

    [Fact]
    public async Task CancelOrder_ShouldNotChangeProductStock()
    {
        var (provider, rate, sales) = await SeedSetupAsync(856);
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();
        var stocksBefore = await DbContext.ProductStock.AsNoTracking()
            .OrderBy(s => s.Id).Select(s => s.Stock).ToListAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var stocksAfter = await DbContext.ProductStock.AsNoTracking()
            .OrderBy(s => s.Id).Select(s => s.Stock).ToListAsync();
        TestAssertions.AssertEqual(stocksBefore.Count, stocksAfter.Count);
        TestAssertions.AssertTrue(stocksBefore.SequenceEqual(stocksAfter));
    }
}
