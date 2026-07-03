using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Commands.ShippingDelete;

public class ShippingDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
