using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IManufacturerRepository : IGenericRepository<Manufacturer>
{
    /// <summary>
    /// True when no other Manufacturer in the current tenant collides with this one.
    /// Declared per repository on purpose: a uniqueness rule that silently does
    /// nothing is worse than none, so there is no inherited default to forget.
    /// </summary>
    Task<bool> IsUniqueAsync(Manufacturer entity, Guid? id = null);
}
