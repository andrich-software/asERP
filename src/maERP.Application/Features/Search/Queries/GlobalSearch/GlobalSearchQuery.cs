using maERP.Application.Mediator;
using maERP.Domain.Dtos.Search;
using maERP.Domain.Wrapper;

namespace maERP.Application.Features.Search.Queries.GlobalSearch;

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
