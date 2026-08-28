namespace asERP.Domain.Enums;

/// <summary>
/// Predefined quick filters for the sales list, surfaced as filter buttons in the client.
/// </summary>
public enum SalesQuickFilter
{
    /// <summary>No status restriction.</summary>
    All = 0,

    /// <summary>Paid sales with items that are not shipped yet - same set the batch shipping dialog works on.</summary>
    ReadyToShip = 1,

    /// <summary>Newly arrived or in-progress sales.</summary>
    Open = 2,

    /// <summary>Still shippable sales without a completed payment.</summary>
    NotPaid = 3,

    /// <summary>Sales that need manual attention (on hold, failed).</summary>
    Problems = 4,

    /// <summary>Fully processed sales.</summary>
    Completed = 5,

    /// <summary>Cancelled, returned or refunded sales.</summary>
    Cancelled = 6,

    /// <summary>Still shippable sales without a completed payment, ordered 7+ days ago.</summary>
    PaymentOverdue = 7
}
