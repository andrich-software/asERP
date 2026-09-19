using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface ITenantRepository : IGenericRepository<Tenant>
{
    Task DeleteTenantWithCascadeAsync(Guid tenantId, CancellationToken cancellationToken = default);

    /// <summary>
    /// True when no other Tenant in the current tenant collides with this one.
    /// Declared per repository on purpose: a uniqueness rule that silently does
    /// nothing is worse than none, so there is no inherited default to forget.
    /// </summary>
    Task<bool> IsUniqueAsync(Tenant entity, Guid? id = null);
}
