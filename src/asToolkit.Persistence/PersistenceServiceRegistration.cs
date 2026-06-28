using asToolkit.Domain.Entities;
using asToolkit.Persistence.Configurations.Options;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace asToolkit.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<ChannelExportNotificationInterceptor>();

        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            var dbOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
            var connectionString = dbOptions.GetConnectionString();

            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            options.AddInterceptors(serviceProvider.GetRequiredService<ChannelExportNotificationInterceptor>());

            switch (dbOptions.Provider.ToUpperInvariant())
            {
                case "MSSQL":
                    options.UseSqlServer(connectionString,
                        b => b.MigrationsAssembly("asToolkit.Persistence.MSSQL"));
                    break;

                case "POSTGRESQL":
                    options.UseNpgsql(connectionString,
                        b => b.MigrationsAssembly("asToolkit.Persistence.PostgreSQL"));
                    break;

                case "SQLITE":
                    options.UseSqlite(connectionString,
                        b => b.MigrationsAssembly("asToolkit.Persistence.SQLite"));
                    break;

                default:
                    throw new ArgumentException($"Unsupported database provider: {dbOptions.Provider}");
            }
        });

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}