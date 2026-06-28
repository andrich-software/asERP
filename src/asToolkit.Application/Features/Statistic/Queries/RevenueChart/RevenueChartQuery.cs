using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.RevenueChart;

/// <summary>
/// Query for daily revenue between two dates (inclusive), optionally scoped to a sales channel.
/// </summary>
public record RevenueChartQuery(DateTime StartDate, DateTime EndDate, Guid? SalesChannelId = null)
    : IRequest<Result<RevenueChartDto>>;
