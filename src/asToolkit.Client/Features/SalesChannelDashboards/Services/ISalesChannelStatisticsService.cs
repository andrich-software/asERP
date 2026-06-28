using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Dtos.WebAnalytics;

namespace asToolkit.Client.Features.SalesChannelDashboards.Services;

/// <summary>
/// Service interface for SalesChannel-filtered statistics API operations.
/// </summary>
public interface ISalesChannelStatisticsService
{
    /// <summary>
    /// Gets the revenue/sales statistics for today, filtered by SalesChannel.
    /// </summary>
    Task<SalesTodayDto?> GetSalesTodayAsync(Guid salesChannelId, CancellationToken ct = default);

    /// <summary>
    /// Gets the saless statistics for today, filtered by SalesChannel.
    /// </summary>
    Task<SalessTodayDto?> GetSalessTodayAsync(Guid salesChannelId, CancellationToken ct = default);

    /// <summary>
    /// Gets the latest saless, filtered by SalesChannel.
    /// </summary>
    Task<SalessLatestDto?> GetSalessLatestAsync(Guid salesChannelId, int count = 5, CancellationToken ct = default);

    /// <summary>
    /// Gets web-session counts (today / yesterday / this week / last week) for the SalesChannel.
    /// </summary>
    Task<WebSessionsSummaryDto?> GetWebSessionsAsync(Guid salesChannelId, CancellationToken ct = default);

    /// <summary>
    /// Gets the most-visited products for the SalesChannel within the given date range.
    /// </summary>
    Task<WebTopProductsDto?> GetWebTopProductsAsync(Guid salesChannelId, DateTime startDate, DateTime endDate, int count = 10, CancellationToken ct = default);
}
