using maERP.Application.Notifications;
using maERP.Domain.Constants;
using maERP.Domain.Enums;
using maERP.SalesChannels.NotificationHandlers;
using maERP.SalesChannels.Orchestration;
using maERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace maERP.Server.Tests.Features.Product.Commands;

/// <summary>
/// Deleting a listed product must enqueue a DelistProduct outbox row carrying the remote id
/// captured before the channel links were removed — otherwise the remote listing is orphaned.
/// The capture happens in the persistence interceptor; this exercises the handler that turns the
/// captured snapshot into a payload-bearing outbox row (and the cases where it must not).
/// </summary>
public class ProductDelistOnDeleteTests : TenantIsolatedTestBase
{
    private async Task<Guid> SeedChannelAsync(bool exportProducts = true, bool enabled = true)
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        var salesChannelId = Guid.NewGuid();
        try
        {
            DbContext.SalesChannel.Add(new maERP.Domain.Entities.SalesChannel
            {
                Id = salesChannelId,
                Type = SalesChannelType.WooCommerce,
                Name = "Delist Test Channel",
                Url = "https://shop.example.com",
                Username = "key",
                Password = "secret",
                IsEnabled = enabled,
                ExportProducts = exportProducts,
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

    private ProductChangedNotificationHandler CreateHandler()
    {
        var enqueuer = new ChannelExportOutboxEnqueuer(DbContext, NullLogger<ChannelExportOutboxEnqueuer>.Instance);
        return new ProductChangedNotificationHandler(DbContext, enqueuer);
    }

    private static ProductChangedNotification DeleteNotification(Guid productId, Guid salesChannelId, string remoteId, bool isListed)
        => new(productId, TenantConstants.TestTenant1Id, ProductChangeKind.Deleted,
            new[] { new ProductDelistSnapshot(salesChannelId, Guid.NewGuid(), "DELIST-SKU-1", remoteId, null, isListed) });

    [Fact]
    public async Task DeletedProduct_WithListedSnapshot_EnqueuesDelistWithRemoteIdPayload()
    {
        var salesChannelId = await SeedChannelAsync();
        var productId = Guid.NewGuid();
        const string remoteId = "REMOTE-12345";

        await CreateHandler().Handle(DeleteNotification(productId, salesChannelId, remoteId, isListed: true), CancellationToken.None);

        var outbox = await DbContext.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.AggregateId == productId && o.Operation == ChannelSyncOperation.DelistProduct)
            .ToListAsync();

        TestAssertions.AssertEqual(1, outbox.Count);
        TestAssertions.AssertEqual(salesChannelId, outbox[0].SalesChannelId);
        // The snapshot payload must carry the remote id since the channel link is already gone.
        TestAssertions.AssertTrue(outbox[0].PayloadJson.Contains(remoteId));
    }

    [Fact]
    public async Task DeletedProduct_OnChannelWithoutExport_DoesNotEnqueueDelist()
    {
        var salesChannelId = await SeedChannelAsync(exportProducts: false);
        var productId = Guid.NewGuid();

        await CreateHandler().Handle(DeleteNotification(productId, salesChannelId, "REMOTE-1", isListed: true), CancellationToken.None);

        var anyDelist = await DbContext.ChannelExportOutbox
            .IgnoreQueryFilters()
            .AnyAsync(o => o.AggregateId == productId && o.Operation == ChannelSyncOperation.DelistProduct);

        TestAssertions.AssertFalse(anyDelist);
    }

    [Fact]
    public async Task DeletedProduct_UnlistedSnapshot_DoesNotEnqueueDelist()
    {
        var salesChannelId = await SeedChannelAsync();
        var productId = Guid.NewGuid();

        await CreateHandler().Handle(DeleteNotification(productId, salesChannelId, "REMOTE-1", isListed: false), CancellationToken.None);

        var anyDelist = await DbContext.ChannelExportOutbox
            .IgnoreQueryFilters()
            .AnyAsync(o => o.AggregateId == productId && o.Operation == ChannelSyncOperation.DelistProduct);

        TestAssertions.AssertFalse(anyDelist);
    }

    [Fact]
    public async Task DeletedProduct_WithoutSnapshots_DoesNotEnqueueDelist()
    {
        var productId = Guid.NewGuid();
        var notification = new ProductChangedNotification(productId, TenantConstants.TestTenant1Id, ProductChangeKind.Deleted);

        await CreateHandler().Handle(notification, CancellationToken.None);

        var anyDelist = await DbContext.ChannelExportOutbox
            .IgnoreQueryFilters()
            .AnyAsync(o => o.AggregateId == productId && o.Operation == ChannelSyncOperation.DelistProduct);

        TestAssertions.AssertFalse(anyDelist);
    }
}
