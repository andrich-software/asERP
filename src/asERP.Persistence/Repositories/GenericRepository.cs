using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities.Common;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace asERP.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext Context;
    protected readonly ITenantContext TenantContext;

    public GenericRepository(ApplicationDbContext context, ITenantContext tenantContext)
    {
        Context = context;
        TenantContext = tenantContext;
    }

    public IQueryable<TCt> GetContext<TCt>() where TCt : class => Context.Set<TCt>();

    // Tenant isolation is enforced by the global query filter in ApplicationDbContext — do not
    // re-filter on TenantId here (the filter is the contract).
    public IQueryable<T> Entities => Context.Set<T>().AsNoTracking();

    public void Attach(T entity)
    {
        Context.Set<T>().Attach(entity);
    }

    public void AttachRange(IEnumerable<T> entities)
    {
        Context.Set<T>().AttachRange(entities);
    }

    public async Task<Guid> CreateAsync(T entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<ICollection<T>> GetAllAsync()
    {
        // Tenant isolation via the global query filter.
        return await Context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id, bool asNoTracking = false)
    {
        // Tenant isolation via the global query filter.
        var query = Context.Set<T>().Where(x => x.Id == id);

        if (asNoTracking)
        {
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        // For tracking entities: load directly for proper Entity Framework tracking.
        return await query.FirstOrDefaultAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        // SECURITY: load the existing row's owner and verify tenant ownership before applying any
        // update. Callers frequently build a fresh detached entity without a TenantId; copying that
        // over the tracked row would null-out the owner and expose the row to every tenant.
        // Look up the owner without the query filter so a cross-tenant target is detected and rejected
        // (rather than silently updating zero rows).
        var ownerTenantId = await Context.Set<T>()
            .IgnoreQueryFilters()
            .Where(e => e.Id == entity.Id)
            .Select(e => e.TenantId)
            .FirstOrDefaultAsync();

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (ownerTenantId != null && currentTenantId.HasValue && ownerTenantId != currentTenantId)
        {
            throw new UnauthorizedAccessException("Cannot update entity from a different tenant");
        }

        // Never let the incoming entity change the persisted owner.
        entity.TenantId = ownerTenantId;

        // Ensure the entity is being tracked and mark it as modified
        var existingEntry = Context.ChangeTracker.Entries<T>().FirstOrDefault(e => e.Entity.Id == entity.Id);

        if (existingEntry != null)
        {
            // If it's the same entity reference, just mark as modified
            if (ReferenceEquals(existingEntry.Entity, entity))
            {
                Context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                // Update the existing tracked entity with values from the new entity
                Context.Entry(existingEntry.Entity).CurrentValues.SetValues(entity);
                Context.Entry(existingEntry.Entity).State = EntityState.Modified;
            }
            // TenantId must never be overwritten by an update.
            Context.Entry(existingEntry.Entity).Property(e => e.TenantId).IsModified = false;
        }
        else
        {
            // Attach and mark as modified if not already tracked
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.Entry(entity).Property(e => e.TenantId).IsModified = false;
        }

        await Context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        // First verify the entity exists and belongs to the current tenant
        var existingEntity = await Context.Set<T>().IgnoreQueryFilters()
            .FirstOrDefaultAsync(e => e.Id == entity.Id);

        if (existingEntity == null)
        {
            throw new InvalidOperationException($"Entity with ID {entity.Id} not found for deletion");
        }

        // SECURITY: verify tenant isolation. A row that has an owner may only be deleted by that
        // owner; a null tenant context may only delete tenant-agnostic (TenantId == null) rows.
        var currentTenantId = TenantContext.GetCurrentTenantId();
        EnsureDeletableByCurrentTenant(existingEntity.TenantId, currentTenantId);

        // Remove the existing entity (not the passed-in entity which may be incomplete)
        Context.Remove(existingEntity);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Enforces tenant ownership for deletes: an owned row (<paramref name="rowTenantId"/> set) may
    /// only be deleted when the current context owns it; a null tenant context may only delete
    /// tenant-agnostic rows.
    /// </summary>
    protected static void EnsureDeletableByCurrentTenant(Guid? rowTenantId, Guid? currentTenantId)
    {
        if (rowTenantId != null)
        {
            if (currentTenantId != rowTenantId)
            {
                throw new UnauthorizedAccessException("Cannot delete entity from a different tenant");
            }
        }
        else if (currentTenantId != null)
        {
            // A tenant-scoped context must not delete tenant-agnostic (global) rows.
            throw new UnauthorizedAccessException("Cannot delete a tenant-agnostic entity from a tenant context");
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        // Tenant isolation via the global query filter.
        return await Context.Set<T>().AsNoTracking().AnyAsync(e => e.Id == id);
    }

    public async Task<bool> ExistsGloballyAsync(Guid id)
    {
        // Check existence without tenant filtering - used for cross-tenant validation scenarios
        return await Context.Set<T>().IgnoreQueryFilters().AsNoTracking().AnyAsync(e => e.Id == id);
    }

    /// <summary>
    /// Default uniqueness check is a no-op (always unique). Entity-specific uniqueness is defined by
    /// the concrete repositories that override this (e.g. ProductRepository checks SKU); the base must
    /// not guess by reflecting over every scalar property — that produced one round-trip per property
    /// and wrongly rejected rows that merely shared a value in an unrelated column.
    /// </summary>
    public virtual Task<bool> IsUniqueAsync(T entity, Guid? id = null) => Task.FromResult(true);

    // Transaction support methods
    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }

    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }
}
