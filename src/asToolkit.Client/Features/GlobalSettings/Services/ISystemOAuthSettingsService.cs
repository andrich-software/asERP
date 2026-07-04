using asToolkit.Domain.Dtos.SystemOAuthSettings;

namespace asToolkit.Client.Features.GlobalSettings.Services;

public interface ISystemOAuthSettingsService
{
    Task<SystemOAuthSettingsDto?> GetAsync(string provider, CancellationToken ct = default);
    Task UpsertAsync(string provider, SystemOAuthSettingsInputDto input, CancellationToken ct = default);
}
