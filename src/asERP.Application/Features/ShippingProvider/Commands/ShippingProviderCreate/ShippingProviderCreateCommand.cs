using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Commands.ShippingProviderCreate;

public class ShippingProviderCreateCommand : ShippingProviderCreateDto, IRequest<Result<Guid>>
{
}
