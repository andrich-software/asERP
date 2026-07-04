using asERP.Application.Contracts.Identity;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Dtos.Tenant;

namespace asERP.Application.Services.Identity;

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