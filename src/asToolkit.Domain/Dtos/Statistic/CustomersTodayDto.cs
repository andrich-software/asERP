namespace asToolkit.Domain.Dtos.Statistic;

/// <summary>
/// DTO for customer statistics (third KPI card)
/// </summary>
public class CustomersTodayDto
{
    /// <summary>
    /// Total number of customers
    /// </summary>
    public int CustomersTotal { get; set; }

    /// <summary>
    /// New customers this month
    /// </summary>
    public int CustomersNewThisMonth { get; set; }

    /// <summary>
    /// New customers within the requested period (last N hours; falls back to this month when no period was requested)
    /// </summary>
    public int CustomersNew { get; set; }

    /// <summary>
    /// Customers percentage change compared to the previous period (or last month when no period was requested)
    /// </summary>
    public decimal CustomersChangePercent { get; set; }
}
