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

            // NOTE: This suppression cannot be removed yet. The admin-user seed in
            // asERP.Identity's UserConfiguration.HasData computes PasswordHash via
            // PasswordHasher.HashPassword(...), which uses a fresh random salt on every model build,
            // so EF always sees the User model as "changed" and would otherwise raise
            // PendingModelChangesWarning on startup. The Persistence-owned seeds (Setting, Country,
            // UserTenant) are already compile-time constants; removing this line is blocked solely on
            // making the user-seed hash deterministic (out of scope — that seed is intentionally kept).
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
