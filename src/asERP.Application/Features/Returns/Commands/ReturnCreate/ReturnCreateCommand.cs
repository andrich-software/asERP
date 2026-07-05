using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Commands.ReturnCreate;

public class ReturnCreateCommand : ReturnShipmentInputDto, IRequest<Result<Guid>>
{
}
