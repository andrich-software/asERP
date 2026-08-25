using asERP.Application.Notifications;
using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.NotificationHandlers;
using asERP.SalesChannels.Orchestration;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Changing a channel's warehouse set (or enabling ExportStock) shifts the effective stock of every
/// listed product at once — the handler must enqueue an UpdateStock outbox row per listed product so
/// the drainer re-pushes the fresh warehouse sum. Exercises the handler directly, mirroring the other
/// SalesChannels handler-level tests.
/// </summary>
public class SalesChannelStockScopeChangedTests : TenantIsolatedTestBase
{
    private async Task<Guid> SeedChannelAsync(bool exportStock = true, bool enabled = true)
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        var salesChannelId = Guid.NewGuid();
        try
        {
            DbContext.SalesChannel.Add(new SalesChannel
            {
                Id = salesChannelId,
                Type = SalesChannelType.WooCommerce,
                Name = "Stock Scope Test Channel",
                Url = "https://shop.example.com",
                Username = "key",
                Password = "secret",
                IsEnabled = enabled,
                ExportStock = exportStock,
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

    private async Task<Guid> SeedListingAsync(Guid salesChannelId, bool isListed = true)
    {
        var productId = Guid.NewGuid();
        DbContext.ProductSalesChannel.Add(new ProductSalesChannel
        {
            Id = Guid.NewGuid(),
            SalesChannelId = salesChannelId,
            ProductId = productId,
            IsListed = isListed,
            TenantId = TenantConstants.TestTenant1Id
        });
        await DbContext.SaveChangesAsync();
        return productId;
    }

    private SalesChannelStockScopeChangedNotificationHandler CreateHandler()
    {
        // Empty registry: the enqueuer fails open for types without a registered connector.
        var registry = new SalesChannelConnectorRegistry(Array.Empty<ISalesChannelConnector>());
        var enqueuer = new ChannelExportOutboxEnqueuer(DbContext, registry, NullLogger<ChannelExportOutboxEnqueuer>.Instance);
        return new SalesChannelStockScopeChangedNotificationHandler(DbContext, enqueuer);
    }

    private async Task<List<ChannelExportOutbox>> GetUpdateStockRowsAsync(Guid salesChannelId)
        => await DbContext.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.SalesChannelId == salesChannelId && o.Operation == ChannelSyncOperation.UpdateStock)
            .ToListAsync();

    [Fact]
    public async Task StockScopeChanged_EnqueuesUpdateStockForEveryListedProduct()
    {
        var salesChannelId = await SeedChannelAsync();
        var listedProduct1 = await SeedListingAsync(salesChannelId);
        var listedProduct2 = await SeedListingAsync(salesChannelId);
        var unlistedProduct = await SeedListingAsync(salesChannelId, isListed: false);

        await CreateHandler().Handle(
            new SalesChannelStockScopeChangedNotification(salesChannelId, TenantConstants.TestTenant1Id),
            CancellationToken.None);

        var rows = await GetUpdateStockRowsAsync(salesChannelId);
        TestAssertions.AssertEqual(2, rows.Count);
        TestAssertions.AssertTrue(rows.Any(o => o.AggregateId == listedProduct1));
        TestAssertions.AssertTrue(rows.Any(o => o.AggregateId == listedProduct2));
        TestAssertions.AssertFalse(rows.Any(o => o.AggregateId == unlistedProduct));
        TestAssertions.AssertTrue(rows.All(o => o.Status == ChannelOutboxStatus.Pending));
        TestAssertions.AssertTrue(rows.All(o => o.AggregateType == ChannelOutboxAggregateType.Stock));
    }

    [Fact]
    public async Task ChannelWithoutExportStock_DoesNotEnqueue()
    {
        var salesChannelId = await SeedChannelAsync(exportStock: false);
        await SeedListingAsync(salesChannelId);

        await CreateHandler().Handle(
            new SalesChannelStockScopeChangedNotification(salesChannelId, TenantConstants.TestTenant1Id),
            CancellationToken.None);

        TestAssertions.AssertEqual(0, (await GetUpdateStockRowsAsync(salesChannelId)).Count);
    }

    [Fact]
    public async Task DisabledChannel_DoesNotEnqueue()
    {
        var salesChannelId = await SeedChannelAsync(enabled: false);
        await SeedListingAsync(salesChannelId);

        await CreateHandler().Handle(
            new SalesChannelStockScopeChangedNotification(salesChannelId, TenantConstants.TestTenant1Id),
            CancellationToken.None);

        TestAssertions.AssertEqual(0, (await GetUpdateStockRowsAsync(salesChannelId)).Count);
    }

    [Fact]
    public async Task ExistingDoneOutboxRow_IsResetToPending()
    {
        var salesChannelId = await SeedChannelAsync();
        var productId = await SeedListingAsync(salesChannelId);

        DbContext.ChannelExportOutbox.Add(new ChannelExportOutbox
        {
            Id = Guid.NewGuid(),
            TenantId = TenantConstants.TestTenant1Id,
            SalesChannelId = salesChannelId,
            Operation = ChannelSyncOperation.UpdateStock,
            AggregateType = ChannelOutboxAggregateType.Stock,
            AggregateId = productId,
            PayloadJson = string.Empty,
            IdempotencyKey = ChannelExportOutboxEnqueuer.BuildIdempotencyKey(
                ChannelSyncOperation.UpdateStock, ChannelOutboxAggregateType.Stock, productId, salesChannelId),
            AttemptCount = 3,
            Status = ChannelOutboxStatus.Done,
            CompletedAt = DateTime.UtcNow.AddHours(-1),
            NextAttemptAt = DateTime.UtcNow.AddHours(-2)
        });
        await DbContext.SaveChangesAsync();

        await CreateHandler().Handle(
            new SalesChannelStockScopeChangedNotification(salesChannelId, TenantConstants.TestTenant1Id),
            CancellationToken.None);

        var rows = await GetUpdateStockRowsAsync(salesChannelId);
        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(ChannelOutboxStatus.Pending, rows[0].Status);
        TestAssertions.AssertEqual(0, rows[0].AttemptCount);
        TestAssertions.AssertNull(rows[0].CompletedAt);
    }
}
