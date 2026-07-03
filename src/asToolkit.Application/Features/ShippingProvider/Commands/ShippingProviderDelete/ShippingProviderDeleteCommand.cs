using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProvider.Commands.ShippingProviderDelete;

public class ShippingProviderDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
