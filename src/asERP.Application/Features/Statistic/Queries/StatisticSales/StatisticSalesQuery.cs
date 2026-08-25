using asERP.Application.Mediator;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Statistic.Queries.StatisticSales;

public record StatisticSalesQuery : IRequest<Result<StatisticSalesDto>>;
