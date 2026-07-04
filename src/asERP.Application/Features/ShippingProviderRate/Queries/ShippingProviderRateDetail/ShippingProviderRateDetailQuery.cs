using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShippingProviderRate;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProviderRate.Queries.ShippingProviderRateDetail;

public class ShippingProviderRateDetailQuery : IRequest<Result<ShippingProviderRateDetailDto>>
{
    public Guid Id { get; set; }
}
