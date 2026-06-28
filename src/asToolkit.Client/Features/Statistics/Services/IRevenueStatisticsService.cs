using asToolkit.Domain.Dtos.Statistic;

namespace asToolkit.Client.Features.Statistics.Services;

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
