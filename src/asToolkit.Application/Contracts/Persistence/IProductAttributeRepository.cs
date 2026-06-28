using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IProductAttributeRepository : IGenericRepository<ProductAttribute>
{
    Task<ProductAttribute?> GetWithValuesAsync(Guid id);
    Task<ProductAttribute?> GetByNameAsync(string name);
    Task<bool> IsInUseAsync(Guid id);
    Task<bool> IsValueInUseAsync(Guid valueId);

    /// <summary>
    /// Tracks a new attribute value as Added via the DbSet. Adding to a tracked parent's
    /// navigation collection mislabels the pre-keyed entity as Modified, so values are added
    /// explicitly through the set instead.
    /// </summary>
    void AddValue(ProductAttributeValue value);

    /// <summary>
    /// Marks an attribute value for deletion via the DbSet. The value→attribute FK is Restrict,
    /// so severing the navigation would throw; an explicit dependent delete is required.
    /// </summary>
    void RemoveValue(ProductAttributeValue value);

    /// <summary>
    /// Deletes an attribute together with its values (explicit cascade per project rule).
    /// </summary>
    Task DeleteWithValuesAsync(ProductAttribute attribute);
}
