using asERP.Application.Contracts.Infrastructure;
using asERP.Shipping.Abstractions;
using asERP.Shipping.Connectors.Dhl;
using asERP.Shipping.Connectors.Dpd;
using asERP.Shipping.Connectors.Gls;
using asERP.Shipping.Connectors.Ups;
using asERP.Shipping.Models.Ups;
using asERP.Shipping.Orchestration;
using asERP.Shipping.Services;
using Microsoft.Extensions.DependencyInjection;

namespace asERP.Shipping;

public static class ShippingServiceRegistration
{
    /// <summary>
    /// Wires the carrier connectors, the label service (with outbox fallback) and — unless
    /// <paramref name="includeBackgroundServices"/> is false (tests) — the shipping orchestrator
    /// that drains the label outbox and polls tracking statuses.
    /// </summary>
    public static IServiceCollection AddShippingServices(this IServiceCollection services, bool includeBackgroundServices = true)
    {
        // Singleton auth helpers — token caches shared across scopes.
        services.AddSingleton<UpsAuthHelper>();

        // Per-carrier typed HttpClients with Polly resilience.
        services.AddHttpClient(DhlConnector.HttpClientName).AddPollyHandlers();
        services.AddHttpClient(DhlConnector.TrackingHttpClientName).AddPollyHandlers();
        services.AddHttpClient(DpdConnector.HttpClientName).AddPollyHandlers();
        services.AddHttpClient(DpdConnector.TrackingHttpClientName).AddPollyHandlers();
        services.AddHttpClient(GlsConnector.HttpClientName).AddPollyHandlers();
        services.AddHttpClient(UpsConnector.HttpClientName).AddPollyHandlers();
        services.AddHttpClient(UpsAuthHelper.HttpClientName).AddPollyHandlers();

        services.AddScoped<IShippingCarrierConnector, DhlConnector>();
        services.AddScoped<IShippingCarrierConnector, DpdConnector>();
        services.AddScoped<IShippingCarrierConnector, GlsConnector>();
        services.AddScoped<IShippingCarrierConnector, UpsConnector>();
        services.AddScoped<IShippingCarrierConnectorRegistry>(sp =>
            new ShippingCarrierConnectorRegistry(sp.GetServices<IShippingCarrierConnector>()));

        services.AddScoped<ShippingCarrierContextFactory>();
        services.AddScoped<ShippingLabelOutboxEnqueuer>();
        services.AddScoped<ShippingCarrierService>();
        services.AddScoped<IShippingCarrierService>(sp => sp.GetRequiredService<ShippingCarrierService>());
        services.AddScoped<ShippingLabelOutboxDrainer>();
        services.AddScoped<ShippingTrackingPoller>();

        if (includeBackgroundServices)
        {
            services.AddHostedService<ShippingOrchestrator>();
        }

        return services;
    }
}
