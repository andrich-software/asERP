using asERP.Application.Mediator;

namespace asERP.Application.Notifications;

/// <summary>
/// Raised after shop host bindings change (create/update/delete, or the owning channel is
/// deleted). Consumed by the storefront host resolver to invalidate its in-memory host map
/// immediately instead of waiting for the TTL refresh.
/// </summary>
public sealed record ShopDomainChangedNotification(Guid SalesChannelId, Guid? TenantId) : INotification;
