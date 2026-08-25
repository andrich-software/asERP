using asERP.Client.Core.Constants;
using asERP.Client.Features.Categories.Models;
using asERP.Client.Features.Categories.Services;
using asERP.Client.Features.Categories.Views;

namespace asERP.Client.Features.Categories;

/// <summary>
/// Module registration for the Categories feature: the category matrix (tree list with one
/// activation checkbox per shop channel) and the category edit page.
/// </summary>
public static class CategoriesModule
{
    /// <summary>
    /// Registers Categories services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // Feature-specific services
        services.AddTransient<ICategoryService, CategoryService>();

        // Page models
        services.AddTransient<CategoryListModel>();
        services.AddTransient<CategoryEditModel>();

        return services;
    }

    /// <summary>
    /// Registers Categories views with the view registry.
    /// </summary>
    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<CategoryListPage, CategoryListModel>(),
            new ViewMap<CategoryEditPage, CategoryEditModel>(Data: new DataMap<CategoryEditData>())
        );
    }

    /// <summary>
    /// Gets the routes for the Categories feature.
    /// </summary>
    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.CategoryList, View: views.FindByViewModel<CategoryListModel>());
        yield return new RouteMap(Routes.CategoryEdit, View: views.FindByViewModel<CategoryEditModel>());
    }
}
