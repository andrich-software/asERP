using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class AiPromptRepository : GenericRepository<AiPrompt>, IAiPromptRepository
{
    public AiPromptRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {

    }

    public async Task<AiPrompt?> GetByIdentifier(string identifier)
    {
        return await Entities.FirstOrDefaultAsync(p => p.Identifier == identifier);
    }

    public override async Task<bool> IsUniqueAsync(AiPrompt entity, Guid? id = null)
    {
        var currentTenantId = TenantContext.GetCurrentTenantId();

        var query = Context.AiPrompt.AsQueryable();

        if (currentTenantId.HasValue)
        {
            query = query.Where(p => p.TenantId == currentTenantId.Value);
        }

        query = query.Where(p => p.Identifier == entity.Identifier);

        if (id.HasValue)
        {
            query = query.Where(p => p.Id != id.Value);
        }

        var exists = await query.AnyAsync();
        return !exists;
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}