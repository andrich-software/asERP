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
}
