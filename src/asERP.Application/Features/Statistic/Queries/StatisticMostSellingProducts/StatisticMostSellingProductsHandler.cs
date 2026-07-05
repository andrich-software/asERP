using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Statistic.Queries.StatisticMostSellingProducts;

public class StatisticMostSellingProductsHandler : IRequestHandler<StatisticMostSellingProductsQuery, Result<StatisticMostSellingProductsDto>>
{
    private readonly IAppLogger<StatisticMostSellingProductsHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly IProductRepository _productRepository;

    public StatisticMostSellingProductsHandler(
        IAppLogger<StatisticMostSellingProductsHandler> logger,
        ISalesRepository salesRepository,
        IProductRepository productRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
        _productRepository = productRepository;
    }

    public async Task<Result<StatisticMostSellingProductsDto>> Handle(StatisticMostSellingProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handle StatisticMostSellingProductsQuery: {0}", request);

            var statisticDto = new StatisticMostSellingProductsDto();

            // Define the reporting time ranges.
            var today = DateTime.UtcNow.Date;
            var sevenDaysAgo = today.AddDays(-7);
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            var firstDayOfYear = new DateTime(today.Year, 1, 1);

            statisticDto.TopProductsToday = await GetTopSellingProducts(today, today.AddDays(1), cancellationToken);
            statisticDto.TopProductsLastSevenDays = await GetTopSellingProducts(sevenDaysAgo, today.AddDays(1), cancellationToken);
            statisticDto.TopProductsThisMonth = await GetTopSellingProducts(firstDayOfMonth, today.AddDays(1), cancellationToken);
            statisticDto.TopProductsThisYear = await GetTopSellingProducts(firstDayOfYear, today.AddDays(1), cancellationToken);
            statisticDto.TopProductsAllTime = await GetTopSellingProducts(null, null, cancellationToken);

            return Result<StatisticMostSellingProductsDto>.Success(statisticDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while determining the most selling products");
            return Result<StatisticMostSellingProductsDto>.Fail(
                ResultStatusCode.InternalServerError,
                "An error occurred while determining the most selling products.");
        }
    }

    private async Task<List<MostSellingProductItem>> GetTopSellingProducts(
        DateTime? startDate,
        DateTime? endDate,
        CancellationToken cancellationToken)
    {
        var query = _salesRepository.Entities
            .Where(o => o.SalesItems.Any());

        // Apply the time range filter when present.
        if (startDate.HasValue)
        {
            query = query.Where(o => o.DateSalesed >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(o => o.DateSalesed < endDate.Value);
        }

        // Group order lines by product and join the product name/SKU in the same query,
        // so we no longer issue a per-product GetByIdAsync (N+1) after grouping.
        var products = _productRepository.Entities;

        return await query
            .SelectMany(o => o.SalesItems)
            .GroupBy(oi => oi.ProductId)
            .Select(g => new
            {
                ProductId = g.Key,
                TotalQuantity = g.Sum(oi => oi.Quantity)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(10)
            .Join(products,
                grouped => grouped.ProductId,
                product => product.Id,
                (grouped, product) => new MostSellingProductItem
                {
                    ProductId = grouped.ProductId,
                    ProductName = product.Name,
                    ProductSku = product.Sku,
                    TotalQuantity = grouped.TotalQuantity
                })
            .ToListAsync(cancellationToken);
    }
}
