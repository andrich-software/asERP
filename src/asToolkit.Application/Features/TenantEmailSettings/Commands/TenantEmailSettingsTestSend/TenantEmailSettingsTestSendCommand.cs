using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.TenantEmailSettings;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.TenantEmailSettings.Commands.TenantEmailSettingsTestSend;

/// <summary>
/// Sends a verification email using the effective configuration (tenant override merged
/// with server defaults). Useful for verifying that SMTP/Microsoft 365 credentials are valid.
/// </summary>
public class TenantEmailSettingsTestSendCommand : TenantEmailSettingsTestSendDto, IRequest<Result<bool>>
{
}
