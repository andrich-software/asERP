namespace asERP.Domain.Dtos.Feed;

/// <summary>
/// A product row for a feed's product selection: catalog metadata plus whether it is currently part of the
/// feed (<see cref="IsActive"/>). Powers both the read-only "Products" detail tab and the edit checkbox list.
/// </summary>
public class FeedProductSelectionDto
{
    public Guid ProductId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    /// <summary>Id of the product's primary image (lowest SortOrder), if any, for list thumbnails.</summary>
    public Guid? PrimaryImageId { get; set; }

    public decimal Price { get; set; }

    /// <summary>True when the product is included in the feed (default true unless explicitly excluded).</summary>
    public bool IsActive { get; set; }
}
