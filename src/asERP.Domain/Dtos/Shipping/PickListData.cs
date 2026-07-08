using asERP.Domain.Dtos.Company;

namespace asERP.Domain.Dtos.Shipping;

/// <summary>
/// Collected data for rendering a pick-list PDF. Multi-shipment capable — the batch-shipping
/// pick list passes several shipment ids and gets one combined, location-sorted list.
/// </summary>
public class PickListData
{
    public Guid? TenantId { get; set; }

    /// <summary>Sender/company block, resolved from the tenant.</summary>
    public CompanySenderInfo Company { get; set; } = new();
    public List<int> SalesNumbers { get; set; } = new();

    /// <summary>Already sorted by storage location ascending; items without a location last.</summary>
    public List<PickListItem> Items { get; set; } = new();
}

public class PickListItem
{
    public double Quantity { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public int SalesNumber { get; set; }
    public string WarehouseName { get; set; } = string.Empty;

    /// <summary>Null for missing products (channel imports without a local product).</summary>
    public double? StorageLocation { get; set; }
}
