namespace asERP.Domain.Dtos.Product;

public class ProductVariantListDto
{
    public Guid Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Ean { get; set; }
    public decimal Price { get; set; }
    public int VariantSortOrder { get; set; }
    public List<ProductVariantOptionDto> Options { get; set; } = new();
}
