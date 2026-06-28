using asToolkit.Domain.Dtos.Country;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Country.Commands.CountryCreate;

/// <summary>
/// Command for creating a new country in the system.
/// Inherits from CountryInputDto to get all country properties and implements IRequest
/// to work with the custom mediator, returning the ID of the newly created country wrapped in a Result.
/// </summary>
public class CountryCreateCommand : CountryInputDto, IRequest<Result<Guid>>
{
}
