using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShippingProviderRate;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateCreate;

public class ShippingProviderRateCreateCommand : ShippingProviderRateCreateDto, IRequest<Result<Guid>>
{
}
