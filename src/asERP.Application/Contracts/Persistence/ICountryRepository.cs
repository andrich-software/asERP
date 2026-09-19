using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface ICountryRepository : IGenericRepository<Country>
{
    Task<Country?> GetCountryByString(string country);

    /// <summary>
    /// True when no other Country in the current tenant collides with this one.
    /// Declared per repository on purpose: a uniqueness rule that silently does
    /// nothing is worse than none, so there is no inherited default to forget.
    /// </summary>
    Task<bool> IsUniqueAsync(Country entity, Guid? id = null);
}
