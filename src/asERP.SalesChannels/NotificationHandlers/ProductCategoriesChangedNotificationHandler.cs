using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Orchestration;
using Microsoft.EntityFrameworkCore;

namespace asERP.SalesChannels.NotificationHandlers;

/// <summary>
/// A product's category assignments changed — push the new assignment set to every channel that
/// knows the product (has a remote id) and exports categories. Connectors without the
/// <c>UpdateProductCategories</c> capability are filtered by the enqueuer/dispatcher.
/// </summary>
public sealed class ProductCategoriesChangedNotificationHandler
    : INotificationHandler<ProductCategoriesChangedNotification>
{
    private readonly ApplicationDbContext _context;
    private readonly ChannelExportOutboxEnqueuer _enqueuer;

    public ProductCategoriesChangedNotificationHandler(
        ApplicationDbContext context,
        ChannelExportOutboxEnqueuer enqueuer)
    {
        _context = context;
        _enqueuer = enqueuer;
    }

    public async Task Handle(ProductCategoriesChangedNotification notification, CancellationToken cancellationToken)
    {
        var channelIds = await _context.ProductSalesChannel
            .IgnoreQueryFilters()
            .Where(psc => psc.ProductId == notification.ProductId
                          && psc.RemoteProductId != null
                          && psc.SalesChannel != null
                          && psc.SalesChannel.IsEnabled
                          && psc.SalesChannel.ExportCategories)
            .Select(psc => psc.SalesChannelId)
            .Distinct()
            .ToListAsync(cancellationToken);

        if (channelIds.Count == 0)
        {
            return;
        }

        await _enqueuer.EnqueueAsync(
            channelIds,
            ChannelSyncOperation.UpdateProductCategories,
            ChannelOutboxAggregateType.Product,
            notification.ProductId,
            notification.TenantId,
            cancellationToken);
    }
}
