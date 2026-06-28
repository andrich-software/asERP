using asToolkit.Client.Core.Constants;
using asToolkit.Client.Features.Account.Models;
using asToolkit.Client.Features.Account.Services;
using asToolkit.Client.Features.Account.Views;

namespace asToolkit.Client.Features.Account;

/// <summary>
/// Module registration for the "Mein Konto" feature: own profile + password change.
/// </summary>
public static class AccountModule
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<AccountModel>();
        return services;
    }

    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<AccountPage, AccountModel>()
        );
    }

    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.UserProfile, View: views.FindByViewModel<AccountModel>());
    }
}
