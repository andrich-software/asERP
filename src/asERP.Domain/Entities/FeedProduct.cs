using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// Per-feed product inclusion override. Products are included in a feed by default; a row here with
/// <see cref="IsActive"/> = <c>false</c> excludes the product. A row only exists as an exception to the
/// default, so the table stays small and newly created products are automatically part of every feed.
/// </summary>
public class FeedProduct : BaseEntity, IBaseEntity
{
    public Guid FeedId { get; set; }
    public Feed? Feed { get; set; }

    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    /// <summary>Whether the product is part of the feed. <c>false</c> = explicitly excluded.</summary>
    public bool IsActive { get; set; }
}
