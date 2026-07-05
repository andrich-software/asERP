using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Commands.ReturnLabelRetry;

public class ReturnLabelRetryCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
