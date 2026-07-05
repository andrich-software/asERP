using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Returns.Commands.ReturnCreate;

public class ReturnCreateHandler : IRequestHandler<ReturnCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<ReturnCreateHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly IShippingRepository _shippingRepository;
    private readonly IShippingProviderRepository _shippingProviderRepository;
    private readonly IReturnShipmentRepository _returnShipmentRepository;
    private readonly IReturnCarrierService _returnCarrierService;

    public ReturnCreateHandler(
        IAppLogger<ReturnCreateHandler> logger,
        ISalesRepository salesRepository,
        IShippingRepository shippingRepository,
        IShippingProviderRepository shippingProviderRepository,
        IReturnShipmentRepository returnShipmentRepository,
        IReturnCarrierService returnCarrierService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _shippingProviderRepository = shippingProviderRepository ?? throw new ArgumentNullException(nameof(shippingProviderRepository));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
        _returnCarrierService = returnCarrierService ?? throw new ArgumentNullException(nameof(returnCarrierService));
    }

    public async Task<Result<Guid>> Handle(ReturnCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating return for sales {SalesId} with {Count} items",
            request.SalesId, request.Items.Count);

        var result = new Result<Guid>();

        var validator = new ReturnCreateValidator(_salesRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var validationErrors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(ReturnCreateCommand), validationErrors);

            return Result<Guid>.Fail(ResultStatusCode.BadRequest, validationErrors);
        }

        try
        {
            var sales = await _salesRepository.GetWithDetailsAsync(request.SalesId);
            if (sales == null)
            {
                return Result<Guid>.Fail(ResultStatusCode.BadRequest, "The sales order does not exist.");
            }

            if (sales.Status == SalesStatus.Cancelled)
            {
                return Result<Guid>.Fail(ResultStatusCode.BadRequest, "A cancelled order cannot be returned.");
            }

            if (request.RequestLabel)
            {
                var provider = await _shippingProviderRepository.GetByIdAsync(request.ShippingProviderId!.Value);
                if (provider == null)
                {
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest, "The shipping provider does not exist.");
                }

                if (!provider.IsEnabled)
                {
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                        $"The shipping provider '{provider.Name}' is disabled.");
                }
            }

            var shippings = await _shippingRepository.GetBySalesIdAsync(request.SalesId);
            var shippedParcelIds = shippings
                .Where(ReturnEligibility.IsPhysicallyShipped)
                .Select(s => s.Id)
                .ToHashSet();

            var returnedQuantities = await _returnShipmentRepository.GetReturnedQuantitiesAsync(request.SalesId);

            foreach (var requestItem in request.Items)
            {
                var item = sales.SalesItems.FirstOrDefault(i => i.Id == requestItem.SalesItemId);
                if (item == null)
                {
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                        $"Sales item {requestItem.SalesItemId} does not belong to this sales order.");
                }

                if (item.ShippingId == null || !shippedParcelIds.Contains(item.ShippingId.Value))
                {
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                        $"Sales item {requestItem.SalesItemId} has not been shipped and cannot be returned.");
                }

                if (request.OriginalShippingId is { } originalShippingId && item.ShippingId != originalShippingId)
                {
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                        $"Sales item {requestItem.SalesItemId} was not shipped in the given parcel.");
                }

                var alreadyReturned = returnedQuantities.GetValueOrDefault(item.Id);
                var returnable = item.Quantity - alreadyReturned;
                if (requestItem.Quantity > returnable + SalesItemAssignment.QuantityTolerance)
                {
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                        $"The requested quantity ({requestItem.Quantity}) for sales item {requestItem.SalesItemId} exceeds the returnable quantity ({returnable}).");
                }

                // Partial returns of serialized lines would leave the returned serials ambiguous —
                // force whole lines, mirroring the outbound split rule.
                if (requestItem.Quantity < item.Quantity - SalesItemAssignment.QuantityTolerance && item.SerialNumbers.Any())
                {
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                        $"Sales item {requestItem.SalesItemId} has serial numbers and must be returned as a whole line.");
                }
            }

            var returnToCreate = new ReturnShipment
            {
                SalesId = sales.Id,
                OriginalShippingId = request.OriginalShippingId,
                ShippingProviderId = request.RequestLabel ? request.ShippingProviderId : null,
                Status = ReturnShipmentStatus.Requested,
                Note = request.Note,
                TenantId = sales.TenantId,
                Items = request.Items.Select(i => new ReturnShipmentItem
                {
                    SalesItemId = i.SalesItemId,
                    Quantity = i.Quantity,
                    Reason = i.Reason,
                    ReasonText = i.ReasonText,
                    TenantId = sales.TenantId
                }).ToList()
            };

            await _returnShipmentRepository.CreateAsync(returnToCreate);

            await _salesRepository.AddSalesHistoryAsync(new SalesHistory
            {
                SalesId = sales.Id,
                UserId = Guid.Empty,
                TenantId = sales.TenantId,
                Description = $"Return requested ({returnToCreate.Items.Count} items)",
                IsSystemGenerated = false
            });

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = returnToCreate.Id;

            if (request.RequestLabel)
            {
                // The carrier service persists tracking number, label bytes and status itself;
                // on transient failure it queues a background retry. Label problems never fail
                // the return creation.
                var labelResult = await _returnCarrierService.CreateReturnLabelAsync(returnToCreate.Id, cancellationToken);
                if (!labelResult.Succeeded)
                {
                    result.Messages.AddRange(labelResult.Messages);
                }
            }

            _logger.LogInformation("Successfully created return with ID: {Id}", returnToCreate.Id);
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while creating the return: {ex.Message}");

            _logger.LogError("Error creating return: {Message}", ex.Message);
        }

        return result;
    }
}
