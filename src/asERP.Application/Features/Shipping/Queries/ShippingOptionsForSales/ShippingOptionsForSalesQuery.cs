using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Queries.ShippingOptionsForSales;

/// <summary>
/// Returns the shipping options applicable to a sales order (enabled providers whose rate
/// ships to the order's delivery country), sorted by price ascending. An unresolvable
/// delivery country yields an empty list with an explanatory message, not an error.
/// </summary>
public class ShippingOptionsForSalesQuery : IRequest<Result<List<ApplicableShippingRateDto>>>
{
    /// <summary>The sales order id.</summary>
    public Guid Id { get; set; }
}
