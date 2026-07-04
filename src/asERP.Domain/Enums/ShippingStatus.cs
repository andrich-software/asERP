namespace asERP.Domain.Enums;

/// <summary>
/// Represents the status of a shipping process.
/// </summary>
public enum ShippingStatus
{
    Open = 1,
    InProgess = 2,
    ReadyForShipping = 3,
    Shipped = 4,
    Delivered = 5,
    Cancelled = 6,

    /// <summary>Carrier label purchased; parcel not yet handed over.</summary>
    LabelCreated = 7,

    /// <summary>Carrier has the parcel and it is moving through the network.</summary>
    InTransit = 8,

    /// <summary>Parcel is on the delivery vehicle for the final leg.</summary>
    OutForDelivery = 9,

    /// <summary>Delivery attempt failed (recipient absent, held at depot, ...). Non-terminal.</summary>
    DeliveryFailed = 10,

    /// <summary>Parcel went back to the sender. Terminal.</summary>
    ReturnedToSender = 11,

    /// <summary>Carrier declared the parcel lost. Terminal, set manually.</summary>
    Lost = 12
}
