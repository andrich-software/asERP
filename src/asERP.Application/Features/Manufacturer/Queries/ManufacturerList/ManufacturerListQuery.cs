using asERP.Application.Mediator;
using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Manufacturer.Queries.ManufacturerList;

public class ManufacturerListQuery : IRequest<PaginatedResult<ManufacturerListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public ManufacturerListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "")
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
