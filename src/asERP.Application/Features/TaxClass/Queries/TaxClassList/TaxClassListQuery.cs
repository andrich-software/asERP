using asERP.Application.Mediator;
using asERP.Domain.Dtos.TaxClass;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TaxClass.Queries.TaxClassList;

public class TaxClassListQuery : IRequest<PaginatedResult<TaxClassListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public TaxClassListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "")
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            SortBy = sortBy.Split(',');
        }
        else SortBy = new string[] { };
    }
}
