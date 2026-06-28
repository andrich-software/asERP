using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IProductImageRepository : IGenericRepository<ProductImage>
{
    /// <summary>Returns a product's images ordered by <see cref="ProductImage.SortOrder"/>.</summary>
    Task<List<ProductImage>> GetByProductIdAsync(Guid productId);

    /// <summary>Highest existing SortOrder for a product, or -1 if it has no images.</summary>
    Task<int> GetMaxSortOrderAsync(Guid productId);
}
