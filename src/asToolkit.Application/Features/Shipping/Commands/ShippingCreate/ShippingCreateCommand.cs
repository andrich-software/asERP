using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Commands.ShippingCreate;

public class ShippingCreateCommand : ShippingInputDto, IRequest<Result<Guid>>
{
}
