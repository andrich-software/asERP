using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Sales.Commands;

/// <summary>
/// Cancelling an order must push a dedicated CancelSales export to the originating channel —
/// but only when the channel opted in (PushSalesCancellations), the order has a remote reference
/// and the connector supports the cancel API. A cancelled order must never produce the generic
/// UpdateSales export (connectors treat that as "confirm progress", e.g. eBay ships the order).
/// Kundennummern 940–949.
/// </summary>
public class SalesCancelChannelPushTests : TenantIsolatedTestBase
{
    private async Task<Guid> SeedChannelAsync(
        SalesChannelType type = SalesChannelType.WooCommerce,
        bool pushCancellations = true,
        bool exportSaless = true,
        bool enabled = true)
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        var salesChannelId = Guid.NewGuid();
        try
        {
            DbContext.SalesChannel.Add(new asERP.Domain.Entities.SalesChannel
            {
                Id = salesChannelId,
                Type = type,
                Name = "Cancel Push Test Channel",
                Url = "https://shop.example.com/wp-json/wc/v3",
                Username = "key",
                Password = "secret",
                IsEnabled = enabled,
                ExportSaless = exportSaless,
                PushSalesCancellations = pushCancellations,
                TenantId = TenantConstants.TestTenant1Id
            });
            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }

        return salesChannelId;
    }

    private async Task<asERP.Domain.Entities.Sales> SeedSalesAsync(
        int customerNumber, Guid salesChannelId, string remoteSalesId = "4711")
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, customerNumber);
        sales.SalesChannelId = salesChannelId;
        sales.RemoteSalesId = remoteSalesId;
        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();
        return sales;
    }

    private Task<List<asERP.Domain.Entities.ChannelExportOutbox>> GetOutboxRowsAsync(Guid salesId) =>
        DbContext.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.AggregateId == salesId)
            .ToListAsync();

    [Fact]
    public async Task Cancel_WithPushEnabled_EnqueuesSingleCancelSalesExport()
    {
        var channelId = await SeedChannelAsync();
        var sales = await SeedSalesAsync(940, channelId);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var rows = await GetOutboxRowsAsync(sales.Id);
        TestAssertions.AssertEqual(1, rows.Count(r => r.Operation == ChannelSyncOperation.CancelSales));
        TestAssertions.AssertEqual(channelId, rows.Single(r => r.Operation == ChannelSyncOperation.CancelSales).SalesChannelId);
        // The generic update must be suppressed for a cancelled order even though ExportSaless is on.
        TestAssertions.AssertEqual(0, rows.Count(r => r.Operation == ChannelSyncOperation.UpdateSales));
    }

    [Fact]
    public async Task Cancel_WithPushDisabled_DoesNotEnqueueCancelSalesExport()
    {
        var channelId = await SeedChannelAsync(pushCancellations: false);
        var sales = await SeedSalesAsync(941, channelId);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var rows = await GetOutboxRowsAsync(sales.Id);
        TestAssertions.AssertEqual(0, rows.Count);
    }

    [Fact]
    public async Task Cancel_WithoutRemoteSalesId_DoesNotEnqueueExport()
    {
        var channelId = await SeedChannelAsync();
        var sales = await SeedSalesAsync(942, channelId, remoteSalesId: string.Empty);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var rows = await GetOutboxRowsAsync(sales.Id);
        TestAssertions.AssertEqual(0, rows.Count);
    }

    [Fact]
    public async Task Cancel_OnChannelWithoutCancelCapability_DoesNotEnqueueExport()
    {
        // Shopware6 has no CancelSaless capability — the setting alone must not enqueue anything.
        var channelId = await SeedChannelAsync(type: SalesChannelType.Shopware6);
        var sales = await SeedSalesAsync(943, channelId);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var rows = await GetOutboxRowsAsync(sales.Id);
        TestAssertions.AssertEqual(0, rows.Count(r => r.Operation == ChannelSyncOperation.CancelSales));
    }

    [Fact]
    public async Task Cancel_OnDisabledChannel_DoesNotEnqueueExport()
    {
        var channelId = await SeedChannelAsync(enabled: false);
        var sales = await SeedSalesAsync(944, channelId);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var rows = await GetOutboxRowsAsync(sales.Id);
        TestAssertions.AssertEqual(0, rows.Count);
    }

    [Fact]
    public async Task Cancel_WithOpenShipment_CoalescesIntoSingleCancelSalesRow()
    {
        // Order cancel + per-shipment cancel each fire a SalesChangedNotification for the same
        // order — the outbox idempotency key must coalesce them into exactly one CancelSales row.
        var channelId = await SeedChannelAsync();
        var sales = await SeedSalesAsync(945, channelId);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var trackedSales = await DbContext.Sales.IgnoreQueryFilters()
            .Include(s => s.SalesItems).FirstAsync(s => s.Id == sales.Id);
        ShippingTestDataSeeder.AddShipping(DbContext, trackedSales, provider, rate);
        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var rows = await GetOutboxRowsAsync(sales.Id);
        TestAssertions.AssertEqual(1, rows.Count(r => r.Operation == ChannelSyncOperation.CancelSales));
        TestAssertions.AssertEqual(0, rows.Count(r => r.Operation == ChannelSyncOperation.UpdateSales));
    }

    [Fact]
    public async Task Cancel_ManualOrderWithoutChannel_DoesNotEnqueueExport()
    {
        // AddSales stamps a random SalesChannelId that resolves to no channel row — the manual-order case.
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 946);
        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Saless/{sales.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var rows = await GetOutboxRowsAsync(sales.Id);
        TestAssertions.AssertEqual(0, rows.Count);
    }
}
