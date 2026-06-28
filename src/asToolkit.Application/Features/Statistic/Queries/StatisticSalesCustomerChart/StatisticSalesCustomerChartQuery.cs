using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.StatisticSalesCustomerChart;

public record StatisticSalesCustomerChartQuery : IRequest<Result<StatisticSalesCustomerChartResponse>>;