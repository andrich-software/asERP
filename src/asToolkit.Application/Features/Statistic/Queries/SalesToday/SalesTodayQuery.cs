using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.SalesToday;

/// <param name="Hours">Optional look-back window in hours. When set, RevenueToday/RevenueChangePercent cover the last N hours (vs the previous N hours); when null, the legacy calendar-day semantics apply.</param>
public record SalesTodayQuery(Guid? SalesChannelId = null, int? Hours = null) : IRequest<Result<SalesTodayDto>>;
