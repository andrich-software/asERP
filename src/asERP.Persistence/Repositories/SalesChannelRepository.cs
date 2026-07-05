using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Domain.Dtos.WebAnalytics;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class SalesChannelRepository : GenericRepository<SalesChannel>, ISalesChannelRepository
{
    public SalesChannelRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {

    }

    public async Task<SalesChannel> GetDetails(Guid id)
    {
        // Tenant isolation via the global query filter.
        var salesChannel = await Context.SalesChannel
            .Include(s => s.Warehouses)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (salesChannel == null)
        {
            throw new NotFoundException("SalesChannel not found", id);
        }

        return salesChannel;
    }

    public async Task<List<SalesChannelTrackingRef>> GetEnabledTrackingChannelsAsync(CancellationToken cancellationToken = default)
    {
        // Anonymous, cross-tenant lookup for the ingest hot path: bypass the tenant query filter.
        // Only channels that are tracking-enabled and have a configured token hash are returned.
        return await Context.SalesChannel
            .IgnoreQueryFilters()
            .AsNoTracking()
            .Where(s => s.TrackingEnabled
                        && s.TenantId != null
                        && s.TrackingTokenHash != null
                        && s.TrackingTokenHash != "")
            .Select(s => new SalesChannelTrackingRef
            {
                SalesChannelId = s.Id,
                TenantId = s.TenantId!.Value,
                TrackingTokenHash = s.TrackingTokenHash!
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> SalesChannelIsUniqueAsync(SalesChannel salesChannel, Guid? id = null)
    {
        if (id == null)
        {
            return await Context.SalesChannel
                .AnyAsync(s => s.Name == salesChannel.Name) ? false : true;
        }

        return await Context.SalesChannel
            .AnyAsync(s => s.Name == salesChannel.Name && s.Id != id) ? false : true;
    }

    public override async Task UpdateAsync(SalesChannel entity)
    {
        // Snapshot the desired warehouse IDs up front. When the caller already loaded the entity
        // tracked (e.g. via GetDetails), EF identity resolution makes the query below return the
        // *same* instance, so clearing existing.Warehouses would also clear entity.Warehouses and
        // we would lose the IDs we are about to re-apply. Copy them before any mutation.
        var desiredWarehouseIds = entity.Warehouses?.Select(w => w.Id).ToList() ?? new List<Guid>();

        // Get the existing entity with its warehouses
        var existing = await Context.SalesChannel
            .Include(s => s.Warehouses)
            .FirstOrDefaultAsync(s => s.Id == entity.Id);

        if (existing == null)
        {
            throw new InvalidOperationException($"SalesChannel with ID {entity.Id} not found for update");
        }

        // Update scalar properties
        Context.Entry(existing).CurrentValues.SetValues(entity);

        // Update warehouse relationships. Batch-load all desired warehouses in one query instead of
        // issuing a FindAsync per id.
        existing.Warehouses.Clear();
        if (desiredWarehouseIds.Count > 0)
        {
            var warehouses = await Context.Warehouse
                .Where(w => desiredWarehouseIds.Contains(w.Id))
                .ToListAsync();
            foreach (var warehouse in warehouses)
            {
                existing.Warehouses.Add(warehouse);
            }
        }

        await Context.SaveChangesAsync();
    }

    public override async Task DeleteAsync(SalesChannel entity)
    {
        // Get the existing entity with its warehouses to properly handle many-to-many relationships
        var existingEntity = await Context.SalesChannel
            .Include(s => s.Warehouses)
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(e => e.Id == entity.Id);

        if (existingEntity == null)
        {
            throw new InvalidOperationException($"SalesChannel with ID {entity.Id} not found for deletion");
        }

        // Verify tenant isolation for security
        var currentTenantId = TenantContext.GetCurrentTenantId();
        EnsureDeletableByCurrentTenant(existingEntity.TenantId, currentTenantId);

        // Clear many-to-many relationships first
        existingEntity.Warehouses.Clear();

        // Remove the entity
        Context.Remove(existingEntity);
        await Context.SaveChangesAsync();
    }
}
