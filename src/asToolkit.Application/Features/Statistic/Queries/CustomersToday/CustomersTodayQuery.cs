using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.CustomersToday;

/// <param name="Hours">Optional look-back window in hours. When set, CustomersNew/CustomersChangePercent cover the last N hours (vs the previous N hours); when null, the legacy month semantics apply.</param>
public record CustomersTodayQuery(int? Hours = null) : IRequest<Result<CustomersTodayDto>>;
