using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IGoodsReceiptRepository : IGenericRepository<GoodsReceipt>
{
    Task<GoodsReceipt?> GetByIdWithDetailsAsync(Guid id);
    Task<ProductStock?> GetProductStockAsync(Guid productId, Guid warehouseId);
    Task UpdateProductStockAsync(ProductStock productStock);
    Task CreateProductStockAsync(ProductStock productStock);

    /// <summary>
    /// Atomically adds <paramref name="delta"/> to the stock of the given (product, warehouse) row
    /// directly in the database, avoiding the read-modify-write lost-update race under concurrent
    /// receipts. Returns the number of rows affected (0 when no stock row exists yet).
    /// </summary>
    Task<int> IncrementProductStockAsync(Guid productId, Guid warehouseId, double delta);
}
