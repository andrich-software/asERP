using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Commands.ReturnCancel;

public class ReturnCancelHandler : IRequestHandler<ReturnCancelCommand, Result<Guid>>
{
    private static readonly ReturnShipmentStatus[] CancellableStatuses =
    [
        ReturnShipmentStatus.Requested,
        ReturnShipmentStatus.LabelCreated,
        ReturnShipmentStatus.InTransit
    ];

    private readonly IAppLogger<ReturnCancelHandler> _logger;
    private readonly IReturnShipmentRepository _returnShipmentRepository;
    private readonly IReturnCarrierService _returnCarrierService;
    private readonly IReturnStatusUpdater _returnStatusUpdater;

    public ReturnCancelHandler(
        IAppLogger<ReturnCancelHandler> logger,
        IReturnShipmentRepository returnShipmentRepository,
        IReturnCarrierService returnCarrierService,
        IReturnStatusUpdater returnStatusUpdater)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
        _returnCarrierService = returnCarrierService ?? throw new ArgumentNullException(nameof(returnCarrierService));
        _returnStatusUpdater = returnStatusUpdater ?? throw new ArgumentNullException(nameof(returnStatusUpdater));
    }

    public async Task<Result<Guid>> Handle(ReturnCancelCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Cancelling return with ID: {Id}", request.Id);

        // Best-effort carrier warnings collected along the way; they ride along on the result.
        var warnings = new List<string>();

        try
        {
            var existsGlobally = await _returnShipmentRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                _logger.LogWarning("Return not found: {Id}", request.Id);
                throw new NotFoundException("ReturnShipment", request.Id);
            }

            var returnShipment = await _returnShipmentRepository.GetByIdAsync(request.Id);
            if (returnShipment == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for return {Id}", request.Id);
                throw new NotFoundException("ReturnShipment", request.Id);
            }

            if (!CancellableStatuses.Contains(returnShipment.Status))
            {
                return Result<Guid>.Invalid(ErrorCodes.Returns.Invalid, $"A return in status {returnShipment.Status} cannot be cancelled.");
            }

            // Void at the carrier is best effort — a failed void must not block the local cancel.
            if (!string.IsNullOrEmpty(returnShipment.CarrierShipmentId))
            {
                var cancelResult = await _returnCarrierService.CancelReturnLabelAsync(returnShipment.Id, cancellationToken);
                if (!cancelResult.Succeeded)
                {
                    _logger.LogWarning("Carrier-side cancel failed for return {Id}: {Messages}",
                        returnShipment.Id, string.Join("; ", cancelResult.Messages));
                    warnings.AddRange(cancelResult.Messages);
                }
            }

            // Close a still-pending label-outbox row so the drainer never buys a label for a
            // cancelled return.
            var outbox = await _returnShipmentRepository.GetLabelOutboxAsync(returnShipment.Id);
            if (outbox is { Status: ShippingOutboxStatus.Pending or ShippingOutboxStatus.InFlight })
            {
                outbox.Status = ShippingOutboxStatus.Done;
                outbox.CompletedAt = DateTime.UtcNow;
                outbox.LastError = "Return cancelled before the label was created.";
                await _returnShipmentRepository.SaveChangesAsync(cancellationToken);
            }

            var statusResult = await _returnStatusUpdater.ApplyStatusAsync(
                returnShipment.Id,
                ReturnShipmentStatus.Cancelled,
                cancellationToken: cancellationToken);

            if (!statusResult.Succeeded)
            {
                return Result<Guid>.From(statusResult, request.Id, warnings);
            }

            _logger.LogInformation("Successfully cancelled return with ID: {Id}", returnShipment.Id);
            return Result<Guid>.Ok(returnShipment.Id, warnings);
        }
        catch (NotFoundException)
        {
            throw;
        }
    }
}
