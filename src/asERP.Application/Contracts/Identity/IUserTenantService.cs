using asERP.Domain.Dtos.Tenant;

namespace asERP.Application.Contracts.Identity;

public interface IUserTenantService
{
    Task<List<TenantListDto>> GetUserTenantsAsync(string userId);
}