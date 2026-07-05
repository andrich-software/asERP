using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class ReturnShipmentRepository : GenericRepository<ReturnShipment>, IReturnShipmentRepository
{
    /// <summary>Returns in these states do not consume returnable quantity.</summary>
    private static readonly ReturnShipmentStatus[] NonCountingStatuses =
    [
        ReturnShipmentStatus.Cancelled,
        ReturnShipmentStatus.Rejected
    ];

    public ReturnShipmentRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<ReturnShipment?> GetWithDetailsAsync(Guid id)
    {
        // Tenant isolation via the global query filter.
        return await Context.ReturnShipment
            .Where(x => x.Id == id)
            .Include(x => x.Sales)
            .Include(x => x.ShippingProvider)
            .Include(x => x.Items)
                .ThenInclude(i => i.SalesItem)
                    .ThenInclude(s => s.SerialNumbers)
            .Include(x => x.Items)
                .ThenInclude(i => i.SerialNumbers)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<List<ReturnShipment>> GetBySalesIdAsync(Guid salesId)
    {
        // Tenant isolation via the global query filter.
        return await Context.ReturnShipment
            .Where(x => x.SalesId == salesId)
            .Include(x => x.Items)
            .OrderByDescending(x => x.DateCreated)
            .ToListAsync();
    }

    public async Task<Dictionary<Guid, double>> GetReturnedQuantitiesAsync(Guid salesId)
    {
        // Tenant isolation via the global query filter.
        return await Context.ReturnShipmentItem
            .Where(i => i.ReturnShipment.SalesId == salesId
                        && !NonCountingStatuses.Contains(i.ReturnShipment.Status))
            .GroupBy(i => i.SalesItemId)
            .Select(g => new { g.Key, Quantity = g.Sum(i => i.Quantity) })
            .ToDictionaryAsync(g => g.Key, g => g.Quantity);
    }

    public async Task<ReturnLabelOutbox?> GetLabelOutboxAsync(Guid returnShipmentId)
    {
        return await Context.ReturnLabelOutbox
            .Where(x => x.ReturnShipmentId == returnShipmentId)
            .OrderByDescending(x => x.DateCreated)
            .FirstOrDefaultAsync();
    }

    public void AddItemSerialNumbers(ICollection<ReturnShipmentItemSerialNumber> serialNumbers)
    {
        Context.ReturnShipmentItemSerialNumber.AddRange(serialNumbers);
    }
}
