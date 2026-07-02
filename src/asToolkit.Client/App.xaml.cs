using asToolkit.Client.Features.Account;
using asToolkit.Client.Features.Auth;
using asToolkit.Client.Features.Auth.Services;
using asToolkit.Client.Features.Customers;
using asToolkit.Client.Features.Dashboard;
using asToolkit.Client.Features.Statistics;
using asToolkit.Client.Features.Dashboard.Models;
using asToolkit.Client.Features.Invoices;
using asToolkit.Client.Features.Manufacturers;
using asToolkit.Client.Features.Saless;
using asToolkit.Client.Features.Search;
using asToolkit.Client.Features.Products;
using asToolkit.Client.Features.Shell;
using asToolkit.Client.Features.AiModels;
using asToolkit.Client.Features.AiPrompts;
using asToolkit.Client.Features.SalesChannels;
using asToolkit.Client.Features.SalesChannelDashboards;
using asToolkit.Client.Features.Superadmin;
using asToolkit.Client.Features.ProductAttributes;
using asToolkit.Client.Features.TaxClasses;
using asToolkit.Client.Features.Tenants;
using asToolkit.Client.Features.Warehouses;
using asToolkit.Client.Features.SystemOAuthSettings;
using asToolkit.Client.Features.TenantOAuthSettings;
using asToolkit.Client.Features.Shell.Views;
using asToolkit.Client.Features.Shell.Models;
using asToolkit.Domain.Dtos.Auth;
#if __WASM__
using System.Runtime.InteropServices.JavaScript;
#endif

namespace asToolkit.Client;

