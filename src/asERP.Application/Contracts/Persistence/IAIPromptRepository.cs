using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IAiPromptRepository : IGenericRepository<AiPrompt>
{
    Task<AiPrompt?> GetByIdentifier(string identifier);
    Task SaveChangesAsync();

    /// <summary>
    /// True when no other AiPrompt in the current tenant collides with this one.
    /// Declared per repository on purpose: a uniqueness rule that silently does
    /// nothing is worse than none, so there is no inherited default to forget.
    /// </summary>
    Task<bool> IsUniqueAsync(AiPrompt entity, Guid? id = null);
}
