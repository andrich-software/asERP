using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Statistic.Queries.ProductsBestSelling;

public record ProductsBestSellingQuery(int Count = 5) : IRequest<Result<ProductsBestSellingDto>>;
