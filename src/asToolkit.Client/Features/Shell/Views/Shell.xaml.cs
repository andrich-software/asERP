using asToolkit.Client.Core.Exceptions;
using Windows.ApplicationModel.Resources;
using asToolkit.Client.Features.Account.Models;
using asToolkit.Client.Features.Shell.Models;
using asToolkit.Client.Features.Auth.Services;
using asToolkit.Client.Features.Auth.Models;
using asToolkit.Client.Features.Auth.Views;
using Microsoft.UI.Xaml.Controls;
using asToolkit.Client.Features.Tenants.Services;
using asToolkit.Domain.Dtos.Auth;
using asToolkit.Domain.Dtos.Tenant;
using asToolkit.Client.Features.Dashboard.Models;
using asToolkit.Client.Features.Statistics.Models;
using asToolkit.Client.Features.Customers.Models;
using asToolkit.Client.Features.Invoices.Models;
using asToolkit.Client.Features.Manufacturers.Models;
using asToolkit.Client.Features.Saless;
using asToolkit.Client.Features.Saless.Models;
using asToolkit.Client.Features.Customers;
using asToolkit.Client.Features.Products.Models;
using asToolkit.Client.Features.Search;
using asToolkit.Client.Features.Search.Services;
using asToolkit.Domain.Dtos.Search;
using asToolkit.Client.Features.SalesChannels.Models;
using asToolkit.Client.Features.SalesChannels.Services;
using asToolkit.Client.Features.SalesChannelDashboards.Models;
using asToolkit.Client.Features.Superadmin.Models;
using asToolkit.Domain.Enums;
using asToolkit.Client.Features.ProductAttributes.Models;
using asToolkit.Client.Features.TaxClasses.Models;
using asToolkit.Client.Features.Tenants.Models;
using asToolkit.Client.Features.Warehouses.Models;
using asToolkit.Client.Features.AiModels.Models;
using asToolkit.Client.Features.AiPrompts.Models;
using Uno.Toolkit.UI;

namespace asToolkit.Client.Features.Shell.Views;

public sealed partial class Shell : UserControl, IContentControlProvider
{
    // Mapping of navigation tags to their corresponding sidebar Button
    private Dictionary<string, Button>? _sidebarTagMap;

    // Currently highlighted sidebar button (active state)
    private Button? _activeNavButton;

    // Debounce token for the quick-search autocomplete
    private CancellationTokenSource? _searchDebounceCts;

    // Cached reference to avoid service lookup on every pointer move
    private ISessionManager? _sessionManager;

    // Dynamic SalesChannel sidebar items (buttons inside SalesChannelSubItemsContainer)
    private readonly List<Button> _dynamicSalesChannelItems = new();
    private readonly SemaphoreSlim _salesChannelRefreshLock = new(1, 1);

    public Shell()
    {
        this.InitializeComponent();

        SetUnauthenticatedVisibility();

        ShellModel.AuthenticationStateChanged += OnAuthenticationStateChanged;
        ShellModel.TenantStateChanged += OnTenantStateChanged;
        ShellModel.NoTenantsStateChanged += OnNoTenantsStateChanged;
        ShellModel.SalesChannelsChanged += OnSalesChannelsChanged;

        this.PointerMoved += OnUserActivity;
        this.KeyDown += OnUserActivity;

        TabBarNav.SelectionChanged += OnTabBarSelectionChanged;
        this.Loaded += OnShellLoaded;
    }

    private void OnUserActivity(object sender, RoutedEventArgs e)
    {
        _sessionManager ??= (Application.Current as App)?.Host?.Services?.GetService<ISessionManager>();
        _sessionManager?.RecordUserActivity();
    }

    private void InitializeSidebarTagMap()
    {
        _sidebarTagMap = new Dictionary<string, Button>
        {
            { "Main", NavItemDashboard },
            { "Dashboard", NavItemDashboard },
            { "Customers", NavItemCustomers },
            { "Products", NavItemProducts },
            { "Manufacturers", NavItemManufacturers },
            { "Saless", NavItemSaless },
            { "Invoices", NavItemInvoices },
            { "StatisticsRevenue", NavItemRevenue },
            { "SalesChannelOverview", NavItemSalesChannels },
            { "SalesChannels", NavItemSalesChannelList },
            { "TaxClasses", NavItemTaxClasses },
            { "ProductAttributes", NavItemProductAttributes },
            { "Warehouses", NavItemWarehouses },
            { "AiModels", NavItemAiModels },
            { "AiPrompts", NavItemAiPrompts },
            { "TenantOAuthSettings", NavItemTenantOAuthSettings },
            { "SuperadminTenants", NavItemSuperadminTenants },
            { "SystemOAuthSettings", NavItemSystemOAuthSettings }
        };
    }

    /// <summary>
    /// Highlights the sidebar button that corresponds to the given tag.
    /// </summary>
    private void UpdateSidebarSelection(string? tag)
    {
        if (_sidebarTagMap == null)
        {
            InitializeSidebarTagMap();
        }

        if (_activeNavButton != null)
        {
            _activeNavButton.Background = new SolidColorBrush(Microsoft.UI.Colors.Transparent);
            _activeNavButton.ClearValue(Button.FontWeightProperty);
        }

        _activeNavButton = null;

        if (!string.IsNullOrEmpty(tag) && _sidebarTagMap!.TryGetValue(tag, out var btn))
        {
            if (Application.Current.Resources["PrimaryContainerBrush"] is Brush highlight)
            {
                btn.Background = highlight;
            }
            _activeNavButton = btn;
        }
    }

    /// <summary>
    /// Runs UI-touching work on the dispatcher thread. ShellModel state events can be raised from
    /// background threads (Task continuations); accessing XAML elements off the UI thread throws
    /// "The dependency property system should not be accessed from non UI thread."
    /// </summary>
    private void RunOnUiThread(Func<Task> work)
    {
        if (DispatcherQueue.HasThreadAccess)
        {
            _ = work();
        }
        else
        {
            DispatcherQueue.TryEnqueue(() => _ = work());
        }
    }

