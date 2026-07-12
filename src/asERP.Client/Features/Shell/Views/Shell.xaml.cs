using asERP.Client.Features.Account.Models;
using asERP.Client.Features.Shell.Models;
using asERP.Client.Features.Auth.Services;
using Microsoft.UI.Xaml.Controls;
using asERP.Domain.Dtos.Tenant;
using asERP.Client.Features.Dashboard.Models;
using asERP.Client.Features.Statistics.Models;
using asERP.Client.Features.Customers.Models;
using asERP.Client.Features.Invoices.Models;
using asERP.Client.Features.Manufacturers.Models;
using asERP.Client.Features.Saless;
using asERP.Client.Features.Saless.Models;
using asERP.Client.Features.Customers;
using asERP.Client.Features.Products.Models;
using asERP.Client.Features.Search;
using asERP.Client.Features.Search.Services;
using asERP.Domain.Dtos.Search;
using asERP.Client.Features.SalesChannels.Models;
using asERP.Client.Features.SalesChannelDashboards.Models;
using asERP.Client.Features.Superadmin.Models;
using asERP.Domain.Enums;
using asERP.Client.Features.ProductAttributes.Models;
using asERP.Client.Features.TaxClasses.Models;
using asERP.Client.Features.Tenants.Models;
using asERP.Client.Features.Warehouses.Models;
using asERP.Client.Features.AiModels.Models;
using asERP.Client.Features.AiPrompts.Models;
using Uno.Toolkit.UI;

