namespace asERP.Domain.Enums;

/// <summary>
/// Bitmask of operations a connector supports. The orchestrator AND-combines this with the
/// SalesChannel's per-direction Import/Export flags before dispatching, so a connector that
/// does not implement (e.g.) <see cref="UpdatePrice"/> never receives that work item.
/// </summary>
[Flags]
public enum SalesChannelCapabilities
{
    None = 0,
    ImportProducts = 1,
    ImportSaless = 1 << 1,
    ImportCustomers = 1 << 2,
    ExportProducts = 1 << 3,
    UpdateStock = 1 << 4,
    UpdatePrice = 1 << 5,
    UpdateSaless = 1 << 6,
    DelistProducts = 1 << 7,
    OAuth = 1 << 8,
    RequiresMarketplaceId = 1 << 9,

    /// <summary>Can mirror the shop's stock levels into a local warehouse (stock-master channels).</summary>
    ImportStock = 1 << 10,

    /// <summary>Can push a local order cancellation back to the shop (dedicated CancelSales export).</summary>
    CancelSales = 1 << 11,

    /// <summary>Can pull the channel's category tree.</summary>
    ImportCategories = 1 << 12,

    /// <summary>Can create/update/delete categories on the channel.</summary>
    ExportCategories = 1 << 13,

    /// <summary>Can push a product's category assignments as a partial product update.</summary>
    UpdateProductCategories = 1 << 14,

    /// <summary>Can read shipment tracking numbers the shop recorded for an order.</summary>
    ImportShipments = 1 << 15,

    /// <summary>Can write a local shipment's tracking numbers back to the shop's order.</summary>
    PushShipments = 1 << 16,
}
