using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.GlobalSettings.Commands.GlobalSettingsUpdate;

public class GlobalSettingsUpdateHandler : IRequestHandler<GlobalSettingsUpdateCommand, Result<int>>
{
    private readonly IAppLogger<GlobalSettingsUpdateHandler> _logger;
    private readonly ISettingRepository _settingRepository;
    private readonly ISettingsService _settings;

    public GlobalSettingsUpdateHandler(
        IAppLogger<GlobalSettingsUpdateHandler> logger,
        ISettingRepository settingRepository,
        ISettingsService settings)
    {
        _logger = logger;
        _settingRepository = settingRepository;
        _settings = settings;
    }

    public async Task<Result<int>> Handle(
        GlobalSettingsUpdateCommand request, CancellationToken cancellationToken)
    {
        var existing = _settingRepository.Entities
            .AsEnumerable()
            .ToDictionary(s => s.Key, s => s, StringComparer.OrdinalIgnoreCase);

        // Validate the whole batch before writing anything — a typo'd key must not leave the
        // settings half-updated.
        foreach (var entry in request.Settings)
        {
            if (GlobalSettingsRules.IsHidden(entry.Key) || !existing.ContainsKey(entry.Key))
            {
                return Result<int>.Fail(ResultStatusCode.BadRequest,
                    $"Unknown setting key '{entry.Key}'.");
            }
        }

        var updated = 0;
        foreach (var entry in request.Settings)
        {
            if (entry.Value is null)
            {
                continue;
            }

            var row = existing[entry.Key];
            if (GlobalSettingsRules.IsSecret(row.Key, row.IsEncrypted))
            {
                // The client never sees the stored secret, so an empty field means "unchanged".
                if (entry.Value.Length == 0)
                {
                    continue;
                }

                await _settings.SetEncryptedSettingValueAsync(row.Key, entry.Value);
                updated++;
            }
            else if (!string.Equals(row.Value, entry.Value, StringComparison.Ordinal))
            {
                await _settings.SetSettingValueAsync(row.Key, entry.Value);
                updated++;
            }
        }

        _logger.LogInformation("Updated {Count} global settings", updated);
        return new Result<int> { Succeeded = true, Data = updated, StatusCode = ResultStatusCode.NoContent };
    }
}
