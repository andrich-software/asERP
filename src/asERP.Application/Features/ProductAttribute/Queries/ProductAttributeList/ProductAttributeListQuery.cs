using asERP.Application.Mediator;
using asERP.Domain.Dtos.ProductAttribute;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductAttribute.Queries.ProductAttributeList;

public class ProductAttributeListQuery : IRequest<PaginatedResult<ProductAttributeListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public ProductAttributeListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "")
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
