using asERP.Application.Mediator;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Statistic.Queries.StatisticSalesOverview;

public record StatisticSalesOverviewQuery : IRequest<Result<StatisticSalesOverviewDto>>;
