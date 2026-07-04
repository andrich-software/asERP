using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Application.Features.Sales.Queries.SalesShippableItems;

public class SalesShippableItemsHandler : IRequestHandler<SalesShippableItemsQuery, Result<List<ShippableSalesItemDto>>>
{
    private readonly IAppLogger<SalesShippableItemsHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly IProductRepository _productRepository;

    public SalesShippableItemsHandler(
        IAppLogger<SalesShippableItemsHandler> logger,
        ISalesRepository salesRepository,
        IProductRepository productRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Result<List<ShippableSalesItemDto>>> Handle(SalesShippableItemsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving shippable items for sales {Id}", request.Id);

        var result = new Result<List<ShippableSalesItemDto>>();

        var sales = await _salesRepository.GetWithDetailsAsync(request.Id);
        if (sales == null)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.NotFound;
            result.Messages.Add($"Sales with ID {request.Id} not found");

            _logger.LogWarning("Sales with ID {Id} not found", request.Id);
            return result;
        }

        var openItems = sales.SalesItems
            .Where(i => i.ShippingId == null)
            .ToList();

        var productIds = openItems.Select(i => i.ProductId).Distinct().ToList();

        var products = await _productRepository.Entities
            .Where(p => productIds.Contains(p.Id))
            .Select(p => new { p.Id, p.Sku, p.Weight, p.Width, p.Height, p.Depth })
            .ToListAsync(cancellationToken);
        var productById = products.ToDictionary(p => p.Id);

        var stockSums = await _productRepository.GetContext<ProductStock>()
            .Where(ps => productIds.Contains(ps.ProductId))
            .GroupBy(ps => ps.ProductId)
            .Select(g => new { ProductId = g.Key, Stock = g.Sum(ps => ps.Stock) })
            .ToListAsync(cancellationToken);
        var stockByProduct = stockSums.ToDictionary(s => s.ProductId, s => s.Stock);

        var data = openItems.Select(item =>
        {
            var product = productById.GetValueOrDefault(item.ProductId);

            return new ShippableSalesItemDto
            {
                SalesItemId = item.Id,
                ProductId = item.ProductId,
                Name = item.Name,
                Sku = product?.Sku ?? item.MissingProductSku,
                OpenQuantity = item.Quantity,
                Price = item.Price,
                TaxRate = item.TaxRate,
                HasSerialNumbers = item.SerialNumbers.Any(),
                StockAvailable = product != null ? stockByProduct.GetValueOrDefault(item.ProductId) : 0,
                ProductWeight = product?.Weight ?? 0,
                ProductWidth = product?.Width ?? 0,
                ProductHeight = product?.Height ?? 0,
                ProductDepth = product?.Depth ?? 0
            };
        }).ToList();

        result.Succeeded = true;
        result.StatusCode = ResultStatusCode.Ok;
        result.Data = data;

        return result;
    }
}
