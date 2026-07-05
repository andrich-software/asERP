using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
{
    public ManufacturerRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public override async Task<bool> IsUniqueAsync(Manufacturer entity, Guid? id = null)
    {
        var currentTenantId = TenantContext.GetCurrentTenantId();

        var query = Context.Manufacturer.AsQueryable();

        if (currentTenantId.HasValue)
        {
            query = query.Where(m => m.TenantId == currentTenantId.Value);
        }

        query = query.Where(m => m.Name == entity.Name);

        if (id.HasValue)
        {
            query = query.Where(m => m.Id != id.Value);
        }

        var exists = await query.AnyAsync();
        return !exists;
    }
}