using asERP.Application.Mediator;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Product.Queries.ProductList;

public class ProductListQuery : IRequest<PaginatedResult<ProductListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }

    /// <summary>When false (default), variant child products are excluded from the top-level list.</summary>
    public bool IncludeVariants { get; set; }

    /// <summary>When true, only products below their minimum stock in at least one warehouse are returned.</summary>
    public bool LowStockOnly { get; set; }

    public ProductListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string salesBy = "", bool includeVariants = false, bool lowStockOnly = false)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
        IncludeVariants = includeVariants;
        LowStockOnly = lowStockOnly;

        if (!string.IsNullOrWhiteSpace(salesBy))
        {
            SalesBy = salesBy.Split(',');
        }
        else SalesBy = new string[] { };
    }
}
