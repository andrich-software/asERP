using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.SalesChannel.Commands.SalesChannelDelete;

public class SalesChannelDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}