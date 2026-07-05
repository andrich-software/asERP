using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class ShippingProviderRateRepository : GenericRepository<ShippingProviderRate>, IShippingProviderRateRepository
{
    public ShippingProviderRateRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<ShippingProviderRate?> GetWithCountriesAsync(Guid id)
    {
        // Tenant isolation via the global query filter.
        return await Context.ShippingProviderRate
            .Where(x => x.Id == id)
            .Include(x => x.ShippingProvider)
            .Include(x => x.AllowedCountries)
                .ThenInclude(c => c.Country)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<List<ShippingProviderRate>> GetByProviderAsync(Guid providerId)
    {
        // Tenant isolation via the global query filter.
        return await Context.ShippingProviderRate
            .Where(x => x.ShippingProviderId == providerId)
            .Include(x => x.AllowedCountries)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<bool> IsNameUniqueForProviderAsync(Guid providerId, string name, Guid? excludeId = null)
    {
        // Tenant isolation via the global query filter.
        var query = Context.ShippingProviderRate
            .Where(x => x.ShippingProviderId == providerId && x.Name == name);

        if (excludeId.HasValue)
        {
            query = query.Where(x => x.Id != excludeId.Value);
        }

        return !await query.AnyAsync();
    }

    public async Task<bool> HasShipmentsAsync(Guid rateId)
    {
        return await Context.Shipping.AnyAsync(x => x.ShippingProviderRateId == rateId);
    }

    public async Task ReplaceAllowedCountriesAsync(Guid rateId, ICollection<Guid> countryIds)
    {
        var existing = await Context.ShippingProviderRateCountry
            .Where(x => x.ShippingProviderRateId == rateId)
            .ToListAsync();

        Context.ShippingProviderRateCountry.RemoveRange(existing.Where(x => !countryIds.Contains(x.CountryId)));

        var currentTenantId = TenantContext.GetCurrentTenantId();
        var existingCountryIds = existing.Select(x => x.CountryId).ToHashSet();
        foreach (var countryId in countryIds.Where(c => !existingCountryIds.Contains(c)))
        {
            Context.ShippingProviderRateCountry.Add(new ShippingProviderRateCountry
            {
                ShippingProviderRateId = rateId,
                CountryId = countryId,
                TenantId = currentTenantId
            });
        }

        await Context.SaveChangesAsync();
    }
}
