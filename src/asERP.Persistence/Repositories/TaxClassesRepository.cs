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

    /// <summary>
    /// A tax class is unique per tenant by its rate — two classes with the same
    /// percentage would make the rate ambiguous when mapping imported orders.
    /// </summary>
    public async Task<bool> IsUniqueAsync(TaxClass entity, Guid? id = null)
    {
        var currentTenantId = TenantContext.GetCurrentTenantId();

        var query = Context.TaxClass.AsQueryable();

        if (currentTenantId.HasValue)
        {
            query = query.Where(t => t.TenantId == currentTenantId.Value);
        }

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        query = query.Where(t => t.TaxRate == entity.TaxRate);

        if (id.HasValue)
        {
            query = query.Where(t => t.Id != id.Value);
        }

        return !await query.AnyAsync();
    }
}
