using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Queries.ShippingDetail;

public class ShippingDetailHandler : IRequestHandler<ShippingDetailQuery, Result<ShippingDetailDto>>
{
    private readonly IAppLogger<ShippingDetailHandler> _logger;
    private readonly IShippingRepository _shippingRepository;
    private readonly ISalesRepository _salesRepository;

    public ShippingDetailHandler(
        IAppLogger<ShippingDetailHandler> logger,
        IShippingRepository shippingRepository,
        ISalesRepository salesRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
    }

    public async Task<Result<ShippingDetailDto>> Handle(ShippingDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving shipment details for ID: {Id}", request.Id);

        var shipping = await _shippingRepository.GetWithDetailsAsync(request.Id);
        if (shipping == null)
        {
            _logger.LogWarning("Shipment not found: {Id}", request.Id);
            throw new NotFoundException("Shipping", request.Id);
        }

        var assignedItems = await _shippingRepository.GetAssignedSalesItemsAsync(shipping.Id);
        var labelOutbox = await _shippingRepository.GetLabelOutboxAsync(shipping.Id);
        var history = await _salesRepository.GetShippingHistoryAsync(shipping.Id);

        var data = new ShippingDetailDto
        {
            Id = shipping.Id,
            SalesId = shipping.SalesId,
            SalesNumber = shipping.Sales.SalesId,
            ShippingProviderId = shipping.ShippingProviderId,
            ProviderName = shipping.ShippingProvider.Name,
            ProviderType = shipping.ShippingProvider.Type,
            ShippingProviderRateId = shipping.ShippingProviderRateId,
            RateName = shipping.ShippingProviderRate?.Name ?? string.Empty,
            Status = shipping.Status,
            TrackingNumber = shipping.TrackingNumber,
            TrackingUrl = shipping.TrackingUrl,
            ShippingCost = shipping.ShippingCost,
            TaxRate = shipping.TaxRate,
            WeightKg = shipping.WeightKg,
            LengthCm = shipping.LengthCm,
            WidthCm = shipping.WidthCm,
            HeightCm = shipping.HeightCm,
            CarrierShipmentId = shipping.CarrierShipmentId,
            HasLabel = shipping.LabelData is { Length: > 0 },
            LabelFormat = shipping.LabelFormat,
            LastTrackedAt = shipping.LastTrackedAt,
            ShippedAt = shipping.ShippedAt,
            DeliveredAt = shipping.DeliveredAt,
            LastCarrierStatusRaw = shipping.LastCarrierStatusRaw,
            LabelQueueStatus = labelOutbox?.Status,
            LabelQueueLastError = labelOutbox?.LastError,
            SalesItemIds = assignedItems.Select(i => i.Id).ToList(),
            History = history.Select(h => new ShippingHistoryEntryDto
            {
                Id = h.Id,
                ShippingStatusOld = h.ShippingStatusOld,
                ShippingStatusNew = h.ShippingStatusNew,
                Description = h.Description,
                IsSystemGenerated = h.IsSystemGenerated,
                UserId = h.UserId,
                DateCreated = h.DateCreated
            }).ToList(),
            DateCreated = shipping.DateCreated
        };

        return Result<ShippingDetailDto>.Success(data);
    }
}
