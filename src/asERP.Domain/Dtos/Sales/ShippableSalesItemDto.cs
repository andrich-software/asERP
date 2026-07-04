namespace asERP.Domain.Dtos.Sales;

/// <summary>
/// An order line that is not yet assigned to a shipment, enriched with the stock and
/// dimension data the create-shipment dialog needs for preselection and weight prefill.
/// </summary>
public class ShippableSalesItemDto
{
    public Guid SalesItemId { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;

    /// <summary>Quantity of the line still open for shipping.</summary>
    public double OpenQuantity { get; set; }

    /// <summary>Per-unit price.</summary>
    public decimal Price { get; set; }

    public double TaxRate { get; set; }

    /// <summary>Serialized lines can only be shipped as a whole line.</summary>
    public bool HasSerialNumbers { get; set; }

    /// <summary>Sum of the product's stock across all warehouses. 0 for missing products.</summary>
    public double StockAvailable { get; set; }

    /// <summary>Product weight in kg; 0 for missing products.</summary>
    public decimal ProductWeight { get; set; }

    public decimal ProductWidth { get; set; }
    public decimal ProductHeight { get; set; }
    public decimal ProductDepth { get; set; }
}
