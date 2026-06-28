using asToolkit.Domain.Dtos.ProductAttribute;

namespace asToolkit.Domain.Dtos.Product;

public class ProductVariantAxisDto
{
    public Guid ProductAttributeId { get; set; }
    public string AttributeName { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public List<ProductAttributeValueDto> AvailableValues { get; set; } = new();
}