    private void OnAuthenticationStateChanged(object? sender, bool isAuthenticated)
    {
        Console.WriteLine($"[Shell] OnAuthenticationStateChanged received: {isAuthenticated}");

        RunOnUiThread(async () =>
        {
            if (isAuthenticated)
            {
                SetAuthenticatedVisibility();
                await UpdateSuperadminMenuVisibilityAsync();
                UpdateTenantDisplay();
                await RefreshSalesChannelSidebar();
            }
            else
            {
                SetUnauthenticatedVisibility();
                GroupSuperadminPanel.Visibility = Visibility.Collapsed;
            }
        });
    }

    private void OnTenantStateChanged(object? sender, TenantListDto? tenant)
    {
        Console.WriteLine($"[Shell] OnTenantStateChanged received: {tenant?.Name ?? "null"}");

        RunOnUiThread(async () =>
        {
            UpdateTenantDisplay();
            await RefreshSalesChannelSidebar();
        });
    }

    private void OnNoTenantsStateChanged(object? sender, bool hasNoTenants)
    {
        Console.WriteLine($"[Shell] OnNoTenantsStateChanged received: {hasNoTenants}");

        RunOnUiThread(async () =>
        {
            if (hasNoTenants)
            {
                SetNoTenantsVisibility();
            }
            else
            {
                SetAuthenticatedVisibility();
                await UpdateSuperadminMenuVisibilityAsync();
                UpdateTenantDisplay();
            }
        });
    }

    private void UpdateTenantDisplay()
    {
        try
        {
            var app = Application.Current as App;
            var tenantContext = app?.Host?.Services?.GetService<ITenantContextService>();
            if (tenantContext == null)
            {
                TenantSwitcher.Visibility = Visibility.Collapsed;
                TenantName.Visibility = Visibility.Visible;
                TenantName.Text = "asToolkit";
                return;
            }

            var tenants = tenantContext.AvailableTenants;

            if (tenants.Count > 1)
            {
                TenantSwitcherText.Text = tenantContext.CurrentTenant?.Name ?? "Tenant";
                PopulateTenantMenu(tenants, tenantContext.CurrentTenantId);
                TenantSwitcher.Visibility = Visibility.Visible;
                TenantName.Visibility = Visibility.Collapsed;
            }
            else
            {
                TenantSwitcher.Visibility = Visibility.Collapsed;
                TenantName.Visibility = Visibility.Visible;
                TenantName.Text = tenants.Count == 1 ? tenants[0].Name : "asToolkit";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] UpdateTenantDisplay error: {ex.Message}");
            TenantSwitcher.Visibility = Visibility.Collapsed;
            TenantName.Visibility = Visibility.Visible;
            TenantName.Text = "asToolkit";
        }
    }

    private void PopulateTenantMenu(IReadOnlyList<TenantListDto> tenants, Guid? currentTenantId)
    {
        TenantMenuFlyout.Items.Clear();

        foreach (var tenant in tenants)
        {
            var menuItem = new MenuFlyoutItem
            {
                Text = tenant.Name,
                Tag = tenant.Id
            };

            if (tenant.Id == currentTenantId)
            {
                menuItem.Icon = new FontIcon { Glyph = "\uE73E" };
            }

            menuItem.Click += OnTenantMenuItemClick;
            TenantMenuFlyout.Items.Add(menuItem);
        }
    }

    private async void OnTenantMenuItemClick(object sender, RoutedEventArgs e)
    {
        if (sender is not MenuFlyoutItem menuItem) return;
        if (menuItem.Tag is not Guid selectedTenantId) return;

        TenantMenuFlyout.Hide();

        try
        {
            var app = Application.Current as App;
            var tenantContext = app?.Host?.Services?.GetService<ITenantContextService>();

            if (tenantContext?.CurrentTenantId == selectedTenantId) return;

            if (tenantContext != null)
            {
                await tenantContext.SetCurrentTenantAsync(selectedTenantId);
            }

            var navigator = Splash.Navigator() ?? app?.Host?.Services?.GetService<INavigator>();

            if (navigator != null)
            {
                await navigator.NavigateViewModelAsync<DashboardModel>(this, qualifier: Qualifiers.ClearBackStack);
                UpdateSidebarSelection("Dashboard");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] OnTenantMenuItemClick error: {ex.Message}");
        }
    }

    private void SetAuthenticatedVisibility()
    {
        LoginOverlay.Visibility = Visibility.Collapsed;
        RegistrationOverlay.Visibility = Visibility.Collapsed;
        FirstTenantOverlay.Visibility = Visibility.Collapsed;

        Sidebar.Visibility = Visibility.Visible;
        ContentHeader.Visibility = Visibility.Visible;

        NavItemDashboard.Visibility = Visibility.Visible;
        NavItemCustomers.Visibility = Visibility.Visible;
        NavItemProducts.Visibility = Visibility.Visible;
        NavItemManufacturers.Visibility = Visibility.Visible;
        NavItemSaless.Visibility = Visibility.Visible;
        NavItemInvoices.Visibility = Visibility.Visible;
        NavItemRevenue.Visibility = Visibility.Visible;
        NavItemSalesChannels.Visibility = Visibility.Visible;
        NavItemTaxClasses.Visibility = Visibility.Visible;
        NavItemProductAttributes.Visibility = Visibility.Visible;
        NavItemWarehouses.Visibility = Visibility.Visible;
        NavItemAiModels.Visibility = Visibility.Visible;
        NavItemAiPrompts.Visibility = Visibility.Visible;
        NavItemTenantOAuthSettings.Visibility = Visibility.Visible;
        NavItemSalesChannelList.Visibility = Visibility.Visible;

        TabItemDashboard.Visibility = Visibility.Visible;
        TabItemCustomers.Visibility = Visibility.Visible;
        TabItemSaless.Visibility = Visibility.Visible;
        TabItemSettings.Visibility = Visibility.Visible;
        TabItemLogout.Visibility = Visibility.Visible;
    }

