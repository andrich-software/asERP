using asERP.Application.Mediator;
using asERP.Domain.Dtos.SalesChannelOAuth;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannelOAuth.Commands.OAuthCallback;

public class OAuthCallbackCommand : IRequest<Result<OAuthCallbackResultDto>>
{
    public SalesChannelType Provider { get; set; }
    public string State { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}
