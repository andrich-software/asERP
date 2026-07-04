using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Commands.ShippingCancel;

public class ShippingCancelHandler : IRequestHandler<ShippingCancelCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingCancelHandler> _logger;
    private readonly IShippingRepository _shippingRepository;
    private readonly IShippingCarrierService _shippingCarrierService;
    private readonly IShippingStatusUpdater _shippingStatusUpdater;
    private readonly ISalesShippingStatusService _salesShippingStatusService;

    public ShippingCancelHandler(
        IAppLogger<ShippingCancelHandler> logger,
        IShippingRepository shippingRepository,
        IShippingCarrierService shippingCarrierService,
        IShippingStatusUpdater shippingStatusUpdater,
        ISalesShippingStatusService salesShippingStatusService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _shippingCarrierService = shippingCarrierService ?? throw new ArgumentNullException(nameof(shippingCarrierService));
        _shippingStatusUpdater = shippingStatusUpdater ?? throw new ArgumentNullException(nameof(shippingStatusUpdater));
        _salesShippingStatusService = salesShippingStatusService ?? throw new ArgumentNullException(nameof(salesShippingStatusService));
    }

    public async Task<Result<Guid>> Handle(ShippingCancelCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Cancelling shipment with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        try
        {
            var existsGlobally = await _shippingRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                _logger.LogWarning("Shipment not found: {Id}", request.Id);
                throw new NotFoundException("Shipping", request.Id);
            }

            var shipping = await _shippingRepository.GetByIdAsync(request.Id);
            if (shipping == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for shipment {Id}", request.Id);
                throw new NotFoundException("Shipping", request.Id);
            }

            if (shipping.Status is ShippingStatus.Delivered or ShippingStatus.Cancelled)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add($"A shipment in status {shipping.Status} cannot be cancelled.");
                return result;
            }

            // Void at the carrier is best effort — a failed void must not block the local cancel.
            if (!string.IsNullOrEmpty(shipping.CarrierShipmentId))
            {
                var cancelResult = await _shippingCarrierService.CancelShipmentAsync(shipping.Id, cancellationToken);
                if (!cancelResult.Succeeded)
                {
                    _logger.LogWarning("Carrier-side cancel failed for shipment {Id}: {Messages}",
                        shipping.Id, string.Join("; ", cancelResult.Messages));
                    result.Messages.AddRange(cancelResult.Messages);
                }
            }

            var statusResult = await _shippingStatusUpdater.ApplyStatusAsync(
                shipping.Id,
                ShippingStatus.Cancelled,
                rawCarrierStatus: null,
                eventTimeUtc: null,
                isSystemGenerated: false,
                userId: null,
                cancellationToken: cancellationToken);

            if (!statusResult.Succeeded)
            {
                result.Succeeded = false;
                result.StatusCode = statusResult.StatusCode;
                result.Messages.AddRange(statusResult.Messages);
                return result;
            }

            // Free the order lines for a replacement shipment.
            var assignedItems = await _shippingRepository.GetAssignedSalesItemsAsync(shipping.Id);
            foreach (var item in assignedItems)
            {
                item.ShippingId = null;
            }

            await _shippingRepository.SaveChangesAsync(cancellationToken);

            await _salesShippingStatusService.RecomputeAsync(shipping.SalesId, cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = shipping.Id;

            _logger.LogInformation("Successfully cancelled shipment with ID: {Id}", shipping.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while cancelling the shipment: {ex.Message}");

            _logger.LogError("Error cancelling shipment: {Message}", ex.Message);
        }

        return result;
    }
}
