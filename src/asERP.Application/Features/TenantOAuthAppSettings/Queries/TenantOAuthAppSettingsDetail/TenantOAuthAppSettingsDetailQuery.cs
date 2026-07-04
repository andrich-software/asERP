using asERP.Application.Mediator;
using asERP.Domain.Dtos.TenantOAuthAppSettings;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TenantOAuthAppSettings.Queries.TenantOAuthAppSettingsDetail;

public class TenantOAuthAppSettingsDetailQuery : IRequest<Result<TenantOAuthAppSettingsDetailDto>>
{
    public SalesChannelType Provider { get; set; }
}
