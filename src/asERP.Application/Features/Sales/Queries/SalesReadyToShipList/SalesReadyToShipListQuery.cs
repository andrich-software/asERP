using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesReadyToShipList;

public class SalesReadyToShipListQuery : IRequest<PaginatedResult<SalesReadyToShipListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string[] SalesBy { get; set; }

    public SalesReadyToShipListQuery(int pageNumber = 0, int pageSize = 10, string salesBy = "")
    {
        PageNumber = pageNumber;
        PageSize = pageSize;

        if (!string.IsNullOrWhiteSpace(salesBy))
        {
            SalesBy = salesBy.Split(',');
        }
        else SalesBy = Array.Empty<string>();
    }
}
