using System.ComponentModel.DataAnnotations;

namespace asERP.Domain.Dtos.Auth;

public class RefreshTokenRequestDto
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}
