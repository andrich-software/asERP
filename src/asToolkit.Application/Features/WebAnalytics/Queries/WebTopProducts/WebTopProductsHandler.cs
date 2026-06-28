using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.WebAnalytics;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.WebAnalytics.Queries.WebTopProducts;

public class WebTopProductsHandler : IRequestHandler<WebTopProductsQuery, Result<WebTopProductsDto>>
{
    private readonly IAppLogger<WebTopProductsHandler> _logger;
    private readonly IWebAnalyticsQueryService _queryService;

    public WebTopProductsHandler(
        IAppLogger<WebTopProductsHandler> logger,
        IWebAnalyticsQueryService queryService)
    {
        _logger = logger;
        _queryService = queryService;
    }

    public async Task<Result<WebTopProductsDto>> Handle(WebTopProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handle WebTopProductsQuery for channel {0}", request.SalesChannelId);

            // Normalise to inclusive UTC day boundaries (consistent with RevenueChart).
            var startDay = DateTime.SpecifyKind(request.StartDate.Date, DateTimeKind.Utc);
            var endDay = DateTime.SpecifyKind(request.EndDate.Date, DateTimeKind.Utc);
            if (endDay < startDay)
            {
                (startDay, endDay) = (endDay, startDay);
            }

            var count = request.Count is > 0 and <= 100 ? request.Count : 10;

            var dto = await _queryService.GetTopProductsAsync(request.SalesChannelId, startDay, endDay, count, cancellationToken);
            return Result<WebTopProductsDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while loading web top products: {0}", ex.Message);
            return Result<WebTopProductsDto>.Fail(ResultStatusCode.InternalServerError, "Error while loading web top products");
        }
    }
}
