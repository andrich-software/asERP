namespace maERP.Client.Features.Auth.Models;

/// <summary>
/// A locally stored maERP server the user can connect to from the login screen.
/// Persisted as JSON in <c>ApplicationData.LocalSettings</c> via <c>IServerProfileStore</c>.
/// </summary>
public sealed class ServerProfile
{
    /// <summary>Fixed id of the always-present, non-removable maERP Cloud entry.</summary>
    public static readonly Guid BuiltInId = new("11111111-1111-1111-1111-111111111111");

    /// <summary>Url of the built-in maERP Cloud server.</summary>
    public const string BuiltInUrl = "https://www.maerp.de";

    /// <summary>Display name of the built-in maERP Cloud server.</summary>
    public const string BuiltInName = "maERP Cloud";

    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    /// <summary>Normalized base url (with scheme, without trailing slash).</summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>True for the built-in maERP Cloud entry — it cannot be edited or deleted.</summary>
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
}
