using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Queries.ShippingLabel;

public class ShippingLabelQuery : IRequest<Result<ShippingLabelDto>>
{
    public Guid Id { get; set; }
}
