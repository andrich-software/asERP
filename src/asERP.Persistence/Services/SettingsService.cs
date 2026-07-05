using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Models.Analytics;
using asERP.Application.Models.Email;
using asERP.Application.Models.Grafana;
using asERP.Application.Models.Identity;
using asERP.Application.Models.Telemetry;
using asERP.Application.Services;
using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Services;

public class SettingsService : ISettingsService
{
    private readonly ISettingRepository _settingRepository;
    private readonly ICredentialEncryptor _encryptor;

    public SettingsService(ISettingRepository settingRepository, ICredentialEncryptor? encryptor = null)
    {
        _settingRepository = settingRepository;
        // Optional injection: keep CLI/test paths that don't wire DataProtection working with the
        // identity-function NoOp (same fallback the DbContext uses for design-time scenarios). Warn
        // loudly if this happens at runtime — secrets would then be stored unencrypted.
        if (encryptor is null && !DatabaseContext.DesignTimeDetection.IsDesignTime)
        {
            System.Diagnostics.Trace.TraceWarning(
                "ICredentialEncryptor was not provided to SettingsService at runtime — falling back to a no-op encryptor. Secret settings will be stored UNENCRYPTED at rest.");
        }
        _encryptor = encryptor ?? new NoOpCredentialEncryptor();
    }

    public async Task<JwtSettings> GetJwtSettingsAsync()
    {
        var settings = await _settingRepository.Entities.Where(s => s.Key.StartsWith("Jwt.")).ToListAsync();

        var jwtSettings = new JwtSettings();

        foreach (var setting in settings)
        {
            switch (setting.Key)
            {
                case "Jwt.Key":
                    jwtSettings.Key = setting.Value;
                    break;
                case "Jwt.Issuer":
                    jwtSettings.Issuer = setting.Value;
                    break;
                case "Jwt.Audience":
                    jwtSettings.Audience = setting.Value;
                    break;
                case "Jwt.DurationInMinutes":
                    if (double.TryParse(setting.Value, out var duration))
                        jwtSettings.DurationInMinutes = duration;
                    break;
                case "Jwt.RefreshTokenExpireDays":
                    if (int.TryParse(setting.Value, out var refreshDays))
                        jwtSettings.RefreshTokenExpireDays = refreshDays;
                    break;
                case "Jwt.RefreshTokenExpireDaysShort":
                    if (int.TryParse(setting.Value, out var refreshDaysShort))
                        jwtSettings.RefreshTokenExpireDaysShort = refreshDaysShort;
                    break;
            }
        }

        return jwtSettings;
    }

    public async Task<EmailSettings> GetEmailSettingsAsync()
    {
        var settings = await _settingRepository.Entities.Where(s => s.Key.StartsWith("Email.")).ToListAsync();

        var emailSettings = new EmailSettings();

        foreach (var setting in settings)
        {
            switch (setting.Key)
            {
                case "Email.ProviderType":
                    if (Enum.TryParse<Domain.Enums.EmailProviderType>(setting.Value, out var providerType))
                        emailSettings.ProviderType = providerType;
                    break;
                case "Email.SmtpHost":
                    emailSettings.SmtpHost = setting.Value;
                    break;
                case "Email.SmtpPort":
                    if (int.TryParse(setting.Value, out var port))
                        emailSettings.SmtpPort = port;
                    break;
                case "Email.SmtpUsername":
                    emailSettings.SmtpUsername = setting.Value;
                    break;
                case "Email.SmtpPassword":
                    // May have been re-saved via the encrypted settings path (global-settings UI).
                    emailSettings.SmtpPassword = setting.IsEncrypted ? _encryptor.Decrypt(setting.Value) : setting.Value;
                    break;
                case "Email.SmtpEnableSsl":
                    if (bool.TryParse(setting.Value, out var enableSsl))
                        emailSettings.SmtpEnableSsl = enableSsl;
                    break;
                case "Email.M365TenantId":
                    emailSettings.M365TenantId = setting.Value;
                    break;
                case "Email.M365ClientId":
                    emailSettings.M365ClientId = setting.Value;
                    break;
                case "Email.M365ClientSecret":
                    emailSettings.M365ClientSecret = setting.IsEncrypted ? _encryptor.Decrypt(setting.Value) : setting.Value;
                    break;
                case "Email.M365SenderAddress":
                    emailSettings.M365SenderAddress = setting.Value;
                    break;
                case "Email.FromAddress":
                    emailSettings.FromAddress = setting.Value;
                    break;
                case "Email.FromName":
                    emailSettings.FromName = setting.Value;
                    break;
                case "Email.ReplyToAddress":
                    emailSettings.ReplyToAddress = setting.Value;
                    break;
                case "Email.ReplyToName":
                    emailSettings.ReplyToName = setting.Value;
                    break;
            }
        }

        return emailSettings;
    }

