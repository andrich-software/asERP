using asERP.Client.Core.Constants;
using asERP.Client.Features.ShippingProviders.Models;
using asERP.Client.Features.ShippingProviders.Services;
using asERP.Client.Features.ShippingProviders.Views;

namespace asERP.Client.Features.ShippingProviders;

public static class ShippingProvidersModule
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IShippingProviderAdminService, ShippingProviderAdminService>();
        services.AddTransient<ShippingProviderListModel>();
        services.AddTransient<ShippingProviderEditModel>();
        services.AddTransient<ShippingRateEditModel>();
        return services;
    }

    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<ShippingProviderListPage, ShippingProviderListModel>(),
            new ViewMap<ShippingProviderEditPage, ShippingProviderEditModel>(Data: new DataMap<ShippingProviderEditData>()),
            new ViewMap<ShippingRateEditPage, ShippingRateEditModel>(Data: new DataMap<ShippingRateEditData>())
        );
    }

    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.ShippingProviderList, View: views.FindByViewModel<ShippingProviderListModel>());
        yield return new RouteMap(Routes.ShippingProviderEdit, View: views.FindByViewModel<ShippingProviderEditModel>());
        yield return new RouteMap(Routes.ShippingRateEdit, View: views.FindByViewModel<ShippingRateEditModel>());
    }
}
