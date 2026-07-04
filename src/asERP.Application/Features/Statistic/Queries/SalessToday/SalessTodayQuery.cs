using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.SalessToday;

/// <param name="Hours">Optional look-back window in hours. When set, SalessToday/SalessChangePercent cover the last N hours (vs the previous N hours); when null, the legacy calendar-day/week semantics apply.</param>
public record SalessTodayQuery(Guid? SalesChannelId = null, int? Hours = null) : IRequest<Result<SalessTodayDto>>;
