using asToolkit.Domain.Dtos.Tenant;
using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IUserTenantRepository : IGenericRepository<UserTenant>
{
    Task<List<TenantListDto>> GetUserTenantsAsync(string userId);
}