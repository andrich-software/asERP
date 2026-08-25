using asERP.Domain.Enums;

namespace asERP.SalesChannels.Abstractions;

/// <summary>
/// Maps each <see cref="ChannelSyncOperation"/> to the capability flag a connector must declare
/// to perform it. Scheduling and outbox enqueue gate on this so channels whose sync flags are on
/// but whose connector cannot act (the internal PointOfSale/asShop connectors declare
/// <see cref="SalesChannelCapabilities.None"/> — the storefront reads the ERP data directly)
/// neither produce a Failed run every interval nor pile up dead-letter outbox rows.
/// </summary>
public static class ChannelOperationSupport
{
    public static bool Supports(this ISalesChannelConnector connector, ChannelSyncOperation operation) => operation switch
    {
        ChannelSyncOperation.ImportProducts => connector.Capabilities.HasFlag(SalesChannelCapabilities.ImportProducts),
        ChannelSyncOperation.ImportSaless => connector.Capabilities.HasFlag(SalesChannelCapabilities.ImportSaless),
        ChannelSyncOperation.ImportCustomers => connector.Capabilities.HasFlag(SalesChannelCapabilities.ImportCustomers),
        ChannelSyncOperation.ImportStock => connector.Capabilities.HasFlag(SalesChannelCapabilities.ImportStock),
        ChannelSyncOperation.ExportProduct => connector.Capabilities.HasFlag(SalesChannelCapabilities.ExportProducts),
        ChannelSyncOperation.UpdateStock => connector.Capabilities.HasFlag(SalesChannelCapabilities.UpdateStock),
        ChannelSyncOperation.UpdatePrice => connector.Capabilities.HasFlag(SalesChannelCapabilities.UpdatePrice),
        ChannelSyncOperation.UpdateSales => connector.Capabilities.HasFlag(SalesChannelCapabilities.UpdateSaless),
        ChannelSyncOperation.DelistProduct => connector.Capabilities.HasFlag(SalesChannelCapabilities.DelistProducts),
        ChannelSyncOperation.CancelSales => connector.Capabilities.HasFlag(SalesChannelCapabilities.CancelSales),
        ChannelSyncOperation.ImportCategories => connector.Capabilities.HasFlag(SalesChannelCapabilities.ImportCategories),
        ChannelSyncOperation.ExportCategory => connector.Capabilities.HasFlag(SalesChannelCapabilities.ExportCategories),
        ChannelSyncOperation.DeleteCategory => connector.Capabilities.HasFlag(SalesChannelCapabilities.ExportCategories),
        ChannelSyncOperation.UpdateProductCategories => connector.Capabilities.HasFlag(SalesChannelCapabilities.UpdateProductCategories),
        _ => false,
    };
}
