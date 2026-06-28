using asToolkit.Client.Core.Abstractions;
using asToolkit.Client.Core.Notifications;
using asToolkit.Client.Features.Shell.Models;
using asToolkit.Client.Features.Shell.Views;

namespace asToolkit.Client.Features.Shell;

/// <summary>
/// Module registration for Shell feature.
/// The Shell is the main application frame with navigation.
/// </summary>
public static class ShellModule
{
    /// <summary>
    /// Registers Shell services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // ShellModel is singleton to share authentication state across the app
        services.AddSingleton<ShellModel>();

        // App-wide toast/notification bus. Singleton so background work (e.g. a sales-channel
        // import started after navigation) can surface results to the user. Rendered by the
        // NotificationHost hosted in Shell.xaml.
        services.AddSingleton<INotificationService, NotificationService>();
        return services;
    }

    /// <summary>
    /// Registers Shell views with the view registry.
    /// </summary>
    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap(ViewModel: typeof(ShellModel))
        );
    }

    /// <summary>
    /// Gets the root route for the Shell.
    /// Child routes are provided by other feature modules.
    /// </summary>
    public static RouteMap GetRootRoute(IViewRegistry views, IEnumerable<RouteMap> nestedRoutes)
    {
        return new RouteMap("", View: views.FindByViewModel<ShellModel>(),
            Nested: nestedRoutes.ToArray()
        );
    }
}
