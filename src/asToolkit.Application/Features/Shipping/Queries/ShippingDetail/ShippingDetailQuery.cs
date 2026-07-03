using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Queries.ShippingDetail;

public class ShippingDetailQuery : IRequest<Result<ShippingDetailDto>>
{
    public Guid Id { get; set; }
}
