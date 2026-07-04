using asERP.Domain.Dtos.GoodsReceipt;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.GoodsReceipt.Commands.GoodsReceiptCreate;

public class GoodsReceiptCreateCommand : GoodsReceiptInputDto, IRequest<Result<Guid>>
{
}