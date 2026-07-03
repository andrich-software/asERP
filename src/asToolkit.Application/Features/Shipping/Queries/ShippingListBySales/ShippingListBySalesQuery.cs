using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Queries.ShippingListBySales;

public class ShippingListBySalesQuery : IRequest<Result<List<ShippingListDto>>>
{
    public Guid SalesId { get; set; }
}
