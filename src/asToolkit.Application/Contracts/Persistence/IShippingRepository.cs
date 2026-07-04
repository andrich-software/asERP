using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IShippingRepository : IGenericRepository<Shipping>
{
    Task<Shipping?> GetWithDetailsAsync(Guid id);
    Task<List<Shipping>> GetBySalesIdAsync(Guid salesId);
    Task<List<SalesItem>> GetAssignedSalesItemsAsync(Guid shippingId);

    /// <summary>Assigned order lines incl. serial numbers — for packing-slip/pick-list documents.</summary>
    Task<List<SalesItem>> GetAssignedSalesItemsWithSerialsAsync(Guid shippingId);

    /// <summary>Stamps <c>ShippingId</c> on the given order lines via a tracked update.</summary>
    Task AssignSalesItemsAsync(Guid shippingId, ICollection<Guid> salesItemIds);

    /// <summary>Assigns order lines with optional partial quantities — a partial quantity splits
    /// the line into a shipped part (keeps the row identity) and an unassigned remainder row.</summary>
    Task AssignSalesItemsAsync(Guid shippingId, ICollection<SalesItemAssignment> assignments);

    /// <summary>Latest label-outbox row for the shipment, if any — surfaces queue state in the detail DTO.</summary>
    Task<ShippingLabelOutbox?> GetLabelOutboxAsync(Guid shippingId);
}
