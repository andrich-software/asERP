using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Search;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Search.Queries.GlobalSearch;

/// <summary>
/// Global quick search across customers, sales, invoices and products.
/// Returns up to <see cref="Limit"/> hits per entity type.
/// </summary>
public class GlobalSearchQuery : IRequest<Result<GlobalSearchResultDto>>
{
    public string SearchString { get; set; } = string.Empty;

    /// <summary>Maximum number of hits per entity type (autocomplete uses a small value).</summary>
    public int Limit { get; set; } = 5;
}
