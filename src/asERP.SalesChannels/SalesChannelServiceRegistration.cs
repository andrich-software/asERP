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
using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

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
        // client by name from IHttpClientFactory via the SalesChannelContext. Each carries an
        // SSRF connect-time guard so a redirect or DNS-rebind to an internal IP is refused at the
        // socket, not just at the pre-flight URL check.
        services.AddHttpClient("shopware6").AddPollyHandlers().AddSsrfGuardedPrimaryHandler();
        // NOTE: no "woocommerce" named client — the WooCommerce REST connector uses WooCommerceNET's own
        // RestAPI transport (see WooCommerceConnector.BuildRestApi), not IHttpClientFactory. Product-image
        // downloads for every channel go through the shared product-images client below.
        services.AddHttpClient("ebay").AddPollyHandlers().AddSsrfGuardedPrimaryHandler();
        services.AddHttpClient("amazon").AddPollyHandlers().AddSsrfGuardedPrimaryHandler();
        // Dedicated client for the LWA token endpoint — different host (api.amazon.com) and
        // shorter Polly settings make sense; for now we share the default policy. No SSRF guard:
        // the host is Amazon's fixed OAuth endpoint, not tenant-controlled.
        services.AddHttpClient("amazon-lwa").AddPollyHandlers();
        // Plain (unauthenticated) client for downloading product photos from the shops' public URLs.
        // The Chrome UA + "asERP" suffix lets the shop's CDN/WAF rules identify and allow the importer.
        // Image URLs come from the remote shop's API response, so this client is the prime SSRF target —
        // hence the connect-time IP guard in addition to the per-URL validation before download.
        services.AddHttpClient(ProductImageImportService.HttpClientName, client =>
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/137.0.0.0 Safari/537.36 asERP");
            })
            .AddPollyHandlers()
            .AddSsrfGuardedPrimaryHandler();

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

        // All channel work is driven by SalesChannelOrchestrator dispatching through the connectors;
        // there are no per-channel hosted-service tasks.

        return services;
    }

    /// <summary>
    /// Sets a <see cref="SocketsHttpHandler"/> primary handler whose <c>ConnectCallback</c> re-validates
    /// the IP actually being dialed against <see cref="SalesChannelUrlValidator.IsBlockedAddress"/>. This
    /// closes the gap the pre-flight URL check cannot: a 3xx redirect to an internal host, or a
    /// DNS-rebind/TOCTOU where the name resolves to a public IP at check time and an internal IP at
    /// connect time. A blocked target aborts the connection before any bytes are sent.
    /// </summary>
    private static IHttpClientBuilder AddSsrfGuardedPrimaryHandler(this IHttpClientBuilder builder) =>
        builder.ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
        {
            ConnectCallback = async (ctx, cancellationToken) =>
            {
                var endPoint = new DnsEndPoint(ctx.DnsEndPoint.Host, ctx.DnsEndPoint.Port);
                var addresses = await Dns.GetHostAddressesAsync(endPoint.Host, cancellationToken);

                foreach (var address in addresses)
                {
                    if (SalesChannelUrlValidator.IsBlockedAddress(address))
                    {
                        throw new HttpRequestException(
                            $"Refused to connect to {endPoint.Host}: it resolves to a blocked private/reserved address ({address}).");
                    }
                }

                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp) { NoDelay = true };
                try
                {
                    await socket.ConnectAsync(addresses, endPoint.Port, cancellationToken);
                    return new NetworkStream(socket, ownsSocket: true);
                }
                catch
                {
                    socket.Dispose();
                    throw;
                }
            },
        });
}
