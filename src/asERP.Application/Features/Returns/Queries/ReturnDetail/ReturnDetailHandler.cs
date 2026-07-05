using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Returns.Queries.ReturnDetail;

public class ReturnDetailHandler : IRequestHandler<ReturnDetailQuery, Result<ReturnShipmentDetailDto>>
{
    private readonly IAppLogger<ReturnDetailHandler> _logger;
    private readonly IReturnShipmentRepository _returnShipmentRepository;
    private readonly IProductRepository _productRepository;

    public ReturnDetailHandler(
        IAppLogger<ReturnDetailHandler> logger,
        IReturnShipmentRepository returnShipmentRepository,
        IProductRepository productRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Result<ReturnShipmentDetailDto>> Handle(ReturnDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving return details for ID: {Id}", request.Id);

        var returnShipment = await _returnShipmentRepository.GetWithDetailsAsync(request.Id);
        if (returnShipment == null)
        {
            _logger.LogWarning("Return not found: {Id}", request.Id);
            throw new NotFoundException("ReturnShipment", request.Id);
        }

        var labelOutbox = await _returnShipmentRepository.GetLabelOutboxAsync(returnShipment.Id);

        var productIds = returnShipment.Items.Select(i => i.SalesItem.ProductId).Distinct().ToList();
        var skuByProduct = await _productRepository.Entities
            .Where(p => productIds.Contains(p.Id))
            .Select(p => new { p.Id, p.Sku })
            .ToDictionaryAsync(p => p.Id, p => p.Sku, cancellationToken);

        var data = new ReturnShipmentDetailDto
        {
            Id = returnShipment.Id,
            SalesId = returnShipment.SalesId,
            SalesNumber = returnShipment.Sales.SalesId,
            OriginalShippingId = returnShipment.OriginalShippingId,
            ShippingProviderId = returnShipment.ShippingProviderId,
            ProviderName = returnShipment.ShippingProvider?.Name ?? string.Empty,
            Status = returnShipment.Status,
            TrackingNumber = returnShipment.TrackingNumber,
            TrackingUrl = returnShipment.TrackingUrl,
            CarrierShipmentId = returnShipment.CarrierShipmentId,
            HasLabel = returnShipment.LabelData is { Length: > 0 },
            LabelFormat = returnShipment.LabelFormat,
            RefundAmount = returnShipment.RefundAmount,
            Note = returnShipment.Note,
            ReceivedAt = returnShipment.ReceivedAt,
            LabelQueueStatus = labelOutbox?.Status,
            LabelQueueLastError = labelOutbox?.LastError,
            Items = returnShipment.Items.Select(i => new ReturnShipmentItemDto
            {
                Id = i.Id,
                SalesItemId = i.SalesItemId,
                Name = i.SalesItem.Name,
                Sku = skuByProduct.GetValueOrDefault(i.SalesItem.ProductId) ?? i.SalesItem.MissingProductSku,
                Quantity = i.Quantity,
                Reason = i.Reason,
                ReasonText = i.ReasonText,
                Condition = i.Condition,
                SerialNumbers = i.SerialNumbers.Select(s => s.SerialNumber).ToList(),
                AvailableSerialNumbers = i.SalesItem.SerialNumbers.Select(s => s.SerialNumber).ToList()
            }).ToList(),
            DateCreated = returnShipment.DateCreated
        };

        return Result<ReturnShipmentDetailDto>.Success(data);
    }
}
