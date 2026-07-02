using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Mediator;
using asToolkit.Application.Notifications;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asToolkit.Persistence.Services;

/// <summary>
/// Ledger-backed stock writes: every balance change books an append-only <see cref="StockMovement"/> and
/// adjusts <c>ProductStock</c> in the same transaction. The balance update is an atomic in-database
/// increment (<c>SET Stock = Stock + delta</c>), so concurrent imports from several channels never lose
/// an update; order-driven movements are exactly-once via the unique <c>(SalesItemId, Type)</c> index.
/// After a successful booking a <see cref="StockChangedNotification"/> is published explicitly — the
/// SaveChanges interceptor cannot see <c>ExecuteUpdate</c> writes. Duplicate notifications from the
/// tracked fallback path are harmless: the outbox enqueuer coalesces by idempotency key.
/// </summary>
public sealed class StockLedgerService : IStockLedgerService
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;
    private readonly ILogger<StockLedgerService> _logger;

    public StockLedgerService(ApplicationDbContext context, IMediator mediator, ILogger<StockLedgerService> logger)
    {
        _context = context;
        _mediator = mediator;
        _logger = logger;
    }

    public async Task<bool> ApplyMovementAsync(StockMovementRequest request, CancellationToken cancellationToken)
    {
        if (request.QuantityDelta == 0)
        {
            return false;
        }

        // Idempotency pre-check (the unique index is the backstop for the race window). Only movements
        // tied to an order line are deduplicated; mirror/manual movements may repeat.
        if (request.SalesItemId is { } salesItemId
            && await _context.StockMovement.AnyAsync(
                m => m.SalesItemId == salesItemId && m.Type == request.Type, cancellationToken))
        {
            return false;
        }

        var applied = await ExecuteBookingAsync(
            request.ProductId,
            request.WarehouseId,
            request.QuantityDelta,
            absolute: null,
            request,
            cancellationToken);

        if (applied)
        {
            await PublishStockChangedAsync(request.ProductId, request.WarehouseId, request.TenantId, cancellationToken);
        }

        return applied;
    }

    public async Task<bool> SetAbsoluteStockAsync(
        Guid productId,
        Guid warehouseId,
        double absoluteQuantity,
        StockMovementType type,
        Guid? tenantId,
        CancellationToken cancellationToken,
        string? note = null)
    {
        var current = await _context.ProductStock
            .Where(ps => ps.ProductId == productId && ps.WarehouseId == warehouseId)
            .Select(ps => (double?)ps.Stock)
            .FirstOrDefaultAsync(cancellationToken);

        var delta = absoluteQuantity - (current ?? 0);
        if (Math.Abs(delta) < 0.000001 && current is not null)
        {
            return false;
        }

        // NOTE: a sale imported between this read and the write below is momentarily overwritten by the
        // absolute value — self-healing, because that sale was also forwarded to the master shop and the
        // next mirror sync reflects it.
        var request = new StockMovementRequest(productId, warehouseId, delta, type, TenantId: tenantId, Note: note);
        var applied = await ExecuteBookingAsync(productId, warehouseId, delta, absoluteQuantity, request, cancellationToken);

        if (applied)
        {
            await PublishStockChangedAsync(productId, warehouseId, tenantId, cancellationToken);
        }

        return applied;
    }

    /// <summary>
    /// Books the movement row and adjusts the balance in one transaction. <paramref name="absolute"/>
    /// null → relative increment; set → the balance is pinned to that value (mirror sync).
    /// </summary>
    private async Task<bool> ExecuteBookingAsync(
        Guid productId,
        Guid warehouseId,
        double delta,
        double? absolute,
        StockMovementRequest request,
        CancellationToken cancellationToken)
    {
        // The InMemory test provider supports neither transactions nor ExecuteUpdate; fall back to
        // tracked writes there. All real providers (MSSQL/PostgreSQL/SQLite) take the atomic path.
        var relational = _context.Database.IsRelational();

        await using var transaction = relational
            ? await _context.Database.BeginTransactionAsync(cancellationToken)
            : null;

        var movement = new StockMovement
        {
            Id = Guid.NewGuid(),
            TenantId = request.TenantId,
            ProductId = productId,
            WarehouseId = warehouseId,
            QuantityDelta = delta,
            Type = request.Type,
            SalesItemId = request.SalesItemId,
            SalesChannelId = request.SalesChannelId,
            Note = request.Note,
        };
        _context.StockMovement.Add(movement);

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            // Unique (SalesItemId, Type) violation: another run booked this movement first. Roll back
            // and report "already applied" instead of failing the whole order import.
            _context.Entry(movement).State = EntityState.Detached;
            if (transaction is not null)
            {
                await transaction.RollbackAsync(CancellationToken.None);
            }

            if (request.SalesItemId is not null)
            {
                _logger.LogDebug(ex, "Stock movement for sales item {SalesItemId}/{Type} already booked", request.SalesItemId, request.Type);
                return false;
            }

            throw;
        }

        if (relational)
        {
            var affected = absolute is { } abs
                ? await _context.ProductStock
                    .Where(ps => ps.ProductId == productId && ps.WarehouseId == warehouseId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(ps => ps.Stock, abs)
                        .SetProperty(ps => ps.DateModified, DateTime.UtcNow), cancellationToken)
                : await _context.ProductStock
                    .Where(ps => ps.ProductId == productId && ps.WarehouseId == warehouseId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(ps => ps.Stock, ps => ps.Stock + delta)
                        .SetProperty(ps => ps.DateModified, DateTime.UtcNow), cancellationToken);

            if (affected == 0)
            {
                await InsertBalanceRowAsync(productId, warehouseId, absolute ?? delta, request.TenantId, cancellationToken);
            }
        }
        else
        {
            var stockRow = await _context.ProductStock
                .FirstOrDefaultAsync(ps => ps.ProductId == productId && ps.WarehouseId == warehouseId, cancellationToken);

            if (stockRow is null)
            {
                await InsertBalanceRowAsync(productId, warehouseId, absolute ?? delta, request.TenantId, cancellationToken);
            }
            else
            {
                stockRow.Stock = absolute ?? stockRow.Stock + delta;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        if (transaction is not null)
        {
            await transaction.CommitAsync(cancellationToken);
        }

        return true;
    }

    /// <summary>
    /// First booking for this product/warehouse: create the balance row. A negative starting balance is
    /// deliberate — it makes "sold without a mirrored stock level" visible instead of silently clamping.
    /// </summary>
    private async Task InsertBalanceRowAsync(Guid productId, Guid warehouseId, double stock, Guid? tenantId, CancellationToken cancellationToken)
    {
        _context.ProductStock.Add(new ProductStock
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            ProductId = productId,
            WarehouseId = warehouseId,
            Stock = stock,
        });
        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task PublishStockChangedAsync(Guid productId, Guid warehouseId, Guid? tenantId, CancellationToken cancellationToken)
    {
        try
        {
            await _mediator.Publish(new StockChangedNotification(productId, warehouseId, tenantId), cancellationToken);
        }
        catch (Exception ex)
        {
            // The booking itself is committed; a failed export enqueue must not fail the order import.
            // The next mirror sync / stock change re-triggers the export.
            _logger.LogError(ex, "StockChangedNotification failed for product {ProductId}", productId);
        }
    }
}
