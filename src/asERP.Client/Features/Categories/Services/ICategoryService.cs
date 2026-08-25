using asERP.Domain.Dtos.Category;

namespace asERP.Client.Features.Categories.Services;

/// <summary>
/// Service interface for category-related API operations.
/// </summary>
public interface ICategoryService
{
    /// <summary>Gets the tenant's complete category list (unpaginated — the tree needs the full set).</summary>
    Task<List<CategoryListDto>> GetCategoriesAsync(CancellationToken ct = default);

    /// <summary>Gets a single category by ID.</summary>
    Task<CategoryDetailDto?> GetCategoryAsync(Guid id, CancellationToken ct = default);

    /// <summary>Creates a new category and returns its id.</summary>
    Task<Guid> CreateCategoryAsync(CategoryInputDto input, CancellationToken ct = default);

    /// <summary>Updates an existing category.</summary>
    Task UpdateCategoryAsync(Guid id, CategoryInputDto input, CancellationToken ct = default);

    /// <summary>Deletes a category (server rejects when child categories exist).</summary>
    Task DeleteCategoryAsync(Guid id, CancellationToken ct = default);

    /// <summary>Sends the delta-tracked per-channel activation changes as one batch.</summary>
    Task UpdateChannelActivationsAsync(CategoryChannelActivationUpdateDto update, CancellationToken ct = default);
}
