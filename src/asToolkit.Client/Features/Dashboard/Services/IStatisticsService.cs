using asToolkit.Domain.Dtos.Statistic;

namespace asToolkit.Client.Features.Dashboard.Services;

/// <summary>
/// Service interface for statistics-related API operations.
/// </summary>
public interface IStatisticsService
{
    /// <summary>
    /// Gets the revenue/sales statistics. When <paramref name="hours"/> is set,
    /// the KPI covers the last N hours; otherwise today.
    /// </summary>
    Task<SalesTodayDto?> GetSalesTodayAsync(int? hours = null, CancellationToken ct = default);

    /// <summary>
    /// Gets the saless statistics. When <paramref name="hours"/> is set,
    /// the KPI covers the last N hours; otherwise today.
    /// </summary>
    Task<SalessTodayDto?> GetSalessTodayAsync(int? hours = null, CancellationToken ct = default);

    /// <summary>
    /// Gets the customer statistics. When <paramref name="hours"/> is set,
    /// new customers cover the last N hours; otherwise this month.
    /// </summary>
    Task<CustomersTodayDto?> GetCustomersTodayAsync(int? hours = null, CancellationToken ct = default);

    /// <summary>
    /// Gets the product/inventory statistics.
    /// </summary>
    Task<ProductsTodayDto?> GetProductsTodayAsync(CancellationToken ct = default);

    /// <summary>
    /// Gets the latest saless.
    /// </summary>
    Task<SalessLatestDto?> GetSalessLatestAsync(int count = 5, CancellationToken ct = default);

    /// <summary>
    /// Gets the best-selling products. When <paramref name="hours"/> is set,
    /// only sales from the last N hours are ranked; otherwise all-time.
    /// </summary>
    Task<ProductsBestSellingDto?> GetProductsBestSellingAsync(int count = 5, int? hours = null, CancellationToken ct = default);
}
