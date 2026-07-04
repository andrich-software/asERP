using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

public class ProductAttribute : BaseEntity, IBaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }

    public ICollection<ProductAttributeValue> Values { get; set; } = [];
}
