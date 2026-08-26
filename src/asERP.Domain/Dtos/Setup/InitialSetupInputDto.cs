namespace asERP.Domain.Dtos.Setup;

/// <summary>
/// Payload for the one-shot initial server setup: creates the first Superadmin account
/// together with the first tenant. Only accepted while the server reports
/// <c>SetupRequired</c> via <c>/api/v1/server-info</c>.
/// </summary>
public class InitialSetupInputDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string TenantName { get; set; } = string.Empty;
    public string TenantDescription { get; set; } = string.Empty;
}
