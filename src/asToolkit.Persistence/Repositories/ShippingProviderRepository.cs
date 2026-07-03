using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Persistence.Repositories;

public class ShippingProviderRepository : GenericRepository<ShippingProvider>, IShippingProviderRepository
{
    public ShippingProviderRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<ShippingProvider?> GetWithRatesAsync(Guid id)
    {
        var query = Context.ShippingProvider
            .Where(x => x.Id == id);

        // Apply manual tenant filtering
        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return await query
            .Include(x => x.ShippingRates!)
                .ThenInclude(r => r.AllowedCountries)
                    .ThenInclude(c => c.Country)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<bool> IsNameUniqueAsync(string name, Guid? excludeId = null)
    {
        var query = Context.ShippingProvider
            .Where(x => x.Name == name);

        if (excludeId.HasValue)
        {
            query = query.Where(x => x.Id != excludeId.Value);
        }

        // Apply manual tenant filtering
        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return !await query.AnyAsync();
    }

    public async Task<bool> HasShipmentsAsync(Guid providerId)
    {
        return await Context.Shipping.AnyAsync(x => x.ShippingProviderId == providerId);
    }
}
