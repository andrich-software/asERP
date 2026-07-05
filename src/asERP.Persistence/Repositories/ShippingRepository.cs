using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class ShippingRepository : GenericRepository<Shipping>, IShippingRepository
{
    public ShippingRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<Shipping?> GetWithDetailsAsync(Guid id)
    {
        // Tenant isolation via the global query filter.
        return await Context.Shipping
            .Where(x => x.Id == id)
            .Include(x => x.ShippingProvider)
            .Include(x => x.ShippingProviderRate)
            .Include(x => x.Sales)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<List<Shipping>> GetBySalesIdAsync(Guid salesId)
    {
        // Tenant isolation via the global query filter.
        return await Context.Shipping
            .Where(x => x.SalesId == salesId)
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

    public Task AssignSalesItemsAsync(Guid shippingId, ICollection<Guid> salesItemIds)
    {
        return AssignSalesItemsAsync(shippingId,
            salesItemIds.Select(id => new SalesItemAssignment(id, null)).ToList());
    }

    public async Task AssignSalesItemsAsync(Guid shippingId, ICollection<SalesItemAssignment> assignments)
    {
        if (assignments.Count == 0)
        {
            return;
        }

        // Tracked load on purpose: the sales aggregate is fetched AsNoTracking elsewhere, so the
        // stamping must happen on tracked instances to be persisted.
        var itemIds = assignments.Select(a => a.SalesItemId).ToList();
        var items = await Context.SalesItem
            .Where(i => itemIds.Contains(i.Id))
            .ToListAsync();

        // TOCTOU guard: refuse items already claimed by another shipment. The caller runs this inside
        // a transaction, so a concurrent create that committed first is observed here and rejected
        // (surfaced as a conflict) instead of silently double-assigning the same line.
        var alreadyAssigned = items
            .Where(i => i.ShippingId != null && i.ShippingId != shippingId)
            .Select(i => i.Id)
            .ToList();
        if (alreadyAssigned.Count > 0)
        {
            throw new InvalidOperationException(
                $"Sales item(s) [{string.Join(", ", alreadyAssigned)}] are already assigned to another shipment.");
        }

        foreach (var assignment in assignments)
        {
            var item = items.First(i => i.Id == assignment.SalesItemId);

            // Within tolerance of the full line quantity → whole-line assignment, no split.
            if (assignment.Quantity is not double quantity
                || Math.Abs(item.Quantity - quantity) < SalesItemAssignment.QuantityTolerance)
            {
                item.ShippingId = shippingId;
                continue;
            }

            // The original row becomes the shipped part (serial-number rows stay attached to it);
            // the remainder is a new unassigned row. Price is per-unit, so amounts follow quantity.
            var remainder = Math.Round(item.Quantity - quantity, 4);
            item.Quantity = quantity;
            item.ShippingId = shippingId;

            if (remainder >= SalesItemAssignment.QuantityTolerance)
            {
                Context.SalesItem.Add(new SalesItem
                {
                    Id = Guid.NewGuid(),
                    SalesId = item.SalesId,
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Price = item.Price,
                    TaxRate = item.TaxRate,
                    MissingProductSku = item.MissingProductSku,
                    MissingProductEan = item.MissingProductEan,
                    Quantity = remainder,
                    ShippingId = null,
                    TenantId = item.TenantId
                });
            }
        }

        await Context.SaveChangesAsync();
    }

    public async Task<List<SalesItem>> GetAssignedSalesItemsAsync(Guid shippingId)
    {
        // Tenant isolation via the global query filter.
        return await Context.SalesItem
            .Where(x => x.ShippingId == shippingId)
            .ToListAsync();
    }

    public async Task<List<SalesItem>> GetAssignedSalesItemsWithSerialsAsync(Guid shippingId)
    {
        // Tenant isolation via the global query filter.
        return await Context.SalesItem
            .Where(x => x.ShippingId == shippingId)
            .Include(x => x.SerialNumbers)
            .ToListAsync();
    }
}
