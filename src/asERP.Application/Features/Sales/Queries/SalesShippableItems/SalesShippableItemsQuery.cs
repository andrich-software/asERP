using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesShippableItems;

/// <summary>
/// Returns the order lines of a sales order that are not yet assigned to a shipment,
/// enriched with stock and product dimension data for the create-shipment dialog.
/// </summary>
public class SalesShippableItemsQuery : IRequest<Result<List<ShippableSalesItemDto>>>
{
    public Guid Id { get; set; }
}
