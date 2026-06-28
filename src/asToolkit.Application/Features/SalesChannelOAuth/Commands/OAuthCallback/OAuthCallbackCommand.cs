using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.SalesChannelOAuth;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.SalesChannelOAuth.Commands.OAuthCallback;

public class OAuthCallbackCommand : IRequest<Result<OAuthCallbackResultDto>>
{
    public SalesChannelType Provider { get; set; }
    public string State { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}
