using asToolkit.Application.Models.Identity;

namespace asToolkit.Application.Contracts.Persistence;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}