using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateDelete;

public class ShippingProviderRateDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
