using asToolkit.Domain.Dtos.GoodsReceipt;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.GoodsReceipt.Commands.GoodsReceiptCreate;

public class GoodsReceiptCreateCommand : GoodsReceiptInputDto, IRequest<Result<Guid>>
{
}