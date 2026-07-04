using asERP.Domain.Dtos.TaxClass;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.TaxClass.Queries.TaxClassDetail;

/// <summary>
/// Query for retrieving detailed information about a specific tax class.
/// Implements IRequest to work with MediatR, returning tax class details wrapped in a Result.
/// </summary>
public class TaxClassDetailQuery : IRequest<Result<TaxClassDetailDto>>
{
    /// <summary>
    /// The unique identifier of the tax class to retrieve
    /// </summary>
    public Guid Id { get; set; }
}