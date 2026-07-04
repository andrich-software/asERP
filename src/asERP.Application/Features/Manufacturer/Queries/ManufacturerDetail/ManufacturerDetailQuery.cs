using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Manufacturer.Queries.ManufacturerDetail;

/// <summary>
/// Query for retrieving detailed information about a specific manufacturer.
/// Implements IRequest to work with MediatR, returning manufacturer details wrapped in a Result.
/// </summary>
public class ManufacturerDetailQuery : IRequest<Result<ManufacturerDetailDto>>
{
    /// <summary>
    /// The unique identifier of the manufacturer to retrieve
    /// </summary>
    public Guid Id { get; set; }
}