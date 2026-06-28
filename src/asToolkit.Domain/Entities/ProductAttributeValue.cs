using asToolkit.Domain.Entities.Common;

namespace asToolkit.Domain.Entities;

public class ProductAttributeValue : BaseEntity, IBaseEntity
{
    public Guid ProductAttributeId { get; set; }
    public ProductAttribute? ProductAttribute { get; set; }

    public string Value { get; set; } = string.Empty;
    public int SortOrder { get; set; }
}
