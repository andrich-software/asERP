using asToolkit.Domain.Dtos.Tenant;

namespace asToolkit.Application.Contracts.Identity;

public interface IUserTenantService
{
    Task<List<TenantListDto>> GetUserTenantsAsync(string userId);
}