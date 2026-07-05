using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Queries.ReturnList;

public class ReturnListQuery : IRequest<PaginatedResult<ReturnShipmentListItemDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }
    public ReturnShipmentStatus? Status { get; set; }
    public Guid? SalesId { get; set; }

    public ReturnListQuery(
        int pageNumber = 0,
        int pageSize = 10,
        string searchString = "",
        string salesBy = "",
        ReturnShipmentStatus? status = null,
        Guid? salesId = null)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
        Status = status;
        SalesId = salesId;

        if (!string.IsNullOrWhiteSpace(salesBy))
        {
            SalesBy = salesBy.Split(',');
        }
        else SalesBy = new string[] { };
    }
}
