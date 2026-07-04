using asERP.Application.Mediator;
using asERP.Domain.Dtos.SystemOAuthSettings;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SystemOAuthSettings.Queries.SystemOAuthSettingsDetail;

public class SystemOAuthSettingsDetailQuery : IRequest<Result<SystemOAuthSettingsDto>>
{
    public SalesChannelType Provider { get; set; }
}
