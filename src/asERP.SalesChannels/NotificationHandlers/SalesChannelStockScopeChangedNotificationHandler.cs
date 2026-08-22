using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Orchestration;
using Microsoft.EntityFrameworkCore;

namespace asERP.SalesChannels.NotificationHandlers;

/// <summary>
/// Reacts to a changed stock scope on a channel (warehouse set changed, or ExportStock switched on):
/// the exported stock is the sum over the channel's linked warehouses, so every listed product's
/// effective stock changed at once. Enqueues one <c>UpdateStock</c> outbox row per listed product —
/// the drainer computes the fresh warehouse sum at dispatch time, and the idempotency key coalesces
/// with any per-product stock pushes already queued.
/// </summary>
public sealed class SalesChannelStockScopeChangedNotificationHandler : INotificationHandler<SalesChannelStockScopeChangedNotification>
{
    private readonly ApplicationDbContext _context;
    private readonly ChannelExportOutboxEnqueuer _enqueuer;

    public SalesChannelStockScopeChangedNotificationHandler(ApplicationDbContext context, ChannelExportOutboxEnqueuer enqueuer)
    {
        _context = context;
        _enqueuer = enqueuer;
    }

    public async Task Handle(SalesChannelStockScopeChangedNotification notification, CancellationToken cancellationToken)
    {
        // Re-check on the current DB state (the publisher's view may be stale by now).
        var channelQualifies = await _context.SalesChannel
            .IgnoreQueryFilters()
            .AnyAsync(sc => sc.Id == notification.SalesChannelId && sc.IsEnabled && sc.ExportStock, cancellationToken);

        if (!channelQualifies)
        {
            return;
        }

        var productIds = await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Where(psc => psc.SalesChannelId == notification.SalesChannelId && psc.IsListed)
            .Select(psc => psc.ProductId)
            .Distinct()
            .ToListAsync(cancellationToken);

        if (productIds.Count == 0)
        {
            return;
        }

        await _enqueuer.EnqueueForAggregatesAsync(
            notification.SalesChannelId,
            ChannelSyncOperation.UpdateStock,
            ChannelOutboxAggregateType.Stock,
            productIds,
            notification.TenantId,
            cancellationToken);
    }
}
