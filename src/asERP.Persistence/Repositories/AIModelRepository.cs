using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;

namespace asERP.Persistence.Repositories;

public class AiModelRepository : GenericRepository<AiModel>, IAiModelRepository
{
    public AiModelRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {

    }
}