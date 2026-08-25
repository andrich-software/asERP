using asERP.Application.Mediator;
using asERP.Domain.Dtos.GoodsReceipt;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.GoodsReceipt.Queries.GoodsReceiptDetail;

public class GoodsReceiptDetailQuery : IRequest<Result<GoodsReceiptDetailDto>>
{
    public Guid Id { get; set; }
}
