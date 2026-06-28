using asToolkit.Domain.Dtos.WebAnalytics;

namespace asToolkit.Application.Contracts.Persistence;

/// <summary>
/// Read gateway over the ClickHouse analytics store for the dashboard. ClickHouse has NO EF global
/// query filter, so EVERY implementation MUST inject the current tenant id (from <c>ITenantContext</c>)
/// into every query and fail closed when no tenant is in context — never run an unscoped query. The
/// tenant id is read by the implementation itself; it is never accepted from an (untrusted) caller.
/// </summary>
public interface IWebAnalyticsQueryService
{
    /// <summary>Session counts (today / yesterday / this week / last week) for one channel of the current tenant.</summary>
    Task<WebSessionsSummaryDto> GetSessionsSummaryAsync(Guid salesChannelId, CancellationToken cancellationToken = default);

    /// <summary>Most-visited products in [startUtc, endUtc] for one channel of the current tenant.</summary>
    Task<WebTopProductsDto> GetTopProductsAsync(
        Guid salesChannelId,
        DateTime startUtc,
        DateTime endUtc,
        int count,
        CancellationToken cancellationToken = default);
}
