using asToolkit.Domain.Dtos.Customer;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Customer.Queries.CustomerListWithAddress;

public class CustomerListWithAddressQuery : IRequest<PaginatedResult<CustomerListWithAddressDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }

    public CustomerListWithAddressQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string salesBy = "")
    {
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
