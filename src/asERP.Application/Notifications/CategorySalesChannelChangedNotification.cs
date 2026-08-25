using asERP.Application.Mediator;

namespace asERP.Application.Notifications;

/// <summary>
/// Raised when a per-channel category activation row changes (IsActive toggled, row created).
/// Triggers export or remote delete of that single (Category × SalesChannel) tuple.
/// </summary>
public sealed record CategorySalesChannelChangedNotification(
    Guid CategorySalesChannelId,
    Guid CategoryId,
    Guid SalesChannelId,
    Guid? TenantId) : INotification;
