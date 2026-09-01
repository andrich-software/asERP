using asERP.Application.Mediator;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Warehouse.Queries.WarehouseList;

public class WarehouseListQuery : IRequest<PaginatedResult<WarehouseListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public WarehouseListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "")
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
