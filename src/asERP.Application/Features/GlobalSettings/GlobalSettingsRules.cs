namespace asERP.Application.Features.GlobalSettings;

/// <summary>
/// Shared visibility/secret rules for the Superadmin global-settings endpoints. Kept in one
/// place so the list query and the bulk update command can never disagree about which rows
/// are exposed and which values must be masked.
/// </summary>
public static class GlobalSettingsRules
{
    /// <summary>
    /// Keys never exposed or editable through the generic endpoint. <c>Jwt.Key</c> is the
    /// machine-generated signing key (rotated by <c>SettingsInitializer</c>); a UI edit could
    /// only break authentication.
    /// </summary>
    private static readonly HashSet<string> HiddenKeys = new(StringComparer.OrdinalIgnoreCase)
    {
        "Jwt.Key",
    };

    /// <summary>
    /// Prefixes never exposed or editable through the generic endpoint:
    /// <list type="bullet">
    /// <item><c>OAuth.</c> — managed by their own dedicated bundle endpoints (system OAuth apps),
    /// hidden here so the same value is not editable through two doors.</item>
    /// <item><c>Company.</c> — company/sender data moved to the tenant level; legacy rows in older
    /// databases are hidden here so they never reappear in the Superadmin UI.</item>
    /// </list>
    /// </summary>
    private static readonly string[] HiddenPrefixes = ["OAuth.", "Company."];

    /// <summary>
    /// Plaintext-credential keys that predate the per-row <c>IsEncrypted</c> flag. They are
    /// masked on read and migrated to the encrypted write path on their next save.
    /// </summary>
    private static readonly HashSet<string> SecretKeys = new(StringComparer.OrdinalIgnoreCase)
    {
        "Email.SmtpPassword",
        "Email.M365ClientSecret",
        "Email.ApiKey",
        "ClickHouse.Password",
        "Grafana.LokiPassword",
    };

    public static bool IsHidden(string key) =>
        HiddenKeys.Contains(key) ||
        HiddenPrefixes.Any(p => key.StartsWith(p, StringComparison.OrdinalIgnoreCase));

    public static bool IsSecret(string key, bool isEncrypted) =>
        isEncrypted || SecretKeys.Contains(key);
}
