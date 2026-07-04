using asERP.Application.Models.Identity;

namespace asERP.Application.Contracts.Persistence;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}