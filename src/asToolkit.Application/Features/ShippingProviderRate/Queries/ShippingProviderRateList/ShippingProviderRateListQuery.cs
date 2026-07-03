using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProviderRate;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProviderRate.Queries.ShippingProviderRateList;

public class ShippingProviderRateListQuery : IRequest<Result<List<ShippingProviderRateListDto>>>
{
    public Guid ShippingProviderId { get; set; }
}
