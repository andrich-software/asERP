using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;

namespace asToolkit.Persistence.Repositories;

public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
{
    public ManufacturerRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }
}