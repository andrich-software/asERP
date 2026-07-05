using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace asERP.Persistence.Repositories;

public class TenantEmailSettingsRepository : ITenantEmailSettingsRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ITenantContext _tenantContext;

    public TenantEmailSettingsRepository(ApplicationDbContext context, ITenantContext tenantContext)
    {
        _context = context;
        _tenantContext = tenantContext;
    }

    // TenantEmailSettings is BaseEntityWithoutTenant, so no global query filter applies. Every read
    // that could span tenants must be scoped explicitly to the current tenant.
    public IQueryable<TenantEmailSettings> Entities => ScopedToCurrentTenant().AsNoTracking();

    private IQueryable<TenantEmailSettings> ScopedToCurrentTenant()
    {
        var query = _context.Set<TenantEmailSettings>().AsQueryable();
        var currentTenantId = _tenantContext.GetCurrentTenantId();
        return currentTenantId.HasValue
            ? query.Where(s => s.TenantId == currentTenantId.Value)
            // No tenant context → expose nothing (these rows are always tenant-owned).
            : query.Where(_ => false);
    }

    public async Task<TenantEmailSettings?> GetByTenantIdAsync(Guid tenantId)
    {
        return await _context.Set<TenantEmailSettings>()
            .Where(s => s.TenantId == tenantId)
            .FirstOrDefaultAsync();
    }

    public async Task<TenantEmailSettings?> GetActiveTenantSettingsAsync(Guid tenantId)
    {
        return await _context.Set<TenantEmailSettings>()
            .Where(s => s.TenantId == tenantId && s.IsActive)
            .FirstOrDefaultAsync();
    }

    public async Task<Guid> CreateAsync(TenantEmailSettings entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<ICollection<TenantEmailSettings>> GetAllAsync()
    {
        // Scoped to the current tenant — never return other tenants' SMTP credentials.
        return await ScopedToCurrentTenant()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TenantEmailSettings?> GetByIdAsync(Guid id, bool asNoTracking = false)
    {
        // Scoped to the current tenant — an id from another tenant resolves to null.
        var query = ScopedToCurrentTenant()
            .Where(x => x.Id == id);

        return asNoTracking
            ? await query.AsNoTracking().FirstOrDefaultAsync()
            : await query.FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(TenantEmailSettings entity)
    {
        entity.DateModified = DateTime.UtcNow;
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TenantEmailSettings entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Set<TenantEmailSettings>()
            .AsNoTracking()
            .AnyAsync(e => e.Id == id);
    }

    public async Task<bool> ExistsGloballyAsync(Guid id)
    {
        return await ExistsAsync(id);
    }

    public async Task<bool> IsUniqueAsync(TenantEmailSettings entity, Guid? id = null)
    {
        // Each tenant should only have one active email configuration
        var query = _context.Set<TenantEmailSettings>()
            .Where(s => s.TenantId == entity.TenantId && s.IsActive);

        if (id.HasValue)
        {
            query = query.Where(s => s.Id != id.Value);
        }

        return !await query.AnyAsync();
    }

    public void Attach(TenantEmailSettings entity)
    {
        _context.Set<TenantEmailSettings>().Attach(entity);
    }

    public void AttachRange(IEnumerable<TenantEmailSettings> entities)
    {
        _context.Set<TenantEmailSettings>().AttachRange(entities);
    }

    public IQueryable<TCt> GetContext<TCt>() where TCt : class
    {
        return _context.Set<TCt>();
    }

    // Transaction support methods
    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Add(TenantEmailSettings entity)
    {
        _context.Set<TenantEmailSettings>().Add(entity);
    }
}
