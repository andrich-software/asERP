namespace asERP.Domain.Enums;

/// <summary>
/// Condition of a returned item, recorded at goods receipt. Informational in v1 —
/// restocking happens in the sales channel (WooCommerce is the stock master).
/// </summary>
public enum ReturnItemCondition
{
    Unknown = 0,
    Resalable = 1,
    Damaged = 2,
    Defective = 3,
    Incomplete = 4,
    Disposed = 5
}
