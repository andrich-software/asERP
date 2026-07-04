using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShippingProviderRate;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateUpdate;

public class ShippingProviderRateUpdateCommand : ShippingProviderRateUpdateDto, IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
