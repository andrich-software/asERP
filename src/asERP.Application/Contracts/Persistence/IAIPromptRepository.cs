using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IAiPromptRepository : IGenericRepository<AiPrompt>
{
    Task<AiPrompt?> GetByIdentifier(string identifier);
    Task SaveChangesAsync();
}