using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProvider;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProvider.Commands.ShippingProviderUpdate;

public class ShippingProviderUpdateCommand : ShippingProviderUpdateDto, IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