    private void SetUnauthenticatedVisibility()
    {
        InitializeLoginOverlay();
        LoginOverlay.Visibility = Visibility.Visible;
        RegistrationOverlay.Visibility = Visibility.Collapsed;
        FirstTenantOverlay.Visibility = Visibility.Collapsed;

        FirstTenantName.Text = string.Empty;
        FirstTenantDescription.Text = string.Empty;
        FirstTenantSaveButton.IsEnabled = false;
        FirstTenantErrorBanner.Visibility = Visibility.Collapsed;
        FirstTenantErrorText.Text = string.Empty;
        FirstTenantProgress.Visibility = Visibility.Collapsed;
        FirstTenantProgress.IsActive = false;

        Sidebar.Visibility = Visibility.Collapsed;
        ContentHeader.Visibility = Visibility.Collapsed;

        TenantSwitcher.Visibility = Visibility.Collapsed;
        TenantName.Visibility = Visibility.Visible;
        TenantName.Text = "asToolkit";
        TenantMenuFlyout.Items.Clear();

        TabItemDashboard.Visibility = Visibility.Collapsed;
        TabItemCustomers.Visibility = Visibility.Collapsed;
        TabItemSaless.Visibility = Visibility.Collapsed;
        TabItemSettings.Visibility = Visibility.Collapsed;
        TabItemLogout.Visibility = Visibility.Collapsed;

        ClearDynamicSalesChannelItems();
        UpdateSidebarSelection(null);
    }

    private void SetNoTenantsVisibility()
    {
        LoginOverlay.Visibility = Visibility.Collapsed;
        RegistrationOverlay.Visibility = Visibility.Collapsed;
        FirstTenantOverlay.Visibility = Visibility.Visible;

        FirstTenantName.Text = string.Empty;
        FirstTenantDescription.Text = string.Empty;
        FirstTenantSaveButton.IsEnabled = false;
        FirstTenantErrorBanner.Visibility = Visibility.Collapsed;
        FirstTenantErrorText.Text = string.Empty;
        FirstTenantProgress.Visibility = Visibility.Collapsed;
        FirstTenantProgress.IsActive = false;

        Sidebar.Visibility = Visibility.Collapsed;
        ContentHeader.Visibility = Visibility.Collapsed;

        TenantSwitcher.Visibility = Visibility.Collapsed;
        TenantName.Visibility = Visibility.Collapsed;

        TabItemDashboard.Visibility = Visibility.Collapsed;
        TabItemCustomers.Visibility = Visibility.Collapsed;
        TabItemSaless.Visibility = Visibility.Collapsed;
        TabItemSettings.Visibility = Visibility.Collapsed;
        TabItemLogout.Visibility = Visibility.Collapsed;
    }

    public ContentControl ContentControl => Splash;

