using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Commands.ShippingCancel;

public class ShippingCancelCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
