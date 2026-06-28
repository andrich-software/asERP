using asToolkit.Client.Core.Constants;
using asToolkit.Client.Features.TenantOAuthSettings.Models;
using asToolkit.Client.Features.TenantOAuthSettings.Services;
using asToolkit.Client.Features.TenantOAuthSettings.Views;

namespace asToolkit.Client.Features.TenantOAuthSettings;

public static class TenantOAuthSettingsModule
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<ITenantOAuthSettingsService, TenantOAuthSettingsService>();
        services.AddTransient<TenantOAuthSettingsModel>();
        return services;
    }

    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(new ViewMap<TenantOAuthSettingsPage, TenantOAuthSettingsModel>());
    }

    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.TenantOAuthSettings, View: views.FindByViewModel<TenantOAuthSettingsModel>());
    }
}
