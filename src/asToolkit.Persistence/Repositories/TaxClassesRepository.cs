using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Persistence.Repositories;

public class TaxClassRepository : GenericRepository<TaxClass>, ITaxClassRepository
{
    public TaxClassRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<TaxClass?> GetByTaxRateAsync(double taxRate)
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        return await Context.TaxClass.FirstOrDefaultAsync(p => p.TaxRate == taxRate);
    }
}