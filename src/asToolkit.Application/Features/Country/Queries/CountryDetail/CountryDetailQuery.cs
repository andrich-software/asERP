using asToolkit.Domain.Dtos.Country;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Country.Queries.CountryDetail;

/// <summary>
/// Query for retrieving detailed information about a specific country.
/// Implements IRequest to work with the custom mediator, returning country details wrapped in a Result.
/// </summary>
public class CountryDetailQuery : IRequest<Result<CountryDetailDto>>
{
    /// <summary>
    /// The unique identifier of the country to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
