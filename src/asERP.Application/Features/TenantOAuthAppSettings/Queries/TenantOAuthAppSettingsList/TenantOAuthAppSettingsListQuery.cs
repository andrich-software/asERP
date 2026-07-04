using asERP.Application.Mediator;
using asERP.Domain.Dtos.TenantOAuthAppSettings;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TenantOAuthAppSettings.Queries.TenantOAuthAppSettingsList;

public class TenantOAuthAppSettingsListQuery : IRequest<Result<List<TenantOAuthAppSettingsListDto>>>
{
}
