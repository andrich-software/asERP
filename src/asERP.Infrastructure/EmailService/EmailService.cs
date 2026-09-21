using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Models.Email;
using asERP.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace asERP.Infrastructure.EmailService;

public class TenantAwareEmailService : IEmailService
{
    private readonly ITenantEmailSettingsRepository _emailSettingsRepository;
    private readonly ITenantContext _tenantContext;
    private readonly IEmailTemplateService _templateService;
    private readonly ISettingsService _settingsService;
    private readonly ILogger<TenantAwareEmailService> _logger;
    private readonly IConfiguration _configuration;
    private readonly Dictionary<EmailProviderType, IEmailProvider> _providers;

    public TenantAwareEmailService(
        ITenantEmailSettingsRepository emailSettingsRepository,
        ITenantContext tenantContext,
        IEmailTemplateService templateService,
        ISettingsService settingsService,
        ILogger<TenantAwareEmailService> logger,
        IConfiguration configuration,
        IEnumerable<IEmailProvider> providers)
    {
        _emailSettingsRepository = emailSettingsRepository;
        _tenantContext = tenantContext;
        _templateService = templateService;
        _settingsService = settingsService;
        _logger = logger;
        _configuration = configuration;

        _providers = providers.ToDictionary(p => p.ProviderType);
    }

    public async Task<bool> SendEmailAsync(EmailMessage email, Guid? tenantId = null)
    {
        try
        {
            var settings = await GetEmailSettingsAsync(tenantId);

            if (settings == null || string.IsNullOrWhiteSpace(settings.FromAddress))
            {
                _logger.LogError("No usable email settings found for tenant {TenantId}", tenantId);
                return false;
            }

            if (!_providers.TryGetValue(settings.ProviderType, out var provider))
            {
                _logger.LogError("No email provider found for type {ProviderType}", settings.ProviderType);
                return false;
            }

            return await provider.SendAsync(email, settings);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending email to {To}", email.To);
            return false;
        }
    }

