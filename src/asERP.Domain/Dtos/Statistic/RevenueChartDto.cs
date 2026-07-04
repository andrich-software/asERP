namespace asERP.Domain.Dtos.Statistic;

/// <summary>
/// DTO for the revenue line chart: a series of daily revenue data points
/// for a requested date range.
/// </summary>
public class RevenueChartDto
{
    /// <summary>
    /// Inclusive start date of the requested range (UTC).
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Inclusive end date of the requested range (UTC).
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Total revenue across the whole range.
    /// </summary>
    public decimal TotalRevenue { get; set; }

    /// <summary>
    /// One point per day in the range; days without sales are included with a revenue of 0.
    /// </summary>
    public List<RevenueChartPointDto> Points { get; set; } = new();
}

/// <summary>
/// A single point on the revenue line chart.
/// </summary>
public class RevenueChartPointDto
{
    /// <summary>
    /// The day (UTC, date component only) the revenue is aggregated for.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Total revenue summed over that day.
    /// </summary>
    public decimal Revenue { get; set; }
}
