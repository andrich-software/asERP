using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Orchestration;
using Microsoft.EntityFrameworkCore;

namespace asERP.SalesChannels.NotificationHandlers;

/// <summary>
/// Per-channel category activation changed (checkbox toggled in the matrix, or a row created by
/// import/expansion). Active rows are (re-)exported, deactivated rows are deleted remotely —
/// single channel only, no fan-out. A row deleted together with its category is handled by the
/// snapshot path in <see cref="CategoryChangedNotificationHandler"/>.
/// </summary>
public sealed class CategorySalesChannelChangedNotificationHandler
    : INotificationHandler<CategorySalesChannelChangedNotification>
{
    private readonly ApplicationDbContext _context;
    private readonly ChannelExportOutboxEnqueuer _enqueuer;

    public CategorySalesChannelChangedNotificationHandler(
        ApplicationDbContext context,
        ChannelExportOutboxEnqueuer enqueuer)
    {
        _context = context;
        _enqueuer = enqueuer;
    }

    public async Task Handle(CategorySalesChannelChangedNotification notification, CancellationToken cancellationToken)
    {
        var link = await _context.CategorySalesChannel
            .IgnoreQueryFilters()
            .Include(l => l.SalesChannel)
            .FirstOrDefaultAsync(l => l.Id == notification.CategorySalesChannelId, cancellationToken);

        if (link?.SalesChannel is null || !link.SalesChannel.IsEnabled || !link.SalesChannel.ExportCategories)
        {
            return;
        }

        var operation = link.IsActive
            ? ChannelSyncOperation.ExportCategory
            : ChannelSyncOperation.DeleteCategory;

        await _enqueuer.EnqueueAsync(
            new[] { notification.SalesChannelId },
            operation,
            ChannelOutboxAggregateType.Category,
            notification.CategoryId,
            notification.TenantId,
            cancellationToken);
    }
}
