using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Statistic.Queries.StatisticSalesCustomerChart;

public record StatisticSalesCustomerChartQuery : IRequest<Result<StatisticSalesCustomerChartResponse>>;
