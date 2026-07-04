using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.ProductsToday;

public record ProductsTodayQuery : IRequest<Result<ProductsTodayDto>>;
