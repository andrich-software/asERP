using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Queries.ShippingLabel;

public class ShippingLabelQuery : IRequest<Result<ShippingLabelDto>>
{
    public Guid Id { get; set; }
}
