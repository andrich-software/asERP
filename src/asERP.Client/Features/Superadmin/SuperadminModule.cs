using asERP.Client.Core.Constants;
using asERP.Client.Features.Superadmin.Models;
using asERP.Client.Features.Superadmin.Services;
using asERP.Client.Features.Superadmin.Views;

namespace asERP.Client.Features.Superadmin;

/// <summary>
/// Module registration for Superadmin feature.
/// Provides access to all tenants for users with Superadmin role.
/// </summary>
public static class SuperadminModule
{
    /// <summary>
    /// Registers Superadmin services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // Feature-specific services
        // SuperadminTenantService: Transient - stateless, creates new instance per request
        services.AddTransient<ISuperadminTenantService, SuperadminTenantService>();
        services.AddTransient<ISuperadminCountryService, SuperadminCountryService>();

        // Page models
        services.AddTransient<SuperadminTenantListModel>();
        services.AddTransient<SuperadminTenantEditModel>();
        services.AddTransient<SuperadminCountryListModel>();
        services.AddTransient<SuperadminCountryEditModel>();

        return services;
    }

    /// <summary>
    /// Registers Superadmin views with the view registry.
    /// </summary>
    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<SuperadminTenantListPage, SuperadminTenantListModel>(),
            new ViewMap<SuperadminTenantEditPage, SuperadminTenantEditModel>(Data: new DataMap<SuperadminTenantEditData>()),
            new ViewMap<SuperadminCountryListPage, SuperadminCountryListModel>(),
            new ViewMap<SuperadminCountryEditPage, SuperadminCountryEditModel>(Data: new DataMap<SuperadminCountryEditData>())
        );
    }

    /// <summary>
    /// Gets the routes for the Superadmin feature.
    /// </summary>
    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.SuperadminTenantList, View: views.FindByViewModel<SuperadminTenantListModel>());
        yield return new RouteMap(Routes.SuperadminTenantEdit, View: views.FindByViewModel<SuperadminTenantEditModel>());
        yield return new RouteMap(Routes.SuperadminCountryList, View: views.FindByViewModel<SuperadminCountryListModel>());
        yield return new RouteMap(Routes.SuperadminCountryEdit, View: views.FindByViewModel<SuperadminCountryEditModel>());
    }
}