public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    protected Window? MainWindow { get; private set; }
    public IHost? Host { get; private set; }

    public new static App Current => (App)Application.Current;
    public IServiceProvider Services => Host!.Services;

    [System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Uno Platform framework APIs are not trim-compatible by design")]
    [System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Interoperability", "CA1416", Justification = "Browser-specific calls are guarded by #if __WASM__")]
    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        // Load runtime config (WASM: from /config.json written by nginx entrypoint)
        // before the Shell initializes its login overlay.
        await asToolkit.Client.Core.Configuration.RuntimeConfig.LoadAsync();

        var builder = this.CreateBuilder(args)
            // Add navigation support for toolkit controls such as TabBar and NavigationView
            .UseToolkitNavigation()
            .Configure(host => host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                .UseLogging(configure: (context, logBuilder) =>
                {
                    // Configure log levels for different categories of logging
                    logBuilder
                        .SetMinimumLevel(
                            context.HostingEnvironment.IsDevelopment() ?
                                LogLevel.Debug :
                                LogLevel.Information)

                        // Default filters for core Uno Platform namespaces
                        .CoreLogLevel(LogLevel.Warning);

                    // Configure asToolkit-specific log levels
                    logBuilder.AddFilter("asToolkit.Client",
                        context.HostingEnvironment.IsDevelopment() ? LogLevel.Debug : LogLevel.Information);
                    logBuilder.AddFilter("asToolkit.Client.Features.Auth", LogLevel.Debug);
                    logBuilder.AddFilter("asToolkit.Client.Services", LogLevel.Debug);

                    // HTTP logging - useful for debugging API calls
                    logBuilder.AddFilter("System.Net.Http",
                        context.HostingEnvironment.IsDevelopment() ? LogLevel.Information : LogLevel.Warning);

                    // Uno Platform namespace filter groups
                    // Uncomment individual methods to see more detailed logging
                    //// Generic Xaml events
                    //logBuilder.XamlLogLevel(LogLevel.Debug);
                    //// Layout specific messages
                    //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
                    //// Storage messages
                    //logBuilder.StorageLogLevel(LogLevel.Debug);
                    //// Binding related messages
                    //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
                    //// Binder memory references tracking
                    //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
                    //// DevServer and HotReload related
                    //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
                    //// Debug JS interop
                    //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);

                }, enableUnoLogging: true)
                .UseSerilog(consoleLoggingEnabled: true, fileLoggingEnabled: true)
                .UseConfiguration(configure: configBuilder =>
                    configBuilder
                        .EmbeddedSource<App>()
                        .Section<AppConfig>()
                )
                // Enable localization (see appsettings.json for supported languages)
                .UseLocalization()
                .UseHttp((context, services) =>
                {
#if DEBUG
                // DelegatingHandler will be automatically injected
                services.AddTransient<DelegatingHandler, DebugHttpHandler>();
#endif
                    // Add authentication handler for all HTTP requests
                    services.AddTransient<AuthenticationHandler>();
                })
                .UseAuthentication(auth =>
                    auth.AddCustom<IMaErpAuthenticationService>(custom =>
                        custom
                            .Login(async (authService, dispatcher, tokenCache, credentials, cancellationToken) =>
                            {
                                if (!credentials.TryGetValue("Email", out var email) ||
                                    !credentials.TryGetValue("Password", out var password) ||
                                    !credentials.TryGetValue("ServerUrl", out var serverUrl))
                                {
                                    return default;
                                }

                                var rememberMe = credentials.TryGetValue("RememberMe", out var r)
                                    && bool.TryParse(r, out var parsed) && parsed;

                                var loginRequest = new LoginRequestDto
                                {
                                    Email = email,
                                    Password = password,
                                    Server = serverUrl,
                                    RememberMe = rememberMe
                                };

                                var response = await authService.LoginAsync(loginRequest, cancellationToken);

                                if (response?.Succeeded == true && !string.IsNullOrEmpty(response.Token))
                                {
                                    var tokens = new Dictionary<string, string>
                                    {
                                        ["AccessToken"] = response.Token,
                                        ["UserId"] = response.UserId,
                                        ["ServerUrl"] = serverUrl
                                    };

                                    if (response.CurrentTenantId.HasValue)
                                    {
                                        tokens["TenantId"] = response.CurrentTenantId.Value.ToString();
                                    }

                                    return tokens;
                                }

                                return default;
                            })
                            .Refresh(async (authService, tokenCache, cancellationToken) =>
                            {
                                var tokenStorage = tokenCache.TryGetValue("AccessToken", out var token) ? token : null;

                                if (!string.IsNullOrEmpty(tokenStorage) &&
                                    await authService.ValidateTokenAsync(tokenStorage, cancellationToken))
                                {
                                    return tokenCache;
                                }

                                // Access token missing/expired/invalid — try the long-lived refresh token.
                                // On success, hand the new access token back to the Uno auth cache so the
                                // user is silently re-authenticated without a login prompt.
                                var refreshed = await authService.RefreshTokenAsync(cancellationToken);
                                if (refreshed?.Succeeded == true && !string.IsNullOrEmpty(refreshed.Token))
                                {
                                    var tokens = new Dictionary<string, string>(tokenCache)
                                    {
                                        ["AccessToken"] = refreshed.Token
                                    };
                                    if (refreshed.CurrentTenantId.HasValue)
                                    {
                                        tokens["TenantId"] = refreshed.CurrentTenantId.Value.ToString();
                                    }
                                    return tokens;
                                }

                                return default;
                            })
                            .Logout(async (authService, dispatcher, tokenCache, cancellationToken) =>
                            {
                                // Best-effort server-side revoke before Uno clears the cache.
                                try { await authService.LogoutAsync(cancellationToken); }
                                catch { /* Refresh-token revocation is best-effort. */ }
#if __WASM__
                                // After logout the browser must not silently hand the saved
                                // password back — require the account chooser again.
                                await BrowserCredentialService.TryPreventSilentAccessAsync();
#endif
                                return true;
                            })
                    )
                )
                .ConfigureServices(RegisterAllServices)
                .UseNavigation(RegisterRoutes)
            );
        MainWindow = builder.Window;

#if DEBUG
        // MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

#if __DESKTOP__
        // Restore the window's saved position/size (or default), and keep persisting changes.
        asToolkit.Client.Core.Window.DesktopWindowState.RestoreAndTrack(MainWindow, 1500, 900);
#endif

        Host = await builder.NavigateAsync<Shell>
            (initialNavigate: async (services, navigator) =>
            {
                var auth = services.GetRequiredService<IAuthenticationService>();

                // Honour "remember me": if the user did not opt in, drop any persisted tokens
                // (incl. the Uno token cache) before attempting silent re-auth, so a reload or
                // relaunch does not auto-login an un-remembered session.
                var tokenStorage = services.GetRequiredService<ITokenStorageService>();
                if (!await tokenStorage.GetRememberMeAsync())
                {
                    await tokenStorage.ClearTokenAsync();
                }

                var authenticated = await auth.RefreshAsync();

                if (authenticated)
                {
                    var tenantContext = services.GetRequiredService<ITenantContextService>();
                    var shell = services.GetRequiredService<ShellModel>();

                    if (tenantContext.AvailableTenants.Count == 0)
                    {
                        // Authenticated but no tenants - show first tenant creation overlay
                        // Don't navigate anywhere, the Shell's FirstTenantOverlay will be shown
                        shell.UpdateNoTenantsState(true);
                    }
                    else
                    {
                        // Has tenants - normal Dashboard
                        await navigator.NavigateViewModelAsync<DashboardModel>(this, qualifier: Qualifiers.Nested);
                    }
                }
                else
                {
                    // Not authenticated: clear any deep-link URL (e.g. /Dashboard from a
                    // bookmark or reload) so the LoginOverlay is shown at "/". On WASM we
                    // rewrite the browser URL directly because Uno's INavigator does not
                    // expose the Shell ("") route from initialNavigate.
#if __WASM__
                    ReplaceWasmUrlWithRoot();
#endif
                    await Task.CompletedTask;
                }
            });

        // Hook into Window.Activated for app lifecycle (suspend/resume)
        if (MainWindow != null)
        {
            MainWindow.Activated += OnWindowActivated;
        }
    }

    private async void OnWindowActivated(object sender, WindowActivatedEventArgs args)
    {
        try
        {
            var sessionManager = Host?.Services?.GetService<ISessionManager>();
            if (sessionManager == null || !sessionManager.IsActive)
            {
                return;
            }

            if (args.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                sessionManager.OnAppSuspended();
            }
            else
            {
                // CodeActivated or PointerActivated
                await sessionManager.OnAppResumedAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[App] OnWindowActivated error: {ex.Message}");
        }
    }

#if __WASM__
    [JSImport("globalThis.history.replaceState")]
    private static partial void HistoryReplaceState(string? state, string title, string url);

    [System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static void ReplaceWasmUrlWithRoot()
    {
        try
        {
            var location = JSHost.GlobalThis.GetPropertyAsJSObject("location");
            var pathname = location?.GetPropertyAsString("pathname");
            if (string.Equals(pathname, "/", StringComparison.Ordinal)) return;

            HistoryReplaceState(null, string.Empty, "/");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[App] ReplaceWasmUrlWithRoot error: {ex.Message}");
        }
    }
#endif

    /// <summary>
    /// Registers all services from feature modules.
    /// </summary>
    private static void RegisterAllServices(HostBuilderContext context, IServiceCollection services)
    {
        // Register handlers for HTTP client pipeline
        services.AddTransient<ServerUrlHandler>();
        services.AddTransient<AuthenticationHandler>();
#if DEBUG
        services.AddTransient<DebugHttpHandler>();
#endif

        // Register Named HttpClient "MaErpApi" with handlers for API requests
        // Handler sales: ServerUrlHandler (sets base URL) -> AuthenticationHandler (adds token/tenant) -> DebugHttpHandler (logging)
#if DEBUG
        services.AddHttpClient("MaErpApi")
            .AddHttpMessageHandler<ServerUrlHandler>()
            .AddHttpMessageHandler<AuthenticationHandler>()
            .AddHttpMessageHandler<DebugHttpHandler>();
#else
        services.AddHttpClient("MaErpApi")
            .AddHttpMessageHandler<ServerUrlHandler>()
            .AddHttpMessageHandler<AuthenticationHandler>();
#endif

        // Also register default HttpClient factory for other uses
        services.AddHttpClient();

        // Register feature modules
        ShellModule.RegisterServices(services);
        AuthModule.RegisterServices(services);
        DashboardModule.RegisterServices(services);
        StatisticsModule.RegisterServices(services);
        SearchModule.RegisterServices(services);
        CustomersModule.RegisterServices(services);
        SalessModule.RegisterServices(services);
        ProductsModule.RegisterServices(services);
        ManufacturersModule.RegisterServices(services);
        InvoicesModule.RegisterServices(services);
        WarehousesModule.RegisterServices(services);
        AiModelsModule.RegisterServices(services);
        AiPromptsModule.RegisterServices(services);
        SalesChannelsModule.RegisterServices(services);
        SalesChannelDashboardsModule.RegisterServices(services);
        SuperadminModule.RegisterServices(services);
        TaxClassesModule.RegisterServices(services);
        ProductAttributesModule.RegisterServices(services);
        TenantsModule.RegisterServices(services);
        AccountModule.RegisterServices(services);
        SystemOAuthSettingsModule.RegisterServices(services);
        TenantOAuthSettingsModule.RegisterServices(services);
    }

    /// <summary>
    /// Registers all views and routes from feature modules.
    /// </summary>
    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        // Register views from all feature modules
        ShellModule.RegisterViews(views);
        AuthModule.RegisterViews(views);
        DashboardModule.RegisterViews(views);
        StatisticsModule.RegisterViews(views);
        SearchModule.RegisterViews(views);
        CustomersModule.RegisterViews(views);
        SalessModule.RegisterViews(views);
        ProductsModule.RegisterViews(views);
        ManufacturersModule.RegisterViews(views);
        InvoicesModule.RegisterViews(views);
        WarehousesModule.RegisterViews(views);
        AiModelsModule.RegisterViews(views);
        AiPromptsModule.RegisterViews(views);
        SalesChannelsModule.RegisterViews(views);
        SalesChannelDashboardsModule.RegisterViews(views);
        SuperadminModule.RegisterViews(views);
        TaxClassesModule.RegisterViews(views);
        ProductAttributesModule.RegisterViews(views);
        TenantsModule.RegisterViews(views);
        AccountModule.RegisterViews(views);
        SystemOAuthSettingsModule.RegisterViews(views);
        TenantOAuthSettingsModule.RegisterViews(views);

        // Collect routes from all feature modules
        var nestedRoutes = new List<RouteMap>();
        nestedRoutes.AddRange(AuthModule.GetRoutes(views));
        nestedRoutes.AddRange(DashboardModule.GetRoutes(views));
        nestedRoutes.AddRange(StatisticsModule.GetRoutes(views));
        nestedRoutes.AddRange(SearchModule.GetRoutes(views));
        nestedRoutes.AddRange(CustomersModule.GetRoutes(views));
        nestedRoutes.AddRange(SalessModule.GetRoutes(views));
        nestedRoutes.AddRange(ProductsModule.GetRoutes(views));
        nestedRoutes.AddRange(ManufacturersModule.GetRoutes(views));
        nestedRoutes.AddRange(InvoicesModule.GetRoutes(views));
        nestedRoutes.AddRange(WarehousesModule.GetRoutes(views));
        nestedRoutes.AddRange(AiModelsModule.GetRoutes(views));
        nestedRoutes.AddRange(AiPromptsModule.GetRoutes(views));
        nestedRoutes.AddRange(SalesChannelsModule.GetRoutes(views));
        nestedRoutes.AddRange(SalesChannelDashboardsModule.GetRoutes(views));
        nestedRoutes.AddRange(SuperadminModule.GetRoutes(views));
        nestedRoutes.AddRange(TaxClassesModule.GetRoutes(views));
        nestedRoutes.AddRange(ProductAttributesModule.GetRoutes(views));
        nestedRoutes.AddRange(TenantsModule.GetRoutes(views));
        nestedRoutes.AddRange(AccountModule.GetRoutes(views));
        nestedRoutes.AddRange(SystemOAuthSettingsModule.GetRoutes(views));
        nestedRoutes.AddRange(TenantOAuthSettingsModule.GetRoutes(views));

        // Register the root route with all nested routes
        routes.Register(ShellModule.GetRootRoute(views, nestedRoutes));
    }
}
