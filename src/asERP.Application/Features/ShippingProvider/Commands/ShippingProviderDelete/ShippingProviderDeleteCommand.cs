using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Commands.ShippingProviderDelete;

public class ShippingProviderDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
