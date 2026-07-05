using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Commands.ReturnComplete;

public class ReturnCompleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    /// <summary>Close the return as Rejected instead of Completed.</summary>
    public bool Reject { get; set; }
}
