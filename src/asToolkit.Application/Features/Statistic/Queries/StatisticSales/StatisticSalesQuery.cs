using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.StatisticSales;

public record StatisticSalesQuery : IRequest<Result<StatisticSalesDto>>;