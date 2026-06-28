using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.SystemOAuthSettings;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.SystemOAuthSettings.Queries.SystemOAuthSettingsDetail;

public class SystemOAuthSettingsDetailQuery : IRequest<Result<SystemOAuthSettingsDto>>
{
    public SalesChannelType Provider { get; set; }
}
