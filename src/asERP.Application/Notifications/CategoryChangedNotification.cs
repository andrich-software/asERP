using asERP.Application.Mediator;

namespace asERP.Application.Notifications;

/// <summary>
/// Raised when a Category is created, updated or deleted. Handlers fan this out to all
/// SalesChannels where the category is active and <c>ExportCategories=true</c> via the export outbox.
///
/// On <see cref="CategoryChangeKind.Deleted"/> the category's channel links are gone by the time
/// the handler runs, so <see cref="DeleteSnapshots"/> carries the per-channel remote ids captured
/// before deletion — without them a deleted category could never be removed remotely.
/// </summary>
public sealed record CategoryChangedNotification(
    Guid CategoryId,
    Guid? TenantId,
    CategoryChangeKind Kind,
    IReadOnlyList<CategoryDeleteSnapshot>? DeleteSnapshots = null) : INotification;

/// <summary>
/// Per-channel snapshot of a deleted category's link, captured before the rows are removed so
/// the remote delete can still address the channel-side category.
/// </summary>
public sealed record CategoryDeleteSnapshot(
    Guid SalesChannelId,
    Guid CategorySalesChannelId,
    string? RemoteCategoryId,
    bool IsActive);

public enum CategoryChangeKind
{
    Created = 0,
    Updated = 1,
    Deleted = 2,
}
