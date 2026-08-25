using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Country.Commands.CountryDelete;

public class CountryDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
