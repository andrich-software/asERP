using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Queries.ShippingProviderDetail;

public class ShippingProviderDetailQuery : IRequest<Result<ShippingProviderDetailDto>>
{
    public Guid Id { get; set; }
}
