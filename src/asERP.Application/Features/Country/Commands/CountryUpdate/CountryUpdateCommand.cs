using asERP.Domain.Dtos.Country;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Country.Commands.CountryUpdate;

public class CountryUpdateCommand : CountryInputDto, IRequest<Result<Guid>>
{
}
