namespace asERP.Domain.Enums;

/// <summary>
/// What a single sync run / outbox row represents. Used both by <c>ChannelSyncRun</c>
/// (audit log) and <c>ChannelExportOutbox</c> (export queue).
/// </summary>
public enum ChannelSyncOperation
{
    ImportProducts = 1,
    ImportSaless = 2,
    ImportCustomers = 3,

    /// <summary>Mirror the master shop's stock levels into the channel's linked warehouse.</summary>
    ImportStock = 4,

    /// <summary>Pull the channel's category tree (full sweep — category counts are small).</summary>
    ImportCategories = 5,
    ExportProduct = 10,
    UpdateStock = 11,
    UpdatePrice = 12,
    UpdateSales = 13,
    DelistProduct = 14,

    /// <summary>Push a local order cancellation back to the originating channel.</summary>
    CancelSales = 15,

    /// <summary>Create or update a single category on the channel.</summary>
    ExportCategory = 16,

    /// <summary>Remove a category from the channel (deactivated or deleted locally).</summary>
    DeleteCategory = 17,

    /// <summary>Push a product's category assignments to the channel (partial product update).</summary>
    UpdateProductCategories = 18,
}
