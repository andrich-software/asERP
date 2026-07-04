using asERP.Domain.Dtos.Tenant;
using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IUserTenantRepository : IGenericRepository<UserTenant>
{
    Task<List<TenantListDto>> GetUserTenantsAsync(string userId);
}