    public async Task<bool> SendPasswordResetEmailAsync(string toEmail, string toName, string resetToken, Guid? tenantId = null)
    {
        try
        {
            var resetUrl = _configuration["EmailSettings:PasswordResetUrl"] ?? "https://localhost:5001/reset-password";

            var htmlBody = await _templateService.GeneratePasswordResetEmailAsync(toName, resetToken, resetUrl);

            var emailMessage = new EmailMessage
            {
                To = toEmail,
                ToName = toName,
                Subject = "Passwort zurücksetzen - asERP",
                Body = htmlBody,
                IsHtml = true
            };

            return await SendEmailAsync(emailMessage, tenantId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending password reset email to {Email}", toEmail);
            return false;
        }
    }

    public async Task<bool> SendWelcomeEmailAsync(string toEmail, string toName, Guid? tenantId = null)
    {
        try
        {
            var htmlBody = await _templateService.GenerateWelcomeEmailAsync(toName);

            var emailMessage = new EmailMessage
            {
                To = toEmail,
                ToName = toName,
                Subject = "Willkommen bei asERP",
                Body = htmlBody,
                IsHtml = true
            };

            return await SendEmailAsync(emailMessage, tenantId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending welcome email to {Email}", toEmail);
            return false;
        }
    }

    private async Task<EmailSettings?> GetEmailSettingsAsync(Guid? tenantId)
    {
        // 1. Server-level defaults — Setting table first, otherwise appsettings.json.
        var serverSettings = await LoadServerSettingsAsync();

        // 2. Tenant override (if any) merged on top of the server defaults.
        var resolvedTenantId = tenantId ?? _tenantContext.GetCurrentTenantId();
        if (resolvedTenantId.HasValue)
        {
            var tenantSettings = await _emailSettingsRepository.GetActiveTenantSettingsAsync(resolvedTenantId.Value);
            if (tenantSettings != null)
            {
                _logger.LogDebug("Merging tenant email settings for tenant {TenantId} onto server defaults", resolvedTenantId);

                // A null merge result is a deliberate refusal, not a miss: do not fall back to the server settings.
                return MergeWithTenant(serverSettings, tenantSettings, resolvedTenantId.Value);
            }
        }

        return serverSettings;
    }

    private async Task<EmailSettings> LoadServerSettingsAsync()
    {
        try
        {
            var systemSettings = await _settingsService.GetEmailSettingsAsync();
            if (systemSettings != null && !string.IsNullOrWhiteSpace(systemSettings.FromAddress))
            {
                _logger.LogDebug("Using system-wide email settings from Setting table");
                return systemSettings;
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to load system-wide email settings from database");
        }

        _logger.LogDebug("Falling back to email settings from appsettings.json");
        return GetDefaultEmailSettingsFromConfiguration();
    }

    private EmailSettings? MergeWithTenant(EmailSettings server, Domain.Entities.TenantEmailSettings tenant, Guid tenantId)
    {
        // Host, username and password form one atomic override group: the installation-wide relay
        // credentials must never be presented to an SMTP host a tenant picked.
        var isForeignHost = IsForeignSmtpHost(tenant.SmtpHost, server.SmtpHost);
        var hasOwnSmtpCredentials = !string.IsNullOrWhiteSpace(tenant.SmtpUsername)
                                    && !string.IsNullOrWhiteSpace(tenant.SmtpPassword);

        // What waives the guard is provenance, not equality: a half stays the operator's only while
        // the tenant supplies nothing for it. A tenant that echoes the server's own host back —
        // "localhost" on a stock install is a guess, not a secret — is choosing that value and is
        // checked like any other caller. The conditions below are the ones Coalesce and ?? use, so a
        // surviving mark always describes the server's own string rather than a matching copy of it.
        //
        // The three dimensions are carried separately because SmtpHostPolicy judges them separately
        // (SmtpEndpointGuard): the operator's host stays exempt from the private-address check when
        // the tenant only picks another port, and a port the tenant picked is checked even on the
        // operator's own host. Coupling them would refuse an operator relay on the LAN as soon as a
        // tenant moved from 25 to 587 — a working installation, stopped silently. The transport flag
        // is the third: only the operator's own SmtpEnableSsl=false can ask for a cleartext session,
        // so a tenant cannot flip even the operator's loopback relay out of TLS (F34).
        //
        // This is deliberately not the test that governs credential inheritance below: isForeignHost
        // asks "would these credentials reach someone other than the server's own relay", which an
        // echoed host does not, so such a tenant still inherits them exactly as it did (F3).
        var keepsServerSmtpHost = server.SmtpHostIsOperatorConfigured
                                  && string.IsNullOrWhiteSpace(tenant.SmtpHost);
        var keepsServerSmtpPort = server.SmtpPortIsOperatorConfigured && tenant.SmtpPort is null;
        var keepsServerSmtpEnableSsl = server.SmtpEnableSslIsOperatorConfigured && tenant.SmtpEnableSsl is null;

        if (isForeignHost)
        {
            _logger.LogWarning(
                "Tenant {TenantId} overrides the SMTP host with {SmtpHost}; server-level SMTP credentials are not inherited by a tenant-chosen host",
                tenantId, tenant.SmtpHost);

            // Without credentials of its own the message would be relayed anonymously through a
            // tenant-chosen host from the installation's network identity, so fail closed instead.
            if (tenant.ProviderType == EmailProviderType.Smtp && !hasOwnSmtpCredentials)
            {
                _logger.LogError(
                    "Refusing to send email for tenant {TenantId}: SMTP host {SmtpHost} is tenant-configured but the tenant supplied no SMTP credentials of its own",
                    tenantId, tenant.SmtpHost);
                return null;
            }
        }

        return new EmailSettings
        {
            ProviderType = tenant.ProviderType,
            SmtpHost = Coalesce(tenant.SmtpHost, server.SmtpHost),
            SmtpPort = tenant.SmtpPort ?? server.SmtpPort,
            SmtpUsername = isForeignHost ? tenant.SmtpUsername : Coalesce(tenant.SmtpUsername, server.SmtpUsername),
            SmtpPassword = isForeignHost ? tenant.SmtpPassword : Coalesce(tenant.SmtpPassword, server.SmtpPassword),
            SmtpEnableSsl = tenant.SmtpEnableSsl ?? server.SmtpEnableSsl,
            SmtpHostIsOperatorConfigured = keepsServerSmtpHost,
            SmtpPortIsOperatorConfigured = keepsServerSmtpPort,
            SmtpEnableSslIsOperatorConfigured = keepsServerSmtpEnableSsl,
            M365TenantId = Coalesce(tenant.M365TenantId, server.M365TenantId),
            M365ClientId = Coalesce(tenant.M365ClientId, server.M365ClientId),
            M365ClientSecret = Coalesce(tenant.M365ClientSecret, server.M365ClientSecret),
            M365SenderAddress = Coalesce(tenant.M365SenderAddress, server.M365SenderAddress),
            FromAddress = Coalesce(tenant.FromAddress, server.FromAddress) ?? string.Empty,
            FromName = Coalesce(tenant.FromName, server.FromName) ?? string.Empty,
            ReplyToAddress = Coalesce(tenant.ReplyToAddress, server.ReplyToAddress),
            ReplyToName = Coalesce(tenant.ReplyToName, server.ReplyToName)
        };
    }

    private static string? Coalesce(string? primary, string? fallback)
        => string.IsNullOrWhiteSpace(primary) ? fallback : primary;

    /// <summary>
    /// True when the tenant points SMTP at a host other than the server-configured one.
    /// An empty tenant host means "no override" and is never foreign.
    /// </summary>
    private static bool IsForeignSmtpHost(string? tenantHost, string? serverHost)
        => !string.IsNullOrWhiteSpace(tenantHost)
           && !string.Equals(tenantHost.Trim(), serverHost?.Trim(), StringComparison.OrdinalIgnoreCase);

    private EmailSettings GetDefaultEmailSettingsFromConfiguration()
    {
        var providerTypeString = _configuration["EmailSettings:ProviderType"];
        if (!Enum.TryParse<EmailProviderType>(providerTypeString, out var providerType))
        {
            providerType = EmailProviderType.Smtp;
        }

        return new EmailSettings
        {
            ProviderType = providerType,
            SmtpHost = _configuration["EmailSettings:SmtpHost"],
            SmtpPort = int.TryParse(_configuration["EmailSettings:SmtpPort"], out var port) ? port : 587,
            SmtpUsername = _configuration["EmailSettings:SmtpUsername"],
            SmtpPassword = _configuration["EmailSettings:SmtpPassword"],
            SmtpEnableSsl = !bool.TryParse(_configuration["EmailSettings:SmtpEnableSsl"], out var enableSsl) || enableSsl,
            // appsettings is operator configuration, so this endpoint is not the one SmtpHostPolicy
            // guards, and its transport flag is the operator's own answer.
            SmtpHostIsOperatorConfigured = true,
            SmtpPortIsOperatorConfigured = true,
            SmtpEnableSslIsOperatorConfigured = true,
            M365TenantId = _configuration["EmailSettings:M365TenantId"],
            M365ClientId = _configuration["EmailSettings:M365ClientId"],
            M365ClientSecret = _configuration["EmailSettings:M365ClientSecret"],
            M365SenderAddress = _configuration["EmailSettings:M365SenderAddress"],
            FromAddress = _configuration["EmailSettings:FromAddress"] ?? "noreply@aserp.com",
            FromName = _configuration["EmailSettings:FromName"] ?? "asERP",
            ReplyToAddress = _configuration["EmailSettings:ReplyToAddress"],
            ReplyToName = _configuration["EmailSettings:ReplyToName"]
        };
    }
}
