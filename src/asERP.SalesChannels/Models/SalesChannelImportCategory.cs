namespace asERP.SalesChannels.Models;

/// <summary>Channel-agnostic shape of one remote category node, produced by the connectors' category imports.</summary>
public class SalesChannelImportCategory
{
    /// <summary>Channel-side category id (numeric term id for WooCommerce, UUID for Shopware 6).</summary>
    public string RemoteCategoryId { get; set; } = string.Empty;

    /// <summary>Channel-side id of the parent category; null/empty for roots.</summary>
    public string? ParentRemoteCategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int SortOrder { get; set; }
}
