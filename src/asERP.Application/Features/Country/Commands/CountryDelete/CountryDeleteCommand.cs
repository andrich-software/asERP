using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Country.Commands.CountryDelete;

public class CountryDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
