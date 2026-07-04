using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.TaxClass.Commands.TaxClassDelete;

public class TaxClassDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}