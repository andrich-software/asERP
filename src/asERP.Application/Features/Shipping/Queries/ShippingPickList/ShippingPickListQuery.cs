using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Queries.ShippingPickList;

public class ShippingPickListQuery : IRequest<Result<ShippingLabelDto>>
{
    public Guid Id { get; set; }
}
