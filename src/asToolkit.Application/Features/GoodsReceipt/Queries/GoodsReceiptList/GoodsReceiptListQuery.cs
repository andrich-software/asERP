using asToolkit.Domain.Dtos.GoodsReceipt;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.GoodsReceipt.Queries.GoodsReceiptList;

public class GoodsReceiptListQuery : IRequest<PaginatedResult<GoodsReceiptListDto>>
{
    public int PageNumber { get; set; } = 0;
    public int PageSize { get; set; } = 50;
    public string SearchTerm { get; set; } = string.Empty;
    public string SalesBy { get; set; } = "ReceiptDate Descending";
}