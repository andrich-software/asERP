using asERP.Application.Mediator;

namespace asERP.Application.Notifications;

/// <summary>
/// Raised whenever a shipment of an order is created or changed. Routes to the <c>PushShipment</c>
/// export on channels running in <c>ShipmentTrackingMode.Push</c>.
/// <para>
/// Carries the order id rather than the shipment id: the push writes the order's complete set of
/// tracking numbers in one call (a shop order has one tracking field, not one per parcel), so the
/// outbox coalesces several shipments of the same order into a single export row.
/// </para>
/// </summary>
public sealed record ShipmentTrackingChangedNotification(Guid SalesId, Guid? TenantId) : INotification;
