namespace maERP.Domain.Dtos.ProductAttribute;

public class ProductAttributeDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public List<ProductAttributeValueDto> Values { get; set; } = new();
}
