using asERP.Domain.Dtos.GoodsReceipt;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.GoodsReceipt.Queries.GoodsReceiptDetail;

public class GoodsReceiptDetailQuery : IRequest<Result<GoodsReceiptDetailDto>>
{
    public Guid Id { get; set; }
}