using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.RevenueChart;

/// <summary>
/// Query for daily revenue between two dates (inclusive), optionally scoped to a sales channel.
/// </summary>
public record RevenueChartQuery(DateTime StartDate, DateTime EndDate, Guid? SalesChannelId = null)
    : IRequest<Result<RevenueChartDto>>;
