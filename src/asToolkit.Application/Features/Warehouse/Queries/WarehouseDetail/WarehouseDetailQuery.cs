using asToolkit.Domain.Dtos.Warehouse;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Warehouse.Queries.WarehouseDetail;

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