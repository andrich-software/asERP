namespace asERP.Domain.Dtos.Product;

/// <summary>
/// Stock of a product in a single warehouse. Warehouses without a stock row for the
/// product are reported with a stock of zero.
/// </summary>
public class ProductStockDto
{
    public Guid WarehouseId { get; set; }

    public string WarehouseName { get; set; } = string.Empty;

    public double Stock { get; set; }

    public double StockMin { get; set; }

    public double StockMax { get; set; }
}
