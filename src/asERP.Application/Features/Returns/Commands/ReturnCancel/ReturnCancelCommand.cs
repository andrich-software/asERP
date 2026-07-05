using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Commands.ReturnCancel;

public class ReturnCancelCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
