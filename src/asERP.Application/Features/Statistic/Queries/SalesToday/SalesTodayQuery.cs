using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.SalesToday;

/// <param name="Hours">Optional look-back window in hours. When set, RevenueToday/RevenueChangePercent cover the last N hours (vs the previous N hours); when null, the legacy calendar-day semantics apply.</param>
public record SalesTodayQuery(Guid? SalesChannelId = null, int? Hours = null) : IRequest<Result<SalesTodayDto>>;
