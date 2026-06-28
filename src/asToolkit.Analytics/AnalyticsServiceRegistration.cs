using asToolkit.Analytics.ClickHouse;
using asToolkit.Analytics.Identity;
using asToolkit.Analytics.Ingest;
using asToolkit.Analytics.Query;
using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Analytics.Enrichment;
using Microsoft.Extensions.DependencyInjection;

namespace asToolkit.Analytics;

public static class AnalyticsServiceRegistration
{
    /// <summary>
    /// Wires the ClickHouse-backed web-analytics module. The background services (schema bootstrapper +
    /// batch writer) talk to ClickHouse and must be skipped in the Testing environment, mirroring
    /// <c>AddSalesChannelServices(includeBackgroundServices)</c>.
    /// </summary>
    /// <param name="includeBackgroundServices">
    /// When false, the hosted services are not registered — integration tests have no ClickHouse.
    /// </param>
    public static IServiceCollection AddAnalyticsServices(this IServiceCollection services, bool includeBackgroundServices = true)
    {
        // Connection factory + token resolver are singletons; they reach scoped services (settings,
        // repositories) through a service scope created per unit of work — never via captured scopes.
        services.AddSingleton<IClickHouseConnectionFactory, ClickHouseConnectionFactory>();
        services.AddSingleton<ITrackingTokenResolver, TrackingTokenResolver>();

        // Ingest write path: shared queue + stateless session hasher + the enqueue service. All singletons
        // (the ingest endpoint resolves the service on the request scope but it holds no scoped state).
        services.AddSingleton<ISessionHasher, SessionHasher>();
        services.AddSingleton<WebAnalyticsIngestQueue>();
        services.AddSingleton<IWebAnalyticsIngestService, WebAnalyticsIngestService>();

        // Read path: scoped so it observes the request's tenant context (tenant isolation is enforced here).
        services.AddScoped<IWebAnalyticsQueryService, ClickHouseWebAnalyticsQueryService>();

        if (includeBackgroundServices)
        {
            services.AddHostedService<ClickHouseSchemaBootstrapper>();
            services.AddHostedService<WebAnalyticsBatchWriter>();
        }

        return services;
    }
}
