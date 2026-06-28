using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Exceptions;
using asToolkit.Domain.Dtos.WebAnalytics;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace asToolkit.Persistence.Repositories;

public class SalesChannelRepository : GenericRepository<SalesChannel>, ISalesChannelRepository
{
    public SalesChannelRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {

    }

    public async Task<SalesChannel> GetDetails(Guid id)
    {
        // Apply tenant filtering similar to GenericRepository
        var currentTenantId = TenantContext.GetCurrentTenantId();
        var query = Context.SalesChannel
            .Include(s => s.Warehouses)
            .AsQueryable();

        // Apply manual tenant filtering
        if (currentTenantId.HasValue)
        {
            query = query.Where(s => s.TenantId == null || s.TenantId == currentTenantId.Value);
        }
        else
        {
            query = query.Where(s => s.TenantId == null);
        }

        var salesChannel = await query.FirstOrDefaultAsync(s => s.Id == id);

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

        // Update warehouse relationships
        existing.Warehouses.Clear();
        foreach (var warehouseId in desiredWarehouseIds)
        {
            // Ensure warehouse is tracked
            var trackedWarehouse = await Context.Warehouse.FindAsync(warehouseId);
            if (trackedWarehouse != null)
            {
                existing.Warehouses.Add(trackedWarehouse);
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
        if (currentTenantId.HasValue && existingEntity.TenantId != null && existingEntity.TenantId != currentTenantId)
        {
            throw new UnauthorizedAccessException($"Cannot delete SalesChannel from different tenant");
        }

        // Clear many-to-many relationships first
        existingEntity.Warehouses.Clear();

        // Remove the entity
        Context.Remove(existingEntity);
        await Context.SaveChangesAsync();

        // For InMemory database scenarios, ensure the deletion is immediately visible across all scopes
        if (Context.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
        {
            // Clear change tracker to ensure fresh reads
            Context.ChangeTracker.Clear();

            // Force immediate garbage collection for InMemory database synchronization
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Verify deletion in InMemory database
            var verifyEntity = await Context.SalesChannel
                .IgnoreQueryFilters()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (verifyEntity != null)
            {
                // Force delete the entity directly from the context if it still exists
                Context.Entry(verifyEntity).State = EntityState.Deleted;
                await Context.SaveChangesAsync();
                Context.ChangeTracker.Clear();
            }
        }
    }
}