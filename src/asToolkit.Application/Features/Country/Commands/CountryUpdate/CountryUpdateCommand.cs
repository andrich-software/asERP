using asToolkit.Domain.Dtos.Country;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Country.Commands.CountryUpdate;

public class CountryUpdateCommand : CountryInputDto, IRequest<Result<Guid>>
{
}