    public async Task<TelemetrySettings> GetTelemetrySettingsAsync()
    {
        var settings = await _settingRepository.Entities.Where(s => s.Key.StartsWith("Telemetry.")).ToListAsync();

        var telemetrySettings = new TelemetrySettings();

        foreach (var setting in settings)
        {
            switch (setting.Key)
            {
                case "Telemetry.Endpoint":
                    telemetrySettings.Endpoint = setting.Value;
                    break;
                case "Telemetry.ServiceName":
                    telemetrySettings.ServiceName = setting.Value;
                    break;
            }
        }

        return telemetrySettings;
    }

    public async Task<GrafanaSettings> GetGrafanaSettingsAsync()
    {
        var settings = await _settingRepository.Entities.Where(s => s.Key.StartsWith("Grafana.")).ToListAsync();

        var grafanaSettings = new GrafanaSettings();

        foreach (var setting in settings)
        {
            switch (setting.Key)
            {
                case "Grafana.Endpoint":
                    grafanaSettings.Endpoint = setting.Value;
                    break;
                case "Grafana.LokiEndpoint":
                    grafanaSettings.LokiEndpoint = setting.Value;
                    break;
                case "Grafana.LokiUser":
                    grafanaSettings.LokiUser = setting.Value;
                    break;
                case "Grafana.LokiPassword":
                    grafanaSettings.LokiPassword = setting.IsEncrypted ? _encryptor.Decrypt(setting.Value) : setting.Value;
                    break;
                case "Grafana.OtlpEndpoint":
                    grafanaSettings.OtlpEndpoint = setting.Value;
                    break;
                case "Grafana.MetricsEnabled":
                    if (bool.TryParse(setting.Value, out var metricsEnabled))
                        grafanaSettings.MetricsEnabled = metricsEnabled;
                    break;
                case "Grafana.LogsEnabled":
                    if (bool.TryParse(setting.Value, out var logsEnabled))
                        grafanaSettings.LogsEnabled = logsEnabled;
                    break;
            }
        }

        return grafanaSettings;
    }

    public async Task<ClickHouseSettings> GetClickHouseSettingsAsync()
    {
        var settings = await _settingRepository.Entities.Where(s => s.Key.StartsWith("ClickHouse.")).ToListAsync();

        var clickHouseSettings = new ClickHouseSettings();

        foreach (var setting in settings)
        {
            switch (setting.Key)
            {
                case "ClickHouse.Host":
                    if (!string.IsNullOrWhiteSpace(setting.Value)) clickHouseSettings.Host = setting.Value;
                    break;
                case "ClickHouse.Port":
                    if (int.TryParse(setting.Value, out var port)) clickHouseSettings.Port = port;
                    break;
                case "ClickHouse.Database":
                    if (!string.IsNullOrWhiteSpace(setting.Value)) clickHouseSettings.Database = setting.Value;
                    break;
                case "ClickHouse.User":
                    if (!string.IsNullOrWhiteSpace(setting.Value)) clickHouseSettings.User = setting.Value;
                    break;
                case "ClickHouse.Password":
                    // Password is stored encrypted; decrypt via the encryptor (plaintext rows pass through).
                    clickHouseSettings.Password = setting.IsEncrypted ? _encryptor.Decrypt(setting.Value) : setting.Value;
                    break;
                case "ClickHouse.UseTls":
                    if (bool.TryParse(setting.Value, out var useTls)) clickHouseSettings.UseTls = useTls;
                    break;
                case "ClickHouse.Enabled":
                    if (bool.TryParse(setting.Value, out var enabled)) clickHouseSettings.Enabled = enabled;
                    break;
            }
        }

        return clickHouseSettings;
    }

    public async Task<string> GetSettingValueAsync(string key)
    {
        var setting = await _settingRepository.Entities.FirstOrDefaultAsync(s => s.Key == key);
        return setting?.Value ?? string.Empty;
    }

    public async Task SetSettingValueAsync(string key, string value)
    {
        var setting = await _settingRepository.Entities.FirstOrDefaultAsync(s => s.Key == key);
        if (setting != null)
        {
            setting.Value = value;
            await _settingRepository.UpdateAsync(setting);
        }
        else
        {
            setting = new Setting { Key = key, Value = value };
            await _settingRepository.CreateAsync(setting);
        }
    }

    public async Task<string> GetEncryptedSettingValueAsync(string key)
    {
        var setting = await _settingRepository.Entities.FirstOrDefaultAsync(s => s.Key == key);
        if (setting is null) return string.Empty;

        // Plaintext rows pass through unchanged; encrypted rows go through the encryptor whose
        // Decrypt() also passes legacy plaintext through as a safety net.
        var raw = setting.Value ?? string.Empty;
        return setting.IsEncrypted ? _encryptor.Decrypt(raw) : raw;
    }

    public async Task SetEncryptedSettingValueAsync(string key, string value)
    {
        var ciphertext = string.IsNullOrEmpty(value) ? string.Empty : _encryptor.Encrypt(value);
        var setting = await _settingRepository.Entities.FirstOrDefaultAsync(s => s.Key == key);
        if (setting is not null)
        {
            setting.Value = ciphertext;
            setting.IsEncrypted = true;
            await _settingRepository.UpdateAsync(setting);
        }
        else
        {
            setting = new Setting { Key = key, Value = ciphertext, IsEncrypted = true };
            await _settingRepository.CreateAsync(setting);
        }
    }
}
