using asToolkit.Domain.Entities.Common;

namespace asToolkit.Domain.Entities;

/// <summary>
/// Assigns one attribute value to a variant product. A variant carries exactly
/// one option per axis of its parent; the combination is unique among siblings.
/// </summary>
public class ProductVariantOption : BaseEntity, IBaseEntity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public Guid ProductAttributeValueId { get; set; }
    public ProductAttributeValue? ProductAttributeValue { get; set; }
}
