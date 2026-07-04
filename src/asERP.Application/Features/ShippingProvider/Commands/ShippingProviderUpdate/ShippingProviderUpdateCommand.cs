using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Commands.ShippingProviderUpdate;

public class ShippingProviderUpdateCommand : ShippingProviderUpdateDto, IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
