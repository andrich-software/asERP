namespace asERP.Domain.Dtos.Product;

public class ProductVariantGenerateDto
{
    public Guid ParentProductId { get; set; }

    /// <summary>Per parent axis: the attribute and the values to combine.</summary>
    public List<ProductVariantGenerateAxisDto> Axes { get; set; } = new();
}

public class ProductVariantGenerateAxisDto
{
    public Guid ProductAttributeId { get; set; }
    public List<Guid> ValueIds { get; set; } = new();
}
