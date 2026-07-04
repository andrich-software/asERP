using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface ITenantRepository : IGenericRepository<Tenant>
{
    Task DeleteTenantWithCascadeAsync(Guid tenantId, CancellationToken cancellationToken = default);
}