using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Warehouse.Queries.WarehouseDetail;

/// <summary>
/// Query for retrieving detailed information about a specific warehouse.
/// Implements IRequest to work with MediatR, returning warehouse details wrapped in a Result.
/// </summary>
public class WarehouseDetailQuery : IRequest<Result<WarehouseDetailDto>>
{
    /// <summary>
    /// The unique identifier of the warehouse to retrieve
    /// </summary>
    public Guid Id { get; set; }
}