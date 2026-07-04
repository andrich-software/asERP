using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Commands.ShippingDelete;

public class ShippingDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
