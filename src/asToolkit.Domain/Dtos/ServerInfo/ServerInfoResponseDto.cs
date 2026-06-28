namespace asToolkit.Domain.Dtos.ServerInfo;

public class ServerInfoResponseDto
{
    public bool RegistrationEnabled { get; set; }
    public string Version { get; set; } = string.Empty;
}
