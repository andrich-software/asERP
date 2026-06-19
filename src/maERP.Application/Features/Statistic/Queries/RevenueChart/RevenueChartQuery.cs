using maERP.Domain.Dtos.Statistic;
using maERP.Domain.Wrapper;
using maERP.Application.Mediator;

namespace maERP.Application.Features.Statistic.Queries.RevenueChart;

/// <summary>
/// Query for daily revenue between two dates (inclusive), optionally scoped to a sales channel.
/// </summary>
public record RevenueChartQuery(DateTime StartDate, DateTime EndDate, Guid? SalesChannelId = null)
    : IRequest<Result<RevenueChartDto>>;
