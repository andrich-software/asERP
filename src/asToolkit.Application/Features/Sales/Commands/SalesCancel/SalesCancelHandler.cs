using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Exceptions;
using asToolkit.Application.Features.Shipping.Commands.ShippingCancel;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Sales.Commands.SalesCancel;

public class SalesCancelHandler : IRequestHandler<SalesCancelCommand, Result<Guid>>
{
    /// <summary>Order states that cannot be cancelled anymore.</summary>
    private static readonly SalesStatus[] NonCancellableStatuses =
    [
        SalesStatus.Completed,
        SalesStatus.Cancelled,
        SalesStatus.Returned,
        SalesStatus.Refunded
    ];

    /// <summary>A parcel in one of these states physically left the building — the order
    /// cannot be cancelled anymore; handle it as a return instead.</summary>
    private static readonly ShippingStatus[] ShippedStatuses =
    [
        ShippingStatus.Shipped,
        ShippingStatus.InTransit,
        ShippingStatus.OutForDelivery,
        ShippingStatus.Delivered,
        ShippingStatus.DeliveryFailed,
        ShippingStatus.ReturnedToSender,
        ShippingStatus.Lost
    ];

    private readonly IAppLogger<SalesCancelHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly IShippingRepository _shippingRepository;
    private readonly IMediator _mediator;

    public SalesCancelHandler(
        IAppLogger<SalesCancelHandler> logger,
        ISalesRepository salesRepository,
        IShippingRepository shippingRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(SalesCancelCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Cancelling sales order with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        try
        {
            var existsGlobally = await _salesRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                _logger.LogWarning("Sales order not found: {Id}", request.Id);
                throw new NotFoundException("Sales", request.Id);
            }

            var sales = await _salesRepository.GetByIdAsync(request.Id);
            if (sales == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for sales order {Id}", request.Id);
                throw new NotFoundException("Sales", request.Id);
            }

            if (NonCancellableStatuses.Contains(sales.Status))
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add($"An order in status {sales.Status} cannot be cancelled.");
                return result;
            }

            var shippings = await _shippingRepository.GetBySalesIdAsync(request.Id);
            if (shippings.Any(s => s.ShippedAt != null || ShippedStatuses.Contains(s.Status)))
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add("The order has shipped parcels and cannot be cancelled anymore.");
                return result;
            }

            // Cancel the order FIRST: the recompute triggered inside each shipment cancel then
            // sees a protected status and cannot flip the order back to Processing.
            var oldStatus = sales.Status;
            sales.Status = SalesStatus.Cancelled;
            await _salesRepository.UpdateAsync(sales);

            await _salesRepository.AddSalesHistoryAsync(new SalesHistory
            {
                SalesId = sales.Id,
                UserId = Guid.Empty,
                TenantId = sales.TenantId,
                SalesStatusOld = oldStatus,
                SalesStatusNew = SalesStatus.Cancelled,
                Description = "Order cancelled",
                IsSystemGenerated = false
            });

            // Reuse the shipment cancel command: carrier void, label-outbox handling, item
            // freeing and per-shipment history come for free. Failures are collected, not fatal.
            foreach (var shipping in shippings.Where(s => s.Status != ShippingStatus.Cancelled))
            {
                var cancelResult = await _mediator.Send(new ShippingCancelCommand { Id = shipping.Id },
                    cancellationToken);
                if (!cancelResult.Succeeded)
                {
                    _logger.LogWarning("Cancelling shipment {ShippingId} during order cancel failed: {Messages}",
                        shipping.Id, string.Join("; ", cancelResult.Messages));
                    result.Messages.AddRange(cancelResult.Messages);
                }
            }

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = sales.Id;

            _logger.LogInformation("Successfully cancelled sales order with ID: {Id}", sales.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while cancelling the sales order: {ex.Message}");

            _logger.LogError("Error cancelling sales order: {Message}", ex.Message);
        }

        return result;
    }
}
