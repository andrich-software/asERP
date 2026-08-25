using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TaxClass.Commands.TaxClassDelete;

public class TaxClassDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
