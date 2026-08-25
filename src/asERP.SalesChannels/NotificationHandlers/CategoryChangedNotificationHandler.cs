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
/// On Category create/update, enqueue an <c>ExportCategory</c> outbox row for every channel where
/// the category is active (CSC.IsActive=true) AND the channel exports categories AND IsEnabled.
/// Deletion routes to <c>DeleteCategory</c> on every previously-linked channel; the channel links
/// are already gone, so the delete payload is taken from the notification's pre-delete snapshot.
/// </summary>
public sealed class CategoryChangedNotificationHandler : INotificationHandler<CategoryChangedNotification>
{
    private readonly ApplicationDbContext _context;
    private readonly ChannelExportOutboxEnqueuer _enqueuer;

    public CategoryChangedNotificationHandler(ApplicationDbContext context, ChannelExportOutboxEnqueuer enqueuer)
    {
        _context = context;
        _enqueuer = enqueuer;
    }

    public async Task Handle(CategoryChangedNotification notification, CancellationToken cancellationToken)
    {
        if (notification.Kind == CategoryChangeKind.Deleted)
        {
            await HandleDeleteAsync(notification, cancellationToken);
            return;
        }

        var channelIds = await _context.CategorySalesChannel
            .IgnoreQueryFilters()
            .Where(csc => csc.CategoryId == notification.CategoryId
                          && csc.IsActive
                          && csc.SalesChannel != null
                          && csc.SalesChannel.IsEnabled
                          && csc.SalesChannel.ExportCategories)
            .Select(csc => csc.SalesChannelId)
            .Distinct()
            .ToListAsync(cancellationToken);

        if (channelIds.Count == 0)
        {
            return;
        }

        await _enqueuer.EnqueueAsync(
            channelIds,
            ChannelSyncOperation.ExportCategory,
            ChannelOutboxAggregateType.Category,
            notification.CategoryId,
            notification.TenantId,
            cancellationToken);
    }

    private async Task HandleDeleteAsync(CategoryChangedNotification notification, CancellationToken cancellationToken)
    {
        // The category's channel links were deleted in the same transaction, so the snapshot
        // captured before deletion is the only remaining source of the remote ids.
        var snapshots = notification.DeleteSnapshots;
        if (snapshots is null || snapshots.Count == 0)
        {
            return;
        }

        // Only channels that actually hold the category remotely need a delete.
        var linkedChannelIds = snapshots
            .Where(s => !string.IsNullOrEmpty(s.RemoteCategoryId))
            .Select(s => s.SalesChannelId)
            .Distinct()
            .ToList();
        if (linkedChannelIds.Count == 0)
        {
            return;
        }

        var exportableChannelIds = await _context.SalesChannel
            .IgnoreQueryFilters()
            .Where(sc => linkedChannelIds.Contains(sc.Id) && sc.IsEnabled && sc.ExportCategories)
            .Select(sc => sc.Id)
            .ToListAsync(cancellationToken);

        if (exportableChannelIds.Count == 0)
        {
            return;
        }

        var exportable = exportableChannelIds.ToHashSet();
        var perChannel = snapshots
            .Where(s => !string.IsNullOrEmpty(s.RemoteCategoryId) && exportable.Contains(s.SalesChannelId))
            .Select(s => (s.SalesChannelId, JsonSerializer.Serialize(new CategoryDeletePayload(
                notification.CategoryId, s.SalesChannelId, s.RemoteCategoryId))))
            .ToList();

        await _enqueuer.EnqueueWithPayloadAsync(
            ChannelSyncOperation.DeleteCategory,
            ChannelOutboxAggregateType.Category,
            notification.CategoryId,
            notification.TenantId,
            perChannel,
            cancellationToken);
    }
}
