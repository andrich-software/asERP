using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.Configurations.Options;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Interceptors;
using asERP.Persistence.Services.Backup;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace asERP.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<ChannelExportNotificationInterceptor>();

        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            var dbOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
            var connectionString = dbOptions.GetConnectionString();

            // NOTE: This suppression is required. Reference-data seeds (Country, Manufacturer, Warehouse,
            // TaxClass, Setting, SalesChannel) set DateCreated/DateModified (and IdentityRole its
            // ConcurrencyStamp) to non-deterministic values on every model build, so EF always sees the
            // model as diverging from the last migration and would otherwise raise
            // PendingModelChangesWarning on startup. The removed default-data seeds (admin user, default
            // tenant, user↔tenant/role links) are not the cause and do not appear in that diff.
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            options.AddInterceptors(serviceProvider.GetRequiredService<ChannelExportNotificationInterceptor>());

            switch (dbOptions.Provider.ToUpperInvariant())
            {
                case "MSSQL":
                    options.UseSqlServer(connectionString,
                        b => b.MigrationsAssembly("asERP.Persistence.MSSQL"));
                    break;

                case "POSTGRESQL":
                    options.UseNpgsql(connectionString,
                        b => b.MigrationsAssembly("asERP.Persistence.PostgreSQL"));
                    break;

                case "SQLITE":
                    options.UseSqlite(connectionString,
                        b => b.MigrationsAssembly("asERP.Persistence.SQLite"));
                    break;

                default:
                    throw new ArgumentException($"Unsupported database provider: {dbOptions.Provider}");
            }
        });

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // BackupOptions is bound by the host (Program.cs / CliRunner) — this registration
        // only needs the options plumbing to resolve.
        services.AddScoped<IDatabaseBackupService, DatabaseBackupService>();

        return services;
    }
}
