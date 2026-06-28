namespace asToolkit.Domain.Dtos.ProductAttribute;

public class ProductAttributeValueDto
{
    public Guid Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public int SortOrder { get; set; }
}
