using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Constants;

namespace asERP.Application.Features.Setup.Services;

/// <summary>
/// Single source of truth for "does this server still need its initial setup?" — used by
/// the anonymous /server-info endpoint and as the guard of the setup command. Any existing
/// user account closes the window immediately (e.g. a Superadmin created via the CLI),
/// independent of the persisted flag; the flag covers the completed-setup case.
/// </summary>
public class SetupStatusService : ISetupStatusService
{
    private readonly IUserRepository _userRepository;
    private readonly ISettingsService _settingsService;

    public SetupStatusService(IUserRepository userRepository, ISettingsService settingsService)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _settingsService = settingsService ?? throw new ArgumentNullException(nameof(settingsService));
    }

    public async Task<bool> IsSetupRequiredAsync()
    {
        if (await _userRepository.AnyUsersAsync())
        {
            return false;
        }

        var completed = await _settingsService.GetSettingValueAsync(SettingKeys.SetupCompleted);
        return !string.Equals(completed, "True", StringComparison.OrdinalIgnoreCase);
    }
}
