using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Persistence.Repositories;

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