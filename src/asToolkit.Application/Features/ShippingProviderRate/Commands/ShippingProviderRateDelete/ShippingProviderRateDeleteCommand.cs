using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateDelete;

public class ShippingProviderRateDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
