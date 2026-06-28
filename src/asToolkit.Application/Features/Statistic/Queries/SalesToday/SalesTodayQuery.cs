using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.SalesToday;

public record SalesTodayQuery(Guid? SalesChannelId = null) : IRequest<Result<SalesTodayDto>>;
