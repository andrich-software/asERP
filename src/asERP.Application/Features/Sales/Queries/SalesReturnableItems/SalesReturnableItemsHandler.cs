using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Features.Returns;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Sales.Queries.SalesReturnableItems;

public class SalesReturnableItemsHandler : IRequestHandler<SalesReturnableItemsQuery, Result<List<ReturnableSalesItemDto>>>
{
    private readonly IAppLogger<SalesReturnableItemsHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly IShippingRepository _shippingRepository;
    private readonly IReturnShipmentRepository _returnShipmentRepository;
    private readonly IProductRepository _productRepository;

    public SalesReturnableItemsHandler(
        IAppLogger<SalesReturnableItemsHandler> logger,
        ISalesRepository salesRepository,
        IShippingRepository shippingRepository,
        IReturnShipmentRepository returnShipmentRepository,
        IProductRepository productRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Result<List<ReturnableSalesItemDto>>> Handle(SalesReturnableItemsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving returnable items for sales {Id}", request.Id);

        var result = new Result<List<ReturnableSalesItemDto>>();

        var sales = await _salesRepository.GetWithDetailsAsync(request.Id);
        if (sales == null)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.NotFound;
            result.Messages.Add($"Sales with ID {request.Id} not found");

            _logger.LogWarning("Sales with ID {Id} not found", request.Id);
            return result;
        }

        var shippings = await _shippingRepository.GetBySalesIdAsync(request.Id);
        var shippedParcels = shippings
            .Where(ReturnEligibility.IsPhysicallyShipped)
            .ToDictionary(s => s.Id);

        var returnedQuantities = await _returnShipmentRepository.GetReturnedQuantitiesAsync(request.Id);

        var shippedItems = sales.SalesItems
            .Where(i => i.ShippingId != null && shippedParcels.ContainsKey(i.ShippingId.Value))
            .ToList();

        var productIds = shippedItems.Select(i => i.ProductId).Distinct().ToList();
        var skuByProduct = await _productRepository.Entities
            .Where(p => productIds.Contains(p.Id))
            .Select(p => new { p.Id, p.Sku })
            .ToDictionaryAsync(p => p.Id, p => p.Sku, cancellationToken);

        var data = shippedItems
            .Select(item =>
            {
                var alreadyReturned = returnedQuantities.GetValueOrDefault(item.Id);

                return new ReturnableSalesItemDto
                {
                    SalesItemId = item.Id,
                    ShippingId = item.ShippingId!.Value,
                    TrackingNumber = shippedParcels[item.ShippingId.Value].TrackingNumber,
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Sku = skuByProduct.GetValueOrDefault(item.ProductId) ?? item.MissingProductSku,
                    ShippedQuantity = item.Quantity,
                    AlreadyReturnedQuantity = alreadyReturned,
                    ReturnableQuantity = Math.Max(0, Math.Round(item.Quantity - alreadyReturned, 4)),
                    HasSerialNumbers = item.SerialNumbers.Any(),
                    SerialNumbers = item.SerialNumbers.Select(s => s.SerialNumber).ToList()
                };
            })
            .Where(dto => dto.ReturnableQuantity > SalesItemAssignment.QuantityTolerance)
            .ToList();

        result.Succeeded = true;
        result.StatusCode = ResultStatusCode.Ok;
        result.Data = data;

        return result;
    }
}
