namespace asERP.SalesChannels.Models;

public class SalesChannelImportProduct
{
    /// <summary>Channel-side product id (numeric for WooCommerce/eBay, UUID for Shopware 6).</summary>
    public string RemoteProductId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double TaxRate { get; set; }
    public decimal Price { get; set; }
    public double Stock { get; set; }

    /// <summary>True when the remote product is a variation container (Woo "variable", Sw6 parent, eBay item group).</summary>
    public bool IsVariantParent { get; set; }

    /// <summary>Ordered attribute names the product varies by (e.g. "Farbe", "Größe").</summary>
    public List<string> VariantAxes { get; set; } = new();

    public List<SalesChannelImportVariant> Variants { get; set; } = new();

    /// <summary>Product photos referenced on the channel, downloaded and attached on import.</summary>
    public List<SalesChannelImportImage> Images { get; set; } = new();
}
