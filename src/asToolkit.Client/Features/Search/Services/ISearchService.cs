using asToolkit.Domain.Dtos.Search;

namespace asToolkit.Client.Features.Search.Services;

/// <summary>
/// Global quick search across customers, sales, invoices and products.
/// </summary>
public interface ISearchService
{
    /// <summary>
    /// Searches all entity types for the given query.
    /// </summary>
    /// <param name="query">The search term (at least 3 characters).</param>
    /// <param name="limit">Maximum hits per entity type.</param>
    Task<GlobalSearchResultDto> SearchAsync(string query, int limit, CancellationToken ct = default);
}
