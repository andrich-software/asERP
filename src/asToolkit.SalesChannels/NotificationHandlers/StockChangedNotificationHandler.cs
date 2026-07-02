using asToolkit.Application.Mediator;
using asToolkit.Application.Notifications;
using asToolkit.Domain.Enums;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.SalesChannels.Orchestration;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.SalesChannels.NotificationHandlers;

public sealed class StockChangedNotificationHandler : INotificationHandler<StockChangedNotification>
{
    private readonly ApplicationDbContext _context;
    private readonly ChannelExportOutboxEnqueuer _enqueuer;

    public StockChangedNotificationHandler(ApplicationDbContext context, ChannelExportOutboxEnqueuer enqueuer)
    {
        _context = context;
        _enqueuer = enqueuer;
    }

    public async Task Handle(StockChangedNotification notification, CancellationToken cancellationToken)
    {
        // Only push stock to channels that (a) opted into stock pushes (ExportStock — finer than a full
        // product export), (b) are linked to the warehouse where stock changed, AND (c) have the product
        // listed. In the shop-mirror model ALL synced shops set ExportStock=true, including the stock
        // master: pushing the mirror back to the master is how another channel's sale reaches it (the
        // forward path), and echoing the master's own mirrored numbers back is an idempotent no-op.
        var channelIds = await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Where(psc => psc.ProductId == notification.ProductId
                          && psc.IsListed
                          && psc.SalesChannel != null
                          && psc.SalesChannel.IsEnabled
                          && psc.SalesChannel.ExportStock
                          && psc.SalesChannel.Warehouses.Any(w => w.Id == notification.WarehouseId))
            .Select(psc => psc.SalesChannelId)
            .Distinct()
            .ToListAsync(cancellationToken);

        if (channelIds.Count == 0)
        {
            return;
        }

        await _enqueuer.EnqueueAsync(
            channelIds,
            ChannelSyncOperation.UpdateStock,
            ChannelOutboxAggregateType.Stock,
            notification.ProductId,
            notification.TenantId,
            cancellationToken);
    }
}
