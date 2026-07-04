using asERP.Domain.Enums;

namespace asERP.Client.Features.Shippings.Models;

/// <summary>Status gating for order/shipment actions — pure logic, unit-tested.</summary>
public static class SalesShipmentRules
{
    /// <summary>An order can receive a (further) shipment while it still has open items.</summary>
    public static bool CanShip(SalesStatus status) => status is SalesStatus.Pending
        or SalesStatus.Processing
        or SalesStatus.ReadyForDelivery
        or SalesStatus.PartiallyDelivered;

    /// <summary>An order can be cancelled until anything physically shipped (server re-checks parcels).</summary>
    public static bool CanCancel(SalesStatus status) => status is SalesStatus.Pending
        or SalesStatus.Processing
        or SalesStatus.ReadyForDelivery
        or SalesStatus.OnHold;

    /// <summary>A shipment can be cancelled until it reaches a terminal state.</summary>
    public static bool CanCancelShipment(ShippingStatus status) => status is not (ShippingStatus.Delivered
        or ShippingStatus.Cancelled
        or ShippingStatus.ReturnedToSender
        or ShippingStatus.Lost);
}
