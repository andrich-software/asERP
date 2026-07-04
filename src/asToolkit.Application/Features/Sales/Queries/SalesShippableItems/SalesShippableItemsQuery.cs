using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Sales.Queries.SalesShippableItems;

/// <summary>
/// Returns the order lines of a sales order that are not yet assigned to a shipment,
/// enriched with stock and product dimension data for the create-shipment dialog.
/// </summary>
public class SalesShippableItemsQuery : IRequest<Result<List<ShippableSalesItemDto>>>
{
    public Guid Id { get; set; }
}
