using asERP.Application.Contracts.Persistence;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public sealed class OAuthStateRepository : IOAuthStateRepository
{
    private readonly ApplicationDbContext _context;

    public OAuthStateRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(OAuthState entity)
    {
        await _context.OAuthState.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public Task<OAuthState?> GetByTokenAsync(string stateToken)
    {
        return _context.OAuthState
            .FirstOrDefaultAsync(s => s.StateToken == stateToken);
    }

    public async Task UpdateAsync(OAuthState entity)
    {
        entity.DateModified = DateTime.UtcNow;
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteExpiredAsync(DateTime cutoff)
    {
        // Periodic janitor op — bulk-delete server-side. The InMemory provider (tests) does not
        // support ExecuteDeleteAsync, so fall back to load-then-remove there.
        if (_context.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
        {
            var expired = await _context.OAuthState
                .Where(s => s.ExpiresAt < cutoff)
                .ToListAsync();

            if (expired.Count == 0) return 0;

            _context.OAuthState.RemoveRange(expired);
            await _context.SaveChangesAsync();
            return expired.Count;
        }

        return await _context.OAuthState
            .Where(s => s.ExpiresAt < cutoff)
            .ExecuteDeleteAsync();
    }
}
