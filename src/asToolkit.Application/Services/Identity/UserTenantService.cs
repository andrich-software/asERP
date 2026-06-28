using asToolkit.Application.Contracts.Identity;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Dtos.Tenant;

namespace asToolkit.Application.Services.Identity;

public class UserTenantService : IUserTenantService
{
    private readonly IUserTenantRepository _userTenantRepository;

    public UserTenantService(IUserTenantRepository userTenantRepository)
    {
        _userTenantRepository = userTenantRepository;
    }

    public async Task<List<TenantListDto>> GetUserTenantsAsync(string userId)
    {
        return await _userTenantRepository.GetUserTenantsAsync(userId);
    }
}