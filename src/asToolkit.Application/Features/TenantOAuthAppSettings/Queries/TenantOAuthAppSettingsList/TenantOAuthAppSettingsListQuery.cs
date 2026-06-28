using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.TenantOAuthAppSettings;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.TenantOAuthAppSettings.Queries.TenantOAuthAppSettingsList;

public class TenantOAuthAppSettingsListQuery : IRequest<Result<List<TenantOAuthAppSettingsListDto>>>
{
}
