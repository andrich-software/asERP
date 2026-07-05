using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Services;

/// <summary>
/// Implements the field-by-field tenant→system fallback for OAuth Developer-App credentials.
/// Tenant-level row wins per non-empty field; missing fields fall back to system <c>Setting</c>
/// rows seeded by <c>SettingsInitializer</c>.
///
/// Reads happen with <c>IgnoreQueryFilters()</c> because the per-tenant settings table is
/// scoped via the explicit <c>TenantId</c> FK (sibling of <c>TenantEmailSettings</c>); the
/// service is used both inside tenant-scoped requests and from the OAuth callback which has
/// no tenant context yet.
/// </summary>
public sealed class OAuthAppSettingsService : IOAuthAppSettingsService
{
    private readonly ApplicationDbContext _context;
    private readonly ICredentialEncryptor _encryptor;

    public OAuthAppSettingsService(ApplicationDbContext context, ICredentialEncryptor encryptor)
    {
        _context = context;
        _encryptor = encryptor;
    }

    public async Task<Result<OAuthAppCredentials>> GetEffectiveCredentialsAsync(
        Guid tenantId,
        SalesChannelType provider,
        CancellationToken cancellationToken = default)
    {
        if (!IsSupportedProvider(provider))
        {
            return Result<OAuthAppCredentials>.Fail(
                ResultStatusCode.BadRequest,
                $"OAuth flow is not supported for provider {provider}.");
        }

        var prefix = provider.ToString(); // "eBay" / "Amazon" — matches the Setting key prefix in SettingsInitializer.
        var tenantRow = await _context.TenantOAuthAppSettings
            .IgnoreQueryFilters()
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.TenantId == tenantId && s.Provider == provider, cancellationToken);

        var tenantActive = tenantRow is { IsActive: true };

        // Batch-load all system-level OAuth settings for this provider in a single query instead of
        // issuing one round-trip per key.
        var keyPrefix = $"OAuth.{prefix}.";
        var systemSettings = await _context.Setting
            .AsNoTracking()
            .Where(s => s.Key.StartsWith(keyPrefix))
            .ToDictionaryAsync(s => s.Key, s => s, cancellationToken);

        string System(string suffix) => systemSettings.TryGetValue(keyPrefix + suffix, out var s) ? (s.Value ?? string.Empty) : string.Empty;
        string SystemSecret(string suffix)
        {
            if (!systemSettings.TryGetValue(keyPrefix + suffix, out var s)) return string.Empty;
            var raw = s.Value ?? string.Empty;
            return s.IsEncrypted ? _encryptor.Decrypt(raw) : raw;
        }

        var clientId = Pick(tenantActive ? tenantRow!.ClientId : null, System("ClientId"));
        var clientSecret = Pick(tenantActive ? tenantRow!.ClientSecret : null, SystemSecret("ClientSecret"));
        var authzEndpoint = Pick(null, // No tenant override — endpoints are vendor-fixed.
                                  System("AuthorizationEndpoint"));
        var tokenEndpoint = Pick(null, System("TokenEndpoint"));
        var redirectUri = Pick(tenantActive ? tenantRow!.RedirectUri : null, System("RedirectUri"));
        var ruName = Pick(tenantActive ? tenantRow!.RuName : null, System("RuName"));
        var scopes = Pick(tenantActive ? tenantRow!.Scopes : null, System("Scopes"));
        var useSandbox = (tenantActive ? tenantRow!.UseSandbox : null)
                             ?? ParseBool(System("UseSandbox"));

        if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
        {
            return Result<OAuthAppCredentials>.Fail(
                ResultStatusCode.BadRequest,
                $"OAuth credentials for {provider} are not configured. " +
                "Set ClientId/ClientSecret either at tenant level (TenantOAuthAppSettings) " +
                "or system level (Setting rows OAuth.{provider}.ClientId/ClientSecret).");
        }

        var source = ComputeSource(tenantActive, tenantRow, clientId, clientSecret);

        return Result<OAuthAppCredentials>.Success(new OAuthAppCredentials(
            ClientId: clientId,
            ClientSecret: clientSecret,
            AuthorizationEndpoint: authzEndpoint,
            TokenEndpoint: tokenEndpoint,
            RedirectUri: redirectUri,
            RuName: string.IsNullOrEmpty(ruName) ? null : ruName,
            Scopes: scopes ?? string.Empty,
            UseSandbox: useSandbox,
            Source: source));
    }

    private static bool IsSupportedProvider(SalesChannelType provider) =>
        provider is SalesChannelType.eBay or SalesChannelType.Amazon;

    private static string Pick(string? tenantValue, string systemValue) =>
        !string.IsNullOrWhiteSpace(tenantValue) ? tenantValue! : (systemValue ?? string.Empty);

    private static bool ParseBool(string? value) =>
        bool.TryParse(value, out var parsed) && parsed;

    private static OAuthCredentialSource ComputeSource(
        bool tenantActive,
        TenantOAuthAppSettings? tenantRow,
        string clientId,
        string clientSecret)
    {
        if (!tenantActive || tenantRow is null) return OAuthCredentialSource.System;

        var allFromTenant =
            !string.IsNullOrWhiteSpace(tenantRow.ClientId) && tenantRow.ClientId == clientId &&
            !string.IsNullOrWhiteSpace(tenantRow.ClientSecret) && tenantRow.ClientSecret == clientSecret;

        var anyFromTenant =
            !string.IsNullOrWhiteSpace(tenantRow.ClientId) ||
            !string.IsNullOrWhiteSpace(tenantRow.ClientSecret) ||
            !string.IsNullOrWhiteSpace(tenantRow.RedirectUri) ||
            !string.IsNullOrWhiteSpace(tenantRow.RuName) ||
            !string.IsNullOrWhiteSpace(tenantRow.Scopes) ||
            tenantRow.UseSandbox.HasValue;

        return allFromTenant ? OAuthCredentialSource.Tenant
             : anyFromTenant ? OAuthCredentialSource.Mixed
             : OAuthCredentialSource.System;
    }
}
