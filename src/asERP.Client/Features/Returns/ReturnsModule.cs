using asERP.Client.Features.Returns.Services;

namespace asERP.Client.Features.Returns;

/// <summary>
/// Module registration for the Returns (RMA) feature. v1 has no own pages — the returns UI
/// lives on the SalesDetailPage (header action, shipments-tab section, dialogs), so only the
/// service is registered here.
/// </summary>
public static class ReturnsModule
{
    /// <summary>
    /// Registers Returns services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // ReturnService: Transient - stateless, creates new instance per request
        services.AddTransient<IReturnService, ReturnService>();

        return services;
    }
}
