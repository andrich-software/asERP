using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.StatisticSales;

public record StatisticSalesQuery : IRequest<Result<StatisticSalesDto>>;