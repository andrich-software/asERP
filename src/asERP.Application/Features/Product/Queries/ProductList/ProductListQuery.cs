using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Product.Queries.ProductList;

public class ProductListQuery : IRequest<PaginatedResult<ProductListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }

    /// <summary>When false (default), variant child products are excluded from the top-level list.</summary>
    public bool IncludeVariants { get; set; }

    public ProductListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string salesBy = "", bool includeVariants = false)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
        IncludeVariants = includeVariants;

        if (!string.IsNullOrWhiteSpace(salesBy))
        {
            SalesBy = salesBy.Split(',');
        }
        else SalesBy = new string[] { };
    }
}