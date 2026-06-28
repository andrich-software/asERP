using asToolkit.Application.Mediator;

namespace asToolkit.Application.Notifications;

/// <summary>
/// Raised when a per-channel listing-config row changes (Price, Min/Max, IsListed, MetadataJson).
/// Triggers re-export of that single (Product × SalesChannel) tuple.
/// </summary>
public sealed record ProductSalesChannelChangedNotification(
    Guid ProductSalesChannelId,
    Guid ProductId,
    Guid SalesChannelId,
    Guid? TenantId) : INotification;
