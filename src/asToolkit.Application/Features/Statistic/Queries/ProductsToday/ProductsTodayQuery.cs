using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.ProductsToday;

public record ProductsTodayQuery : IRequest<Result<ProductsTodayDto>>;
