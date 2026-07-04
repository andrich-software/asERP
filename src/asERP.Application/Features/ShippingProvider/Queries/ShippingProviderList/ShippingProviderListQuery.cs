using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Queries.ShippingProviderList;

public class ShippingProviderListQuery : IRequest<PaginatedResult<ShippingProviderListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }

    public ShippingProviderListQuery(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
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
