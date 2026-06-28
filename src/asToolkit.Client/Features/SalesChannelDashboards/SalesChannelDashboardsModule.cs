using asToolkit.Client.Core.Constants;
using asToolkit.Client.Features.SalesChannelDashboards.Models;
using asToolkit.Client.Features.SalesChannelDashboards.Services;
using asToolkit.Client.Features.SalesChannelDashboards.Views;

namespace asToolkit.Client.Features.SalesChannelDashboards;

/// <summary>
/// Module registration for SalesChannel Dashboards feature.
/// Provides per-SalesChannel dashboard pages with KPIs and type-specific features.
/// </summary>
public static class SalesChannelDashboardsModule
{
    /// <summary>
    /// Registers SalesChannel Dashboard services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<ISalesChannelStatisticsService, SalesChannelStatisticsService>();
        services.AddTransient<PosDashboardModel>();
        services.AddTransient<SalesChannelDashboardModel>();

        return services;
    }

    /// <summary>
    /// Registers SalesChannel Dashboard views with the view registry.
    /// </summary>
    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<PosDashboardPage, PosDashboardModel>(Data: new DataMap<SalesChannelDashboardData>()),
            new ViewMap<SalesChannelDashboardPage, SalesChannelDashboardModel>(Data: new DataMap<SalesChannelDashboardData>())
        );
    }

    /// <summary>
    /// Gets the routes for the SalesChannel Dashboards feature.
    /// </summary>
    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.PosDashboard, View: views.FindByViewModel<PosDashboardModel>());
        yield return new RouteMap(Routes.SalesChannelDashboard, View: views.FindByViewModel<SalesChannelDashboardModel>());
    }
}
