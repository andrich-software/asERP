using System.Text.Json;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Orchestration;
using Microsoft.EntityFrameworkCore;

namespace asERP.SalesChannels.NotificationHandlers;

/// <summary>
/// On Product create/update, enqueue an <c>ExportProduct</c> outbox row for every channel where
/// the product is listed (PSC.IsListed=true) AND the channel exports products AND IsEnabled.
/// Deletion routes to <c>DelistProduct</c> on every previously-listed channel; the channel links
/// are already gone, so the delist payload is taken from the notification's pre-delete snapshot.
/// </summary>
public sealed class ProductChangedNotificationHandler : INotificationHandler<ProductChangedNotification>
{
    private readonly ApplicationDbContext _context;
    private readonly ChannelExportOutboxEnqueuer _enqueuer;

    public ProductChangedNotificationHandler(ApplicationDbContext context, ChannelExportOutboxEnqueuer enqueuer)
    {
        _context = context;
        _enqueuer = enqueuer;
    }

    public async Task Handle(ProductChangedNotification notification, CancellationToken cancellationToken)
    {
        if (notification.Kind == ProductChangeKind.Deleted)
        {
            await HandleDeleteAsync(notification, cancellationToken);
            return;
        }

        var channelIds = await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Where(psc => psc.ProductId == notification.ProductId
                          && psc.IsListed
                          && psc.SalesChannel != null
                          && psc.SalesChannel.IsEnabled
                          && psc.SalesChannel.ExportProducts)
            .Select(psc => psc.SalesChannelId)
            .Distinct()
            .ToListAsync(cancellationToken);

        if (channelIds.Count == 0)
        {
            return;
        }

        await _enqueuer.EnqueueAsync(
            channelIds,
            ChannelSyncOperation.ExportProduct,
            ChannelOutboxAggregateType.Product,
            notification.ProductId,
            notification.TenantId,
            cancellationToken);
    }

    private async Task HandleDeleteAsync(ProductChangedNotification notification, CancellationToken cancellationToken)
    {
        // The product's channel links were deleted in the same transaction, so the snapshot
        // captured before deletion is the only remaining source of the remote ids.
        var snapshots = notification.DelistSnapshots;
        if (snapshots is null || snapshots.Count == 0)
        {
            return;
        }

        // Only delist where the product was actually listed and the channel still exports products.
        var listedChannelIds = snapshots.Where(s => s.IsListed).Select(s => s.SalesChannelId).Distinct().ToList();
        if (listedChannelIds.Count == 0)
        {
            return;
        }

        var exportableChannelIds = await _context.SalesChannel
            .IgnoreQueryFilters()
            .Where(sc => listedChannelIds.Contains(sc.Id) && sc.IsEnabled && sc.ExportProducts)
            .Select(sc => sc.Id)
            .ToListAsync(cancellationToken);

        if (exportableChannelIds.Count == 0)
        {
            return;
        }

        var exportable = exportableChannelIds.ToHashSet();
        var perChannel = snapshots
            .Where(s => s.IsListed && exportable.Contains(s.SalesChannelId))
            .Select(s => (s.SalesChannelId, JsonSerializer.Serialize(new DelistPayload(
                s.ProductSalesChannelId, s.Sku, s.RemoteProductId, s.ExternalListingId))))
            .ToList();

        await _enqueuer.EnqueueWithPayloadAsync(
            ChannelSyncOperation.DelistProduct,
            ChannelOutboxAggregateType.Product,
            notification.ProductId,
            notification.TenantId,
            perChannel,
            cancellationToken);
    }
}
