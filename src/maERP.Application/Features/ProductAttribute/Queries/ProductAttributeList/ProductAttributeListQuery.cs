using maERP.Domain.Dtos.ProductAttribute;
using maERP.Domain.Wrapper;
using maERP.Application.Mediator;

namespace maERP.Application.Features.ProductAttribute.Queries.ProductAttributeList;

public class ProductAttributeListQuery : IRequest<PaginatedResult<ProductAttributeListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }

    public ProductAttributeListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string salesBy = "")
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
