using asERP.Application.Mediator;
using asERP.Domain.Dtos.GlobalSettings;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.GlobalSettings.Queries.GlobalSettingsList;

/// <summary>
/// Returns every editable global <c>Setting</c> row (Superadmin settings page). Secrets are
/// masked, <c>OAuth.*</c> rows and <c>Jwt.Key</c> are excluded — see
/// <see cref="GlobalSettingsRules"/>.
/// </summary>
public class GlobalSettingsListQuery : IRequest<Result<List<GlobalSettingDto>>>
{
}
