using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.Configurations.Options;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Interceptors;
using asERP.Persistence.Services.Backup;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

            // Credential columns are encrypted at rest through value converters that capture the
            // ICredentialEncryptor injected into ApplicationDbContext. Without a registration the context
            // falls back to the identity-function no-op and secrets are written in cleartext — fail closed
            // here instead of degrading silently. Design-time (dotnet ef) has no key ring and never writes
            // data, so the no-op stays acceptable there.
            if (!DesignTimeDetection.IsDesignTime && serviceProvider.GetService<ICredentialEncryptor>() is null)
            {
                throw new InvalidOperationException(
                    "No ICredentialEncryptor is registered in this service collection. ApplicationDbContext would " +
                    "store sales-channel, shipping, email and OAuth credentials UNENCRYPTED at rest. Register the " +
                    "DataProtection-backed encryptor (see Program.cs) before calling AddPersistenceServices().");
            }

            // EF caches the model per DbContext CLR type, so the credential converters of the first context
            // built in the process would otherwise be handed to every later context — including one built by
            // a bootstrap service provider that has no encryptor. Key the cache on the encryptor identity.
            options.ReplaceService<IModelCacheKeyFactory, CredentialEncryptorModelCacheKeyFactory>();

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
