using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Commands.ShippingCancel;

public class ShippingCancelCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
