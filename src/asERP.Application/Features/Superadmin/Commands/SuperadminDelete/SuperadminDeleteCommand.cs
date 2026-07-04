using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Superadmin.Commands.SuperadminDelete;

public class SuperadminDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public SuperadminDeleteCommand(Guid id)
    {
        Id = id;
    }
}