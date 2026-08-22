using asERP.Application.Mediator;

namespace asERP.Application.Notifications;

/// <summary>
/// Raised when the set of warehouses feeding a channel's stock changes (warehouse added/removed on the
/// channel, or ExportStock switched on). The stock exported to a channel is the sum over its linked
/// warehouses, so such a change silently shifts the effective stock of every listed product — the
/// SalesChannels handler reacts by enqueueing an <c>UpdateStock</c> export for each of them.
/// </summary>
public sealed record SalesChannelStockScopeChangedNotification(Guid SalesChannelId, Guid? TenantId) : INotification;
