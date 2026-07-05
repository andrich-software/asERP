using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Contracts.Services;

/// <summary>
/// The single path for return status transitions — every change lands in SalesHistory
/// and raises SalesChangedNotification. All transitions are manual in v1 (no tracking poller).
/// </summary>
public interface IReturnStatusUpdater
{
    /// <summary>
    /// Applies a status change: no-op when unchanged, rejects transitions out of a terminal
    /// state (Completed/Rejected/Cancelled), stamps ReceivedAt, writes a SalesHistory entry
    /// and raises SalesChangedNotification.
    /// </summary>
    Task<Result> ApplyStatusAsync(
        Guid returnShipmentId,
        ReturnShipmentStatus newStatus,
        string? description = null,
        Guid? userId = null,
        CancellationToken cancellationToken = default);
}
