using asToolkit.Domain.Dtos.TaxClass;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.TaxClass.Queries.TaxClassList;

public class TaxClassListQuery : IRequest<PaginatedResult<TaxClassListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }

    public TaxClassListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string salesBy = "")
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