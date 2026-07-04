using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.StatisticProduct;

public record StatisticProductQuery : IRequest<Result<StatisticProductDto>>;