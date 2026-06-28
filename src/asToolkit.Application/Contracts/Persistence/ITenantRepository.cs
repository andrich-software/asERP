using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface ITenantRepository : IGenericRepository<Tenant>
{
    Task DeleteTenantWithCascadeAsync(Guid tenantId, CancellationToken cancellationToken = default);
}