using asERP.Application.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace asERP.Persistence.DatabaseContext;

/// <summary>
/// Design-time factory used by <c>dotnet ef</c> (migrations / model build). It lets EF construct the
/// context WITHOUT the Server startup project, which pulls in the entire application graph. Provider
/// and connection string come from the same <c>DatabaseConfig__*</c> environment variables that
/// <c>create-migrations.sh</c> exports, so behaviour is unchanged; only the startup dependency is
/// dropped. This is never used at runtime — the app configures the context via DI in
/// <see cref="PersistenceServiceRegistration"/>.
/// </summary>
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var provider = (Environment.GetEnvironmentVariable("DatabaseConfig__Provider") ?? "SQLITE")
            .ToUpperInvariant();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // Mirror the runtime warning suppression (see PersistenceServiceRegistration for the why).
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        switch (provider)
        {
            case "MSSQL":
                optionsBuilder.UseSqlServer(
                    Environment.GetEnvironmentVariable("DatabaseConfig__ConnectionStrings__MSSQL")
                        ?? "Server=localhost;Database=aserp_design;TrustServerCertificate=True;",
                    b => b.MigrationsAssembly("asERP.Persistence.MSSQL"));
                break;

            case "POSTGRESQL":
                optionsBuilder.UseNpgsql(
                    Environment.GetEnvironmentVariable("DatabaseConfig__ConnectionStrings__POSTGRESQL")
                        ?? "Host=localhost;Port=5432;Database=aserp_design;Username=aserp;Password=aserp;",
                    b => b.MigrationsAssembly("asERP.Persistence.PostgreSQL"));
                break;

            case "SQLITE":
                optionsBuilder.UseSqlite(
                    Environment.GetEnvironmentVariable("DatabaseConfig__ConnectionStrings__SQLITE")
                        ?? "Data Source=aserp_design.db",
                    b => b.MigrationsAssembly("asERP.Persistence.SQLite"));
                break;

            default:
                throw new ArgumentException($"Unsupported database provider: {provider}");
        }

        return new ApplicationDbContext(optionsBuilder.Options, new DesignTimeTenantContext());
    }

    /// <summary>No-op tenant context — the model build never reads a live tenant.</summary>
    private sealed class DesignTimeTenantContext : ITenantContext
    {
        public Guid? GetCurrentTenantId() => null;
        public void SetCurrentTenantId(Guid? tenantId) { }
        public bool HasTenant() => false;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() => Array.Empty<Guid>();
        public void SetAssignedTenantIds(IEnumerable<Guid> tenantIds) { }
        public bool IsAssignedToTenant(Guid tenantId) => false;
    }
}
