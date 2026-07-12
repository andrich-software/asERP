using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using asERP.Client.Core.Abstractions;
using asERP.Client.Core.Events;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.SalesChannels.Services;
using asERP.Client.Features.Shell.Models;
using asERP.Client.Features.Warehouses.Services;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.SalesChannels.Models;

/// <summary>
/// Navigation data for SalesChannelEditModel.
/// </summary>
public record SalesChannelEditData(Guid? SalesChannelId = null);

/// <summary>
/// Model for sales channel edit/create page.
/// Inherits from AsyncInitializableModel for safe async initialization.
/// </summary>
public class SalesChannelEditModel : AsyncInitializableModel
{
    private readonly ISalesChannelService _salesChannelService;
    private readonly IWarehouseService _warehouseService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly INotificationService _notifications;
    private readonly ILogger<SalesChannelEditModel> _logger;
    private readonly Guid? _salesChannelId;

    // Snapshot of ImportProducts as loaded from the server (edit mode) — lets us detect when the
    // user just turned product import on, so we trigger a one-off import for them.
    private bool _originalImportProducts;

    // Basic Information
    private string _name = string.Empty;
    private SalesChannelType _salesChannelType = SalesChannelType.Shopware6;

    // Connection Information
    private string _url = string.Empty;
    private string _username = string.Empty;
    private string _password = string.Empty;

    // MySQL settings (WooCommerceDatabase) — persisted as connector-owned AdditionalConfigJson.
    private string _dbHost = string.Empty;
    private string _dbPort = "3306";
    private string _dbName = string.Empty;
    private string _dbTablePrefix = "wp_";

    // Import Settings
    private bool _importProducts;
    private bool _importCustomers;
    private bool _importSaless;

    // Export Settings
    private bool _exportProducts;
    private bool _exportCustomers;
    private bool _exportSaless;
    private bool _exportStock;
    private bool _pushSalesCancellations;
    private bool _importStock;

    // Warehouses
    private ObservableCollection<SelectableWarehouse> _warehouses = new();
    // Selected warehouse ids captured from the channel (edit mode) — applied once the (background-
    // loaded) warehouse list has arrived, so channel loading no longer waits on the warehouse query.
    private IReadOnlyCollection<Guid> _selectedWarehouseIds = Array.Empty<Guid>();
    private bool _isWarehousesLoading;

    // OAuth state — populated for eBay / Amazon channels after the channel has been saved.
    private bool _hasRefreshToken;
    private DateTime? _tokenExpiresAt;
    private string _oAuthStatusMessage = string.Empty;
    private bool _isConnecting;

    // UI State
    private bool _isSaving;
    private string _errorMessage = string.Empty;

    public SalesChannelEditModel(
        ISalesChannelService salesChannelService,
        IWarehouseService warehouseService,
        INavigator navigator,
        IStringLocalizer localizer,
        INotificationService notifications,
        ILogger<SalesChannelEditModel> logger,
        SalesChannelEditData? data = null)
        : base(logger)
    {
        _salesChannelService = salesChannelService;
        _warehouseService = warehouseService;
        _navigator = navigator;
        _localizer = localizer;
        _notifications = notifications;
        _logger = logger;
        _salesChannelId = data?.SalesChannelId;

        // Start async initialization with proper error handling
        StartInitialization();
    }

    /// <inheritdoc />
    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        // Only the channel data (edit mode) gates the form — it populates the visible fields. The
        // warehouse multi-select is optional and loads in the background so a slow warehouse query
        // never blocks the create/edit form behind the loading overlay (previously a slow warehouse
        // response left "Neuer Vertriebskanal" stuck on a spinner).
        if (_salesChannelId.HasValue)
        {
            await LoadSalesChannelAsync(ct);
        }

