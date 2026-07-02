using asToolkit.Domain.Enums;

namespace asToolkit.Application.Contracts.Services;

/// <summary>
/// One movement to book against the stock ledger. <see cref="SalesItemId"/> + <see cref="Type"/> form
/// the idempotency key for order-driven movements (unique index) — re-applying the same request is a
/// silent no-op, which keeps idempotent order re-imports from double-decrementing.
/// </summary>
public sealed record StockMovementRequest(
    Guid ProductId,
    Guid WarehouseId,
    double QuantityDelta,
    StockMovementType Type,
    Guid? SalesItemId = null,
    Guid? SalesChannelId = null,
    Guid? TenantId = null,
    string? Note = null);

/// <summary>
/// Books stock movements and keeps the <c>ProductStock</c> balance in sync — the single write path for
/// stock in the shop-mirror model (the master shop stays the leading system; asToolkit mirrors its stock
/// and forwards other channels' sales). Implementations publish <c>StockChangedNotification</c> after a
/// successful booking so the export outbox pushes the new level to the other channels.
/// </summary>
public interface IStockLedgerService
{
    /// <summary>
    /// Applies a relative movement (sale, cancellation, POS sale, manual correction).
    /// Returns false when the movement was already booked (idempotent skip).
    /// </summary>
    Task<bool> ApplyMovementAsync(StockMovementRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Sets the absolute stock level for a product/warehouse (mirror sync from the master shop),
    /// booking the delta as a movement of the given type. Returns false when the level was already
    /// up to date (no movement booked, no notification raised).
    /// </summary>
    Task<bool> SetAbsoluteStockAsync(
        Guid productId,
        Guid warehouseId,
        double absoluteQuantity,
        StockMovementType type,
        Guid? tenantId,
        CancellationToken cancellationToken,
        string? note = null);
}
