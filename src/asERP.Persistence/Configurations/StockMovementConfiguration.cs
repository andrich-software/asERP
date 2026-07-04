using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
    private readonly string _salesItemFilter;

    /// <param name="salesItemFilter">
    /// Provider-specific SQL for the partial-index predicate (identifier quoting differs: PostgreSQL
    /// needs <c>"SalesItemId"</c> — unquoted identifiers are folded to lowercase and would not resolve —
    /// MSSQL uses <c>[SalesItemId]</c>, SQLite accepts it unquoted). Supplied by ApplicationDbContext,
    /// which knows the active provider.
    /// </param>
    public StockMovementConfiguration(string salesItemFilter)
    {
        _salesItemFilter = salesItemFilter;
    }

    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        // Idempotency for order-driven movements: the same order line books the same movement type at
        // most once, so re-importing an order (idempotent upserts everywhere) never double-decrements.
        // Filtered: mirror/manual movements have no SalesItemId and may repeat freely (and on MSSQL,
        // where NULLs count as equal in unique indexes, the filter is what makes repeats legal at all).
        builder.HasIndex(e => new { e.SalesItemId, e.Type })
            .IsUnique()
            .HasFilter(_salesItemFilter);

        // Balance/audit lookups per product (+ warehouse) ordered by time.
        builder.HasIndex(e => new { e.ProductId, e.WarehouseId, e.DateCreated });

        builder.Property(e => e.Note).HasMaxLength(500);
    }
}
