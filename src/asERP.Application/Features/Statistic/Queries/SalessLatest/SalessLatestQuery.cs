using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.SalessLatest;

public record SalessLatestQuery(int Count = 5, Guid? SalesChannelId = null) : IRequest<Result<SalessLatestDto>>;
