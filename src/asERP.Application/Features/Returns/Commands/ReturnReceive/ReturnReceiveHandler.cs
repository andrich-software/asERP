using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Commands.ReturnReceive;

public class ReturnReceiveHandler : IRequestHandler<ReturnReceiveCommand, Result<Guid>>
{
    private static readonly ReturnShipmentStatus[] ReceivableStatuses =
    [
        ReturnShipmentStatus.Requested,
        ReturnShipmentStatus.LabelCreated,
        ReturnShipmentStatus.InTransit
    ];

    /// <summary>Only physically received returns count toward the order-level Returned flip.</summary>
    private static readonly ReturnShipmentStatus[] ReceivedStatuses =
    [
        ReturnShipmentStatus.Received,
        ReturnShipmentStatus.Completed
    ];

    private readonly IAppLogger<ReturnReceiveHandler> _logger;
    private readonly IReturnShipmentRepository _returnShipmentRepository;
    private readonly ISalesRepository _salesRepository;
    private readonly IReturnStatusUpdater _returnStatusUpdater;
    private readonly IMediator _mediator;

    public ReturnReceiveHandler(
        IAppLogger<ReturnReceiveHandler> logger,
        IReturnShipmentRepository returnShipmentRepository,
        ISalesRepository salesRepository,
        IReturnStatusUpdater returnStatusUpdater,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _returnStatusUpdater = returnStatusUpdater ?? throw new ArgumentNullException(nameof(returnStatusUpdater));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(ReturnReceiveCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Receiving return {Id}", request.Id);

        var result = new Result<Guid>();

        try
        {
            var existsGlobally = await _returnShipmentRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                _logger.LogWarning("Return not found: {Id}", request.Id);
                throw new NotFoundException("ReturnShipment", request.Id);
            }

            var returnShipment = await _returnShipmentRepository.GetWithDetailsAsync(request.Id);
            if (returnShipment == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for return {Id}", request.Id);
                throw new NotFoundException("ReturnShipment", request.Id);
            }

            if (!ReceivableStatuses.Contains(returnShipment.Status))
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add($"A return in status {returnShipment.Status} cannot be received.");
                return result;
            }

            foreach (var receiveItem in request.Items)
            {
                var item = returnShipment.Items.FirstOrDefault(i => i.Id == receiveItem.ReturnShipmentItemId);
                if (item == null)
                {
                    result.Succeeded = false;
                    result.StatusCode = ResultStatusCode.BadRequest;
                    result.Messages.Add($"Return item {receiveItem.ReturnShipmentItemId} does not belong to this return.");
                    return result;
                }

                var serials = receiveItem.SerialNumbers
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s => s.Trim())
                    .Distinct()
                    .ToList();

                if (serials.Count > item.Quantity + SalesItemAssignment.QuantityTolerance)
                {
                    result.Succeeded = false;
                    result.StatusCode = ResultStatusCode.BadRequest;
                    result.Messages.Add($"More serial numbers ({serials.Count}) than returned quantity ({item.Quantity}) for return item {item.Id}.");
                    return result;
                }

                var knownSerials = item.SalesItem.SerialNumbers
                    .Select(s => s.SerialNumber)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                var unknown = serials.FirstOrDefault(s => !knownSerials.Contains(s));
                if (unknown != null)
                {
                    result.Succeeded = false;
                    result.StatusCode = ResultStatusCode.BadRequest;
                    result.Messages.Add($"Serial number '{unknown}' does not belong to the returned order line.");
                    return result;
                }

                item.Condition = receiveItem.Condition;
                if (serials.Count > 0)
                {
                    _returnShipmentRepository.AddItemSerialNumbers(serials
                        .Select(serial => new ReturnShipmentItemSerialNumber
                        {
                            Id = Guid.NewGuid(),
                            ReturnShipmentItemId = item.Id,
                            SerialNumber = serial,
                            TenantId = returnShipment.TenantId
                        })
                        .ToList());
                }
            }

            if (request.RefundAmount.HasValue)
            {
                returnShipment.RefundAmount = request.RefundAmount;
            }

            if (!string.IsNullOrWhiteSpace(request.Note))
            {
                returnShipment.Note = string.IsNullOrWhiteSpace(returnShipment.Note)
                    ? request.Note
                    : $"{returnShipment.Note}\n{request.Note}";
            }

            await _returnShipmentRepository.UpdateAsync(returnShipment);

            var statusResult = await _returnStatusUpdater.ApplyStatusAsync(
                returnShipment.Id,
                ReturnShipmentStatus.Received,
                description: "Goods receipt recorded",
                cancellationToken: cancellationToken);

            if (!statusResult.Succeeded)
            {
                result.Succeeded = false;
                result.StatusCode = statusResult.StatusCode;
                result.Messages.AddRange(statusResult.Messages);
                return result;
            }

            await FlipSalesStatusWhenFullyReturnedAsync(returnShipment.SalesId, cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = returnShipment.Id;

            _logger.LogInformation("Successfully received return {Id}", returnShipment.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while receiving the return: {ex.Message}");

            _logger.LogError("Error receiving return: {Message}", ex.Message);
        }

        return result;
    }

    /// <summary>
    /// Sets the order to Returned when every shipped line is fully covered by received returns
    /// and nothing is left unshipped. Deliberately NOT part of SalesShippingStatusService's
    /// recompute — Returned is in its protected set, so this transition must originate here.
    /// </summary>
    private async Task FlipSalesStatusWhenFullyReturnedAsync(Guid salesId, CancellationToken cancellationToken)
    {
        var sales = await _salesRepository.GetWithDetailsAsync(salesId);
        if (sales == null || sales.Status == SalesStatus.Returned)
        {
            return;
        }

        var shippedItems = sales.SalesItems.Where(i => i.ShippingId != null).ToList();
        var unshippedItems = sales.SalesItems.Any(i => i.ShippingId == null);
        if (shippedItems.Count == 0 || unshippedItems)
        {
            return;
        }

        var returns = await _returnShipmentRepository.GetBySalesIdAsync(salesId);
        var receivedQuantities = returns
            .Where(r => ReceivedStatuses.Contains(r.Status))
            .SelectMany(r => r.Items)
            .GroupBy(i => i.SalesItemId)
            .ToDictionary(g => g.Key, g => g.Sum(i => i.Quantity));

        var fullyReturned = shippedItems.All(i =>
            receivedQuantities.GetValueOrDefault(i.Id) >= i.Quantity - SalesItemAssignment.QuantityTolerance);

        if (!fullyReturned)
        {
            return;
        }

        var oldStatus = sales.Status;
        var trackedSales = await _salesRepository.GetByIdAsync(salesId);
        if (trackedSales == null)
        {
            return;
        }

        trackedSales.Status = SalesStatus.Returned;
        await _salesRepository.UpdateAsync(trackedSales);

        await _salesRepository.AddSalesHistoryAsync(new SalesHistory
        {
            SalesId = salesId,
            UserId = Guid.Empty,
            TenantId = trackedSales.TenantId,
            SalesStatusOld = oldStatus,
            SalesStatusNew = SalesStatus.Returned,
            Description = "Order fully returned",
            IsSystemGenerated = true
        });

        _logger.LogInformation("Sales {SalesId} status changed {Old} -> Returned (all shipped items returned)",
            salesId, oldStatus);

        await _mediator.Publish(
            new SalesChangedNotification(salesId, trackedSales.TenantId, SalesChangeKind.StatusChanged),
            cancellationToken);
    }
}
