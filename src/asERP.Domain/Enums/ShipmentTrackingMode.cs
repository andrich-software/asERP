namespace asERP.Domain.Enums;

/// <summary>
/// How a sales channel exchanges shipment tracking numbers with the shop. Deliberately an enum
/// and not two booleans: import and push are mutually exclusive by nature. With both enabled an
/// imported tracking number would immediately be pushed back to the shop it just came from, and
/// the resulting write would be re-imported on the next run — a feedback loop the type system
/// now rules out.
/// </summary>
public enum ShipmentTrackingMode
{
    /// <summary>No tracking exchange at all (default).</summary>
    None = 0,

    /// <summary>The shop is the source of truth: tracking numbers are pulled into asERP shipments.</summary>
    Import = 1,

    /// <summary>asERP is the source of truth: locally created tracking numbers are pushed to the shop.</summary>
    Push = 2,
}
