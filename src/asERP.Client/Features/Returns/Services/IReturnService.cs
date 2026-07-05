using asERP.Domain.Dtos.Returns;

namespace asERP.Client.Features.Returns.Services;

/// <summary>
/// Service interface for return (RMA) API operations.
/// </summary>
public interface IReturnService
{
    /// <summary>Gets the shipped order lines that can (still) be returned.</summary>
    Task<List<ReturnableSalesItemDto>> GetReturnableItemsAsync(Guid salesId, CancellationToken ct = default);

    /// <summary>Creates a return for a sales order and returns the new return id.</summary>
    Task<Guid> CreateReturnAsync(ReturnShipmentInputDto input, CancellationToken ct = default);

    /// <summary>Gets a single return incl. its items.</summary>
    Task<ReturnShipmentDetailDto?> GetReturnAsync(Guid id, CancellationToken ct = default);

    /// <summary>Records the goods receipt of a return (per-item condition + serial numbers).</summary>
    Task ReceiveReturnAsync(Guid id, ReturnReceiveInputDto input, CancellationToken ct = default);

    /// <summary>Cancels a return before receipt (carrier void runs server-side, best effort).</summary>
    Task CancelReturnAsync(Guid id, CancellationToken ct = default);

    /// <summary>Closes a received return as Completed (or Rejected).</summary>
    Task CompleteReturnAsync(Guid id, bool reject = false, CancellationToken ct = default);

    /// <summary>Re-queues the return-label creation after a dead-lettered outbox row.</summary>
    Task RetryLabelAsync(Guid id, CancellationToken ct = default);
}
