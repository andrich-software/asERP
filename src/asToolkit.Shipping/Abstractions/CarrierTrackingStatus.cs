namespace asToolkit.Shipping.Abstractions;

/// <summary>
/// Carrier-neutral tracking state. Each connector maps its carrier's status vocabulary to this
/// enum; <see cref="TrackingStatusMapper"/> is the single place that translates it to the
/// domain's <c>ShippingStatus</c>.
/// </summary>
public enum CarrierTrackingStatus
{
    Unknown = 0,
    PreTransit = 1,
    InTransit = 2,
    OutForDelivery = 3,
    Delivered = 4,
    DeliveryFailed = 5,
    ReturnedToSender = 6,
    Cancelled = 7,
    Lost = 8
}
