using asERP.Client.Core.Constants;
using asERP.Client.Features.GlobalSettings.Models;
using asERP.Client.Features.GlobalSettings.Services;
using asERP.Client.Features.GlobalSettings.Views;

namespace asERP.Client.Features.GlobalSettings;

public static class GlobalSettingsModule
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IGlobalSettingsService, GlobalSettingsService>();
        services.AddTransient<ISystemOAuthSettingsService, SystemOAuthSettingsService>();
        services.AddTransient<GlobalSettingsModel>();
        return services;
    }

    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(new ViewMap<GlobalSettingsPage, GlobalSettingsModel>());
    }

    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.GlobalSettings, View: views.FindByViewModel<GlobalSettingsModel>());
    }
}
