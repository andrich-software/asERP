using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Application.Extensions;
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

        var result = new Result<Guid>();

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
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add($"A return in status {returnShipment.Status} cannot be cancelled.");
                return result;
            }

            // Void at the carrier is best effort — a failed void must not block the local cancel.
            if (!string.IsNullOrEmpty(returnShipment.CarrierShipmentId))
            {
                var cancelResult = await _returnCarrierService.CancelReturnLabelAsync(returnShipment.Id, cancellationToken);
                if (!cancelResult.Succeeded)
                {
                    _logger.LogWarning("Carrier-side cancel failed for return {Id}: {Messages}",
                        returnShipment.Id, string.Join("; ", cancelResult.Messages));
                    result.Messages.AddRange(cancelResult.Messages);
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
                result.Succeeded = false;
                result.StatusCode = statusResult.StatusCode;
                result.Messages.AddRange(statusResult.Messages);
                return result;
            }

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = returnShipment.Id;

            _logger.LogInformation("Successfully cancelled return with ID: {Id}", returnShipment.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while cancelling the return.",
                "Error cancelling return {Id}.", request.Id);
        }

        return result;
    }
}
