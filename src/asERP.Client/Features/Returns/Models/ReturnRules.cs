using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;

namespace asERP.Client.Features.Returns.Models;

/// <summary>Status gating for return actions — pure logic, unit-testable.</summary>
public static class ReturnRules
{
    /// <summary>Statuses of the outbound parcel that count as "physically shipped".</summary>
    private static readonly ShippingStatus[] ShippedStatuses =
    [
        ShippingStatus.Shipped,
        ShippingStatus.InTransit,
        ShippingStatus.OutForDelivery,
        ShippingStatus.Delivered,
        ShippingStatus.DeliveryFailed,
        ShippingStatus.ReturnedToSender,
        ShippingStatus.Lost
    ];

    /// <summary>
    /// A return can be created when at least one parcel has physically shipped and the order
    /// is not cancelled (the server re-checks quantities per line).
    /// </summary>
    public static bool CanCreateReturn(SalesDetailDto sales) =>
        sales.Status != SalesStatus.Cancelled
        && sales.Shippings.Any(s => s.ShippedAt != null || ShippedStatuses.Contains(s.Status));

    /// <summary>Goods receipt can be recorded until the return reaches a post-receipt state.</summary>
    public static bool CanReceive(ReturnShipmentStatus status) => status is ReturnShipmentStatus.Requested
        or ReturnShipmentStatus.LabelCreated
        or ReturnShipmentStatus.InTransit;

    /// <summary>A return can be cancelled until the goods are received.</summary>
    public static bool CanCancelReturn(ReturnShipmentStatus status) => status is ReturnShipmentStatus.Requested
        or ReturnShipmentStatus.LabelCreated
        or ReturnShipmentStatus.InTransit;
}
