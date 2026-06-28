using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.StatisticSalesOverview;

public record StatisticSalesOverviewQuery : IRequest<Result<StatisticSalesOverviewDto>>;