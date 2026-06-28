using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IAiPromptRepository : IGenericRepository<AiPrompt>
{
    Task<AiPrompt?> GetByIdentifier(string identifier);
    Task SaveChangesAsync();
}