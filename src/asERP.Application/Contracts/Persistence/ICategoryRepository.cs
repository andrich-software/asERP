using asERP.Domain.Dtos.Category;
using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<bool> HasChildrenAsync(Guid id);

    /// <summary>Channel links of a category including the SalesChannel navigation (for export gating).</summary>
    Task<List<CategorySalesChannel>> GetChannelLinksAsync(Guid categoryId);

    /// <summary>
    /// Deletes the category together with its ProductCategory and CategorySalesChannel rows
    /// (explicit cascade — project rule, no EF cascade defaults).
    /// </summary>
    Task DeleteWithDependentsAsync(Guid id);

    /// <summary>
    /// Upserts per-channel activation rows for the given changes (last write wins per cell; unknown
    /// category/channel ids are ignored). Returns only the rows whose state actually flipped, so
    /// the caller can publish export/delete notifications for real transitions only.
    /// </summary>
    Task<IReadOnlyList<CategorySalesChannel>> ApplyChannelActivationAsync(
        IReadOnlyList<CategoryChannelActivationChange> changes,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// True when no other Category in the current tenant collides with this one.
    /// Declared per repository on purpose: a uniqueness rule that silently does
    /// nothing is worse than none, so there is no inherited default to forget.
    /// </summary>
    Task<bool> IsUniqueAsync(Category entity, Guid? id = null);
}
