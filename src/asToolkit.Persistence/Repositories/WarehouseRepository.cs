using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;

namespace asToolkit.Persistence.Repositories;

public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
{
    public WarehouseRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    /*
    public bool IsUnique(string name)
    {
        return !_context.Warehouse.Any(c => c.Name == name);
    }
    */
}