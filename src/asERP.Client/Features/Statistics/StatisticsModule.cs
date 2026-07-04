using asERP.Client.Core.Constants;
using asERP.Client.Features.Statistics.Models;
using asERP.Client.Features.Statistics.Services;
using asERP.Client.Features.Statistics.Views;

namespace asERP.Client.Features.Statistics;

/// <summary>
/// Module registration for the Statistics feature.
/// Provides revenue and other statistical chart views.
/// </summary>
public static class StatisticsModule
{
    /// <summary>
    /// Registers Statistics services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IRevenueStatisticsService, RevenueStatisticsService>();
        services.AddTransient<RevenueModel>();
        return services;
    }

    /// <summary>
    /// Registers Statistics views with the view registry.
    /// </summary>
    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<RevenuePage, RevenueModel>()
        );
    }

    /// <summary>
    /// Gets the routes for the Statistics feature.
    /// </summary>
    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.StatisticsRevenue, View: views.FindByViewModel<RevenueModel>());
    }
}
