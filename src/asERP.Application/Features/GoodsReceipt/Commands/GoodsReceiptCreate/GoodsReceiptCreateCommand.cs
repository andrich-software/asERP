using asERP.Application.Mediator;
using asERP.Domain.Dtos.GoodsReceipt;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.GoodsReceipt.Commands.GoodsReceiptCreate;

public class GoodsReceiptCreateCommand : GoodsReceiptInputDto, IRequest<Result<Guid>>
{
}
