using asERP.Domain.Dtos.Tenant;
using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IUserTenantRepository : IGenericRepository<UserTenant>
{
    Task<List<TenantListDto>> GetUserTenantsAsync(string userId);

    /// <summary>
    /// True when no other UserTenant in the current tenant collides with this one.
    /// Declared per repository on purpose: a uniqueness rule that silently does
    /// nothing is worse than none, so there is no inherited default to forget.
    /// </summary>
    Task<bool> IsUniqueAsync(UserTenant entity, Guid? id = null);
}
