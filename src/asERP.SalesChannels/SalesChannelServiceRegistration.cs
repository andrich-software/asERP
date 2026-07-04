using asERP.Application;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.Amazon;
using asERP.SalesChannels.Connectors.Ebay;
using asERP.SalesChannels.Connectors.Pos;
using asERP.SalesChannels.Connectors.Shopware6;
using asERP.SalesChannels.Connectors.WooCommerce;
using asERP.SalesChannels.Connectors.WooCommerceDatabase;
using asERP.SalesChannels.Contracts;
using asERP.SalesChannels.Logging;
using asERP.SalesChannels.Models.Amazon;
using asERP.SalesChannels.Models.eBay;
using asERP.SalesChannels.Models.Shopware6;
using asERP.SalesChannels.Orchestration;
using asERP.SalesChannels.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace asERP.SalesChannels;

public static class SalesChannelServiceRegistration
{
    /// <param name="includeBackgroundServices">
    /// When false, the orchestrator hosted service is not registered — useful in integration
    /// tests where the test host owns scheduling.
    /// </param>
    public static IServiceCollection AddSalesChannelServices(this IServiceCollection services, bool includeBackgroundServices = true)
    {
        services.AddScoped<IProductImportRepository, ProductImportRepository>();
        services.AddScoped<ISalesImportRepository, SalesImportRepository>();
        services.AddScoped<ICustomerImportRepository, CustomerImportRepository>();
        services.AddScoped<IStockImportRepository, StockImportRepository>();
        services.AddScoped<IProductImageImportService, ProductImageImportService>();
        // Singleton: one CustomerId/SalesId sequence per (tenant, kind) across all concurrent import runs.
        services.AddSingleton<ImportIdAllocator>();
        // Auth helpers are singletons because they hold per-channel access-token caches; they
        // resolve the scoped IOAuthAppSettingsService internally via IServiceScopeFactory.
        services.AddSingleton<EbayAuthHelper>();
        services.AddSingleton<AmazonAuthHelper>();
        services.AddSingleton<Shopware6AuthHelper>();

        // Per-channel typed HttpClients with Polly resilience. Connectors get the matching
        // client by name from IHttpClientFactory via the SalesChannelContext.
        services.AddHttpClient("shopware6").AddPollyHandlers();
        services.AddHttpClient("woocommerce").AddPollyHandlers();
        services.AddHttpClient("ebay").AddPollyHandlers();
        services.AddHttpClient("amazon").AddPollyHandlers();
        // Dedicated client for the LWA token endpoint — different host (api.amazon.com) and
        // shorter Polly settings make sense; for now we share the default policy.
        services.AddHttpClient("amazon-lwa").AddPollyHandlers();
        // Plain (unauthenticated) client for downloading product photos from the shops' public URLs.
        // The Chrome UA + "asERP" suffix lets the shop's CDN/WAF rules identify and allow the importer.
        services.AddHttpClient(ProductImageImportService.HttpClientName, client =>
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/137.0.0.0 Safari/537.36 asERP");
            })
            .AddPollyHandlers();

        // Connectors (one per SalesChannelType). Resolved through the registry, never via
        // direct DI — keeps the channel-specific switch in one place.
        services.AddScoped<ISalesChannelConnector, PosConnector>();
        services.AddScoped<ISalesChannelConnector, Shopware6Connector>();
        services.AddScoped<ISalesChannelConnector, WooCommerceConnector>();
        services.AddScoped<ISalesChannelConnector, WooCommerceDatabaseConnector>();
        services.AddScoped<ISalesChannelConnector, EbayConnector>();
        services.AddScoped<ISalesChannelConnector, AmazonConnector>();

        services.AddScoped<ISalesChannelConnectorRegistry>(sp =>
            new SalesChannelConnectorRegistry(sp.GetServices<ISalesChannelConnector>()));

        services.AddScoped<ChannelExportOutboxEnqueuer>();
        services.AddScoped<SalesChannelContextFactory>();
        services.AddScoped<SyncDispatcher>();
        services.AddScoped<OutboxDrainer>();

        // Sync-log capture: the buffer is a process-wide singleton shared by the Serilog sink
        // (producer) and the drainer (consumer). The drainer is scoped like OutboxDrainer.
        services.AddSingleton<ISalesChannelSyncLogBuffer, SalesChannelSyncLogBuffer>();
        services.AddScoped<SyncLogDrainer>();
        if (includeBackgroundServices)
        {
            services.AddHostedService<SalesChannelOrchestrator>();
        }

        services.RegisterHandlersFromAssembly(typeof(SalesChannelServiceRegistration).Assembly);

        // Legacy per-channel hosted-service tasks (Tasks/WooCommerce*, /Ebay*) are
        // superseded by SalesChannelOrchestrator dispatching through the connectors. The .cs files
        // remain in the repo as historical reference until the PR 16 cleanup deletes them.

        return services;
    }
}
