using System.Linq.Expressions;

namespace asERP.Application.Features.Product.Shared;

/// <summary>
/// EF-translatable stock predicates shared by the product list filter and the dashboard
/// to-do count.
/// </summary>
public static class ProductStockFilters
{
    /// <summary>
    /// Below minimum stock in at least one warehouse; unset minimums (0) are ignored,
    /// zero stock counts.
    /// </summary>
    public static Expression<Func<Domain.Entities.Product, bool>> LowStock =>
        p => p.ProductStocks.Any(ps => ps.Stock <= ps.StockMin && ps.StockMin > 0);
}
