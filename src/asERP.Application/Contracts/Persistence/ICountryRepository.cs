using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface ITaxClassRepository : IGenericRepository<TaxClass>
{
    Task<TaxClass?> GetByTaxRateAsync(double taxRate);
}