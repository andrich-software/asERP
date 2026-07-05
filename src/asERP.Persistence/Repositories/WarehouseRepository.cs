using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
{
    public WarehouseRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public override async Task<bool> IsUniqueAsync(Warehouse entity, Guid? id = null)
    {
        var currentTenantId = TenantContext.GetCurrentTenantId();

        var query = Context.Warehouse.AsQueryable();

        if (currentTenantId.HasValue)
        {
            query = query.Where(w => w.TenantId == currentTenantId.Value);
        }

        query = query.Where(w => w.Name == entity.Name);

        if (id.HasValue)
        {
            query = query.Where(w => w.Id != id.Value);
        }

        var exists = await query.AnyAsync();
        return !exists;
    }
}