        _ = LoadWarehousesAsync(ct);
    }

    private async Task LoadWarehousesAsync(CancellationToken ct)
    {
        RunOnUi(() => IsWarehousesLoading = true);
        try
        {
            var parameters = new Core.Models.QueryParameters { PageSize = 1000 };
            var response = await _warehouseService.GetWarehousesAsync(parameters, ct);

            // This model's async continuations run off the UI thread (the navigation pipeline
            // resolves it on a background thread). The ObservableCollection mutation and the
            // change notifications below drive classic {Binding} targets (the warehouse table,
            // spinner and empty-state visibility) — those only refresh from UI-thread
            // notifications, so marshal them explicitly or they are silently dropped.
            RunOnUi(() =>
            {
                foreach (var existing in Warehouses)
                {
                    existing.PropertyChanged -= OnWarehouseSelectionChanged;
                }
                Warehouses.Clear();
                foreach (var warehouse in response.Data)
                {
                    var selectable = new SelectableWarehouse
                    {
                        Id = warehouse.Id,
                        Name = warehouse.Name,
                        // Reflect the channel's stored selection (edit mode); no-op for new channels.
                        IsSelected = _selectedWarehouseIds.Contains(warehouse.Id)
                    };
                    // Keep the Save button / required hint in sync when the user toggles a row.
                    selectable.PropertyChanged += OnWarehouseSelectionChanged;
                    Warehouses.Add(selectable);
                }

                OnPropertyChanged(nameof(HasWarehouses));
                OnPropertyChanged(nameof(ShowNoWarehouses));
                OnPropertyChanged(nameof(HasSelectedWarehouse));
                OnPropertyChanged(nameof(ShowWarehouseRequiredHint));
                OnPropertyChanged(nameof(CanSave));
            });
        }
        catch (OperationCanceledException)
        {
            // Page navigated away while loading — nothing to do.
        }
        catch (Exception ex)
        {
            // Warehouses are optional; a failure must not break the form. Surface the empty state.
            _logger.LogError(ex, "Failed to load warehouses for the sales channel edit page");
        }
        finally
        {
            RunOnUi(() => IsWarehousesLoading = false);
        }
    }

    /// <summary>
    /// Runs a UI-affecting action on the UI thread. This model's async continuations can run on a
    /// background thread, so classic {Binding} updates (and ObservableCollection mutations bound to
    /// the UI) must be marshalled onto the UI dispatcher; otherwise they are dropped on Desktop/Skia.
    /// Falls back to inline execution when already on the UI thread or when no dispatcher is available.
    /// </summary>
    private static void RunOnUi(Action action)
    {
        var dispatcher = App.UiDispatcher;
        if (dispatcher is null || dispatcher.HasThreadAccess)
        {
            action();
        }
        else
        {
            dispatcher.TryEnqueue(() => action());
        }
    }

    public bool IsEditMode => _salesChannelId.HasValue;

    public string Title => IsEditMode
        ? _localizer["SalesChannelEditPage.TitleEdit"]
        : _localizer["SalesChannelEditPage.TitleNew"];

    /// <summary>
    /// Available sales channel type options for the ComboBox.
    /// </summary>
    public IReadOnlyList<SalesChannelTypeOption> SalesChannelTypeOptions { get; } = new List<SalesChannelTypeOption>
    {
        new(SalesChannelType.PointOfSale, "SalesChannelType.PointOfSale"),
        new(SalesChannelType.Shopware6, "SalesChannelType.Shopware6"),
        new(SalesChannelType.WooCommerce, "SalesChannelType.WooCommerce"),
        new(SalesChannelType.WooCommerceDatabase, "SalesChannelType.WooCommerceDatabase"),
        new(SalesChannelType.eBay, "SalesChannelType.eBay"),
        new(SalesChannelType.Amazon, "SalesChannelType.Amazon")
    };

    #region Basic Information

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public SalesChannelType SalesChannelType
    {
        get => _salesChannelType;
        set
        {
            if (SetProperty(ref _salesChannelType, value))
            {
                // Update visibility properties when type changes
                OnPropertyChanged(nameof(IsOAuthChannel));
                OnPropertyChanged(nameof(ShowConnectionInfo));
                OnPropertyChanged(nameof(ShowConnectionHint));
                OnPropertyChanged(nameof(ShowOAuthSection));
                OnPropertyChanged(nameof(ShowOAuthSaveFirstHint));
                OnPropertyChanged(nameof(ConnectionStatusLabel));
                OnPropertyChanged(nameof(ShowUrlField));
                OnPropertyChanged(nameof(ShowDatabaseSettings));
                OnPropertyChanged(nameof(ShowImportExportSettings));
                OnPropertyChanged(nameof(CanSave));

                // Connection field labels/placeholders are type-specific (e.g. WooCommerce
                // uses Consumer Key / Consumer Secret instead of Username / Password).
                OnPropertyChanged(nameof(UrlPlaceholder));
                OnPropertyChanged(nameof(UsernameLabel));
                OnPropertyChanged(nameof(UsernamePlaceholder));
                OnPropertyChanged(nameof(PasswordLabel));
                OnPropertyChanged(nameof(PasswordPlaceholder));
                OnPropertyChanged(nameof(ShowPasswordKeepHint));
                OnPropertyChanged(nameof(ConnectionHintText));
            }
        }
    }

    #endregion

    #region Type-Specific Visibility

    /// <summary>
    /// True for OAuth Authorization-Code channels (eBay, Amazon). These hide the
    /// Username/Password inputs in favor of a "Connect" button that triggers the OAuth flow.
    /// </summary>
    public bool IsOAuthChannel => SalesChannelType is SalesChannelType.eBay or SalesChannelType.Amazon;

    /// <summary>
    /// Shows the Username/Password connection block for credential-style channels (Shopware6,
    /// WooCommerce). PointOfSale skips it entirely; OAuth channels use <see cref="ShowOAuthSection"/>.
    /// </summary>
    public bool ShowConnectionInfo =>
        SalesChannelType != SalesChannelType.PointOfSale && !IsOAuthChannel;

    /// <summary>OAuth section is only useful once the channel has been persisted (we need its id).</summary>
    public bool ShowOAuthSection => IsOAuthChannel && IsEditMode;

    /// <summary>Hint shown on the OAuth section when the channel has never been saved.</summary>
    public bool ShowOAuthSaveFirstHint => IsOAuthChannel && !IsEditMode;

    public bool IsConnected => _hasRefreshToken;

    public string ConnectionStatusLabel
    {
        get
        {
            if (!IsOAuthChannel) return string.Empty;
            if (!_hasRefreshToken) return _localizer["SalesChannelEditPage.OAuth.StatusNotConnected"];
            var expiry = _tokenExpiresAt is null
                ? string.Empty
                : $" — {_tokenExpiresAt.Value.ToLocalTime():g}";
            return _localizer["SalesChannelEditPage.OAuth.StatusConnected"] + expiry;
        }
    }

    public string OAuthStatusMessage
    {
        get => _oAuthStatusMessage;
        private set => SetProperty(ref _oAuthStatusMessage, value);
    }

    public bool IsConnecting
    {
        get => _isConnecting;
        private set
        {
            if (SetProperty(ref _isConnecting, value))
            {
                OnPropertyChanged(nameof(IsLoading));
                OnPropertyChanged(nameof(IsNotLoading));
                OnPropertyChanged(nameof(ShowConnectionHint));
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    /// <summary>
    /// Shows URL field only for Shopware6 and the WooCommerce types.
    /// eBay, Amazon and PointOfSale do not require URL. The database-backed WooCommerce type still
    /// needs the shop's base URL to build product-image download links.
    /// </summary>
    public bool ShowUrlField => SalesChannelType is
        SalesChannelType.Shopware6 or
        SalesChannelType.WooCommerce or
        SalesChannelType.WooCommerceDatabase;

    /// <summary>Shows the MySQL connection block (host/port/database/table prefix).</summary>
    public bool ShowDatabaseSettings => IsWooCommerceDb;

    /// <summary>
    /// Shows import/export settings for all types except PointOfSale.
    /// </summary>
    public bool ShowImportExportSettings => SalesChannelType != SalesChannelType.PointOfSale;

    /// <summary>
    /// Shows the bottom-of-page hint that explains URL/credentials configuration.
    /// Only meaningful for credential-style channels (Shopware6, WooCommerce). Hidden for
    /// PointOfSale (no remote endpoint) and OAuth channels (eBay/Amazon — no URL/credentials).
    /// </summary>
    public bool ShowConnectionHint => IsNotLoading && ShowConnectionInfo;

    #endregion

    #region Type-Specific Connection Labels

    /// <summary>True for WooCommerce (REST), which labels its credentials Consumer Key / Consumer Secret.</summary>
    private bool IsWooCommerce => SalesChannelType == SalesChannelType.WooCommerce;

    /// <summary>True for WooCommerce (database), which labels its credentials as MySQL user/password.</summary>
    private bool IsWooCommerceDb => SalesChannelType == SalesChannelType.WooCommerceDatabase;

    // NOTE: these resolve via IStringLocalizer. Resource keys must be SINGLE-DOT (2-segment),
    // PascalCase — e.g. "SalesChannelEditPage.ConnUrlLabel" — matching the proven pattern used
    // elsewhere (AddressDialog.CityPlaceholder, Common.Save). Multi-dot keys (X.Y.Z) get mangled
    // by the .resw → resource indexing (only the first dot becomes the section separator), so the
    // lookup path no longer matches and the raw key is shown. Reserved x:Uid property suffixes
    // (.Header/.Text/.PlaceholderText) must also be avoided here.

    public string UrlLabel => _localizer["SalesChannelEditPage.ConnUrlLabel"];

    /// <summary>Placeholder for the URL field — both WooCommerce types expect the shop base URL, not an API path.</summary>
    public string UrlPlaceholder => IsWooCommerce || IsWooCommerceDb
        ? _localizer["SalesChannelEditPage.ConnUrlPlaceholderWoo"]
        : _localizer["SalesChannelEditPage.ConnUrlPlaceholder"];

    /// <summary>Username field header — "Consumer Key" for WooCommerce, "Database user" for the DB variant, "Username" otherwise.</summary>
    public string UsernameLabel => IsWooCommerce
        ? _localizer["SalesChannelEditPage.ConnConsumerKeyLabel"]
        : IsWooCommerceDb
            ? _localizer["SalesChannelEditPage.ConnDbUserLabel"]
            : _localizer["SalesChannelEditPage.ConnUsernameLabel"];

    public string UsernamePlaceholder => IsWooCommerce
        ? _localizer["SalesChannelEditPage.ConnConsumerKeyPlaceholder"]
        : IsWooCommerceDb
            ? _localizer["SalesChannelEditPage.ConnDbUserPlaceholder"]
            : _localizer["SalesChannelEditPage.ConnUsernamePlaceholder"];

    /// <summary>Password field header — "Consumer Secret" for WooCommerce, "Database password" for the DB variant, "Password / API Key" otherwise.</summary>
    public string PasswordLabel => IsWooCommerce
        ? _localizer["SalesChannelEditPage.ConnConsumerSecretLabel"]
        : IsWooCommerceDb
            ? _localizer["SalesChannelEditPage.ConnDbPasswordLabel"]
            : _localizer["SalesChannelEditPage.ConnPasswordLabel"];

    public string PasswordPlaceholder
    {
        get
        {
            // On edit the stored secret is kept unless replaced — make that obvious in the field.
            if (IsEditMode)
            {
                return _localizer["SalesChannelEditPage.ConnSecretKeepPlaceholder"];
            }

            return IsWooCommerce
                ? _localizer["SalesChannelEditPage.ConnConsumerSecretPlaceholder"]
                : _localizer["SalesChannelEditPage.ConnPasswordPlaceholder"];
        }
    }

    /// <summary>Shows the "leave blank to keep the stored secret" caption — only when editing a credential channel.</summary>
    public bool ShowPasswordKeepHint => IsEditMode && ShowConnectionInfo;

    /// <summary>Caption under the secret field explaining that an empty value keeps the stored secret.</summary>
    public string PasswordKeepHint => _localizer["SalesChannelEditPage.ConnSecretKeepHint"];

    /// <summary>Bottom-of-page connection hint — the WooCommerce types get tailored explanations.</summary>
    public string ConnectionHintText => IsWooCommerce
        ? _localizer["SalesChannelEditPage.ConnHintWoo"]
        : IsWooCommerceDb
            ? _localizer["SalesChannelEditPage.ConnHintWooDb"]
            : _localizer["SalesChannelEditPage.ConnHintDefault"];

    #endregion

    #region Connection Information

    public string Url
    {
        get => _url;
        set => SetProperty(ref _url, value);
    }

    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    #endregion

    #region Database Settings (WooCommerceDatabase)

    public string DbHost
    {
        get => _dbHost;
        set => SetProperty(ref _dbHost, value);
    }

    public string DbPort
    {
        get => _dbPort;
        set => SetProperty(ref _dbPort, value);
    }

    public string DbName
    {
        get => _dbName;
        set => SetProperty(ref _dbName, value);
    }

    public string DbTablePrefix
    {
        get => _dbTablePrefix;
        set => SetProperty(ref _dbTablePrefix, value);
    }

    /// <summary>Serializes the MySQL settings into the connector-owned config JSON.</summary>
    internal static string BuildDatabaseConfigJson(string dbHost, string dbPort, string dbName, string dbTablePrefix)
    {
        var config = new System.Text.Json.Nodes.JsonObject
        {
            ["host"] = dbHost.Trim(),
            ["port"] = int.TryParse(dbPort, out var port) ? port : 3306,
            ["database"] = dbName.Trim(),
            ["tablePrefix"] = string.IsNullOrWhiteSpace(dbTablePrefix) ? "wp_" : dbTablePrefix.Trim(),
        };
        return config.ToJsonString();
    }

    /// <summary>
    /// Parses the connector-owned config JSON back into the MySQL field values, or null when the
    /// stored value is empty or malformed — the form then keeps its defaults and the user
    /// re-enters the values.
    /// </summary>
    internal static (string Host, string Port, string Database, string TablePrefix)? TryParseDatabaseConfig(string? json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return null;
        }

        try
        {
            if (System.Text.Json.Nodes.JsonNode.Parse(json) is not System.Text.Json.Nodes.JsonObject config)
            {
                return null;
            }

            return (
                config["host"]?.GetValue<string>() ?? string.Empty,
                config["port"]?.GetValue<int>().ToString() ?? "3306",
                config["database"]?.GetValue<string>() ?? string.Empty,
                config["tablePrefix"]?.GetValue<string>() ?? "wp_");
        }
        catch (System.Text.Json.JsonException)
        {
            return null;
        }
    }

    private void LoadDatabaseConfigFromJson(string? json)
    {
        if (TryParseDatabaseConfig(json) is not { } config)
        {
            return;
        }

        DbHost = config.Host;
        DbPort = config.Port;
        DbName = config.Database;
        DbTablePrefix = config.TablePrefix;
    }

    /// <summary>Empty is allowed (save falls back to 3306); otherwise it must be a valid TCP port.</summary>
    internal static bool IsDbPortValid(string dbPort) => string.IsNullOrWhiteSpace(dbPort) ||
        (int.TryParse(dbPort, out var port) && port is > 0 and <= 65535);

    #endregion

    #region Import Settings

    public bool ImportProducts
    {
        get => _importProducts;
        set => SetProperty(ref _importProducts, value);
    }

    public bool ImportCustomers
    {
        get => _importCustomers;
        set => SetProperty(ref _importCustomers, value);
    }

    public bool ImportSaless
    {
        get => _importSaless;
        set => SetProperty(ref _importSaless, value);
    }

    #endregion

    #region Export Settings

    public bool ExportProducts
    {
        get => _exportProducts;
        set => SetProperty(ref _exportProducts, value);
    }

    public bool ExportCustomers
    {
        get => _exportCustomers;
        set => SetProperty(ref _exportCustomers, value);
    }

    public bool ExportSaless
    {
        get => _exportSaless;
        set => SetProperty(ref _exportSaless, value);
    }

    public bool ExportStock
    {
        get => _exportStock;
        set => SetProperty(ref _exportStock, value);
    }

    public bool PushSalesCancellations
    {
        get => _pushSalesCancellations;
        set => SetProperty(ref _pushSalesCancellations, value);
    }

    public bool ImportStock
    {
        get => _importStock;
        set => SetProperty(ref _importStock, value);
    }

    #endregion

    #region Warehouses

    public ObservableCollection<SelectableWarehouse> Warehouses
    {
        get => _warehouses;
        set => SetProperty(ref _warehouses, value);
    }

    public bool HasWarehouses => Warehouses.Count > 0;

    /// <summary>True once the user has selected at least one warehouse — a prerequisite for saving.</summary>
    public bool HasSelectedWarehouse => Warehouses.Any(w => w.IsSelected);

    /// <summary>True while the warehouse list is being fetched in the background.</summary>
    public bool IsWarehousesLoading
    {
        get => _isWarehousesLoading;
        private set
        {
            if (SetProperty(ref _isWarehousesLoading, value))
            {
                OnPropertyChanged(nameof(ShowNoWarehouses));
                OnPropertyChanged(nameof(ShowWarehouseRequiredHint));
            }
        }
    }

    /// <summary>Show the "no warehouses" placeholder only once loading finished and none exist.</summary>
    public bool ShowNoWarehouses => !IsWarehousesLoading && !HasWarehouses;

    /// <summary>
    /// Show the "at least one warehouse required" hint once the list has loaded, warehouses exist,
    /// but none is selected yet — explains why the Save button is disabled.
    /// </summary>
    public bool ShowWarehouseRequiredHint => !IsWarehousesLoading && HasWarehouses && !HasSelectedWarehouse;

    /// <summary>
    /// Recomputes the save-gating properties whenever a warehouse's selection toggles. The warehouse
    /// items raise change notifications independently of this model, so we listen and re-evaluate
    /// <see cref="CanSave"/> (the Save button's IsEnabled) and the required-selection hint.
    /// </summary>
    private void OnWarehouseSelectionChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(SelectableWarehouse.IsSelected))
            return;

        RunOnUi(() =>
        {
            OnPropertyChanged(nameof(HasSelectedWarehouse));
            OnPropertyChanged(nameof(ShowWarehouseRequiredHint));
            OnPropertyChanged(nameof(CanSave));
        });
    }

    #endregion

    #region UI State

    /// <summary>
    /// Indicates whether a save operation is in progress.
    /// </summary>
    public bool IsSaving
    {
        get => _isSaving;
        private set
        {
            if (SetProperty(ref _isSaving, value))
            {
                OnPropertyChanged(nameof(IsLoading));
                OnPropertyChanged(nameof(IsNotLoading));
                OnPropertyChanged(nameof(ShowConnectionHint));
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    /// <summary>
    /// Combined loading state (initializing or saving).
    /// </summary>
    public bool IsLoading => IsInitializing || IsSaving;

    /// <summary>
    /// Inverse of IsLoading for binding convenience.
    /// </summary>
    public bool IsNotLoading => !IsLoading;

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    /// <summary>
    /// Determines if the save operation is allowed based on required fields per SalesChannelType.
    /// </summary>
    public bool CanSave => !IsLoading && CanSaveCore(
        SalesChannelType, IsEditMode, Name, Url, Username, Password,
        DbHost, DbName, DbPort, HasSelectedWarehouse);

    /// <summary>
    /// Pure required-field validation matrix behind <see cref="CanSave"/> — one rule set per
    /// SalesChannelType. Static so it is testable headless (tests/asERP.Client.Tests).
    /// </summary>
    internal static bool CanSaveCore(
        SalesChannelType type,
        bool isEditMode,
        string name,
        string url,
        string username,
        string password,
        string dbHost,
        string dbName,
        string dbPort,
        bool hasSelectedWarehouse)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        // Every channel must have at least one warehouse assigned (stock is always drawn from /
        // mirrored into a concrete warehouse). Enforced server-side too.
        if (!hasSelectedWarehouse)
            return false;

        // Type-specific validation
        return type switch
        {
            // PointOfSale: Only Name required
            SalesChannelType.PointOfSale => true,

            // eBay / Amazon: only Name required at save time. The OAuth flow runs after save
            // (it needs the channel id) and persists the refresh token onto the channel.
            // Developer-App credentials live in TenantOAuthAppSettings or system Settings.
            SalesChannelType.eBay or SalesChannelType.Amazon => true,

            // WooCommerceDatabase additionally needs the MySQL host + database name; the URL
            // stays required because the product images are downloaded from the shop over HTTP.
            SalesChannelType.WooCommerceDatabase =>
                !string.IsNullOrWhiteSpace(url) &&
                !string.IsNullOrWhiteSpace(username) &&
                !string.IsNullOrWhiteSpace(dbHost) &&
                !string.IsNullOrWhiteSpace(dbName) &&
                IsDbPortValid(dbPort) &&
                (isEditMode || !string.IsNullOrWhiteSpace(password)),

            // Shopware6, WooCommerce: Name, URL, Username required.
            // Password is only required when creating — on edit the stored secret is kept
            // unless the user types a new one (it is never returned to the client to prefill).
            _ => !string.IsNullOrWhiteSpace(url) &&
                 !string.IsNullOrWhiteSpace(username) &&
                 (isEditMode || !string.IsNullOrWhiteSpace(password))
        };
    }

    #endregion

    private async Task LoadSalesChannelAsync(CancellationToken ct)
    {
        if (!_salesChannelId.HasValue) return;

        var salesChannel = await _salesChannelService.GetSalesChannelAsync(_salesChannelId.Value, ct);
        if (salesChannel != null)
        {
            // Basic Information
            Name = salesChannel.Name;
            SalesChannelType = salesChannel.SalesChannelType;

            // Connection Information
            Url = salesChannel.Url ?? string.Empty;
            Username = salesChannel.Username ?? string.Empty;
            // Password is not returned from API for security reasons, keep empty

            // MySQL settings (only meaningful for WooCommerceDatabase; harmless otherwise)
            LoadDatabaseConfigFromJson(salesChannel.AdditionalConfigJson);

            // Import Settings
            ImportProducts = salesChannel.ImportProducts;
            ImportCustomers = salesChannel.ImportCustomers;
            ImportSaless = salesChannel.ImportSaless;
            _originalImportProducts = salesChannel.ImportProducts;

            // Export Settings
            ExportProducts = salesChannel.ExportProducts;
            ExportCustomers = salesChannel.ExportCustomers;
            ExportSaless = salesChannel.ExportSaless;
            ExportStock = salesChannel.ExportStock;
            PushSalesCancellations = salesChannel.PushSalesCancellations;
            ImportStock = salesChannel.ImportStock;

            // OAuth status (only meaningful for eBay / Amazon channels).
            _hasRefreshToken = salesChannel.HasRefreshToken;
            _tokenExpiresAt = salesChannel.TokenExpiresAt;
            OnPropertyChanged(nameof(IsConnected));
            OnPropertyChanged(nameof(ConnectionStatusLabel));

            // Capture associated warehouse ids; the (background) warehouse loader applies the
            // selection once the list arrives. Also mark any warehouses already present.
            _selectedWarehouseIds = salesChannel.Warehouses?.Select(w => w.Id).ToHashSet() ?? new HashSet<Guid>();
            foreach (var warehouse in Warehouses)
            {
                warehouse.IsSelected = _selectedWarehouseIds.Contains(warehouse.Id);
            }
        }
    }

    /// <summary>
    /// Begin OAuth flow: ask the Server for the authorize URL and open it in the system browser.
    /// Then poll the channel detail every 3 seconds for the connected state until either
    /// connected, the user navigates away, or 5 minutes elapse.
    /// </summary>
    public async Task ConnectOAuthAsync(CancellationToken ct = default)
    {
        if (!_salesChannelId.HasValue || !IsOAuthChannel) return;

        IsConnecting = true;
        OAuthStatusMessage = string.Empty;
        try
        {
            var providerSlug = SalesChannelType.ToString().ToLowerInvariant();
            var startResult = await _salesChannelService.StartOAuthAsync(_salesChannelId.Value, providerSlug, ct);

            await Windows.System.Launcher.LaunchUriAsync(new Uri(startResult.AuthorizeUrl));
            OAuthStatusMessage = _localizer["SalesChannelEditPage.OAuth.WaitingForCallback"];

            await PollForConnectionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(3), ct);
        }
        catch (ApiException ex)
        {
            OAuthStatusMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            OAuthStatusMessage = ex.Message;
        }
        finally
        {
            IsConnecting = false;
        }
    }

    public async Task DisconnectOAuthAsync(CancellationToken ct = default)
    {
        if (!_salesChannelId.HasValue || !IsOAuthChannel) return;

        IsConnecting = true;
        try
        {
            var providerSlug = SalesChannelType.ToString().ToLowerInvariant();
            await _salesChannelService.DisconnectOAuthAsync(_salesChannelId.Value, providerSlug, ct);

            _hasRefreshToken = false;
            _tokenExpiresAt = null;
            OnPropertyChanged(nameof(IsConnected));
            OnPropertyChanged(nameof(ConnectionStatusLabel));
            OAuthStatusMessage = _localizer["SalesChannelEditPage.OAuth.Disconnected"];
        }
        catch (ApiException ex)
        {
            OAuthStatusMessage = ex.CombinedMessage;
        }
        finally
        {
            IsConnecting = false;
        }
    }

    private async Task PollForConnectionAsync(TimeSpan timeout, TimeSpan interval, CancellationToken ct)
    {
        if (!_salesChannelId.HasValue) return;

        var deadline = DateTime.UtcNow + timeout;
        while (DateTime.UtcNow < deadline)
        {
            try
            {
                await Task.Delay(interval, ct);
            }
            catch (TaskCanceledException) { return; }

            try
            {
                var refreshed = await _salesChannelService.GetSalesChannelAsync(_salesChannelId.Value, ct);
                if (refreshed?.HasRefreshToken == true)
                {
                    _hasRefreshToken = true;
                    _tokenExpiresAt = refreshed.TokenExpiresAt;
                    OnPropertyChanged(nameof(IsConnected));
                    OnPropertyChanged(nameof(ConnectionStatusLabel));
                    OAuthStatusMessage = _localizer["SalesChannelEditPage.OAuth.Connected"];
                    return;
                }
            }
            catch
            {
                // transient — keep polling
            }
        }
    }

    public async Task SaveAsync(CancellationToken ct = default)
    {
        if (!CanSave) return;

        IsSaving = true;
        ErrorMessage = string.Empty;

        // WooCommerce talks to the REST API under /wp-json/wc/v3 — normalize whatever the user
        // typed (bare host or shop base URL) into the full endpoint before persisting, and reflect
        // it back into the field so the stored value is visible.
        if (IsWooCommerce)
        {
            Url = NormalizeWooCommerceUrl(Url);
        }
        // The database variant keeps the plain shop base URL (image downloads) — only ensure a
        // scheme and drop a pasted REST API path.
        else if (IsWooCommerceDb)
        {
            Url = NormalizeShopBaseUrl(Url);
        }

        try
        {
            var input = new SalesChannelInputDto
            {
                Name = Name,
                SalesChannelType = SalesChannelType,
                Url = Url,
                Username = Username,
                Password = Password,
                // Null keeps a channel's stored connector config untouched; only the DB variant
                // owns its config from this form.
                AdditionalConfigJson = IsWooCommerceDb
                    ? BuildDatabaseConfigJson(DbHost, DbPort, DbName, DbTablePrefix)
                    : null,
                ImportProducts = ImportProducts,
                ImportCustomers = ImportCustomers,
                ImportSaless = ImportSaless,
                ExportProducts = ExportProducts,
                ExportCustomers = ExportCustomers,
                ExportSaless = ExportSaless,
                ExportStock = ExportStock,
                PushSalesCancellations = PushSalesCancellations,
                ImportStock = ImportStock,
                WarehouseIds = Warehouses.Where(w => w.IsSelected).Select(w => w.Id).ToList()
            };

            var isNew = !_salesChannelId.HasValue;
            Guid channelId;

            if (_salesChannelId.HasValue)
            {
                input.Id = _salesChannelId.Value;
                await _salesChannelService.UpdateSalesChannelAsync(_salesChannelId.Value, input, ct);
                channelId = _salesChannelId.Value;
            }
            else
            {
                channelId = await _salesChannelService.CreateSalesChannelAsync(input, ct);
            }

            // Notify Shell to refresh dynamic sidebar items
            ShellModel.NotifySalesChannelsChanged();

            // Confirm the save to the user — previously this was silent (just a navigate-back).
            _notifications.Show(
                string.Format(_localizer[isNew ? "SalesChannelEditPage.ToastCreated" : "SalesChannelEditPage.ToastUpdated"], Name),
                NotificationSeverity.Success);

            // Kick off a product import immediately when products should be imported and either the
            // channel is new or product import was just enabled. Otherwise the orchestrator would only
            // pick it up after its poll interval, with no feedback to the user. OAuth channels
            // (eBay/Amazon) are skipped — they must complete the OAuth connect step first.
            var shouldImportNow = ImportProducts && (isNew || !_originalImportProducts) && !IsOAuthChannel;
            if (shouldImportNow && channelId != Guid.Empty)
            {
                StartBackgroundProductImport(channelId, Name);
            }

            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            // Display detailed error messages from the API
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["SalesChannelEditPage.Error.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
        }
    }

    public async Task CancelAsync()
    {
        await _navigator.NavigateBackAsync(this);
    }

    /// <summary>
    /// Triggers a one-off product import for the channel and surfaces the outcome as a toast.
    /// Runs detached (fire-and-forget) so navigation back is not blocked by the import, and uses the
    /// singleton notification service so the result still reaches the user after this page is gone.
    /// </summary>
    private void StartBackgroundProductImport(Guid channelId, string channelName)
    {
        _notifications.Show(
            string.Format(_localizer["SalesChannelEditPage.ToastImportStarted"], channelName),
            NotificationSeverity.Info);

        // Not tied to the page's CancellationToken — that is cancelled on navigate-back.
        _ = Task.Run(async () =>
        {
            try
            {
                var result = await _salesChannelService.TriggerSyncAsync(channelId, "products", CancellationToken.None);

                if (result is null || (result.ItemsProcessed == 0 && result.ItemsFailed == 0))
                {
                    _notifications.Show(
                        string.Format(_localizer["SalesChannelEditPage.ToastImportEmpty"], channelName),
                        NotificationSeverity.Warning);
                    return;
                }

                var severity = result.ItemsFailed == 0
                    ? NotificationSeverity.Success
                    : result.ItemsProcessed == 0
                        ? NotificationSeverity.Error
                        : NotificationSeverity.Warning;

                _notifications.Show(
                    string.Format(_localizer["SalesChannelEditPage.ToastImportDone"], channelName, result.ItemsProcessed, result.ItemsFailed),
                    severity);

                // Products were (at least partly) imported — let an open product list refresh itself.
                if (result.ItemsProcessed > 0)
                {
                    AppRefreshSignals.RaiseProductsChanged();
                }
            }
            catch (ApiException ex)
            {
                _notifications.Show(
                    string.Format(_localizer["SalesChannelEditPage.ToastImportFailed"], channelName, ex.CombinedMessage),
                    NotificationSeverity.Error);
            }
            catch (Exception ex)
            {
                _notifications.Show(
                    string.Format(_localizer["SalesChannelEditPage.ToastImportFailed"], channelName, ex.Message),
                    NotificationSeverity.Error);
            }
        });
    }

    /// <summary>
    /// WooCommerce REST API path appended to the shop's base URL.
    /// </summary>
    private const string WooCommerceApiPath = "/wp-json/wc/v3";

    /// <summary>
    /// Normalizes a user-entered WooCommerce URL into the full REST endpoint:
    /// prepends <c>https://</c> when no scheme is given and appends <see cref="WooCommerceApiPath"/>
    /// unless it is already present. Idempotent — calling it on an already-normalized URL is a no-op.
    /// </summary>
    internal static string NormalizeWooCommerceUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return url;
        }

        var normalized = url.Trim();

        // Add a default scheme so the result is an absolute URI (the Server validates this).
        if (!normalized.Contains("://", StringComparison.Ordinal))
        {
            normalized = "https://" + normalized;
        }

        normalized = normalized.TrimEnd('/');

        // Already points at the REST API (regardless of casing)? Leave the path as-is.
        if (normalized.EndsWith(WooCommerceApiPath, StringComparison.OrdinalIgnoreCase) ||
            normalized.Contains(WooCommerceApiPath + "/", StringComparison.OrdinalIgnoreCase))
        {
            return normalized;
        }

        return normalized + WooCommerceApiPath;
    }

    /// <summary>
    /// Normalizes a user-entered shop URL for the database-backed WooCommerce type: prepends
    /// <c>https://</c> when no scheme is given, trims a trailing slash and strips a pasted
    /// <c>/wp-json/wc/v3</c> path — the connector needs the plain base URL for image links.
    /// </summary>
    internal static string NormalizeShopBaseUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return url;
        }

        var normalized = url.Trim();
        if (!normalized.Contains("://", StringComparison.Ordinal))
        {
            normalized = "https://" + normalized;
        }

        normalized = normalized.TrimEnd('/');
        if (normalized.EndsWith(WooCommerceApiPath, StringComparison.OrdinalIgnoreCase))
        {
            normalized = normalized[..^WooCommerceApiPath.Length];
        }
        return normalized;
    }

    /// <inheritdoc />
    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        // Update CanSave when relevant fields change
        if (propertyName is nameof(Name) or nameof(Url) or nameof(Username) or nameof(Password)
            or nameof(DbHost) or nameof(DbPort) or nameof(DbName))
        {
            base.OnPropertyChanged(nameof(CanSave));
        }

        // Handle IsInitializing changes from base class
        if (propertyName is nameof(IsInitializing))
        {
            base.OnPropertyChanged(nameof(IsLoading));
            base.OnPropertyChanged(nameof(IsNotLoading));
            base.OnPropertyChanged(nameof(ShowConnectionHint));
            base.OnPropertyChanged(nameof(CanSave));
        }
    }
}

/// <summary>
/// Represents a sales channel type option for the ComboBox.
/// </summary>
public record SalesChannelTypeOption(SalesChannelType Value, string ResourceKey);

/// <summary>
/// Selectable warehouse model for the sales channel edit form.
/// </summary>
public class SelectableWarehouse : INotifyPropertyChanged
{
    private Guid _id;
    private string _name = string.Empty;
    private bool _isSelected;

    public Guid Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
