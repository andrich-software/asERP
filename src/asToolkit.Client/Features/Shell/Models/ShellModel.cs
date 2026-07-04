using System.Collections.ObjectModel;
using System.ComponentModel;
using asToolkit.Client.Core.Models;
using asToolkit.Client.Features.Auth.Services;
using asToolkit.Client.Features.Customers.Models;
using asToolkit.Client.Features.Dashboard.Models;
using asToolkit.Client.Features.SalesChannels.Services;
using asToolkit.Domain.Dtos.Tenant;
using asToolkit.Domain.Enums;
using Microsoft.UI.Xaml;

namespace asToolkit.Client.Features.Shell.Models;

public partial class ShellModel : INotifyPropertyChanged
{
    private readonly INavigator _navigator;
    private readonly IAuthenticationService _authentication;
    private readonly ITenantContextService _tenantContext;
    private readonly ISessionManager _sessionManager;
    private readonly ITokenStorageService _tokenStorage;
    private readonly ISalesChannelService _salesChannelService;
    private readonly SemaphoreSlim _salesChannelRefreshLock = new(1, 1);
    private bool _isAuthenticated = false; // Default to false

    public event PropertyChangedEventHandler? PropertyChanged;

    // Static event for authentication state changes - allows Shell to subscribe without DI
    public static event EventHandler<bool>? AuthenticationStateChanged;

    // Static event for tenant state changes - allows Shell to subscribe without DI
    public static event EventHandler<TenantListDto?>? TenantStateChanged;

    // Static event for no-tenants state changes - allows Shell to hide navigation for users without tenants
    public static event EventHandler<bool>? NoTenantsStateChanged;

    // Static event for SalesChannel changes - allows Shell to refresh dynamic sidebar items
    public static event EventHandler? SalesChannelsChanged;

    public static void NotifySalesChannelsChanged() => SalesChannelsChanged?.Invoke(null, EventArgs.Empty);

    // ShellModel is registered as a singleton, but Uno.Extensions.Navigation can construct
    // ADDITIONAL transient instances through the ViewMap when (re)navigating the root route.
    // Only the FIRST instance may wire event subscriptions and kick off auth initialization:
    // every extra instance that subscribes + calls RefreshAsync spawns another
    // validate → token-save → auth-event → navigate cycle (infinite loop, esp. against
    // servers where /auth/validate is missing).
    private static int s_instanceCount;
    private readonly bool _isPrimaryInstance;

    public ShellModel(
        IAuthenticationService authentication,
        INavigator navigator,
        ITenantContextService tenantContext,
        ISessionManager sessionManager,
        ITokenStorageService tokenStorage,
        ISalesChannelService salesChannelService)
    {
        _navigator = navigator;
        _authentication = authentication;
        _tenantContext = tenantContext;
        _sessionManager = sessionManager;
        _tokenStorage = tokenStorage;
        _salesChannelService = salesChannelService;

        var instanceNumber = Interlocked.Increment(ref s_instanceCount);
        _isPrimaryInstance = instanceNumber == 1;
        Console.WriteLine($"[ShellModel] Instance #{instanceNumber} created (primary: {_isPrimaryInstance})");

        if (_isPrimaryInstance)
        {
            _authentication.LoggedOut += LoggedOut;
            _tenantContext.CurrentTenantChanged += OnCurrentTenantChanged;

            // Initialize authentication state asynchronously
            _ = InitializeAuthenticationState();
        }
    }

    // Event-storm watchdog: if tenant-changed events arrive in a tight loop, log ONE
    // stack trace naming the driver instead of flooding the log.
    private DateTimeOffset _tenantEventWindowStart = DateTimeOffset.MinValue;
    private int _tenantEventCount;
    private bool _tenantStormReported;

