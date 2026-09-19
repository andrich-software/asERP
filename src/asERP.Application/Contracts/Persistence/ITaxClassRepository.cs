using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface ITaxClassRepository : IGenericRepository<TaxClass>
{
    Task<TaxClass?> GetByTaxRateAsync(double taxRate);

    /// <summary>
    /// True when no other TaxClass in the current tenant collides with this one.
    /// Declared per repository on purpose: a uniqueness rule that silently does
    /// nothing is worse than none, so there is no inherited default to forget.
    /// </summary>
    Task<bool> IsUniqueAsync(TaxClass entity, Guid? id = null);
}
