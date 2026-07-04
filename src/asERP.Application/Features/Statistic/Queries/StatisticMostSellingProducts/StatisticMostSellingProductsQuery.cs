using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.StatisticMostSellingProducts;

public record StatisticMostSellingProductsQuery : IRequest<Result<StatisticMostSellingProductsDto>>;