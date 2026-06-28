using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Superadmin.Commands.SuperadminDelete;

public class SuperadminDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public SuperadminDeleteCommand(Guid id)
    {
        Id = id;
    }
}