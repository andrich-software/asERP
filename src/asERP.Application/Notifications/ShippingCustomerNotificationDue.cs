using asERP.Application.Mediator;

namespace asERP.Application.Notifications;

/// <summary>
/// Raised by <c>ShippingStatusUpdater</c> exactly once per shipment and kind — when the
/// idempotency stamp (<c>Shipping.CustomerNotifiedAt</c> / <c>CustomerDeliveryNotifiedAt</c>)
/// was written in the same save as the status change. Whether an email actually goes out is
/// decided by the handler (tenant opt-in, customer email present).
/// </summary>
public sealed record ShippingCustomerNotificationDue(
    Guid ShippingId,
    Guid SalesId,
    Guid? TenantId,
    ShippingCustomerNotificationKind Kind) : INotification;

public enum ShippingCustomerNotificationKind
{
    Shipped = 1,
    Delivered = 2,
}
