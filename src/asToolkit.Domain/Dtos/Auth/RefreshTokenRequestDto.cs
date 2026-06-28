using System.ComponentModel.DataAnnotations;

namespace asToolkit.Domain.Dtos.Auth;

public class RefreshTokenRequestDto
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}
