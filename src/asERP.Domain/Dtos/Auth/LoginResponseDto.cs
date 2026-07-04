#nullable disable

using asERP.Domain.Dtos.Tenant;

namespace asERP.Domain.Dtos.Auth;

public class LoginResponseDto
{
    public string UserId { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiresAt { get; set; }
    public List<TenantListDto> AvailableTenants { get; set; } = new();
    public Guid? CurrentTenantId { get; set; }
}
