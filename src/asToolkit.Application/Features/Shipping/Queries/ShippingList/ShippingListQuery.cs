using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Queries.ShippingList;

public class ShippingListQuery : IRequest<PaginatedResult<ShipmentListItemDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }
    public ShippingStatus? Status { get; set; }
    public bool ProblemsOnly { get; set; }
    public Guid? SalesId { get; set; }

    public ShippingListQuery(
        int pageNumber = 0,
        int pageSize = 10,
        string searchString = "",
        string salesBy = "",
        ShippingStatus? status = null,
        bool problemsOnly = false,
        Guid? salesId = null)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
        Status = status;
        ProblemsOnly = problemsOnly;
        SalesId = salesId;

        if (!string.IsNullOrWhiteSpace(salesBy))
        {
            SalesBy = salesBy.Split(',');
        }
        else SalesBy = new string[] { };
    }
}
