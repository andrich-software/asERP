namespace asERP.Client.Features.Auth.Models;

/// <summary>
/// A locally stored asERP server the user can connect to from the login screen.
/// Persisted as JSON in <c>ApplicationData.LocalSettings</c> via <c>IServerProfileStore</c>.
/// </summary>
public sealed class ServerProfile
{
    /// <summary>Fixed id of the always-present, non-removable asERP Cloud entry.</summary>
    public static readonly Guid BuiltInId = new("11111111-1111-1111-1111-111111111111");

    /// <summary>Url of the built-in asERP Cloud server.</summary>
    public const string BuiltInUrl = "https://www.aserp.de";

    /// <summary>Display name of the built-in asERP Cloud server.</summary>
    public const string BuiltInName = "asERP Cloud";

    /// <summary>Fixed id of the DEBUG-only local dev server entry (auto-seeded for convenience).</summary>
    public static readonly Guid LocalDevId = new("22222222-2222-2222-2222-222222222222");

    /// <summary>Url of the local dev server — matches the Server's <c>https</c> launch profile.</summary>
    public const string LocalDevUrl = "https://localhost:8443";

    /// <summary>Display name of the local dev server entry.</summary>
    public const string LocalDevName = "Local Dev";

    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    /// <summary>Normalized base url (with scheme, without trailing slash).</summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>True for the built-in asERP Cloud entry — it cannot be edited or deleted.</summary>
    public bool IsBuiltIn { get; set; }

    /// <summary>Last email used to log in to this server — pre-filled on the login screen.</summary>
    public string? LastUsedEmail { get; set; }

    /// <summary>When this server was last used to log in — drives default selection and ordering.</summary>
    public DateTimeOffset? LastUsedAt { get; set; }

    public static ServerProfile CreateBuiltIn() => new()
    {
        Id = BuiltInId,
        Name = BuiltInName,
        Url = BuiltInUrl,
        IsBuiltIn = true
    };

    /// <summary>A regular (editable/removable) profile pointing at the local dev server.</summary>
    public static ServerProfile CreateLocalDev() => new()
    {
        Id = LocalDevId,
        Name = LocalDevName,
        Url = LocalDevUrl,
        IsBuiltIn = false
    };
}
