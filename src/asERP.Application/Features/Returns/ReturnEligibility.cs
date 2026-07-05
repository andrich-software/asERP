using asERP.Domain.Enums;

namespace asERP.Application.Features.Returns;

/// <summary>
/// Shared "has this parcel physically shipped" predicate — the same set the sales-cancel
/// guard uses. Only lines from physically shipped parcels are returnable.
/// </summary>
public static class ReturnEligibility
{
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

    public static bool IsPhysicallyShipped(Domain.Entities.Shipping shipping)
        => shipping.ShippedAt != null || ShippedStatuses.Contains(shipping.Status);
}
