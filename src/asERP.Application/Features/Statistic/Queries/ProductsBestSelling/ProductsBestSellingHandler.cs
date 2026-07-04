using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Statistic.Queries.ProductsBestSelling;

public class ProductsBestSellingHandler : IRequestHandler<ProductsBestSellingQuery, Result<ProductsBestSellingDto>>
{
    private readonly IAppLogger<ProductsBestSellingHandler> _logger;
    private readonly IProductRepository _productRepository;

    public ProductsBestSellingHandler(
        IAppLogger<ProductsBestSellingHandler> logger,
        IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<Result<ProductsBestSellingDto>> Handle(ProductsBestSellingQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handle ProductsBestSellingQuery - fetching {Count} best-selling products", request.Count);

            // Get SalesItems context
            var salesItems = _productRepository.GetContext<SalesItem>().AsQueryable();

            // Restrict to sales within the requested look-back window
            if (request.Hours.HasValue)
            {
                var periodStart = DateTime.UtcNow.AddHours(-request.Hours.Value);
                var sales = _productRepository.GetContext<Domain.Entities.Sales>();
                salesItems = salesItems
                    .Join(sales.Where(s => s.DateSalesed >= periodStart),
                        oi => oi.SalesId,
                        s => s.Id,
                        (oi, s) => oi);
            }

            // Group sales items by ProductId and calculate totals
            var bestSelling = await salesItems
                .GroupBy(oi => oi.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    QuantitySold = (int)g.Sum(x => x.Quantity),
                    Revenue = g.Sum(x => x.Price * (decimal)x.Quantity)
                })
                .OrderByDescending(x => x.QuantitySold)
                .Take(request.Count)
                .ToListAsync(cancellationToken);

            // Get product details for the best-selling products
            var productIds = bestSelling.Select(b => b.ProductId).ToList();
            var products = await _productRepository.Entities
                .Where(p => productIds.Contains(p.Id))
                .ToDictionaryAsync(p => p.Id, p => p, cancellationToken);

            // Build the result with ranking
            var items = bestSelling
                .Select((item, index) => new ProductsBestSellingItemDto
                {
                    Rank = index + 1,
                    ProductId = item.ProductId,
                    ProductName = products.TryGetValue(item.ProductId, out var product) ? product.Name : "Unknown Product",
                    Sku = product?.Sku ?? string.Empty,
                    QuantitySold = item.QuantitySold,
                    Revenue = item.Revenue
                })
                .ToList();

            var dto = new ProductsBestSellingDto
            {
                Products = items
            };

            _logger.LogInformation("Successfully fetched {Count} best-selling products", items.Count);
            return Result<ProductsBestSellingDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while fetching best-selling products: {0}", ex.Message);
            return Result<ProductsBestSellingDto>.Fail(ResultStatusCode.InternalServerError, "Error while fetching best-selling products");
        }
    }
}
