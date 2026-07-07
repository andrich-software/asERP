namespace asERP.Application.Feeds.Rendering;

/// <summary>Everything a renderer needs: feed-level metadata plus the mapped product rows.</summary>
public sealed record FeedRenderContext
{
    public string FeedName { get; init; } = string.Empty;
    public string Currency { get; init; } = "EUR";

    /// <summary>Absolute public feed URL (/feed/{id}); used as the RSS channel link.</summary>
    public string PublicFeedUrl { get; init; } = string.Empty;

    /// <summary>idealo-only delivery defaults.</summary>
    public string? DefaultDeliveryTime { get; init; }
    public decimal? DefaultShippingCost { get; init; }

    public IReadOnlyList<FeedProductData> Products { get; init; } = Array.Empty<FeedProductData>();
}
