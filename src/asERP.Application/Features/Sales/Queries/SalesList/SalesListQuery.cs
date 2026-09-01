using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesList;

public class SalesListQuery : IRequest<PaginatedResult<SalesListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }
    public Guid? SalesChannelId { get; set; }
    public SalesQuickFilter Filter { get; set; }

    public SalesListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "", Guid? salesChannelId = null, SalesQuickFilter filter = SalesQuickFilter.All)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
        SalesChannelId = salesChannelId;
        Filter = filter;

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            SortBy = sortBy.Split(',');
        }
        else SortBy = new string[] { };
    }
}
