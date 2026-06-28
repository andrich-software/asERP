namespace asToolkit.Domain.Dtos.Product;

/// <summary>
/// New ordering for a product's images. The list must contain exactly the product's image
/// ids; their position in the list becomes the new SortOrder (index 0 = primary).
/// </summary>
public class ProductImageReorderDto
{
    public List<Guid> OrderedImageIds { get; set; } = new();
}
