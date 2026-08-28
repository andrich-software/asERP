using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Orchestration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.NotificationHandlers;

/// <summary>
/// Pushes locally created tracking numbers back to the originating channel. Runs only for channels
/// in <see cref="ShipmentTrackingMode.Push"/> — a channel importing tracking numbers must never push
/// them back to the shop they came from, which the mutually exclusive mode already guarantees.
/// <para>
/// The outbox key is the ORDER, not the shipment: a shop order carries a single tracking field, so
/// several parcels of one order coalesce into one export row that the dispatcher hydrates with the
/// full set at drain time.
/// </para>
/// </summary>
public sealed class ShipmentTrackingChangedNotificationHandler : INotificationHandler<ShipmentTrackingChangedNotification>
{
    private readonly ApplicationDbContext _context;
    private readonly ChannelExportOutboxEnqueuer _enqueuer;
    private readonly ILogger<ShipmentTrackingChangedNotificationHandler> _logger;

    public ShipmentTrackingChangedNotificationHandler(
        ApplicationDbContext context,
        ChannelExportOutboxEnqueuer enqueuer,
        ILogger<ShipmentTrackingChangedNotificationHandler> logger)
    {
        _context = context;
        _enqueuer = enqueuer;
        _logger = logger;
    }

    public async Task Handle(ShipmentTrackingChangedNotification notification, CancellationToken cancellationToken)
    {
        var sales = await _context.Sales
            .IgnoreQueryFilters()
            .Where(o => o.Id == notification.SalesId)
            .Select(o => new { o.SalesChannelId, o.RemoteSalesId })
            .FirstOrDefaultAsync(cancellationToken);

        if (sales is null || string.IsNullOrEmpty(sales.RemoteSalesId))
        {
            // No remote counterpart (POS sale, or an order that never came from a shop) — nothing to push.
            return;
        }

        var channel = await _context.SalesChannel
            .IgnoreQueryFilters()
            .Where(s => s.Id == sales.SalesChannelId)
            .Select(s => new { s.IsEnabled, s.ShipmentTrackingMode })
            .FirstOrDefaultAsync(cancellationToken);

        if (channel is null || !channel.IsEnabled || channel.ShipmentTrackingMode != ShipmentTrackingMode.Push)
        {
            return;
        }

        await _enqueuer.EnqueueAsync(
            new[] { sales.SalesChannelId },
            ChannelSyncOperation.PushShipment,
            ChannelOutboxAggregateType.Sales,
            notification.SalesId,
            notification.TenantId,
            cancellationToken);

        _logger.LogDebug("Queued shipment tracking push for sales {SalesId}", notification.SalesId);
    }
}
