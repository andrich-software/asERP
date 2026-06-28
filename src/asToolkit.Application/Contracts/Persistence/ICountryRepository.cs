using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface ITaxClassRepository : IGenericRepository<TaxClass>
{
    Task<TaxClass?> GetByTaxRateAsync(double taxRate);
}