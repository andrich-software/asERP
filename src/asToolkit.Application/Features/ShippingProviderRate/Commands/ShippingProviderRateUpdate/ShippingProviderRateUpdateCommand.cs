using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProviderRate;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateUpdate;

public class ShippingProviderRateUpdateCommand : ShippingProviderRateUpdateDto, IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
