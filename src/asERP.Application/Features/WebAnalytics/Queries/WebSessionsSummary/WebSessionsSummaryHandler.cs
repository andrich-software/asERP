using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.WebAnalytics;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.WebAnalytics.Queries.WebSessionsSummary;

public class WebSessionsSummaryHandler : IRequestHandler<WebSessionsSummaryQuery, Result<WebSessionsSummaryDto>>
{
    private readonly IAppLogger<WebSessionsSummaryHandler> _logger;
    private readonly IWebAnalyticsQueryService _queryService;

    public WebSessionsSummaryHandler(
        IAppLogger<WebSessionsSummaryHandler> logger,
        IWebAnalyticsQueryService queryService)
    {
        _logger = logger;
        _queryService = queryService;
    }

    public async Task<Result<WebSessionsSummaryDto>> Handle(WebSessionsSummaryQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Handle WebSessionsSummaryQuery for channel {0}", request.SalesChannelId);

            // The query service reads the tenant from ITenantContext and fails closed, so isolation
            // does not depend on this handler. We only forward the channel filter.
            var dto = await _queryService.GetSessionsSummaryAsync(request.SalesChannelId, cancellationToken);
            return Result<WebSessionsSummaryDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while loading web session summary: {0}", ex.Message);
            return Result<WebSessionsSummaryDto>.Fail(ResultStatusCode.InternalServerError, "Error while loading web session summary");
        }
    }
}
