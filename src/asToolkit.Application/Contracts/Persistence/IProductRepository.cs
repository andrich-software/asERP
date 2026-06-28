using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetBySkuAsync(string sku);
    Task<Product?> GetWithDetailsAsync(Guid id);
    Task<List<Product>> GetVariantsAsync(Guid parentProductId);

    /// <summary>
    /// Deletes a product together with its dependents (variant options, axes, sales channel
    /// links, stocks) and — for variant parents — all child variants. Explicit cascade per
    /// project rule; EF cascade defaults are not relied upon.
    /// </summary>
    Task DeleteWithDependentsAsync(Product product);

    // Variant axes/options are pre-keyed BaseEntity children; adding them to a tracked parent's
    // navigation collection mislabels them as Modified, and removing severs a Restrict FK. Route
    // these through the DbSet so they are tracked as Added/Deleted correctly.
    void AddVariantAxis(ProductVariantAxis axis);
    void RemoveVariantAxis(ProductVariantAxis axis);
    void AddVariantOption(ProductVariantOption option);
    void RemoveVariantOption(ProductVariantOption option);
}