using asERP.Application.Mediator;
using asERP.Domain.Dtos.Country;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Country.Queries.CountryList;

public class CountryListQuery : IRequest<PaginatedResult<CountryListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public CountryListQuery(int pageNumber = 0, int pageSize = 300, string searchString = "", string sortBy = "")
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            SortBy = sortBy.Split(',');
        }
        else SortBy = Array.Empty<string>();
    }
}
