using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProviderRate;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProviderRate.Queries.ShippingProviderRateDetail;

public class ShippingProviderRateDetailQuery : IRequest<Result<ShippingProviderRateDetailDto>>
{
    public Guid Id { get; set; }
}
