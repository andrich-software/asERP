namespace asToolkit.Domain.Dtos.WebAnalytics;

/// <summary>
/// The most-visited products for the "Web-Statistiken" dashboard tab, scoped to one tenant + channel.
/// </summary>
public class WebTopProductsDto
{
    /// <summary>Inclusive start of the aggregation window (UTC).</summary>
    public DateTime StartDate { get; set; }

    /// <summary>Inclusive end of the aggregation window (UTC).</summary>
    public DateTime EndDate { get; set; }

    public List<WebTopProductDto> Products { get; set; } = new();
}

/// <summary>A single most-visited-product row.</summary>
public class WebTopProductDto
{
    /// <summary>Product id/SKU as sent by the storefront.</summary>
    public string ProductRef { get; set; } = string.Empty;

    /// <summary>Human-readable product name (most recent seen).</summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>Total product-view events in the window.</summary>
    public long Views { get; set; }

    /// <summary>Distinct visitors (by session) who viewed the product.</summary>
    public long UniqueVisitors { get; set; }
}
