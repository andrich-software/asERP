using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Commands.ShippingDelete;

public class ShippingDeleteHandler : IRequestHandler<ShippingDeleteCommand, Result<Guid>>
{
    /// <summary>A parcel that physically shipped is history — cancel it instead of deleting.</summary>
    private static readonly ShippingStatus[] DeletableStatuses =
    [
        ShippingStatus.Open,
        ShippingStatus.LabelCreated,
        ShippingStatus.Cancelled
    ];

    private readonly IAppLogger<ShippingDeleteHandler> _logger;
    private readonly IShippingRepository _shippingRepository;
    private readonly ISalesShippingStatusService _salesShippingStatusService;

    public ShippingDeleteHandler(
        IAppLogger<ShippingDeleteHandler> logger,
        IShippingRepository shippingRepository,
        ISalesShippingStatusService salesShippingStatusService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _salesShippingStatusService = salesShippingStatusService ?? throw new ArgumentNullException(nameof(salesShippingStatusService));
    }

    public async Task<Result<Guid>> Handle(ShippingDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting shipment with ID: {Id}", request.Id);

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

            if (!DeletableStatuses.Contains(shipping.Status))
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add($"A shipment in status {shipping.Status} cannot be deleted. Cancel it instead.");
                return result;
            }

            var assignedItems = await _shippingRepository.GetAssignedSalesItemsAsync(shipping.Id);
            foreach (var item in assignedItems)
            {
                item.ShippingId = null;
            }

            await _shippingRepository.SaveChangesAsync(cancellationToken);
            await _shippingRepository.DeleteAsync(shipping);

            await _salesShippingStatusService.RecomputeAsync(shipping.SalesId, cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.NoContent;
            result.Data = request.Id;

            _logger.LogInformation("Successfully deleted shipment with ID: {Id}", request.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while deleting the shipment.",
                "Error deleting shipment {Id}.", request.Id);
        }

        return result;
    }
}
