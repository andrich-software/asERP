using asERP.Client.Core.Constants;
using asERP.Client.Features.TenantOAuthSettings.Models;
using asERP.Client.Features.TenantOAuthSettings.Services;
using asERP.Client.Features.TenantOAuthSettings.Views;

namespace asERP.Client.Features.TenantOAuthSettings;

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
