using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// Product category node. Categories form a tree via <see cref="ParentCategoryId"/> (adjacency list,
/// like Shopware/WooCommerce). Channel visibility is modeled per channel on
/// <see cref="CategorySalesChannel"/>; product membership on <see cref="ProductCategory"/>.
/// </summary>
public class Category : BaseEntity, IBaseEntity
{
    public string Name { get; set; } = string.Empty;

    /// <summary>URL-safe identifier used by shop frontends; generated from <see cref="Name"/> when left empty.</summary>
    public string Slug { get; set; } = string.Empty;

    public string? Description { get; set; }

    /// <summary>Display order among siblings (ascending).</summary>
    public int SortOrder { get; set; }

    public Guid? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Category> Children { get; set; } = [];

    public ICollection<ProductCategory> ProductCategories { get; set; } = [];
    public ICollection<CategorySalesChannel> SalesChannels { get; set; } = [];
}
