using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProvider;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProvider.Queries.ShippingProviderDetail;

public class ShippingProviderDetailQuery : IRequest<Result<ShippingProviderDetailDto>>
{
    public Guid Id { get; set; }
}
