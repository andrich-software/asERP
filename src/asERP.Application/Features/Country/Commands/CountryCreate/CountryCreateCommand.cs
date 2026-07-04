using asERP.Domain.Dtos.Country;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Country.Commands.CountryCreate;

/// <summary>
/// Command for creating a new country in the system.
/// Inherits from CountryInputDto to get all country properties and implements IRequest
/// to work with the custom mediator, returning the ID of the newly created country wrapped in a Result.
/// </summary>
public class CountryCreateCommand : CountryInputDto, IRequest<Result<Guid>>
{
}
