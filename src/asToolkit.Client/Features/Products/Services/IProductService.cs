using asToolkit.Client.Core.Models;
using asToolkit.Domain.Dtos.Product;

namespace asToolkit.Client.Features.Products.Services;

/// <summary>
/// Service interface for product-related API operations.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Gets a paginated list of products with full pagination metadata.
    /// </summary>
    Task<PaginatedResponse<ProductListDto>> GetProductsAsync(
        QueryParameters parameters,
        CancellationToken ct = default);

    /// <summary>
    /// Gets a single product by ID.
    /// </summary>
    Task<ProductDetailDto?> GetProductAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Creates a new product.
    /// </summary>
    Task CreateProductAsync(ProductInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    Task UpdateProductAsync(Guid id, ProductInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Generates variant products for a variant parent from the selected attribute values
    /// per axis. Returns the IDs of the newly created variants (existing combinations are skipped).
    /// </summary>
    Task<List<Guid>> GenerateVariantsAsync(Guid parentProductId, ProductVariantGenerateDto request, CancellationToken ct = default);

    /// <summary>Gets a product's images ordered by their position (first = primary).</summary>
    Task<List<ProductImageDto>> GetProductImagesAsync(Guid productId, CancellationToken ct = default);

    /// <summary>Uploads an image for a product. Returns the created image metadata.</summary>
    Task<ProductImageDto?> UploadProductImageAsync(
        Guid productId, Stream content, string fileName, string contentType, CancellationToken ct = default);

    /// <summary>Deletes a product image.</summary>
    Task DeleteProductImageAsync(Guid productId, Guid imageId, CancellationToken ct = default);

    /// <summary>Reorders a product's images; index 0 becomes the primary image.</summary>
    Task ReorderProductImagesAsync(Guid productId, List<Guid> orderedImageIds, CancellationToken ct = default);

    /// <summary>Fetches the raw bytes of an image (or its thumbnail) via the authed client.</summary>
    Task<byte[]> GetProductImageBytesAsync(Guid productId, Guid imageId, bool thumbnail, CancellationToken ct = default);
}
