using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IReturnShipmentRepository : IGenericRepository<ReturnShipment>
{
    Task<ReturnShipment?> GetWithDetailsAsync(Guid id);
    Task<List<ReturnShipment>> GetBySalesIdAsync(Guid salesId);

    /// <summary>
    /// Sum of returned quantities per order line over all returns of the order whose status is
    /// not Cancelled or Rejected. Single source of truth for the quantity accounting used by
    /// the create validator, the returnable-items query and the receive handler.
    /// </summary>
    Task<Dictionary<Guid, double>> GetReturnedQuantitiesAsync(Guid salesId);

    /// <summary>Latest return-label-outbox row for the return, if any — surfaces queue state in the detail DTO.</summary>
    Task<ReturnLabelOutbox?> GetLabelOutboxAsync(Guid returnShipmentId);

    /// <summary>Explicitly tracks new returned-serial rows as Added (graph discovery would mark
    /// them Modified because ids are not store-generated). Caller saves.</summary>
    void AddItemSerialNumbers(ICollection<ReturnShipmentItemSerialNumber> serialNumbers);
}
