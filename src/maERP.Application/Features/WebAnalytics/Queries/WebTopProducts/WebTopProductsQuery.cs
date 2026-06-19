using maERP.Application.Mediator;
using maERP.Domain.Dtos.WebAnalytics;
using maERP.Domain.Wrapper;

namespace maERP.Application.Features.WebAnalytics.Queries.WebTopProducts;

/// <summary>
/// Most-visited products for a sales channel within an inclusive date range (UTC). Tenant scoping is
/// enforced inside the query service from the ambient tenant context.
/// </summary>
public record WebTopProductsQuery(Guid SalesChannelId, DateTime StartDate, DateTime EndDate, int Count = 10)
    : IRequest<Result<WebTopProductsDto>>;
