using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Sales.Queries.SalesCustomerList;

public class SalesCustomerListQuery : IRequest<PaginatedResult<SalesListDto>>
{
    public int CustomerId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }

    public SalesCustomerListQuery(int customerId, int pageNumber = 1, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        CustomerId = customerId;
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;

        if (!string.IsNullOrWhiteSpace(salesBy))
        {
            SalesBy = salesBy.Split(',');
        }
        else SalesBy = new string[] { };
    }
}