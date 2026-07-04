using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

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