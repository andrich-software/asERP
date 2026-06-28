using asToolkit.Client.Core.Constants;
using asToolkit.Client.Features.ProductAttributes.Models;
using asToolkit.Client.Features.ProductAttributes.Services;
using asToolkit.Client.Features.ProductAttributes.Views;

namespace asToolkit.Client.Features.ProductAttributes;

/// <summary>
/// Module registration for ProductAttributes feature.
/// Provides list, detail, and edit views for product attribute management.
/// </summary>
public static class ProductAttributesModule
{
    /// <summary>
    /// Registers ProductAttributes services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // Feature-specific services
        // ProductAttributeService: Transient - stateless, creates new instance per request
        services.AddTransient<IProductAttributeService, ProductAttributeService>();

        // Page models
        services.AddTransient<ProductAttributeListModel>();
        services.AddTransient<ProductAttributeDetailModel>();
        services.AddTransient<ProductAttributeEditModel>();

        return services;
    }

    /// <summary>
    /// Registers ProductAttributes views with the view registry.
    /// </summary>
    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<ProductAttributeListPage, ProductAttributeListModel>(),
            new ViewMap<ProductAttributeDetailPage, ProductAttributeDetailModel>(Data: new DataMap<ProductAttributeDetailData>()),
            new ViewMap<ProductAttributeEditPage, ProductAttributeEditModel>(Data: new DataMap<ProductAttributeEditData>())
        );
    }

    /// <summary>
    /// Gets the routes for the ProductAttributes feature.
    /// </summary>
    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.ProductAttributeList, View: views.FindByViewModel<ProductAttributeListModel>());
        yield return new RouteMap(Routes.ProductAttributeDetail, View: views.FindByViewModel<ProductAttributeDetailModel>());
        yield return new RouteMap(Routes.ProductAttributeEdit, View: views.FindByViewModel<ProductAttributeEditModel>());
    }
}

/// <summary>
/// Navigation data for product attribute detail page.
/// </summary>
public record ProductAttributeDetailData(Guid ProductAttributeId);

/// <summary>
/// Navigation data for product attribute edit page.
/// </summary>
public record ProductAttributeEditData(Guid? ProductAttributeId = null);
