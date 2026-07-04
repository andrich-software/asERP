using asERP.Domain.Dtos.Statistic;

namespace asERP.Client.Features.Statistics.Services;

/// <summary>
/// Service interface for revenue statistics / chart API operations.
/// </summary>
public interface IRevenueStatisticsService
{
    /// <summary>
    /// Gets the daily revenue series between two dates (inclusive).
    /// </summary>
    Task<RevenueChartDto?> GetRevenueChartAsync(DateTime startDate, DateTime endDate, CancellationToken ct = default);
}
