using asToolkit.Client.Features.Auth.Services;
#if __WASM__
using Microsoft.Extensions.DependencyInjection.Extensions;
using Uno.Extensions.Authentication;
#endif

namespace asToolkit.Client.Features.Auth;

/// <summary>
/// Module registration for Authentication feature.
/// Handles login, logout, and authentication state management.
/// </summary>
public static class AuthModule
{
    /// <summary>
    /// Registers Auth services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // Secure credential store for the long-lived refresh token. Default impl uses
        // ApplicationData.Current.LocalSettings on every target — for stronger isolation, swap
        // in a platform-specific impl (e.g. Windows.Security.Credentials.PasswordVault on
        // Windows, Keychain on macOS/iOS, Keystore on Android) behind #if directives.
        services.AddSingleton<ISecureCredentialStore, LocalSettingsCredentialStore>();

#if __WASM__
        // Uno's default ITokenCache does not survive a WASM page reload (its values written via
        // ApplicationDataKeyValueStorage are gone after reload), which leaves RefreshAsync seeing
        // an empty cache and breaks silent auto-login. Replace it on WASM with a cache that writes
        // straight to LocalSettings, which does persist. See WasmLocalSettingsTokenCache.
        // This runs after UseAuthentication() in App.OnLaunched, so it overrides Uno's registration.
        services.RemoveAll<ITokenCache>();
        services.AddSingleton<ITokenCache, WasmLocalSettingsTokenCache>();
#endif

        // Authentication services (singleton for state management)
        services.AddSingleton<ITokenStorageService, TokenStorageService>();
        services.AddSingleton<ITenantContextService, TenantContextService>();
        services.AddSingleton<IMaErpAuthenticationService, MaErpAuthenticationService>();
        services.AddSingleton<IServerInfoService, ServerInfoService>();
        services.AddSingleton<IServerProfileStore, ServerProfileStore>();

        // Session management
        services.AddSingleton<SessionSettings>();
        services.AddSingleton<ISessionManager, SessionManager>();

        return services;
    }

    /// <summary>
    /// Registers Auth views with the view registry.
    /// </summary>
    public static void RegisterViews(IViewRegistry views)
    {
        // Login is handled by Shell's LoginOverlay - no page registration needed
    }

    /// <summary>
    /// Gets the routes for the Auth feature.
    /// </summary>
    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        // Login is handled by Shell's LoginOverlay - no routes needed
        yield break;
    }
}
