namespace asToolkit.Domain.Dtos.Shipping;

/// <summary>
/// Collected data for rendering a packing-slip PDF for a single shipment.
/// An empty <see cref="Items"/> list is valid — shipments without assigned order lines exist.
/// </summary>
public class PackingSlipData
{
    public Guid? TenantId { get; set; }
    public int SalesNumber { get; set; }
    public DateTime SalesDate { get; set; }
    public string TrackingNumber { get; set; } = string.Empty;

    /// <summary>1-based position of this shipment among all shipments of the order.</summary>
    public int PackageIndex { get; set; }
    public int PackageCount { get; set; }

    /// <summary>Whether price columns are rendered — from <c>Tenant.PackingSlipShowPrices</c>.</summary>
    public bool ShowPrices { get; set; }

    public string DeliveryFirstName { get; set; } = string.Empty;
    public string DeliveryLastName { get; set; } = string.Empty;
    public string DeliveryCompanyName { get; set; } = string.Empty;
    public string DeliveryStreet { get; set; } = string.Empty;
    public string DeliveryZip { get; set; } = string.Empty;
    public string DeliveryCity { get; set; } = string.Empty;
    public string DeliveryCountry { get; set; } = string.Empty;

    public List<PackingSlipItem> Items { get; set; } = new();
}

public class PackingSlipItem
{
    public double Quantity { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public string Ean { get; set; } = string.Empty;

    /// <summary>Per-unit price; only rendered when <see cref="PackingSlipData.ShowPrices"/> is set.</summary>
    public decimal Price { get; set; }

    public List<string> SerialNumbers { get; set; } = new();
}
