using asToolkit.Domain.Enums;

namespace asToolkit.Shipping.Abstractions;

/// <summary>
/// Single choke point translating normalized carrier tracking states to the domain
/// <see cref="ShippingStatus"/>.
/// </summary>
public static class TrackingStatusMapper
{
    private static readonly ShippingStatus[] TerminalStatuses =
    [
        ShippingStatus.Delivered,
        ShippingStatus.Cancelled,
        ShippingStatus.ReturnedToSender,
        ShippingStatus.Lost
    ];

    /// <summary>
    /// Maps a carrier state to a shipping status. Returns null for <see cref="CarrierTrackingStatus.Unknown"/>
    /// — an unknown carrier state must never change the shipment.
    /// </summary>
    public static ShippingStatus? Map(CarrierTrackingStatus status) => status switch
    {
        CarrierTrackingStatus.PreTransit => ShippingStatus.LabelCreated,
        CarrierTrackingStatus.InTransit => ShippingStatus.InTransit,
        CarrierTrackingStatus.OutForDelivery => ShippingStatus.OutForDelivery,
        CarrierTrackingStatus.Delivered => ShippingStatus.Delivered,
        CarrierTrackingStatus.DeliveryFailed => ShippingStatus.DeliveryFailed,
        CarrierTrackingStatus.ReturnedToSender => ShippingStatus.ReturnedToSender,
        CarrierTrackingStatus.Cancelled => ShippingStatus.Cancelled,
        CarrierTrackingStatus.Lost => ShippingStatus.Lost,
        _ => null
    };

    /// <summary>
    /// True when the incoming status may replace the current one. Never move a shipment out of a
    /// terminal state, and never downgrade below LabelCreated once tracking has started.
    /// </summary>
    public static bool IsUpgrade(ShippingStatus current, ShippingStatus incoming)
    {
        if (current == incoming)
        {
            return false;
        }

        if (TerminalStatuses.Contains(current))
        {
            return false;
        }

        // Once the parcel moved past label creation, a stale "pre-transit" event must not reset it.
        if (incoming == ShippingStatus.LabelCreated && current != ShippingStatus.Open)
        {
            return false;
        }

        return true;
    }
}
