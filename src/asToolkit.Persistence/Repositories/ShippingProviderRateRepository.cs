using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Persistence.Repositories;

public class ShippingProviderRateRepository : GenericRepository<ShippingProviderRate>, IShippingProviderRateRepository
{
    public ShippingProviderRateRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<ShippingProviderRate?> GetWithCountriesAsync(Guid id)
    {
        var query = Context.ShippingProviderRate
            .Where(x => x.Id == id);

        // Apply manual tenant filtering
        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return await query
            .Include(x => x.ShippingProvider)
            .Include(x => x.AllowedCountries)
                .ThenInclude(c => c.Country)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<List<ShippingProviderRate>> GetByProviderAsync(Guid providerId)
    {
        var query = Context.ShippingProviderRate
            .Where(x => x.ShippingProviderId == providerId);

        // Apply manual tenant filtering
        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return await query
            .Include(x => x.AllowedCountries)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<bool> IsNameUniqueForProviderAsync(Guid providerId, string name, Guid? excludeId = null)
    {
        var query = Context.ShippingProviderRate
            .Where(x => x.ShippingProviderId == providerId && x.Name == name);

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
