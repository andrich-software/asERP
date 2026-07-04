using asERP.Application.Mediator;
using asERP.Domain.Dtos.WebAnalytics;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.WebAnalytics.Queries.WebSessionsSummary;

/// <summary>
/// Session counts (today / yesterday / this week / last week) for a sales channel's web tracking.
/// Tenant scoping is enforced inside the query service from the ambient tenant context.
/// </summary>
public record WebSessionsSummaryQuery(Guid SalesChannelId) : IRequest<Result<WebSessionsSummaryDto>>;
