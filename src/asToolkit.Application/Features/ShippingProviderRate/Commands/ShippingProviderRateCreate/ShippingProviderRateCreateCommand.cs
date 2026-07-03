using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProviderRate;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateCreate;

public class ShippingProviderRateCreateCommand : ShippingProviderRateCreateDto, IRequest<Result<Guid>>
{
}
