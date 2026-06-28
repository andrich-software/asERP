using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.WebAnalytics;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.WebAnalytics.Queries.WebTopProducts;

/// <summary>
/// Most-visited products for a sales channel within an inclusive date range (UTC). Tenant scoping is
/// enforced inside the query service from the ambient tenant context.
/// </summary>
public record WebTopProductsQuery(Guid SalesChannelId, DateTime StartDate, DateTime EndDate, int Count = 10)
    : IRequest<Result<WebTopProductsDto>>;
