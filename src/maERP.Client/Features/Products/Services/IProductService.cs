using maERP.Client.Core.Models;
using maERP.Domain.Dtos.Product;

namespace maERP.Client.Features.Products.Services;

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
}
