namespace asERP.SalesChannels.Models;

public class SalesChannelImportVariant
{
    /// <summary>Channel-side variant id (Woo variation id, Sw6 child product id, eBay variant SKU).</summary>
    public string RemoteVariantId { get; set; } = string.Empty;

    /// <summary>May be empty (common for WooCommerce variations) — the import synthesizes a stable SKU then.</summary>
    public string? Sku { get; set; }

    public string? Ean { get; set; }

    /// <summary>Null means the variant inherits the parent price.</summary>
    public decimal? Price { get; set; }

    public double Stock { get; set; }

    public int SortOrder { get; set; }

    /// <summary>One entry per axis: attribute name and the selected value (e.g. "Farbe" = "Rot").</summary>
    public List<SalesChannelImportVariantOption> Options { get; set; } = new();
}

public class SalesChannelImportVariantOption
{
    public string AttributeName { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
