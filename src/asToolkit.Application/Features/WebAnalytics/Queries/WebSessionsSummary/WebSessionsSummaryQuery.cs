using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.WebAnalytics;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.WebAnalytics.Queries.WebSessionsSummary;

/// <summary>
/// Session counts (today / yesterday / this week / last week) for a sales channel's web tracking.
/// Tenant scoping is enforced inside the query service from the ambient tenant context.
/// </summary>
public record WebSessionsSummaryQuery(Guid SalesChannelId) : IRequest<Result<WebSessionsSummaryDto>>;
