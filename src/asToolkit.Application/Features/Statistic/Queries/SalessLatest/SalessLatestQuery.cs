using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.SalessLatest;

public record SalessLatestQuery(int Count = 5, Guid? SalesChannelId = null) : IRequest<Result<SalessLatestDto>>;
