using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.NotificationHandlers;

/// <summary>
/// Books stock-ledger movements for point-of-sale sales. POS sales are created through the regular
/// Sales API (not the channel importers, which book inline), so this hooks the post-SaveChanges
/// <see cref="SalesChangedNotification"/> instead. Only PointOfSale channels are handled here — imported
/// channels book in <c>SalesImportRepository</c>, and the stock-master shop never books at all.
/// Movements are idempotent per (SalesItemId, Type), so replayed notifications are no-ops.
/// </summary>
public sealed class PosSaleStockNotificationHandler : INotificationHandler<SalesChangedNotification>
{
    private readonly ApplicationDbContext _context;
    private readonly IStockLedgerService _stockLedger;
    private readonly ILogger<PosSaleStockNotificationHandler> _logger;

    public PosSaleStockNotificationHandler(
        ApplicationDbContext context,
        IStockLedgerService stockLedger,
        ILogger<PosSaleStockNotificationHandler> logger)
    {
        _context = context;
        _stockLedger = stockLedger;
        _logger = logger;
    }

    public async Task Handle(SalesChangedNotification notification, CancellationToken cancellationToken)
    {
        if (notification.Kind is not (SalesChangeKind.Created or SalesChangeKind.Cancelled or SalesChangeKind.Refunded))
        {
            return;
        }

        var sale = await _context.Sales
            .IgnoreQueryFilters()
            .Where(s => s.Id == notification.SalesId)
            .Select(s => new { s.Id, s.SalesChannelId, s.Status, s.TenantId })
            .FirstOrDefaultAsync(cancellationToken);

        if (sale is null)
        {
            return;
        }

        var channel = await _context.SalesChannel
            .IgnoreQueryFilters()
            .Where(c => c.Id == sale.SalesChannelId && c.Type == SalesChannelType.PointOfSale && !c.ImportStock)
            .Select(c => new { c.Id, c.TenantId })
            .FirstOrDefaultAsync(cancellationToken);

        if (channel is null)
        {
            return;
        }

        var warehouseId = await _context.SalesChannel
            .IgnoreQueryFilters()
            .Where(c => c.Id == channel.Id)
            .SelectMany(c => c.Warehouses)
            .Select(w => (Guid?)w.Id)
            .FirstOrDefaultAsync(cancellationToken) ?? Guid.Empty;

        if (warehouseId == Guid.Empty)
        {
            _logger.LogDebug("POS channel {Channel} has no linked warehouse — stock booking skipped", channel.Id);
            return;
        }

        var items = await _context.SalesItem
            .IgnoreQueryFilters()
            .Where(i => i.SalesId == sale.Id && i.ProductId != Guid.Empty && i.Quantity != 0)
            .Select(i => new { i.Id, i.ProductId, i.Quantity })
            .ToListAsync(cancellationToken);

        var cancel = notification.Kind is SalesChangeKind.Cancelled or SalesChangeKind.Refunded;
        foreach (var item in items)
        {
            if (cancel)
            {
                // Compensate only lines whose decrement was actually booked.
                var booked = await _context.StockMovement
                    .IgnoreQueryFilters()
                    .AnyAsync(m => m.SalesItemId == item.Id && m.Type == StockMovementType.PosSale, cancellationToken);
                if (!booked)
                {
                    continue;
                }
            }

            await _stockLedger.ApplyMovementAsync(new StockMovementRequest(
                item.ProductId,
                warehouseId,
                cancel ? item.Quantity : -item.Quantity,
                cancel ? StockMovementType.SaleCancelled : StockMovementType.PosSale,
                SalesItemId: item.Id,
                SalesChannelId: channel.Id,
                TenantId: sale.TenantId ?? channel.TenantId), cancellationToken);
        }
    }
}
