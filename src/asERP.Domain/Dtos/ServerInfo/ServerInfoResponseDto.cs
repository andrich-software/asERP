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
}
