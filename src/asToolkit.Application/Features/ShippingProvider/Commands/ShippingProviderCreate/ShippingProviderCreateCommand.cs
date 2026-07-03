using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProvider;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProvider.Commands.ShippingProviderCreate;

public class ShippingProviderCreateCommand : ShippingProviderCreateDto, IRequest<Result<Guid>>
{
}
