namespace asERP.Domain.Dtos.ServerInfo;

public class ServerInfoResponseDto
{
    public bool RegistrationEnabled { get; set; }
    public string Version { get; set; } = string.Empty;

    /// <summary>
    /// Minimum client version required to connect to this server ("YYYY.MM.DD.run"),
    /// or null when the server does not enforce one.
    /// </summary>
    public string? MinimumClientVersion { get; set; }

    /// <summary>
    /// True while the server still awaits its initial setup (no user accounts yet) —
    /// the client then offers the setup wizard instead of the login form. Defaults to
    /// false so older servers without this field keep showing the normal login.
    /// </summary>
    public bool SetupRequired { get; set; }
}
