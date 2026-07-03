using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface IShippingRepository : IGenericRepository<Shipping>
{
    Task<Shipping?> GetWithDetailsAsync(Guid id);
    Task<List<Shipping>> GetBySalesIdAsync(Guid salesId);
    Task<List<SalesItem>> GetAssignedSalesItemsAsync(Guid shippingId);

    /// <summary>Stamps <c>ShippingId</c> on the given order lines via a tracked update.</summary>
    Task AssignSalesItemsAsync(Guid shippingId, ICollection<Guid> salesItemIds);

    /// <summary>Latest label-outbox row for the shipment, if any — surfaces queue state in the detail DTO.</summary>
    Task<ShippingLabelOutbox?> GetLabelOutboxAsync(Guid shippingId);
}
