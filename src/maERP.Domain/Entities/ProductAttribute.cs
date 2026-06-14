using maERP.Domain.Entities.Common;

namespace maERP.Domain.Entities;

public class ProductAttribute : BaseEntity, IBaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }

    public ICollection<ProductAttributeValue> Values { get; set; } = [];
}
