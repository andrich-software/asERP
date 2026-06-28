using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.SalesChannelOAuth.Commands.OAuthDisconnect;

public class OAuthDisconnectCommand : IRequest<Result<int>>
{
    public Guid SalesChannelId { get; set; }
}
