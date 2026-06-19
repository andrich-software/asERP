using maERP.Application.Mediator;
using maERP.Domain.Dtos.WebAnalytics;
using maERP.Domain.Wrapper;

namespace maERP.Application.Features.WebAnalytics.Queries.WebSessionsSummary;

/// <summary>
/// Session counts (today / yesterday / this week / last week) for a sales channel's web tracking.
/// Tenant scoping is enforced inside the query service from the ambient tenant context.
/// </summary>
public record WebSessionsSummaryQuery(Guid SalesChannelId) : IRequest<Result<WebSessionsSummaryDto>>;
