namespace asERP.Domain.Enums;

/// <summary>
/// Lifecycle of a customer return (RMA). Terminal: <see cref="Completed"/>,
/// <see cref="Rejected"/>, <see cref="Cancelled"/>.
/// </summary>
public enum ReturnShipmentStatus
{
    /// <summary>Return announced; no label yet, goods not received.</summary>
    Requested = 1,

    /// <summary>Carrier return label purchased; goods not yet received.</summary>
    LabelCreated = 2,

    /// <summary>Parcel is on its way back (manually set in v1 — returns are not tracking-polled).</summary>
    InTransit = 3,

    /// <summary>Goods physically received; per-item condition recorded.</summary>
    Received = 4,

    /// <summary>Return processed and closed. Terminal.</summary>
    Completed = 5,

    /// <summary>Return refused after inspection. Terminal.</summary>
    Rejected = 6,

    /// <summary>Return withdrawn before receipt. Terminal.</summary>
    Cancelled = 7
}
