using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.TenantEmailSettings;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.TenantEmailSettings.Commands.TenantEmailSettingsUpsert;

/// <summary>
/// Creates or updates the email configuration for the current tenant.
/// Each tenant has at most one configuration; this command upserts that singleton.
/// </summary>
public class TenantEmailSettingsUpsertCommand : TenantEmailSettingsInputDto, IRequest<Result<Guid>>
{
}
