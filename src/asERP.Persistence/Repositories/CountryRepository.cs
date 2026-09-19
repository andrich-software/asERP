using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<Country?> GetCountryByString(string country)
    {
        // Deterministic resolution: prefer an exact ISO-code match over a name match, then order by
        // code so the result never depends on storage/enumeration order.
        return await Context.Country
            .Where(c => c.Name == country || c.CountryCode == country)
            .OrderByDescending(c => c.CountryCode == country)
            .ThenBy(c => c.CountryCode)
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// A country is unique per tenant by name and by ISO code — the create/update
    /// validators report either collision with the same message.
    /// </summary>
    public async Task<bool> IsUniqueAsync(Country entity, Guid? id = null)
    {
        var currentTenantId = TenantContext.GetCurrentTenantId();

        var query = Context.Country.AsQueryable();

        if (currentTenantId.HasValue)
        {
            query = query.Where(c => c.TenantId == currentTenantId.Value);
        }

        query = query.Where(c => c.Name == entity.Name || c.CountryCode == entity.CountryCode);

        if (id.HasValue)
        {
            query = query.Where(c => c.Id != id.Value);
        }

        return !await query.AnyAsync();
    }
}
