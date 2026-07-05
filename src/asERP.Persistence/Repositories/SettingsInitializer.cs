using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.Persistence.Repositories;

public class SettingsInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<SettingsInitializer> _logger;

    public SettingsInitializer(ApplicationDbContext context, ILogger<SettingsInitializer> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// The Jwt.Key value older migrations seeded via HasData. Databases created before the
    /// seed row was removed still carry it — and since it is publicly known from the
    /// open-source repo, anyone could forge valid JWTs against such an installation.
    /// </summary>
    private const string LegacyJwtKeyPlaceholder = "CHANGE_TO_YOUR_VERY_SECRET_JWT_SIGNING_KEY";

    /// <summary>
    /// Earlier releases seeded Grafana.LokiEndpoint without the /grafana path prefix. The
    /// reverse proxy only exposes Loki under /grafana/loki, so the old default never worked.
    /// </summary>
    private const string LegacyLokiEndpointDefault = "https://www.andrich-software.de/loki";
    private const string DefaultLokiEndpoint = "https://www.andrich-software.de/grafana/loki";

    public async Task EnsureRequiredSettingsExistAsync()
    {
        _logger.LogInformation("Checking for required settings...");

        // Get all required settings
        var requiredSettings = GetRequiredSettings();

        // Get existing settings from database
        var existingSettings = await _context.Setting.ToListAsync();
        var existingKeys = existingSettings.Select(s => s.Key).ToHashSet();

        // Find missing settings
        var missingSettings = requiredSettings
            .Where(s => !existingKeys.Contains(s.Key))
            .ToList();

        if (missingSettings.Count > 0)
        {
            _logger.LogInformation("Adding {Count} missing settings", missingSettings.Count);

            // Don't assign IDs manually - let the database generate them
            foreach (var setting in missingSettings)
            {
                await _context.Setting.AddAsync(setting);
            }

            await _context.SaveChangesAsync();
            _logger.LogInformation("Successfully added missing settings");
        }
        else
        {
            _logger.LogInformation("All required settings are present");
        }

        await ReplaceLegacyJwtKeyPlaceholderAsync(existingSettings);
        await ReplaceLegacyLokiEndpointDefaultAsync(existingSettings);
    }

    /// <summary>
    /// Self-heals installations still pointing at the never-reachable legacy Loki default.
    /// Only the untouched default is rewritten — custom endpoints are left alone.
    /// </summary>
    private async Task ReplaceLegacyLokiEndpointDefaultAsync(List<Setting> existingSettings)
    {
        var lokiEndpointSetting = existingSettings.FirstOrDefault(s => s.Key == "Grafana.LokiEndpoint");
        if (lokiEndpointSetting == null || lokiEndpointSetting.Value != LegacyLokiEndpointDefault)
        {
            return;
        }

        lokiEndpointSetting.Value = DefaultLokiEndpoint;
        await _context.SaveChangesAsync();

        _logger.LogInformation("Grafana.LokiEndpoint was updated from the legacy default to {Endpoint}", DefaultLokiEndpoint);
    }

    /// <summary>
    /// Self-heals installations whose Jwt.Key still holds the legacy seeded placeholder by
    /// replacing it with a freshly generated random key. Access tokens signed with the old
    /// key become invalid immediately, but clients re-authenticate silently via their
    /// (database-backed, non-JWT) refresh tokens.
    /// </summary>
    private async Task ReplaceLegacyJwtKeyPlaceholderAsync(List<Setting> existingSettings)
    {
        var jwtKeySetting = existingSettings.FirstOrDefault(s => s.Key == "Jwt.Key");
        if (jwtKeySetting == null || jwtKeySetting.Value != LegacyJwtKeyPlaceholder)
        {
            return;
        }

        _logger.LogWarning("Jwt.Key still holds the publicly known seed placeholder — replacing it with a generated random key");

        jwtKeySetting.Value = GenerateJwtSecretKey();
        await _context.SaveChangesAsync();

        _logger.LogInformation("Jwt.Key was rotated to a per-installation random key");
    }

    private static List<Setting> GetRequiredSettings()
    {
        // Define all settings that should exist in the system
        // This reuses settings from SettingsSeeder and adds any additional required settings
        return new List<Setting>
        {
            // Company Information
            new Setting { Key = "Company.Name", Value = "Musterfirma GmbH" },
            new Setting { Key = "Company.Address", Value = "Musterstraße 123" },
            new Setting { Key = "Company.ZipCity", Value = "12345 Musterstadt" },
            new Setting { Key = "Company.Country", Value = "Deutschland" },
            new Setting { Key = "Company.Phone", Value = "+49 123 456789" },
            new Setting { Key = "Company.Email", Value = "info@musterfirma.de" },
            new Setting { Key = "Company.Website", Value = "www.musterfirma.de" },
            new Setting { Key = "Company.TaxId", Value = "123/456/7890" },
            new Setting { Key = "Company.VatId", Value = "DE123456789" },
            new Setting { Key = "Company.BankName", Value = "Musterbank" },
            new Setting { Key = "Company.Iban", Value = "DE89 3704 0044 0532 0130 00" },
            new Setting { Key = "Company.Bic", Value = "MUSTDEXXX" },
            new Setting { Key = "Company.LogoPath", Value = "" },
            
            // System Settings
            new Setting { Key = "System.Theme", Value = "Light" },
            new Setting { Key = "System.DefaultLanguage", Value = "de-DE" },
            new Setting { Key = "System.CurrencyFormat", Value = "€ #,##0.00" },
            new Setting { Key = "System.DateFormat", Value = "dd.MM.yyyy" },
            
            // Invoice Settings
            new Setting { Key = "Invoice.NumberFormat", Value = "INV-{YEAR}-{NUMBER}" },
            new Setting { Key = "Invoice.DefaultPaymentTerms", Value = "14" },
            new Setting { Key = "Invoice.DefaultFooterText", Value = "Vielen Dank für Ihren Einkauf!" },
            
            // Sales Settings
            new Setting { Key = "Sales.NumberFormat", Value = "ORD-{YEAR}-{NUMBER}" },
            new Setting { Key = "Sales.DefaultStatus", Value = "New" },
            
            // Notification Settings
            new Setting { Key = "Notification.SalesEmail", Value = "True" },
            new Setting { Key = "Notification.InvoiceEmail", Value = "True" },
            new Setting { Key = "Notification.LowStockAlert", Value = "True" },
            new Setting { Key = "Notification.LowStockThreshold", Value = "5" },
            
            // JWT Settings
            new Setting { Key = "Jwt.Key", Value = GenerateJwtSecretKey() },
            new Setting { Key = "Jwt.Issuer", Value = "asERP.Server" },
            new Setting { Key = "Jwt.Audience", Value = "asERP.Client" },
            new Setting { Key = "Jwt.DurationInMinutes", Value = "60" },
            new Setting { Key = "Jwt.RefreshTokenExpireDays", Value = "30" },
            new Setting { Key = "Jwt.RefreshTokenExpireDaysShort", Value = "1" },

            // Email Settings - System-wide fallback configuration
            new Setting { Key = "Email.ProviderType", Value = "Smtp" },
            new Setting { Key = "Email.SmtpHost", Value = "localhost" },
            new Setting { Key = "Email.SmtpPort", Value = "1025" },
            new Setting { Key = "Email.SmtpUsername", Value = "" },
            new Setting { Key = "Email.SmtpPassword", Value = "", IsEncrypted = true },
            new Setting { Key = "Email.SmtpEnableSsl", Value = "False" },
            new Setting { Key = "Email.ApiKey", Value = "", IsEncrypted = true },
            new Setting { Key = "Email.FromAddress", Value = "noreply@aserp.local" },
            new Setting { Key = "Email.FromName", Value = "asERP System" },
            new Setting { Key = "Email.ReplyToAddress", Value = "" },
            new Setting { Key = "Email.ReplyToName", Value = "" },

            // Grafana / Loki Settings. The Loki sink appends /loki/api/v1/push to the endpoint;
            // the push route is protected by basic auth on the Grafana host (htpasswd), so a
            // user/password must be configured before enabling log shipping.
            new Setting { Key = "Grafana.Endpoint", Value = "https://www.andrich-software.de/grafana" },
            new Setting { Key = "Grafana.LokiEndpoint", Value = DefaultLokiEndpoint },
            new Setting { Key = "Grafana.LokiUser", Value = "worker" },
            new Setting { Key = "Grafana.LokiPassword", Value = "", IsEncrypted = true },
            new Setting { Key = "Grafana.OtlpEndpoint", Value = "" },
            new Setting { Key = "Grafana.MetricsEnabled", Value = "False" },
            new Setting { Key = "Grafana.LogsEnabled", Value = "False" },

            // ClickHouse (web analytics). Seeded from environment so docker-compose can point the
            // server at the bundled 'clickhouse' service; defaults to localhost for local dev. These
            // are the source of truth afterwards — edit them to use an external ClickHouse. No default
            // credentials are shipped: User/Password default empty (analytics stays off until
            // configured), and the password is flagged encrypted so writes go through the encryptor.
            new Setting { Key = "ClickHouse.Host", Value = Environment.GetEnvironmentVariable("CLICKHOUSE_HOST") ?? "localhost" },
            new Setting { Key = "ClickHouse.Port", Value = Environment.GetEnvironmentVariable("CLICKHOUSE_PORT") ?? "8123" },
            new Setting { Key = "ClickHouse.Database", Value = Environment.GetEnvironmentVariable("CLICKHOUSE_DB") ?? "aserp_analytics" },
            new Setting { Key = "ClickHouse.User", Value = Environment.GetEnvironmentVariable("CLICKHOUSE_USER") ?? "" },
            new Setting { Key = "ClickHouse.Password", Value = Environment.GetEnvironmentVariable("CLICKHOUSE_PASSWORD") ?? "", IsEncrypted = true },
            new Setting { Key = "ClickHouse.UseTls", Value = "False" },
            new Setting { Key = "ClickHouse.Enabled", Value = Environment.GetEnvironmentVariable("CLICKHOUSE_ENABLED") ?? "False" },

            // OAuth — generic
            // Public base URL the third-party redirects back to. Must be HTTPS in production
            // (eBay/Amazon enforce). e.g. "https://erp.acme.com".
            new Setting { Key = "OAuth.PublicBaseUrl", Value = "" },

            // OAuth — eBay (Developer-App fallback when no per-tenant override is set)
            new Setting { Key = "OAuth.Ebay.ClientId", Value = "" },
            new Setting { Key = "OAuth.Ebay.ClientSecret", Value = "", IsEncrypted = true },
            new Setting { Key = "OAuth.Ebay.RuName", Value = "" },
            new Setting { Key = "OAuth.Ebay.AuthorizationEndpoint", Value = "https://auth.ebay.com/oauth2/authorize" },
            new Setting { Key = "OAuth.Ebay.TokenEndpoint", Value = "https://api.ebay.com/identity/v1/oauth2/token" },
            new Setting { Key = "OAuth.Ebay.Scopes", Value = "https://api.ebay.com/oauth/api_scope https://api.ebay.com/oauth/api_scope/sell.inventory https://api.ebay.com/oauth/api_scope/sell.account https://api.ebay.com/oauth/api_scope/sell.fulfillment https://api.ebay.com/oauth/api_scope/sell.marketing https://api.ebay.com/oauth/api_scope/sell.finances" },
            new Setting { Key = "OAuth.Ebay.UseSandbox", Value = "False" },

            // OAuth — Amazon (LWA / SP-API)
            new Setting { Key = "OAuth.Amazon.ClientId", Value = "" },
            new Setting { Key = "OAuth.Amazon.ClientSecret", Value = "", IsEncrypted = true },
            new Setting { Key = "OAuth.Amazon.AppId", Value = "" },
            new Setting { Key = "OAuth.Amazon.RedirectUri", Value = "" },
            new Setting { Key = "OAuth.Amazon.AuthorizationEndpoint", Value = "https://sellercentral.amazon.com/apps/authorize/consent" },
            new Setting { Key = "OAuth.Amazon.TokenEndpoint", Value = "https://api.amazon.com/auth/o2/token" },
            new Setting { Key = "OAuth.Amazon.Scopes", Value = "" },
            new Setting { Key = "OAuth.Amazon.UseSandbox", Value = "False" }
        };
    }

    private static string GenerateJwtSecretKey()
    {
        // Generate a cryptographically secure 256-bit (32 bytes) key
        using var rng = RandomNumberGenerator.Create();
        var keyBytes = new byte[32];
        rng.GetBytes(keyBytes);
        return Convert.ToBase64String(keyBytes);
    }
}
