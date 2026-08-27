using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    private readonly string? _emailFilter;

    /// <param name="emailFilter">
    /// Provider-specific SQL for the partial-index predicate (identifier quoting differs: PostgreSQL
    /// needs <c>"Email"</c> — unquoted identifiers are folded to lowercase and would not resolve —
    /// MSSQL uses <c>[Email]</c>, SQLite accepts it unquoted). Supplied by ApplicationDbContext,
    /// which knows the active provider. Same pattern as <see cref="StockMovementConfiguration"/>.
    /// Null (non-relational providers, i.e. the InMemory test databases) skips the email index
    /// entirely: InMemory ignores index filters but still enforces unique indexes, so the filtered
    /// index would wrongly reject the legal duplicates the filter exists for (blanked/empty emails).
    /// </param>
    public CustomerConfiguration(string? emailFilter)
    {
        _emailFilter = emailFilter;
    }

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // The human-facing customer number is unique per tenant; this also turns the allocator's
        // MAX(CustomerId) lookups and the order import's GetByCustomerIdAsync into index seeks.
        builder.HasIndex(x => new { x.CustomerId, x.TenantId })
            .IsUnique();

        // Filtered unique index on (TenantId, Email). Email is canonicalized to lowercase by
        // ApplicationDbContext.SaveChangesAsync, so a plain equality index suffices — no functional
        // index on LOWER(Email) (which would be provider-specific) needed. The filter excludes
        // empty/null emails so merged (blanked) customers and legitimately email-less rows do not
        // block one another. This is the index behind the import's match-by-email ladder — without
        // it every imported order full-scans the customer table.
        if (_emailFilter is not null)
        {
            builder.HasIndex(x => new { x.TenantId, x.Email })
                .IsUnique()
                .HasFilter(_emailFilter);
        }
    }
}
