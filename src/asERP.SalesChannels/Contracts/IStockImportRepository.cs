using asERP.Domain.Entities;

namespace asERP.SalesChannels.Contracts;

/// <summary>Outcome of mirroring one remote stock level.</summary>
public enum StockImportOutcome
{
    /// <summary>The mirrored level changed and was booked (export push triggered).</summary>
    Applied,

    /// <summary>The mirror already matched the remote level — nothing booked.</summary>
    Unchanged,

    /// <summary>The remote product is not linked/known locally — skipped.</summary>
    ProductNotFound,

    /// <summary>The channel has no linked warehouse to mirror into — skipped.</summary>
    NoWarehouse,
}

/// <summary>
/// Persists stock levels mirrored from the stock-master shop: resolves the remote product to the local
/// one, pins the channel warehouse's <c>ProductStock</c> to the reported quantity via the stock ledger
/// and thereby triggers the export push to the other channels.
/// </summary>
public interface IStockImportRepository
{
    Task<StockImportOutcome> ApplyRemoteStockAsync(
        SalesChannel salesChannel,
        string remoteProductId,
        string? sku,
        double quantity,
        CancellationToken cancellationToken);
}
