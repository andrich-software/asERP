using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface ITenantEmailSettingsRepository : IGenericRepository<TenantEmailSettings>
{
    /// <summary>
    /// Gets the active email settings for a specific tenant
    /// </summary>
    Task<TenantEmailSettings?> GetByTenantIdAsync(Guid tenantId);

    /// <summary>
    /// Gets the active email settings for a specific tenant, or null if none exists
    /// </summary>
    Task<TenantEmailSettings?> GetActiveTenantSettingsAsync(Guid tenantId);

    /// <summary>
    /// True when no other TenantEmailSettings in the current tenant collides with this one.
    /// Declared per repository on purpose: a uniqueness rule that silently does
    /// nothing is worse than none, so there is no inherited default to forget.
    /// </summary>
    Task<bool> IsUniqueAsync(TenantEmailSettings entity, Guid? id = null);
}