    private async void OnShellLoaded(object sender, RoutedEventArgs e)
    {
        const int maxRetries = 10;
        const int retryDelayMs = 100;

        for (int retry = 0; retry < maxRetries; retry++)
        {
            try
            {
                var app = Application.Current as App;
                if (app?.Host?.Services != null)
                {
                    var shellModel = app.Host.Services.GetRequiredService<ShellModel>();
                    TabBarNav.DataContext = shellModel;
                    shellModel.PropertyChanged += OnShellModelPropertyChanged;

                    await shellModel.InitializeAuthenticationState();
                    UpdateNavigationVisibility(shellModel);

                    await UpdateSuperadminMenuVisibilityAsync();

                    if (shellModel.IsAuthenticated)
                    {
                        UpdateTenantDisplay();
                    }

                    InitializeDarkModeToggle();
                    return;
                }
                else
                {
                    await Task.Delay(retryDelayMs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Shell] Exception getting ShellModel (attempt {retry + 1}): {ex.Message}");
                await Task.Delay(retryDelayMs);
            }
        }
    }

    private void OnShellModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ShellModel.IsAuthenticated))
        {
            if (sender is ShellModel model)
            {
                // PropertyChanged can be raised from a background thread (e.g. the
                // LoggedOut async continuation), so marshal the XAML updates to the
                // UI thread to avoid "dependency property accessed from non UI thread".
                RunOnUiThread(() =>
                {
                    UpdateNavigationVisibility(model);
                    return Task.CompletedTask;
                });
            }
        }
    }

    private void UpdateNavigationVisibility(ShellModel model)
    {
        if (model.IsAuthenticated)
        {
            SetAuthenticatedVisibility();
        }
        else
        {
            SetUnauthenticatedVisibility();
        }
    }

    /// <summary>
    /// Unified click handler for all sidebar nav buttons. Uses the button's Tag to route.
    /// </summary>
    private async void OnNavItemClick(object sender, RoutedEventArgs e)
    {
        if (sender is not FrameworkElement el || el.Tag is not string tag) return;

        var navigator = Splash.Navigator();
        if (navigator == null)
        {
            var app = Application.Current as App;
            navigator = app?.Host?.Services?.GetService<INavigator>();
        }

        if (navigator != null)
        {
            await NavigateToPageFromShell(navigator, tag);
        }
    }

    private async Task NavigateToPageFromShell(INavigator navigator, string tag)
    {
        try
        {
            switch (tag)
            {
                case "Main":
                case "Dashboard":
                    await navigator.NavigateViewModelAsync<DashboardModel>(this);
                    break;
                case "Customers":
                    await navigator.NavigateViewModelAsync<CustomerListModel>(this);
                    break;
                case "Saless":
                    await navigator.NavigateViewModelAsync<SalesListModel>(this);
                    break;
                case "Products":
                    await navigator.NavigateViewModelAsync<ProductListModel>(this);
                    break;
                case "Manufacturers":
                    await navigator.NavigateViewModelAsync<ManufacturerListModel>(this);
                    break;
                case "Invoices":
                    await navigator.NavigateViewModelAsync<InvoiceListModel>(this);
                    break;
                case "StatisticsRevenue":
                    await navigator.NavigateViewModelAsync<RevenueModel>(this);
                    break;
                case "Warehouses":
                    await navigator.NavigateViewModelAsync<WarehouseListModel>(this);
                    break;
                case "SalesChannelOverview":
                    await navigator.NavigateViewModelAsync<SalesChannelOverviewModel>(this);
                    break;
                case "SalesChannels":
                    await navigator.NavigateViewModelAsync<SalesChannelListModel>(this);
                    break;
                case "TaxClasses":
                    await navigator.NavigateViewModelAsync<TaxClassListModel>(this);
                    break;
                case "ProductAttributes":
                    await navigator.NavigateViewModelAsync<ProductAttributeListModel>(this);
                    break;
                case "AiModels":
                    await navigator.NavigateViewModelAsync<AiModelListModel>(this);
                    break;
                case "AiPrompts":
                    await navigator.NavigateViewModelAsync<AiPromptListModel>(this);
                    break;
                case "Tenants":
                    await navigator.NavigateViewModelAsync<TenantListModel>(this);
                    break;
                case "SuperadminTenants":
                    await navigator.NavigateViewModelAsync<SuperadminTenantListModel>(this);
                    break;
                case "SystemOAuthSettings":
                    await navigator.NavigateViewModelAsync<asToolkit.Client.Features.SystemOAuthSettings.Models.SystemOAuthSettingsModel>(this);
                    break;
                case "TenantOAuthSettings":
                    await navigator.NavigateViewModelAsync<asToolkit.Client.Features.TenantOAuthSettings.Models.TenantOAuthSettingsModel>(this);
                    break;
                case "UserProfile":
                    await navigator.NavigateViewModelAsync<AccountModel>(this);
                    break;
                case "Settings":
                    break;
                case "Logout":
                    var app = Application.Current as App;
                    if (app?.Host?.Services != null)
                    {
                        var auth = app.Host.Services.GetRequiredService<IAuthenticationService>();
                        await auth.LogoutAsync(CancellationToken.None);
                    }
                    break;
                default:
                    if (tag.StartsWith("SalesChannel_"))
                    {
                        var parts = tag.Split('_', 4);
                        if (parts.Length >= 4 && Guid.TryParse(parts[1], out var scId) && int.TryParse(parts[2], out var typeInt))
                        {
                            var scType = (SalesChannelType)typeInt;
                            var scName = parts[3];
                            var data = new SalesChannelDashboardData(scId, scName, scType);

                            switch (scType)
                            {
                                case SalesChannelType.PointOfSale:
                                    await navigator.NavigateViewModelAsync<PosDashboardModel>(this, data: data);
                                    break;
                                default:
                                    await navigator.NavigateViewModelAsync<SalesChannelDashboardModel>(this, data: data);
                                    break;
                            }
                        }
                    }
                    break;
            }

            UpdateSidebarSelection(tag);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] Navigation failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Quick-search input changed: debounce, enforce the 3-character threshold and
    /// fetch autocomplete suggestions from the server.
    /// </summary>
    private async void OnQuickSearchTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        // Only react to typing, not programmatic text changes or suggestion selection.
        if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput)
        {
            return;
        }

        var query = (sender.Text ?? string.Empty).Trim();
        if (query.Length < 3)
        {
            sender.ItemsSource = null;
            return;
        }

        _searchDebounceCts?.Cancel();
        var cts = new CancellationTokenSource();
        _searchDebounceCts = cts;
        var token = cts.Token;

        try
        {
            await Task.Delay(250, token);

            var app = Application.Current as App;
            var searchService = app?.Host?.Services?.GetService<ISearchService>();
            if (searchService == null)
            {
                return;
            }

            var result = await searchService.SearchAsync(query, 5, token);
            if (token.IsCancellationRequested)
            {
                return;
            }

            // Flatten the grouped results into a single suggestion list. The two-line
            // item template renders Title + Subtitle so the type stays distinguishable.
            var hits = new List<GlobalSearchHitDto>(result.TotalCount);
            hits.AddRange(result.Customers);
            hits.AddRange(result.Sales);
            hits.AddRange(result.Invoices);
            hits.AddRange(result.Products);

            sender.ItemsSource = hits;
        }
        catch (OperationCanceledException)
        {
            // A newer keystroke superseded this request — ignore.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] Quick search failed: {ex.Message}");
            sender.ItemsSource = null;
        }
    }

    /// <summary>
    /// A suggestion was chosen (click or keyboard highlight) — jump to its detail page.
    /// </summary>
    private async void OnQuickSearchSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        if (args.SelectedItem is GlobalSearchHitDto hit)
        {
            await NavigateToHit(hit);
        }
    }

    /// <summary>
    /// Enter pressed. With a highlighted suggestion jump straight to it; otherwise open
    /// the grouped search-results page for the entered query.
    /// </summary>
    private async void OnQuickSearchQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        if (args.ChosenSuggestion is GlobalSearchHitDto hit)
        {
            await NavigateToHit(hit);
            return;
        }

        var query = (args.QueryText ?? string.Empty).Trim();
        if (query.Length < 3)
        {
            return;
        }

        var navigator = GetShellNavigator();
        if (navigator == null)
        {
            return;
        }

        sender.Text = string.Empty;
        sender.ItemsSource = null;

        try
        {
            await navigator.NavigateDataAsync(this, new SearchResultsData(query));
            UpdateSidebarSelection(null);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] Search results navigation failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Navigate to the detail page matching the hit's entity type.
    /// </summary>
    private async Task NavigateToHit(GlobalSearchHitDto hit)
    {
        var navigator = GetShellNavigator();
        if (navigator == null)
        {
            return;
        }

        QuickSearchBox.Text = string.Empty;
        QuickSearchBox.ItemsSource = null;

        try
        {
            switch (hit.Type)
            {
                case SearchEntityType.Customer:
                    await navigator.NavigateDataAsync(this, new CustomerDetailData(hit.Id));
                    break;
                case SearchEntityType.Sales:
                    await navigator.NavigateDataAsync(this, new SalesDetailData(hit.Id));
                    break;
                case SearchEntityType.Invoice:
                    await navigator.NavigateDataAsync(this, new InvoiceDetailData(hit.Id));
                    break;
                case SearchEntityType.Product:
                    await navigator.NavigateDataAsync(this, new ProductDetailData(hit.Id));
                    break;
            }

            UpdateSidebarSelection(null);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] Search hit navigation failed: {ex.Message}");
        }
    }

    private INavigator? GetShellNavigator()
    {
        var navigator = Splash.Navigator();
        if (navigator == null)
        {
            var app = Application.Current as App;
            navigator = app?.Host?.Services?.GetService<INavigator>();
        }
        return navigator;
    }

    private async void OnTabBarSelectionChanged(object? sender, TabBarSelectionChangedEventArgs args)
    {
        if (args.NewItem is TabBarItem item && item.Tag is string tag)
        {
            var navigator = Splash.Navigator();
            if (navigator == null)
            {
                var app = Application.Current as App;
                navigator = app?.Host?.Services?.GetService<INavigator>();
            }

            if (navigator != null)
            {
                await NavigateToPageFromShell(navigator, tag);
            }
        }
    }

    private async Task UpdateSuperadminMenuVisibilityAsync()
    {
        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services == null) return;

            var tokenStorage = app.Host.Services.GetService<ITokenStorageService>();
            if (tokenStorage == null) return;

            var isSuperadmin = await tokenStorage.IsInRoleAsync("Superadmin");
            GroupSuperadminPanel.Visibility = isSuperadmin ? Visibility.Visible : Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] Error checking superadmin role: {ex.Message}");
            GroupSuperadminPanel.Visibility = Visibility.Collapsed;
        }
    }

    private async void OnLogoutClick(object sender, RoutedEventArgs e)
    {
        var navigator = Splash.Navigator();
        if (navigator == null)
        {
            var app = Application.Current as App;
            navigator = app?.Host?.Services?.GetService<INavigator>();
        }

        if (navigator != null)
        {
            await NavigateToPageFromShell(navigator, "Logout");
        }
    }

    private void OnDarkModeToggle(object sender, RoutedEventArgs e)
    {
        try
        {
            var xamlRoot = this.XamlRoot;
            if (xamlRoot == null) return;

            // Determine current theme via the root element's actual theme
            var currentTheme = (this.XamlRoot?.Content as FrameworkElement)?.ActualTheme
                               ?? Microsoft.UI.Xaml.ApplicationTheme.Light.ToElementTheme();

            var newTheme = currentTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark;
            SystemThemeHelper.SetApplicationTheme(xamlRoot, newTheme);
            UpdateDarkModeIcon(newTheme == ElementTheme.Dark);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] Failed to toggle theme: {ex.Message}");
        }
    }

    private void InitializeDarkModeToggle()
    {
        try
        {
            var osTheme = SystemThemeHelper.GetCurrentOsTheme();
            var isDarkMode = osTheme == Microsoft.UI.Xaml.ApplicationTheme.Dark;

            var xamlRoot = this.XamlRoot;
            if (xamlRoot != null)
            {
                var appTheme = isDarkMode ? ElementTheme.Dark : ElementTheme.Light;
                SystemThemeHelper.SetApplicationTheme(xamlRoot, appTheme);
            }

            UpdateDarkModeIcon(isDarkMode);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] Failed to initialize dark mode toggle: {ex.Message}");
        }
    }

    private void UpdateDarkModeIcon(bool isDarkMode)
    {
        // Moon (&#xE708;) when dark, Sun-like (&#xE793;) when light
        DarkModeIcon.Glyph = isDarkMode ? "\uE708" : "\uE793";
    }

    private void OnGroupHeaderClick(object sender, RoutedEventArgs e)
    {
        if (sender is not Button btn || btn.Tag is not string contentName) return;

        if (this.FindName(contentName) is not FrameworkElement content) return;

        var isExpanding = content.Visibility == Visibility.Collapsed;
        content.Visibility = isExpanding ? Visibility.Visible : Visibility.Collapsed;

        // Chevron sibling: replace "Content" suffix with "Chevron"
        var chevronName = contentName.EndsWith("Content")
            ? contentName.Substring(0, contentName.Length - "Content".Length) + "Chevron"
            : contentName + "Chevron";

        if (this.FindName(chevronName) is FontIcon chevron)
        {
            // Down (E70D) when expanded, Right (E76C) when collapsed
            chevron.Glyph = isExpanding ? "\uE70D" : "\uE76C";
        }
    }

    #region Dynamic SalesChannel Sidebar

    private void OnSalesChannelsChanged(object? sender, EventArgs e)
    {
        RunOnUiThread(RefreshSalesChannelSidebar);
    }

    private async Task RefreshSalesChannelSidebar()
    {
        if (!await _salesChannelRefreshLock.WaitAsync(0)) return;

        try
        {
            ClearDynamicSalesChannelItems();

            var app = Application.Current as App;
            var salesChannelService = app?.Host?.Services?.GetService<ISalesChannelService>();
            if (salesChannelService == null) return;

            var parameters = new Core.Models.QueryParameters { PageSize = 100 };
            var response = await salesChannelService.GetSalesChannelsAsync(parameters);

            ClearDynamicSalesChannelItems();

            if (response.Data.Count == 0) return;

            if (_sidebarTagMap == null) InitializeSidebarTagMap();

            var items = new List<Button>();

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

                var btn = new Button
                {
                    Tag = tag,
                    Style = (Style)this.Resources["SidebarNavItemStyle"],
                    Margin = new Thickness(24, 1, 8, 1),
                    Height = 30,
                    Content = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Spacing = 10,
                        Children =
                        {
                            new FontIcon { Glyph = glyph, FontSize = 14 },
                            new TextBlock
                            {
                                Text = sc.Name,
                                Style = (Style)Application.Current.Resources["BodySmall"],
                                VerticalAlignment = VerticalAlignment.Center,
                                TextTrimming = TextTrimming.CharacterEllipsis
                            }
                        }
                    }
                };
                btn.Click += OnNavItemClick;

                items.Add(btn);
                _sidebarTagMap![tag] = btn;
            }

            SalesChannelSubItemsContainer.ItemsSource = items;
            _dynamicSalesChannelItems.AddRange(items);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] RefreshSalesChannelSidebar error: {ex.Message}");
        }
        finally
        {
            _salesChannelRefreshLock.Release();
        }
    }

    private void ClearDynamicSalesChannelItems()
    {
        SalesChannelSubItemsContainer.ItemsSource = null;
        _dynamicSalesChannelItems.Clear();

        if (_sidebarTagMap != null)
        {
            var dynamicKeys = _sidebarTagMap.Keys.Where(k => k.StartsWith("SalesChannel_")).ToList();
            foreach (var key in dynamicKeys)
            {
                _sidebarTagMap.Remove(key);
            }
        }
    }

    #endregion

    #region Login Overlay

    private void InitializeLoginOverlay()
    {
        LoginEmail.Text = string.Empty;
        LoginPassword.Password = string.Empty;
        LoginErrorBanner.Visibility = Visibility.Collapsed;
        LoginErrorText.Text = string.Empty;
        LoginProgress.Visibility = Visibility.Collapsed;
        LoginProgress.IsActive = false;
        LoginButton.IsEnabled = true;
        LoginServerPanel.Visibility = Visibility.Visible;
        LoginServerStatus.Visibility = Visibility.Collapsed;
        RegisterLink.Visibility = Visibility.Collapsed;

        // Dev convenience credentials (per-server last-used email overrides the email below
        // via the selector's SelectionChanged once a server has been used).
        try
        {
            var app = Application.Current as App;
            var hostEnvironment = app?.Host?.Services?.GetService<IHostEnvironment>();
            if (hostEnvironment?.IsDevelopment() == true)
            {
                LoginEmail.Text = "admin@localhost.com";
                LoginPassword.Password = "P@ssword1";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] InitializeLoginOverlay error: {ex.Message}");
        }

        // Runtime config (WASM: /config.json from nginx env var) may pin the server URL —
        // hide the whole server selector and use the configured value.
        if (asToolkit.Client.Core.Configuration.RuntimeConfig.IsServerUrlRestricted)
        {
            LoginServerPanel.Visibility = Visibility.Collapsed;
            _ = RefreshRegistrationLinkAsync(asToolkit.Client.Core.Configuration.RuntimeConfig.RestrictServerUrl!);
            return;
        }

        _ = InitializeServerSelectorAsync();
    }

    private async Task InitializeServerSelectorAsync()
    {
        try
        {
            var app = Application.Current as App;
            var store = app?.Host?.Services?.GetService<IServerProfileStore>();
            if (store == null) return;

            var servers = await store.GetAllAsync();
            var lastUsed = await store.GetLastUsedAsync();

            LoginServerSelector.ItemsSource = servers;
            // Setting SelectedItem raises SelectionChanged, which applies the email prefill,
            // status badge and registration-link refresh for the chosen server.
            LoginServerSelector.SelectedItem =
                servers.FirstOrDefault(s => s.Id == lastUsed.Id) ?? servers.FirstOrDefault();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] InitializeServerSelectorAsync error: {ex.Message}");
        }
    }

    private void LoginServerSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (LoginServerSelector.SelectedItem is not ServerProfile profile)
        {
            return;
        }

        // Auto-fill the last email used for this server (don't clear an existing entry otherwise).
        if (!string.IsNullOrWhiteSpace(profile.LastUsedEmail))
        {
            LoginEmail.Text = profile.LastUsedEmail;
        }

        _ = RefreshServerStatusAsync(profile.Url);
        _ = RefreshRegistrationLinkAsync(profile.Url);
    }

    private async Task RefreshServerStatusAsync(string serverUrl)
    {
        try
        {
            LoginServerStatus.Visibility = Visibility.Visible;
            LoginServerStatus.Text = Localize("ServerDialog.StatusChecking", "prüfe …");

            var app = Application.Current as App;
            var serverInfo = app?.Host?.Services?.GetService<IServerInfoService>();
            if (serverInfo == null)
            {
                LoginServerStatus.Visibility = Visibility.Collapsed;
                return;
            }

            var info = await serverInfo.GetServerInfoAsync(serverUrl);
            LoginServerStatus.Text = info != null
                ? string.Format(Localize("ServerDialog.StatusConnectedFormat", "asToolkit v{0} · verbunden"), info.Version)
                : Localize("ServerDialog.StatusOffline", "offline");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] RefreshServerStatusAsync error: {ex.Message}");
            LoginServerStatus.Text = Localize("ServerDialog.StatusOffline", "offline");
        }
    }

    private async void ManageServers_Click(object sender, RoutedEventArgs e)
    {
        var app = Application.Current as App;
        var store = app?.Host?.Services?.GetService<IServerProfileStore>();
        var serverInfo = app?.Host?.Services?.GetService<IServerInfoService>();
        if (store == null || serverInfo == null || this.XamlRoot == null)
        {
            return;
        }

        var currentId = (LoginServerSelector.SelectedItem as ServerProfile)?.Id;

        var dialog = new ServerManagementDialog(store, serverInfo, this.XamlRoot);
        await dialog.ShowAsync();

        // Reload the selector after management; keep the current selection if it still exists.
        var servers = await store.GetAllAsync();
        LoginServerSelector.ItemsSource = servers;
        LoginServerSelector.SelectedItem =
            servers.FirstOrDefault(s => s.Id == currentId) ?? servers.FirstOrDefault();
    }

    private static string Localize(string key, string fallback)
    {
        try
        {
            var value = Windows.ApplicationModel.Resources.ResourceLoader
                .GetForViewIndependentUse().GetString(key);
            return string.IsNullOrEmpty(value) ? fallback : value;
        }
        catch
        {
            return fallback;
        }
    }

    private async Task RefreshRegistrationLinkAsync(string serverUrl)
    {
        try
        {
            // Skip half-typed URLs like "https://" — Uri.TryCreate would
            // accept them but the request is guaranteed to fail.
            if (!Uri.TryCreate(serverUrl, UriKind.Absolute, out var uri) ||
                string.IsNullOrWhiteSpace(uri.Host))
            {
                RegisterLink.Visibility = Visibility.Collapsed;
                return;
            }

            var app = Application.Current as App;
            var serverInfoService = app?.Host?.Services?.GetService<IServerInfoService>();
            if (serverInfoService == null) return;

            var info = await serverInfoService.GetServerInfoAsync(serverUrl);
            RegisterLink.Visibility = info?.RegistrationEnabled == true
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] RefreshRegistrationLinkAsync error: {ex.Message}");
            RegisterLink.Visibility = Visibility.Collapsed;
        }
    }

    private void LoginInput_KeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            e.Handled = true;
            LoginButton_Click(LoginButton, new RoutedEventArgs());
        }
    }

    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedProfile = LoginServerSelector.SelectedItem as ServerProfile;
        var serverUrl = asToolkit.Client.Core.Configuration.RuntimeConfig.IsServerUrlRestricted
            ? asToolkit.Client.Core.Configuration.RuntimeConfig.RestrictServerUrl!
            : selectedProfile?.Url;
        var email = LoginEmail.Text?.Trim();
        var password = LoginPassword.Password;

        if (string.IsNullOrWhiteSpace(serverUrl) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            LoginErrorText.Text = "Please fill in all fields";
            LoginErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        serverUrl = ServerUrlUtil.Normalize(serverUrl);

        // If the user typed the URL and clicked Login without leaving the
        // field first, LostFocus may not have fired — refresh the registration
        // link visibility now (fire-and-forget; do not block login).
        _ = RefreshRegistrationLinkAsync(serverUrl);

        LoginButton.IsEnabled = false;
        LoginProgress.Visibility = Visibility.Visible;
        LoginProgress.IsActive = true;
        LoginErrorBanner.Visibility = Visibility.Collapsed;

        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services == null)
            {
                throw new InvalidOperationException("Services not available");
            }

            var auth = app.Host.Services.GetRequiredService<IAuthenticationService>();
            var tenantContext = app.Host.Services.GetRequiredService<ITenantContextService>();
            var shellModel = app.Host.Services.GetRequiredService<ShellModel>();
            var tokenStorage = app.Host.Services.GetRequiredService<ITokenStorageService>();

            var rememberMe = LoginRememberMe.IsChecked == true;

            var credentials = new Dictionary<string, string>
            {
                ["Email"] = email,
                ["Password"] = password,
                ["ServerUrl"] = serverUrl,
                ["RememberMe"] = rememberMe.ToString()
            };

            var success = await auth.LoginAsync(dispatcher: null, credentials);

            if (success)
            {
                // Remember the server used and its email so it becomes the default next time.
                if (selectedProfile != null)
                {
                    var profileStore = app.Host.Services.GetService<IServerProfileStore>();
                    if (profileStore != null)
                    {
                        await profileStore.SetLastUsedAsync(selectedProfile.Id, email);
                    }
                }

                shellModel.UpdateAuthenticationState(true);

                if (tenantContext.AvailableTenants.Count == 0)
                {
                    shellModel.UpdateNoTenantsState(true);
                }
                else
                {
                    var navigator = Splash.Navigator() ?? app.Host.Services.GetService<INavigator>();

                    if (navigator != null)
                    {
                        await navigator.NavigateViewModelAsync<DashboardModel>(this, qualifier: Qualifiers.ClearBackStack);
                    }
                }
            }
            else
            {
                LoginErrorText.Text = "Login failed. Please check your credentials and server URL.";
                LoginErrorBanner.Visibility = Visibility.Visible;
            }
        }
        catch (ApiException ex)
        {
            LoginErrorText.Text = ex.CombinedMessage;
            LoginErrorBanner.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            LoginErrorText.Text = $"An error occurred: {ex.Message}";
            LoginErrorBanner.Visibility = Visibility.Visible;
        }
        finally
        {
            LoginProgress.Visibility = Visibility.Collapsed;
            LoginProgress.IsActive = false;
            LoginButton.IsEnabled = true;
        }
    }

    #endregion

    #region Registration Overlay

    private void RegisterLink_Click(Microsoft.UI.Xaml.Documents.Hyperlink sender, Microsoft.UI.Xaml.Documents.HyperlinkClickEventArgs args)
    {
        ResetRegistrationOverlay();
        LoginOverlay.Visibility = Visibility.Collapsed;
        RegistrationOverlay.Visibility = Visibility.Visible;
    }

    private void ResetRegistrationOverlay()
    {
        RegisterFirstname.Text = string.Empty;
        RegisterLastname.Text = string.Empty;
        RegisterEmail.Text = string.Empty;
        RegisterPassword.Password = string.Empty;
        RegisterPasswordConfirm.Password = string.Empty;
        RegisterErrorBanner.Visibility = Visibility.Collapsed;
        RegisterErrorText.Text = string.Empty;
        RegisterProgress.Visibility = Visibility.Collapsed;
        RegisterProgress.IsActive = false;
        RegisterSubmitButton.IsEnabled = true;
        RegisterCancelButton.IsEnabled = true;
    }

    private void RegisterCancel_Click(object sender, RoutedEventArgs e)
    {
        RegistrationOverlay.Visibility = Visibility.Collapsed;
        LoginOverlay.Visibility = Visibility.Visible;
    }

    private async void RegisterSubmit_Click(object sender, RoutedEventArgs e)
    {
        var firstname = RegisterFirstname.Text?.Trim();
        var lastname = RegisterLastname.Text?.Trim();
        var email = RegisterEmail.Text?.Trim();
        var password = RegisterPassword.Password;
        var passwordConfirm = RegisterPasswordConfirm.Password;

        if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname) ||
            string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            RegisterErrorText.Text = "Bitte füllen Sie alle Felder aus.";
            RegisterErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        if (password != passwordConfirm)
        {
            RegisterErrorText.Text = "Die Passwörter stimmen nicht überein.";
            RegisterErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        var serverUrl = asToolkit.Client.Core.Configuration.RuntimeConfig.IsServerUrlRestricted
            ? asToolkit.Client.Core.Configuration.RuntimeConfig.RestrictServerUrl!
            : (LoginServerSelector.SelectedItem as ServerProfile)?.Url;

        if (string.IsNullOrWhiteSpace(serverUrl))
        {
            RegisterErrorText.Text = "Server-URL fehlt.";
            RegisterErrorBanner.Visibility = Visibility.Visible;
            return;
        }

        serverUrl = ServerUrlUtil.Normalize(serverUrl);

        RegisterSubmitButton.IsEnabled = false;
        RegisterCancelButton.IsEnabled = false;
        RegisterProgress.Visibility = Visibility.Visible;
        RegisterProgress.IsActive = true;
        RegisterErrorBanner.Visibility = Visibility.Collapsed;

        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services == null)
            {
                throw new InvalidOperationException("Services not available");
            }

            var maErpAuth = app.Host.Services.GetRequiredService<IMaErpAuthenticationService>();
            var tenantContext = app.Host.Services.GetRequiredService<ITenantContextService>();
            var shellModel = app.Host.Services.GetRequiredService<ShellModel>();

            var request = new RegisterRequestDto
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Username = email,
                Password = password
            };

            var response = await maErpAuth.RegisterAsync(serverUrl, request);

            if (response?.Succeeded == true && !string.IsNullOrEmpty(response.Token))
            {
                shellModel.UpdateAuthenticationState(true);

                if (tenantContext.AvailableTenants.Count == 0)
                {
                    shellModel.UpdateNoTenantsState(true);
                }
                else
                {
                    var navigator = Splash.Navigator() ?? app.Host.Services.GetService<INavigator>();
                    if (navigator != null)
                    {
                        await navigator.NavigateViewModelAsync<DashboardModel>(this, qualifier: Qualifiers.ClearBackStack);
                    }
                }
            }
            else
            {
                RegisterErrorText.Text = response?.Message ?? "Registrierung fehlgeschlagen.";
                RegisterErrorBanner.Visibility = Visibility.Visible;
            }
        }
        catch (ApiException ex)
        {
            RegisterErrorText.Text = ex.CombinedMessage;
            RegisterErrorBanner.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            RegisterErrorText.Text = ex.Message;
            RegisterErrorBanner.Visibility = Visibility.Visible;
        }
        finally
        {
            RegisterProgress.Visibility = Visibility.Collapsed;
            RegisterProgress.IsActive = false;
            RegisterSubmitButton.IsEnabled = true;
            RegisterCancelButton.IsEnabled = true;
        }
    }

    #endregion

    #region First Tenant Creation

    private void FirstTenantName_TextChanged(object sender, TextChangedEventArgs e)
    {
        FirstTenantSaveButton.IsEnabled = !string.IsNullOrWhiteSpace(FirstTenantName.Text);
    }

    private async void FirstTenantCancel_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services != null)
            {
                var auth = app.Host.Services.GetRequiredService<IAuthenticationService>();
                await auth.LogoutAsync(CancellationToken.None);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] FirstTenantCancel_Click error: {ex.Message}");
        }
    }

    private async void FirstTenantSave_Click(object sender, RoutedEventArgs e)
    {
        var tenantName = FirstTenantName.Text?.Trim();
        if (string.IsNullOrWhiteSpace(tenantName)) return;

        FirstTenantSaveButton.IsEnabled = false;
        FirstTenantCancelButton.IsEnabled = false;
        FirstTenantProgress.Visibility = Visibility.Visible;
        FirstTenantProgress.IsActive = true;
        FirstTenantErrorBanner.Visibility = Visibility.Collapsed;

        try
        {
            var app = Application.Current as App;
            if (app?.Host?.Services == null)
            {
                throw new InvalidOperationException("Services not available");
            }

            var tenantService = app.Host.Services.GetRequiredService<ITenantService>();
            var tenantContext = app.Host.Services.GetRequiredService<ITenantContextService>();
            var shellModel = app.Host.Services.GetRequiredService<ShellModel>();

            var input = new TenantInputDto
            {
                Name = tenantName,
                Description = FirstTenantDescription.Text?.Trim() ?? string.Empty
            };

            var newTenantId = await tenantService.CreateTenantAsync(input);

            await tenantContext.RefreshTokenAndTenantsAsync();

            if (newTenantId != Guid.Empty)
            {
                await tenantContext.SetCurrentTenantAsync(newTenantId);
            }

            shellModel.UpdateNoTenantsState(false);

            var navigator = Splash.Navigator() ?? app.Host.Services.GetService<INavigator>();

            if (navigator != null)
            {
                await navigator.NavigateViewModelAsync<DashboardModel>(this, qualifier: Qualifiers.ClearBackStack);
            }
        }
        catch (ApiException ex)
        {
            FirstTenantErrorText.Text = ex.CombinedMessage;
            FirstTenantErrorBanner.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            FirstTenantErrorText.Text = ex.Message;
            FirstTenantErrorBanner.Visibility = Visibility.Visible;
        }
        finally
        {
            FirstTenantProgress.Visibility = Visibility.Collapsed;
            FirstTenantProgress.IsActive = false;
            FirstTenantSaveButton.IsEnabled = !string.IsNullOrWhiteSpace(FirstTenantName.Text);
            FirstTenantCancelButton.IsEnabled = true;
        }
    }

    #endregion
}

internal static class ApplicationThemeExtensions
{
    public static ElementTheme ToElementTheme(this Microsoft.UI.Xaml.ApplicationTheme theme)
        => theme == Microsoft.UI.Xaml.ApplicationTheme.Dark ? ElementTheme.Dark : ElementTheme.Light;
}
