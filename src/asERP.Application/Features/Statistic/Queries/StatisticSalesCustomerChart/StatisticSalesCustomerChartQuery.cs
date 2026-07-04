using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.StatisticSalesCustomerChart;

public record StatisticSalesCustomerChartQuery : IRequest<Result<StatisticSalesCustomerChartResponse>>;