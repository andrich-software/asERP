using asERP.Application.Mediator;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Statistic.Queries.StatisticProduct;

public record StatisticProductQuery : IRequest<Result<StatisticProductDto>>;
