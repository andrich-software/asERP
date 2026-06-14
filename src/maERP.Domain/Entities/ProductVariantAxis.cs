using maERP.Domain.Entities.Common;

namespace maERP.Domain.Entities;

/// <summary>
/// Defines one attribute a variant parent varies by (e.g. "Color", "Size").
/// Mirrors WooCommerce variation attributes, Shopware configurator settings,
/// eBay variesBy specifications and the Amazon variation theme.
/// </summary>
public class ProductVariantAxis : BaseEntity, IBaseEntity
{
    public Guid ParentProductId { get; set; }
    public Product? ParentProduct { get; set; }

    public Guid ProductAttributeId { get; set; }
    public ProductAttribute? ProductAttribute { get; set; }

    public int SortOrder { get; set; }
}
