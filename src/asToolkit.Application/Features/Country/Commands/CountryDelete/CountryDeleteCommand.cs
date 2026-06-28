using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Country.Commands.CountryDelete;

public class CountryDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
