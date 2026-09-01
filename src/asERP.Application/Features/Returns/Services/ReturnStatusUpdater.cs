using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Services;

public class ReturnStatusUpdater : IReturnStatusUpdater
{
    private static readonly ReturnShipmentStatus[] TerminalStatuses =
    [
        ReturnShipmentStatus.Completed,
        ReturnShipmentStatus.Rejected,
        ReturnShipmentStatus.Cancelled
    ];

    private readonly IAppLogger<ReturnStatusUpdater> _logger;
    private readonly IReturnShipmentRepository _returnShipmentRepository;
    private readonly ISalesRepository _salesRepository;
    private readonly IMediator _mediator;

    public ReturnStatusUpdater(
        IAppLogger<ReturnStatusUpdater> logger,
        IReturnShipmentRepository returnShipmentRepository,
        ISalesRepository salesRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result> ApplyStatusAsync(
        Guid returnShipmentId,
        ReturnShipmentStatus newStatus,
        string? description = null,
        Guid? userId = null,
        CancellationToken cancellationToken = default)
    {
        var returnShipment = await _returnShipmentRepository.GetByIdAsync(returnShipmentId);
        if (returnShipment == null)
        {
            return Result.NotFound(ErrorCodes.Returns.NotFound, $"Return {returnShipmentId} not found.");
        }

        var oldStatus = returnShipment.Status;

        if (oldStatus == newStatus)
        {
            return Result.Ok();
        }

        if (TerminalStatuses.Contains(oldStatus))
        {
            return Result.Invalid(ErrorCodes.Returns.Invalid,
                $"A return in status {oldStatus} cannot change its status anymore.");
        }

        returnShipment.Status = newStatus;

        if (newStatus == ReturnShipmentStatus.Received && returnShipment.ReceivedAt == null)
        {
            returnShipment.ReceivedAt = DateTime.UtcNow;
        }

        await _returnShipmentRepository.UpdateAsync(returnShipment);

        // Return statuses stay out of the ShippingStatusOld/New columns — the timeline UI
        // parses those as ShippingStatus values. The transition lives in the description.
        await _salesRepository.AddSalesHistoryAsync(new SalesHistory
        {
            SalesId = returnShipment.SalesId,
            UserId = userId ?? Guid.Empty,
            TenantId = returnShipment.TenantId,
            Description = string.IsNullOrEmpty(description)
                ? $"Return status changed {oldStatus} -> {newStatus}"
                : $"Return status changed {oldStatus} -> {newStatus}: {description}",
            MessageKey = string.IsNullOrEmpty(description)
                ? SalesHistoryMessage.ReturnStatusChanged
                : SalesHistoryMessage.ReturnStatusChangedWithNote,
            // The statuses travel as enum resource keys so the client localizes them even though
            // they have no typed column here; the free-text note is passed through as-is.
            MessageArgs = string.IsNullOrEmpty(description)
                ? SalesHistoryMessage.EncodeArgs(
                    SalesHistoryMessage.Enum(oldStatus), SalesHistoryMessage.Enum(newStatus))
                : SalesHistoryMessage.EncodeArgs(
                    SalesHistoryMessage.Enum(oldStatus), SalesHistoryMessage.Enum(newStatus), description),
            IsSystemGenerated = false
        });

        _logger.LogInformation("Return {ReturnId} status changed {Old} -> {New}", returnShipmentId, oldStatus, newStatus);

        await _mediator.Publish(
            new SalesChangedNotification(returnShipment.SalesId, returnShipment.TenantId, SalesChangeKind.StatusChanged),
            cancellationToken);

        return Result.Ok();
    }
}
