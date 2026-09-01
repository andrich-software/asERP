using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesReadyToShipList;

public class SalesReadyToShipListQuery : IRequest<PaginatedResult<SalesReadyToShipListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string[] SortBy { get; set; }

    public SalesReadyToShipListQuery(int pageNumber = 0, int pageSize = 10, string sortBy = "")
    {
        PageNumber = pageNumber;
        PageSize = pageSize;

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            SortBy = sortBy.Split(',');
        }
        else SortBy = Array.Empty<string>();
    }
}