    private void OnCurrentTenantChanged(object? sender, TenantListDto? tenant)
    {
        Console.WriteLine($"[ShellModel] OnCurrentTenantChanged: {tenant?.Name ?? "null"}");

        var now = DateTimeOffset.UtcNow;
        if (now - _tenantEventWindowStart > TimeSpan.FromSeconds(1))
        {
            _tenantEventWindowStart = now;
            _tenantEventCount = 0;
            _tenantStormReported = false;
        }

        if (++_tenantEventCount > 10 && !_tenantStormReported)
        {
            _tenantStormReported = true;
            Console.WriteLine($"[ShellModel] WARNING: CurrentTenantChanged fired {_tenantEventCount}x within 1s — event loop suspected. Stack:{Environment.NewLine}{Environment.StackTrace}");
        }
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AvailableTenants)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTenant)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasMultipleTenants)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasTenants)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTenantDisplayName)));
        TenantStateChanged?.Invoke(this, tenant);
    }

    public bool IsAuthenticated
    {
        get
        {
            return _isAuthenticated;
        }
        private set
        {
            if (_isAuthenticated != value)
            {
                Console.WriteLine($"[ShellModel] IsAuthenticated changing from {_isAuthenticated} to {value}");
                _isAuthenticated = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAuthenticated)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNotAuthenticated)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthenticatedVisibility)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NotAuthenticatedVisibility)));

                // Raise static event for Shell to update navigation
                Console.WriteLine($"[ShellModel] Raising AuthenticationStateChanged event with value: {value}");
                AuthenticationStateChanged?.Invoke(this, value);
            }
        }
    }

    public bool IsNotAuthenticated
    {
        get
        {
            System.Diagnostics.Debug.WriteLine($"[ShellModel] IsNotAuthenticated GET returning: {!_isAuthenticated}");
            return !_isAuthenticated;
        }
    }

    public Visibility AuthenticatedVisibility
    {
        get
        {
            var visibility = IsAuthenticated ? Visibility.Visible : Visibility.Collapsed;
            System.Diagnostics.Debug.WriteLine($"[ShellModel] AuthenticatedVisibility GET returning: {visibility}");
            return visibility;
        }
    }

    public Visibility NotAuthenticatedVisibility
    {
        get
        {
            var visibility = IsNotAuthenticated ? Visibility.Visible : Visibility.Collapsed;
            System.Diagnostics.Debug.WriteLine($"[ShellModel] NotAuthenticatedVisibility GET returning: {visibility}");
            return visibility;
        }
    }

    // Tenant properties
    public IReadOnlyList<TenantListDto> AvailableTenants => _tenantContext.AvailableTenants;
    public TenantListDto? CurrentTenant => _tenantContext.CurrentTenant;
    public bool HasMultipleTenants => AvailableTenants.Count > 1;
    public bool HasTenants => AvailableTenants.Count > 0;
    public string CurrentTenantDisplayName => CurrentTenant?.Name ?? "asToolkit";

    public async Task SwitchTenantAsync(Guid tenantId)
    {
        Console.WriteLine($"[ShellModel] SwitchTenantAsync called with tenantId: {tenantId}");
        await _tenantContext.SetCurrentTenantAsync(tenantId);

        // Navigate to Dashboard to reload UI with new tenant context
        Console.WriteLine("[ShellModel] Navigating to Dashboard after tenant switch");
        await _navigator.NavigateViewModelAsync<DashboardModel>(this, qualifier: Qualifiers.ClearBackStack);
    }

    // Single-flight: the ctor (primary instance), App.initialNavigate and Shell.OnShellLoaded
    // all trigger auth init. Concurrent RefreshAsync calls race Uno's clear-then-set token
    // save and can see a momentarily empty cache (-> spurious "not authenticated", which
    // used to leave the shell without any initial navigation). Everyone awaits ONE run.
    private readonly object _authInitSync = new();
    private Task? _authInitTask;

    public Task InitializeAuthenticationState()
    {
        lock (_authInitSync)
        {
            return _authInitTask ??= InitializeAuthenticationStateCore();
        }
    }

    private async Task InitializeAuthenticationStateCore()
    {
        System.Diagnostics.Debug.WriteLine("[ShellModel] InitializeAuthenticationState called");

        if (!await _tokenStorage.GetRememberMeAsync())
        {
            await _tokenStorage.ClearTokenAsync();
        }

        var authenticated = await _authentication.RefreshAsync();
        System.Diagnostics.Debug.WriteLine($"[ShellModel] RefreshAsync returned: {authenticated}");
        IsAuthenticated = authenticated;
        System.Diagnostics.Debug.WriteLine($"[ShellModel] IsAuthenticated set to: {IsAuthenticated}");

        if (authenticated)
        {
            await _sessionManager.StartAsync();
        }
    }

    private async void LoggedOut(object? sender, EventArgs e)
    {
        // Uno's token cache clears all keys as part of every SaveAsync (clear-then-set),
        // and that Cleared event surfaces as LoggedOut — so this fires on every token
        // refresh/save, not just real logouts. A genuine logout also clears OUR token
        // store (TokenStorageService.ClearTokenAsync); a save cycle does not. If our
        // store still holds a token, this is a spurious LoggedOut from a save — ignore it,
        // otherwise the auth-state flip re-triggers auth checks in an infinite loop.
        if (!string.IsNullOrEmpty(await _tokenStorage.GetTokenAsync()))
        {
            return;
        }

        await _sessionManager.StopAsync();
        IsAuthenticated = false;
        await _tenantContext.ClearAsync();
        // LoginOverlay is shown automatically via SetUnauthenticatedVisibility
    }

    public async ValueTask NavigateToPage(string tag)
    {
        Console.WriteLine($"[ShellModel] NavigateToPage called with tag: '{tag}'");

        switch (tag)
        {
            case "Main":
            case "Dashboard":
                Console.WriteLine("[ShellModel] Navigating to DashboardModel");
                await _navigator.NavigateViewModelAsync<DashboardModel>(this);
                break;
            case "Customers":
                Console.WriteLine("[ShellModel] Navigating to CustomerListModel");
                try
                {
                    var result = await _navigator.NavigateViewModelAsync<CustomerListModel>(this);
                    Console.WriteLine($"[ShellModel] Navigation to CustomerListModel result: {result?.Success}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ShellModel] Navigation to CustomerListModel FAILED: {ex.Message}");
                }
                break;
            case "Saless":
                // TODO: Add Saless page when created
                // await _navigator.NavigateViewModelAsync<SalesListModel>(this);
                break;
            case "Products":
                // TODO: Add Products page when created
                // await _navigator.NavigateViewModelAsync<ProductListModel>(this);
                break;
            case "Inventory":
                // TODO: Add Inventory page when created
                // await _navigator.NavigateViewModelAsync<WarehouseListModel>(this);
                break;
            case "Settings":
                // TODO: Add Settings page when created
                // await _navigator.NavigateViewModelAsync<SettingsModel>(this);
                break;
            case "Logout":
                await _authentication.LogoutAsync(CancellationToken.None);
                break;
        }
    }

    public void UpdateAuthenticationState(bool isAuthenticated)
    {
        IsAuthenticated = isAuthenticated;

        if (isAuthenticated)
        {
            _ = _sessionManager.StartAsync();
        }
    }

    public void UpdateNoTenantsState(bool hasNoTenants)
    {
        Console.WriteLine($"[ShellModel] UpdateNoTenantsState: {hasNoTenants}");
        NoTenantsStateChanged?.Invoke(this, hasNoTenants);
    }

    /// <summary>
    /// Dynamic sidebar entries, one per configured sales channel. Bound by the Shell's
    /// ItemsRepeater. Must only be mutated on the UI thread — the Shell marshals all
    /// refresh triggers through its dispatcher before calling into this model.
    /// </summary>
    public ObservableCollection<SalesChannelNavItem> SalesChannels { get; } = new();

    public void ClearSalesChannels() => SalesChannels.Clear();

    /// <summary>
    /// Reloads the sales channels of the current tenant into <see cref="SalesChannels"/>.
    /// Re-entrant calls while a refresh is running are ignored.
    /// </summary>
    public async Task RefreshSalesChannelsAsync()
    {
        if (!await _salesChannelRefreshLock.WaitAsync(0)) return;

        try
        {
            SalesChannels.Clear();

            // Without auth/tenant there is nothing to fetch — and requesting here would 401,
            // which re-triggers the logged-out/tenant-cleared events that called this method
            // (infinite request loop that also wipes freshly stored tokens via the 401-retry path).
            if (!IsAuthenticated || _tenantContext.CurrentTenant is null)
            {
                return;
            }

            var parameters = new QueryParameters { PageSize = 100 };
            var response = await _salesChannelService.GetSalesChannelsAsync(parameters);

            SalesChannels.Clear();

            foreach (var sc in response.Data)
            {
                var tag = $"SalesChannel_{sc.Id}_{(int)sc.SalesChannelType}_{sc.Name}";
                var glyph = sc.SalesChannelType switch
                {
                    SalesChannelType.PointOfSale => "\uE7BF",
                    SalesChannelType.Shopware6 => "\uE774",
                    SalesChannelType.WooCommerce => "\uE774",
                    SalesChannelType.eBay => "\uE774",
                    SalesChannelType.Amazon => "\uE774",
                    _ => "\uE774"
                };

                SalesChannels.Add(new SalesChannelNavItem(tag, glyph, sc.Name));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ShellModel] RefreshSalesChannelsAsync error: {ex.Message}");
        }
        finally
        {
            _salesChannelRefreshLock.Release();
        }
    }
}
