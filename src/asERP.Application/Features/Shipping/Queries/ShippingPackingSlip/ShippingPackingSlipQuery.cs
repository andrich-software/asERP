using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Queries.ShippingPackingSlip;

public class ShippingPackingSlipQuery : IRequest<Result<ShippingLabelDto>>
{
    public Guid Id { get; set; }
}
