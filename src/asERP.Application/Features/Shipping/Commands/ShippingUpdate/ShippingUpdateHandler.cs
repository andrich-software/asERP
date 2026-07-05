using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Commands.ShippingUpdate;

public class ShippingUpdateHandler : IRequestHandler<ShippingUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingUpdateHandler> _logger;
    private readonly IShippingRepository _shippingRepository;
    private readonly IShippingStatusUpdater _shippingStatusUpdater;

    public ShippingUpdateHandler(
        IAppLogger<ShippingUpdateHandler> logger,
        IShippingRepository shippingRepository,
        IShippingStatusUpdater shippingStatusUpdater)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _shippingStatusUpdater = shippingStatusUpdater ?? throw new ArgumentNullException(nameof(shippingStatusUpdater));
    }

    public async Task<Result<Guid>> Handle(ShippingUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating shipment with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        var validator = new ShippingUpdateValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(ShippingUpdateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            var existsGlobally = await _shippingRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                _logger.LogWarning("Shipment not found: {Id}", request.Id);
                throw new NotFoundException("Shipping", request.Id);
            }

            var shippingToUpdate = await _shippingRepository.GetByIdAsync(request.Id);
            if (shippingToUpdate == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for shipment {Id}", request.Id);
                throw new NotFoundException("Shipping", request.Id);
            }

            if (shippingToUpdate.Status == ShippingStatus.Cancelled)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add("A cancelled shipment cannot be updated.");
                return result;
            }

            if (request.TrackingNumber != null)
            {
                shippingToUpdate.TrackingNumber = request.TrackingNumber;
            }

            if (request.TrackingUrl != null)
            {
                shippingToUpdate.TrackingUrl = request.TrackingUrl;
            }

            if (request.ShippingCost.HasValue)
            {
                shippingToUpdate.ShippingCost = request.ShippingCost.Value;
            }

            if (request.TaxRate.HasValue)
            {
                shippingToUpdate.TaxRate = request.TaxRate.Value;
            }

            shippingToUpdate.WeightKg = request.WeightKg ?? shippingToUpdate.WeightKg;
            shippingToUpdate.LengthCm = request.LengthCm ?? shippingToUpdate.LengthCm;
            shippingToUpdate.WidthCm = request.WidthCm ?? shippingToUpdate.WidthCm;
            shippingToUpdate.HeightCm = request.HeightCm ?? shippingToUpdate.HeightCm;

            await _shippingRepository.UpdateAsync(shippingToUpdate);

            if (request.Status.HasValue && request.Status.Value != shippingToUpdate.Status)
            {
                // Manual status changes go through the status updater so they land in SalesHistory.
                var statusResult = await _shippingStatusUpdater.ApplyStatusAsync(
                    shippingToUpdate.Id,
                    request.Status.Value,
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
            }

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = shippingToUpdate.Id;

            _logger.LogInformation("Successfully updated shipment with ID: {Id}", shippingToUpdate.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while updating the shipment.",
                "Error updating shipment {Id}.", request.Id);
        }

        return result;
    }
}
