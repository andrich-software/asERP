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
/// Sales changes only propagate back to the originating channel — we don't broadcast an sales
/// to other marketplaces. Confirms shipment/status updates via <c>UpdateSales</c>; a cancelled
/// order is routed to the dedicated <c>CancelSales</c> export instead (opt-in per channel via
/// <c>PushSalesCancellations</c>) and never to the generic update — connectors interpret
/// <c>UpdateSales</c> as "confirm progress" (eBay: shipment confirmation), which must not fire
/// for an order that just got cancelled.
/// </summary>
public sealed class SalesChangedNotificationHandler : INotificationHandler<SalesChangedNotification>
{
    private readonly ApplicationDbContext _context;
    private readonly ChannelExportOutboxEnqueuer _enqueuer;
    private readonly ISalesChannelConnectorRegistry _connectorRegistry;
    private readonly ILogger<SalesChangedNotificationHandler> _logger;

    public SalesChangedNotificationHandler(
        ApplicationDbContext context,
        ChannelExportOutboxEnqueuer enqueuer,
        ISalesChannelConnectorRegistry connectorRegistry,
        ILogger<SalesChangedNotificationHandler> logger)
    {
        _context = context;
        _enqueuer = enqueuer;
        _connectorRegistry = connectorRegistry;
        _logger = logger;
    }

    public async Task Handle(SalesChangedNotification notification, CancellationToken cancellationToken)
    {
        var sales = await _context.Sales
            .IgnoreQueryFilters()
            .Where(o => o.Id == notification.SalesId)
            .Select(o => new { o.SalesChannelId, o.RemoteSalesId, o.Status })
            .FirstOrDefaultAsync(cancellationToken);

        if (sales is null)
        {
            return;
        }

        var channel = await _context.SalesChannel
            .IgnoreQueryFilters()
            .Where(s => s.Id == sales.SalesChannelId)
            .Select(s => new { s.Type, s.IsEnabled, s.ExportSaless, s.PushSalesCancellations })
            .FirstOrDefaultAsync(cancellationToken);

        if (channel is null || !channel.IsEnabled)
        {
            return;
        }

        if (sales.Status == SalesStatus.Cancelled)
        {
            // Order cancel and the per-shipment cancels it triggers all fire this notification for
            // the same sales id — the enqueuer's idempotency key coalesces them into one row.
            if (!channel.PushSalesCancellations || string.IsNullOrEmpty(sales.RemoteSalesId))
            {
                return;
            }

            var connector = _connectorRegistry.Resolve(channel.Type);
            if (connector is null || !connector.Capabilities.HasFlag(SalesChannelCapabilities.CancelSaless))
            {
                _logger.LogInformation(
                    "Cancellation push for sales {SalesId} skipped: {ChannelType} does not support CancelSales",
                    notification.SalesId, channel.Type);
                return;
            }

            await _enqueuer.EnqueueAsync(
                new[] { sales.SalesChannelId },
                ChannelSyncOperation.CancelSales,
                ChannelOutboxAggregateType.Sales,
                notification.SalesId,
                notification.TenantId,
                cancellationToken);
            return;
        }

        if (!channel.ExportSaless)
        {
            return;
        }

        await _enqueuer.EnqueueAsync(
            new[] { sales.SalesChannelId },
            ChannelSyncOperation.UpdateSales,
            ChannelOutboxAggregateType.Sales,
            notification.SalesId,
            notification.TenantId,
            cancellationToken);
    }
}
