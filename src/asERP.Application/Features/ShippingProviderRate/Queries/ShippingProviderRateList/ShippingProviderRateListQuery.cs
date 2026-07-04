using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShippingProviderRate;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProviderRate.Queries.ShippingProviderRateList;

public class ShippingProviderRateListQuery : IRequest<Result<List<ShippingProviderRateListDto>>>
{
    public Guid ShippingProviderId { get; set; }
}
