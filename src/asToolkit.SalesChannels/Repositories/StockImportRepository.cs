using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.SalesChannels.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asToolkit.SalesChannels.Repositories;

public class StockImportRepository : IStockImportRepository
{
    private readonly ILogger<StockImportRepository> _logger;
    private readonly ApplicationDbContext _dbContext;
    private readonly IStockLedgerService _stockLedger;

    // Per-run caches (scoped lifetime): channel warehouse resolved once; remote-id → product-id lookups
    // repeat across pages, misses (null) are cached too so an unlinked product is only queried once.
    private Guid? _warehouseId;
    private readonly Dictionary<string, Guid?> _productIdByRemoteId = new();

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

        var changed = await _stockLedger.SetAbsoluteStockAsync(
            productId.Value,
            warehouseId,
            quantity,
            StockMovementType.MirrorCorrection,
            salesChannel.TenantId,
            cancellationToken,
            note: $"Mirror from {salesChannel.Name}");

        return changed ? StockImportOutcome.Applied : StockImportOutcome.Unchanged;
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
