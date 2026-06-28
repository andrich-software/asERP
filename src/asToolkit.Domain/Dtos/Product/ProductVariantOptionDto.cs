namespace asToolkit.Domain.Dtos.Product;

public class ProductVariantOptionDto
{
    public Guid ProductAttributeId { get; set; }
    public string AttributeName { get; set; } = string.Empty;
    public Guid ProductAttributeValueId { get; set; }
    public string Value { get; set; } = string.Empty;
}
