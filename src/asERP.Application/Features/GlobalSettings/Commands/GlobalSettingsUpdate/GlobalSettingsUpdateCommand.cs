using asERP.Application.Mediator;
using asERP.Domain.Dtos.GlobalSettings;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.GlobalSettings.Commands.GlobalSettingsUpdate;

/// <summary>
/// Bulk update of global <c>Setting</c> rows by key (Superadmin settings page). Only existing,
/// non-hidden keys are updatable — the command never creates rows. Secret keys are written via
/// the encrypted settings path; a null or empty value keeps the stored secret.
/// </summary>
public class GlobalSettingsUpdateCommand : IRequest<Result<int>>
{
    public List<GlobalSettingValueInputDto> Settings { get; set; } = [];
}
