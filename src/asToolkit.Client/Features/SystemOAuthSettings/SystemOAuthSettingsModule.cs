using asToolkit.Client.Core.Constants;
using asToolkit.Client.Features.SystemOAuthSettings.Models;
using asToolkit.Client.Features.SystemOAuthSettings.Services;
using asToolkit.Client.Features.SystemOAuthSettings.Views;

namespace asToolkit.Client.Features.SystemOAuthSettings;

public static class SystemOAuthSettingsModule
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<ISystemOAuthSettingsService, SystemOAuthSettingsService>();
        services.AddTransient<SystemOAuthSettingsModel>();
        return services;
    }

    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(new ViewMap<SystemOAuthSettingsPage, SystemOAuthSettingsModel>());
    }

    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.SystemOAuthSettings, View: views.FindByViewModel<SystemOAuthSettingsModel>());
    }
}