namespace asERP.Client.Features.Shell.Views;

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

    public Shell()
    {
        this.InitializeComponent();

        // Auth overlays live in their own UserControls; the Shell only switches their
        // visibility and reacts to the events below (see the Auth Overlays region).
        LoginOverlay.LoginSucceeded += OnAuthOverlaySucceededAsync;
        LoginOverlay.RegistrationRequested += OnRegistrationRequested;
        RegistrationOverlay.RegistrationSucceeded += OnAuthOverlaySucceededAsync;
        RegistrationOverlay.BackToLoginRequested += OnBackToLoginRequested;
        FirstTenantOverlay.TenantCreated += OnFirstTenantCreatedAsync;

        SetUnauthenticatedVisibility();

        ShellModel.AuthenticationStateChanged += OnAuthenticationStateChanged;
        ShellModel.TenantStateChanged += OnTenantStateChanged;
        ShellModel.NoTenantsStateChanged += OnNoTenantsStateChanged;
        ShellModel.SalesChannelsChanged += OnSalesChannelsChanged;

        this.PointerMoved += OnUserActivity;
        this.KeyDown += OnUserActivity;

        TabBarNav.SelectionChanged += OnTabBarSelectionChanged;
        this.Loaded += OnShellLoaded;

        // Ctrl+K focuses the sidebar quick search (asERP-style shortcut).
        // Suppress WinUI's automatic accelerator tooltip — otherwise "Ctrl + K" hovers over the
        // whole Shell background, since the accelerator is owned by the root page.
        KeyboardAcceleratorPlacementMode = Microsoft.UI.Xaml.Input.KeyboardAcceleratorPlacementMode.Hidden;
        var quickSearchAccelerator = new Microsoft.UI.Xaml.Input.KeyboardAccelerator
        {
            Key = Windows.System.VirtualKey.K,
            Modifiers = Windows.System.VirtualKeyModifiers.Control
        };
        quickSearchAccelerator.Invoked += (_, args) =>
        {
            QuickSearchBox.Focus(FocusState.Programmatic);
            args.Handled = true;
        };
        KeyboardAccelerators.Add(quickSearchAccelerator);
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
            { "Shippings", NavItemShippings },
            { "Invoices", NavItemInvoices },
            { "StatisticsRevenue", NavItemRevenue },
            { "SalesChannelOverview", NavItemSalesChannels },
            { "SalesChannels", NavItemSalesChannelList },
            { "Feeds", NavItemFeeds },
            { "TaxClasses", NavItemTaxClasses },
            { "ProductAttributes", NavItemProductAttributes },
            { "Warehouses", NavItemWarehouses },
            { "AiModels", NavItemAiModels },
            { "AiPrompts", NavItemAiPrompts },
            { "TenantOAuthSettings", NavItemTenantOAuthSettings },
            { "SuperadminTenants", NavItemSuperadminTenants },
            { "SuperadminCountries", NavItemSuperadminCountries },
            { "GlobalSettings", NavItemGlobalSettings }
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
            _activeNavButton.Style = (Style)Resources["SidebarNavItemStyle"];
        }

        _activeNavButton = null;

        if (string.IsNullOrEmpty(tag))
        {
            return;
        }

        // Static nav items come from the tag map; dynamic sales-channel items are
        // realized by the ItemsRepeater and looked up in its visual children.
        if (!_sidebarTagMap!.TryGetValue(tag, out Button? btn) && tag.StartsWith("SalesChannel_"))
        {
            btn = FindDynamicSalesChannelButton(tag);
        }

        if (btn != null)
        {
            // Style switch instead of a Resources[] lookup: the indexer does not resolve
            // ThemeDictionaries theme-aware, ThemeResource inside the style does.
            btn.Style = (Style)Resources["SidebarNavItemActiveStyle"];
            _activeNavButton = btn;
        }
    }

    private Button? FindDynamicSalesChannelButton(string tag)
    {
        var count = VisualTreeHelper.GetChildrenCount(SalesChannelSubItemsRepeater);
        for (var i = 0; i < count; i++)
        {
            if (VisualTreeHelper.GetChild(SalesChannelSubItemsRepeater, i) is Button btn &&
                btn.Tag is string btnTag && btnTag == tag)
            {
                return btn;
            }
        }

        return null;
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
                TenantName.Text = "asERP";
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
                TenantName.Text = tenants.Count == 1 ? tenants[0].Name : "asERP";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] UpdateTenantDisplay error: {ex.Message}");
            TenantSwitcher.Visibility = Visibility.Collapsed;
            TenantName.Visibility = Visibility.Visible;
            TenantName.Text = "asERP";
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
        NavItemFeeds.Visibility = Visibility.Visible;

        TabItemDashboard.Visibility = Visibility.Visible;
        TabItemCustomers.Visibility = Visibility.Visible;
        TabItemSaless.Visibility = Visibility.Visible;
        TabItemSettings.Visibility = Visibility.Visible;
        TabItemLogout.Visibility = Visibility.Visible;
    }

    private void SetUnauthenticatedVisibility()
    {
        LoginOverlay.Reset();
        LoginOverlay.Visibility = Visibility.Visible;
        RegistrationOverlay.Visibility = Visibility.Collapsed;
        FirstTenantOverlay.Visibility = Visibility.Collapsed;

        FirstTenantOverlay.Reset();

        Sidebar.Visibility = Visibility.Collapsed;
        ContentHeader.Visibility = Visibility.Collapsed;

        TenantSwitcher.Visibility = Visibility.Collapsed;
        TenantName.Visibility = Visibility.Visible;
        TenantName.Text = "asERP";
        TenantMenuFlyout.Items.Clear();

        TabItemDashboard.Visibility = Visibility.Collapsed;
        TabItemCustomers.Visibility = Visibility.Collapsed;
        TabItemSaless.Visibility = Visibility.Collapsed;
        TabItemSettings.Visibility = Visibility.Collapsed;
        TabItemLogout.Visibility = Visibility.Collapsed;

        // Use the DataContext set in OnShellLoaded instead of resolving from DI: this runs
        // in the constructor too, where resolving would construct the ShellModel singleton
        // earlier than before. Before OnShellLoaded there is nothing to clear anyway.
        (TabBarNav.DataContext as ShellModel)?.ClearSalesChannels();
        UpdateSidebarSelection(null);
    }

    private void SetNoTenantsVisibility()
    {
        LoginOverlay.Visibility = Visibility.Collapsed;
        RegistrationOverlay.Visibility = Visibility.Collapsed;
        FirstTenantOverlay.Visibility = Visibility.Visible;

        FirstTenantOverlay.Reset();

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
                    SalesChannelSubItemsRepeater.DataContext = shellModel;
                    shellModel.PropertyChanged += OnShellModelPropertyChanged;

                    await shellModel.InitializeAuthenticationState();
                    UpdateNavigationVisibility(shellModel);

                    await UpdateSuperadminMenuVisibilityAsync();

                    if (shellModel.IsAuthenticated)
                    {
                        UpdateTenantDisplay();
                        await CompleteSessionRestoreAsync(app.Host.Services);
                    }

                    InitializeDarkModeToggle();

#if __DESKTOP__
                    // Auto-updater for the installed Windows client (no-op for
                    // portable-zip/dev runs and non-Windows platforms).
                    asERP.Client.Core.Updates.ClientUpdater.Start(this);
#endif
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

    /// <summary>
    /// Completes a restored session (token from storage still valid). Such sessions skip
    /// the login/refresh-token responses that normally populate the tenant list and
    /// trigger the initial navigation — without this, the shell sits authenticated on an
    /// empty content pane. Loads the tenants if missing, then navigates to the dashboard
    /// (or shows the first-tenant overlay). Never throws: OnShellLoaded's retry loop must
    /// not re-run its setup because of a failed restore.
    /// </summary>
    private async Task CompleteSessionRestoreAsync(IServiceProvider services)
    {
        try
        {
            var shellModel = services.GetRequiredService<ShellModel>();
            var tenantContext = services.GetRequiredService<ITenantContextService>();

            var hasTenants = tenantContext.AvailableTenants.Count > 0;
            if (!hasTenants)
            {
                try
                {
                    hasTenants = await tenantContext.RefreshTenantsAndCheckAvailabilityAsync();
                }
                catch (Exception ex)
                {
                    // Offline/server trouble is inconclusive: prefer the dashboard (it
                    // surfaces its own errors) over wrongly claiming the user has no
                    // tenants and showing the first-tenant overlay.
                    Console.WriteLine($"[Shell] Tenant refresh on session restore failed: {ex.Message}");
                    hasTenants = true;
                }

                UpdateTenantDisplay();
            }

            if (!hasTenants)
            {
                shellModel.UpdateNoTenantsState(true);
                return;
            }

            var navigator = Splash.Navigator() ?? services.GetService<INavigator>();
            if (navigator != null)
            {
                await NavigateToDashboardAsync(navigator);
                UpdateSidebarSelection("Dashboard");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Shell] CompleteSessionRestoreAsync failed: {ex.Message}");
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
                case "Shippings":
                    await navigator.NavigateViewModelAsync<asERP.Client.Features.Shippings.Models.ShippingListModel>(this);
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
                case "Feeds":
                    await navigator.NavigateViewModelAsync<asERP.Client.Features.Feeds.Models.FeedListModel>(this);
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
                case "SuperadminCountries":
                    await navigator.NavigateViewModelAsync<SuperadminCountryListModel>(this);
                    break;
                case "GlobalSettings":
                    await navigator.NavigateViewModelAsync<asERP.Client.Features.GlobalSettings.Models.GlobalSettingsModel>(this);
                    break;
                case "TenantOAuthSettings":
                    await navigator.NavigateViewModelAsync<asERP.Client.Features.TenantOAuthSettings.Models.TenantOAuthSettingsModel>(this);
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

    /// <summary>
    /// Reloads the dynamic sales-channel nav items. The data lives on the ShellModel
    /// (bound by the ItemsRepeater in Shell.xaml); this only triggers the refresh.
    /// Must be called on the UI thread (all callers marshal via RunOnUiThread).
    /// </summary>
    private async Task RefreshSalesChannelSidebar()
    {
        var shellModel = GetShellModel();
        if (shellModel == null) return;

        await shellModel.RefreshSalesChannelsAsync();
    }

    private static ShellModel? GetShellModel()
        => (Application.Current as App)?.Host?.Services?.GetService<ShellModel>();

    #endregion

    #region Auth Overlays

    /// <summary>
    /// The register link on the login overlay was clicked — show the registration overlay
    /// for the server currently selected on the login overlay.
    /// </summary>
    private void OnRegistrationRequested(object? sender, EventArgs e)
    {
        RegistrationOverlay.Reset();
        RegistrationOverlay.ServerUrl = LoginOverlay.SelectedServerUrl;
        LoginOverlay.Visibility = Visibility.Collapsed;
        RegistrationOverlay.Visibility = Visibility.Visible;
    }

    private void OnBackToLoginRequested(object? sender, EventArgs e)
    {
        RegistrationOverlay.Visibility = Visibility.Collapsed;
        LoginOverlay.Visibility = Visibility.Visible;
    }

    /// <summary>
    /// Shared post-success flow for login and registration: mark the session as
    /// authenticated, then either show the first-tenant overlay (no tenants yet) or
    /// navigate to the dashboard with a cleared back stack.
    /// </summary>
    private async Task OnAuthOverlaySucceededAsync()
    {
        var app = Application.Current as App;
        if (app?.Host?.Services == null)
        {
            throw new InvalidOperationException("Services not available");
        }

        var tenantContext = app.Host.Services.GetRequiredService<ITenantContextService>();
        var shellModel = app.Host.Services.GetRequiredService<ShellModel>();

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
                await NavigateToDashboardAsync(navigator);
            }
        }
    }

    /// <summary>
    /// The first tenant was created — leave the no-tenants state and go to the dashboard.
    /// </summary>
    private async Task OnFirstTenantCreatedAsync()
    {
        var app = Application.Current as App;
        if (app?.Host?.Services == null)
        {
            throw new InvalidOperationException("Services not available");
        }

        var shellModel = app.Host.Services.GetRequiredService<ShellModel>();
        shellModel.UpdateNoTenantsState(false);

        var navigator = Splash.Navigator() ?? app.Host.Services.GetService<INavigator>();

        if (navigator != null)
        {
            await NavigateToDashboardAsync(navigator);
        }
    }

    /// <summary>
    /// Post-auth dashboard navigation. The ClearBackStack-qualified request can be
    /// swallowed while the auth flow is still settling — fall back to the plain
    /// navigation the sidebar click uses (which is known to work) if it was not handled.
    /// </summary>
    private async Task NavigateToDashboardAsync(INavigator navigator)
    {
        var response = await navigator.NavigateViewModelAsync<DashboardModel>(this, qualifier: Qualifiers.ClearBackStack);
        Console.WriteLine($"[Shell] Post-auth dashboard navigation (ClearBackStack): {(response is null ? "unhandled" : "ok")}");

        if (response is null)
        {
            response = await navigator.NavigateViewModelAsync<DashboardModel>(this);
            Console.WriteLine($"[Shell] Post-auth dashboard navigation fallback: {(response is null ? "unhandled" : "ok")}");
        }
    }

    #endregion
}

internal static class ApplicationThemeExtensions
{
    public static ElementTheme ToElementTheme(this Microsoft.UI.Xaml.ApplicationTheme theme)
        => theme == Microsoft.UI.Xaml.ApplicationTheme.Dark ? ElementTheme.Dark : ElementTheme.Light;
}
