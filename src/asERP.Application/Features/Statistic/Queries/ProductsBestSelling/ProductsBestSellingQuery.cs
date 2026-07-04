using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Statistic.Queries.ProductsBestSelling;

/// <param name="Hours">Optional look-back window in hours. When set, only sales from the last N hours are ranked; when null, all-time totals are used.</param>
public record ProductsBestSellingQuery(int Count = 5, int? Hours = null) : IRequest<Result<ProductsBestSellingDto>>;
