using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Persistence.Repositories;

public class ShippingRepository : GenericRepository<Shipping>, IShippingRepository
{
    public ShippingRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<Shipping?> GetWithDetailsAsync(Guid id)
    {
        var query = Context.Shipping
            .Where(x => x.Id == id);

        // Apply manual tenant filtering
        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return await query
            .Include(x => x.ShippingProvider)
            .Include(x => x.ShippingProviderRate)
            .Include(x => x.Sales)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<List<Shipping>> GetBySalesIdAsync(Guid salesId)
    {
        var query = Context.Shipping
            .Where(x => x.SalesId == salesId);

        // Apply manual tenant filtering
        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return await query
            .Include(x => x.ShippingProvider)
            .Include(x => x.ShippingProviderRate)
            .OrderByDescending(x => x.DateCreated)
            .ToListAsync();
    }

    public async Task<ShippingLabelOutbox?> GetLabelOutboxAsync(Guid shippingId)
    {
        return await Context.ShippingLabelOutbox
            .Where(x => x.ShippingId == shippingId)
            .OrderByDescending(x => x.DateCreated)
            .FirstOrDefaultAsync();
    }

    public async Task AssignSalesItemsAsync(Guid shippingId, ICollection<Guid> salesItemIds)
    {
        if (salesItemIds.Count == 0)
        {
            return;
        }

        // Tracked load on purpose: the sales aggregate is fetched AsNoTracking elsewhere, so the
        // stamping must happen on tracked instances to be persisted.
        var items = await Context.SalesItem
            .Where(i => salesItemIds.Contains(i.Id))
            .ToListAsync();

        foreach (var item in items)
        {
            item.ShippingId = shippingId;
        }

        await Context.SaveChangesAsync();
    }

    public async Task<List<SalesItem>> GetAssignedSalesItemsAsync(Guid shippingId)
    {
        var query = Context.SalesItem
            .Where(x => x.ShippingId == shippingId);

        // Apply manual tenant filtering
        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return await query.ToListAsync();
    }
}
