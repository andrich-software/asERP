namespace asERP.Application.Feeds.Rendering;

/// <summary>
/// Channel-neutral product row consumed by every <see cref="IFeedRenderer"/>. The mapping from the domain
/// (title/optimized-name choice, availability from stock, deep-link, image URLs) happens once, upstream.
/// </summary>
public sealed record FeedProductData
{
    public Guid Id { get; init; }
    public string Sku { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public string Currency { get; init; } = "EUR";

    /// <summary>Google/Pinterest availability token: "in_stock" or "out_of_stock".</summary>
    public string Availability { get; init; } = "in_stock";

    public string? Brand { get; init; }
    public string? Gtin { get; init; }
    public string? Ean { get; init; }
    public string? Mpn { get; init; }
    public string Condition { get; init; } = "new";

    /// <summary>Parent product id for variants (Google/Pinterest item_group_id).</summary>
    public string? ItemGroupId { get; init; }

    /// <summary>Absolute product landing-page URL, or null when no linked channel/mapping exists.</summary>
    public string? Link { get; init; }

    public IReadOnlyList<string> ImageUrls { get; init; } = Array.Empty<string>();

    public string? CategoryPath { get; init; }
}
