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

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}