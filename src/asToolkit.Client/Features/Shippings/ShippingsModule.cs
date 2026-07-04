using asToolkit.Client.Core.Constants;
using asToolkit.Client.Features.Shippings.Models;
using asToolkit.Client.Features.Shippings.Services;
using asToolkit.Client.Features.Shippings.Views;

namespace asToolkit.Client.Features.Shippings;

/// <summary>
/// Module registration for the Shippings feature.
/// Provides the tenant-wide shipment list and the shipment detail page.
/// </summary>
public static class ShippingsModule
{
    /// <summary>
    /// Registers Shippings services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // Feature-specific services
        // ShippingService: Transient - stateless, creates new instance per request
        services.AddTransient<IShippingService, ShippingService>();

        // Local, tenant-scoped preferences (LocalSettings-backed, stateless)
        services.AddSingleton<IShippingPreferences, ShippingPreferences>();

        // Platform-specific label fetch/save/print (partial class per platform head)
        services.AddTransient<ILabelService, LabelService>();

        // Page models
        services.AddTransient<ShippingListModel>();
        services.AddTransient<ShippingDetailModel>();

        return services;
    }

    /// <summary>
    /// Registers Shippings views with the view registry.
    /// </summary>
    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<ShippingListPage, ShippingListModel>(),
            new ViewMap<ShippingDetailPage, ShippingDetailModel>(Data: new DataMap<ShippingDetailData>())
        );
    }

    /// <summary>
    /// Gets the routes for the Shippings feature.
    /// </summary>
    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.ShippingList, View: views.FindByViewModel<ShippingListModel>());
        yield return new RouteMap(Routes.ShippingDetail, View: views.FindByViewModel<ShippingDetailModel>());
    }
}

/// <summary>
/// Navigation data for the shipment detail page.
/// </summary>
public record ShippingDetailData(Guid shippingId);
