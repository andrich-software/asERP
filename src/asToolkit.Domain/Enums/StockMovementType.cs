namespace asToolkit.Domain.Enums;

/// <summary>
/// Why a <c>StockMovement</c> was booked. asToolkit mirrors the master shop's stock (WooCommerce stays
/// the leading system) and forwards sales from other channels — the type records which flow produced
/// each ledger entry.
/// </summary>
public enum StockMovementType
{
    /// <summary>First full stock mirror from the master shop into an empty warehouse.</summary>
    InitialSeed = 1,

    /// <summary>Scheduled/webhook-triggered re-mirror from the master shop (delta between mirror and shop).</summary>
    MirrorCorrection = 2,

    /// <summary>An imported order line from a sales channel decremented the mirror.</summary>
    SaleImport = 10,

    /// <summary>Compensation for a cancelled/refunded order line (positive delta).</summary>
    SaleCancelled = 11,

    /// <summary>A POS sale decremented the mirror.</summary>
    PosSale = 12,

    /// <summary>Manual stock correction by a user.</summary>
    ManualCorrection = 20,
}
