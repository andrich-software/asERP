using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesDetail;

/// <summary>
/// Query for retrieving detailed information about a specific sales.
/// Implements IRequest to work with the custom mediator, returning sales details wrapped in a Result.
/// </summary>
public class SalesDetailQuery : IRequest<Result<SalesDetailDto>>
{
    /// <summary>
    /// The unique identifier of the sales to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
