namespace asERP.Domain.Dtos.ProductAttribute;

public class ProductAttributeListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public int ValueCount { get; set; }
}
