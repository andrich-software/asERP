using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Repositories;

public class StockImportRepository : IStockImportRepository
{
    private readonly ILogger<StockImportRepository> _logger;
    private readonly ApplicationDbContext _dbContext;
    private readonly IStockLedgerService _stockLedger;

    // Per-run caches (scoped lifetime): channel warehouse resolved once; remote-id → product-id lookups
    // repeat across pages, misses (null) are cached too so an unlinked product is only queried once.
    private Guid? _warehouseId;
    private readonly Dictionary<string, Guid?> _productIdByRemoteId = new();

    // Current stock of the whole target warehouse, loaded once per run. A full-catalogue mirror that
    // checked each product through the ledger paid one SELECT + a transaction per product even when
    // nothing changed; with the preload an unchanged product costs a dictionary hit and no DB work.
    private Dictionary<Guid, double>? _currentStockByProduct;

    public StockImportRepository(
        ILogger<StockImportRepository> logger,
        ApplicationDbContext dbContext,
        IStockLedgerService stockLedger)
    {
        _logger = logger;
        _dbContext = dbContext;
        _stockLedger = stockLedger;
    }

    public async Task<StockImportOutcome> ApplyRemoteStockAsync(
        SalesChannel salesChannel,
        string remoteProductId,
        string? sku,
        double quantity,
        CancellationToken cancellationToken)
    {
        var warehouseId = await ResolveWarehouseIdAsync(salesChannel, cancellationToken);
        if (warehouseId == Guid.Empty)
        {
            return StockImportOutcome.NoWarehouse;
        }

        var productId = await ResolveProductIdAsync(salesChannel, remoteProductId, sku, cancellationToken);
        if (productId is null)
        {
            _logger.LogDebug("Stock mirror: remote product {RemoteId} (SKU {Sku}) is not linked locally, skipping", remoteProductId, sku);
            return StockImportOutcome.ProductNotFound;
        }

        var currentStock = await GetCurrentStockAsync(warehouseId, cancellationToken);
        if (currentStock.TryGetValue(productId.Value, out var existing) && Math.Abs(existing - quantity) < 1e-6)
        {
            return StockImportOutcome.Unchanged;
        }

        var changed = await _stockLedger.SetAbsoluteStockAsync(
            productId.Value,
            warehouseId,
            quantity,
            StockMovementType.MirrorCorrection,
            salesChannel.TenantId,
            cancellationToken,
            note: $"Mirror from {salesChannel.Name}");

        // Keep the preload coherent for repeated rows within this run.
        currentStock[productId.Value] = quantity;

        return changed ? StockImportOutcome.Applied : StockImportOutcome.Unchanged;
    }

    private async Task<Dictionary<Guid, double>> GetCurrentStockAsync(Guid warehouseId, CancellationToken cancellationToken)
    {
        if (_currentStockByProduct is not null)
        {
            return _currentStockByProduct;
        }

        _currentStockByProduct = await _dbContext.ProductStock
            .Where(ps => ps.WarehouseId == warehouseId)
            .ToDictionaryAsync(ps => ps.ProductId, ps => ps.Stock, cancellationToken);
        return _currentStockByProduct;
    }

    private async Task<Guid> ResolveWarehouseIdAsync(SalesChannel salesChannel, CancellationToken cancellationToken)
    {
        if (_warehouseId is { } cached)
        {
            return cached;
        }

        var warehouseId = await _dbContext.SalesChannel
            .IgnoreQueryFilters()
            .Where(s => s.Id == salesChannel.Id)
            .SelectMany(s => s.Warehouses)
            .Select(w => (Guid?)w.Id)
            .FirstOrDefaultAsync(cancellationToken) ?? Guid.Empty;

        if (warehouseId == Guid.Empty)
        {
            _logger.LogWarning("Stock mirror: channel {Channel} has no linked warehouse — nothing to mirror into", salesChannel.Id);
        }

        _warehouseId = warehouseId;
        return warehouseId;
    }

    private async Task<Guid?> ResolveProductIdAsync(SalesChannel salesChannel, string remoteProductId, string? sku, CancellationToken cancellationToken)
    {
        if (_productIdByRemoteId.TryGetValue(remoteProductId, out var cached))
        {
            return cached;
        }

        // Channel link first (survives shop-side SKU edits), SKU as fallback for products imported
        // before the link existed.
        var productId = await _dbContext.ProductSalesChannel
            .Where(psc => psc.SalesChannelId == salesChannel.Id && psc.RemoteProductId == remoteProductId)
            .Select(psc => (Guid?)psc.ProductId)
            .FirstOrDefaultAsync(cancellationToken);

        if (productId is null && !string.IsNullOrEmpty(sku))
        {
            productId = await _dbContext.Product
                .Where(p => p.Sku == sku)
                .Select(p => (Guid?)p.Id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        _productIdByRemoteId[remoteProductId] = productId;
        return productId;
    }
}
