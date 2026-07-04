using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Commands.ShippingCreate;

public class ShippingCreateCommand : ShippingInputDto, IRequest<Result<Guid>>
{
}
