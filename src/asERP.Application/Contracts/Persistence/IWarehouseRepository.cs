using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IWarehouseRepository : IGenericRepository<Warehouse>
{
    // bool IsUnique(string name);

    /// <summary>
    /// True when no other Warehouse in the current tenant collides with this one.
    /// Declared per repository on purpose: a uniqueness rule that silently does
    /// nothing is worse than none, so there is no inherited default to forget.
    /// </summary>
    Task<bool> IsUniqueAsync(Warehouse entity, Guid? id = null);
}
