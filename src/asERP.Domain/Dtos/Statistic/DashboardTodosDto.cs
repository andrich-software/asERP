namespace asERP.Domain.Dtos.Statistic;

/// <summary>
/// DTO for the dashboard to-do card: actionable counts across sales, shipping and stock.
/// </summary>
public class DashboardTodosDto
{
    /// <summary>
    /// Number of paid sales that are ready to be shipped
    /// </summary>
    public int SalessReadyToShip { get; set; }

    /// <summary>
    /// Number of sales without a completed payment for 7+ days
    /// </summary>
    public int SalessPaymentOverdue { get; set; }

    /// <summary>
    /// Number of shipments flagged as problem cases
    /// </summary>
    public int ShippingProblems { get; set; }

    /// <summary>
    /// Number of products below their minimum stock in at least one warehouse
    /// </summary>
    public int ProductsToReorder { get; set; }
}
