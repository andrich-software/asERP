using asERP.Application.Mediator;

namespace asERP.Application.Notifications;

/// <summary>
/// Raised when a Product is created or updated. Notification handlers fan this out to all
/// SalesChannels with <c>ExportProducts=true</c> via the export outbox.
///
/// On <see cref="ProductChangeKind.Deleted"/> the product's sales-channel links are gone by the
/// time the handler runs, so <see cref="DelistSnapshots"/> carries the per-channel remote ids
/// captured before deletion — without them a deleted product could never be delisted remotely.
/// </summary>
public sealed record ProductChangedNotification(
    Guid ProductId,
    Guid? TenantId,
    ProductChangeKind Kind,
    IReadOnlyList<ProductDelistSnapshot>? DelistSnapshots = null) : INotification;

/// <summary>
/// Per-channel snapshot of a deleted product's listing, captured before the rows are removed so
/// the delist can still address the remote item.
/// </summary>
public sealed record ProductDelistSnapshot(
    Guid SalesChannelId,
    Guid ProductSalesChannelId,
    string Sku,
    string? RemoteProductId,
    string? ExternalListingId,
    bool IsListed);

public enum ProductChangeKind
{
    Created = 0,
    Updated = 1,
    Deleted = 2,
}
