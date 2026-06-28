using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.SalessToday;

public record SalessTodayQuery(Guid? SalesChannelId = null) : IRequest<Result<SalessTodayDto>>;
