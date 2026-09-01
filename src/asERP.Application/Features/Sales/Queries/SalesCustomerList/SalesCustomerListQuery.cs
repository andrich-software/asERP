using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesCustomerList;

public class SalesCustomerListQuery : IRequest<PaginatedResult<SalesListDto>>
{
    public int CustomerId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public SalesCustomerListQuery(int customerId, int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "")
    {
        CustomerId = customerId;
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
