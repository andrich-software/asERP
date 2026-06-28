using asToolkit.Client.Core.Models;
using asToolkit.Domain.Dtos.ProductAttribute;

namespace asToolkit.Client.Features.ProductAttributes.Services;

/// <summary>
/// Service interface for product attribute-related API operations.
/// </summary>
public interface IProductAttributeService
{
    /// <summary>
    /// Gets a paginated list of product attributes with full pagination metadata.
    /// </summary>
    Task<PaginatedResponse<ProductAttributeListDto>> GetProductAttributesAsync(
        QueryParameters parameters,
        CancellationToken ct = default);

    /// <summary>
    /// Gets a single product attribute by ID.
    /// </summary>
    Task<ProductAttributeDetailDto?> GetProductAttributeAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Creates a new product attribute.
    /// </summary>
    Task CreateProductAttributeAsync(ProductAttributeInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Updates an existing product attribute.
    /// </summary>
    Task UpdateProductAttributeAsync(Guid id, ProductAttributeInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Deletes a product attribute.
    /// </summary>
    Task DeleteProductAttributeAsync(Guid id, CancellationToken ct = default);
}
