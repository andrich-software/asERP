using asToolkit.Domain.Dtos.GoodsReceipt;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.GoodsReceipt.Queries.GoodsReceiptDetail;

public class GoodsReceiptDetailQuery : IRequest<Result<GoodsReceiptDetailDto>>
{
    public Guid Id { get; set; }
}