using maERP.Domain.Dtos.ProductAttribute;

namespace maERP.Domain.Dtos.Product;

public class ProductVariantAxisDto
{
    public Guid ProductAttributeId { get; set; }
    public string AttributeName { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public List<ProductAttributeValueDto> AvailableValues { get; set; } = new();
}
