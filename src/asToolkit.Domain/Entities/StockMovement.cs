using asToolkit.Domain.Entities.Common;
using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Entities;

/// <summary>
/// Append-only stock ledger entry. Every change to <see cref="ProductStock"/> goes through a movement so
/// (a) order-driven decrements are exactly-once — the unique <c>(SalesItemId, Type)</c> index makes a
/// re-imported order a no-op instead of a double booking, (b) the mirror against the master shop stays
/// auditable, and (c) a crash between ledger insert and balance update cannot lose bookings (both commit
/// in one transaction).
/// </summary>
public class StockMovement : BaseEntity, IBaseEntity
{
    public Guid ProductId { get; set; }
    public Guid WarehouseId { get; set; }

    /// <summary>Signed quantity: negative for a sale, positive for a compensation/receipt.</summary>
    public double QuantityDelta { get; set; }

    public StockMovementType Type { get; set; }

    /// <summary>
    /// The order line that caused this movement (sale imports / POS sales / cancellations). Combined
    /// with <see cref="Type"/> in a unique index for idempotency; null for mirror/manual movements.
    /// </summary>
    public Guid? SalesItemId { get; set; }

    /// <summary>Channel the triggering order came from (null for mirror/manual movements).</summary>
    public Guid? SalesChannelId { get; set; }

    public string? Note { get; set; }
}
