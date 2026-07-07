using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using asERP.Client.Core.Abstractions;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Models;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Feeds.Services;
using asERP.Client.Features.SalesChannels.Services;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Enums;

namespace asERP.Client.Features.Feeds.Models;

/// <summary>
/// Navigation data for FeedEditModel. A null id means "create".
/// </summary>
public record FeedEditData(Guid? FeedId = null);

/// <summary>
/// Model for the feed edit/create page. Inherits <see cref="AsyncInitializableModel"/> for safe
/// async initialization. The product-selection list (edit mode only) is paged and searchable;
/// only changed rows are persisted as deltas.
/// </summary>
public class FeedEditModel : AsyncInitializableModel
{
    private readonly IFeedService _feedService;
    private readonly ISalesChannelService _salesChannelService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly INotificationService _notifications;
    private readonly Guid? _feedId;

    // Product-inclusion changes that differ from the server's current state, keyed by product id.
    // Survives paging/search so the user's pending edits are not lost when they move between pages.
    private readonly Dictionary<Guid, bool> _pendingProductChanges = new();

    // Basic fields
    private string _name = string.Empty;
    private FeedTemplate _template = FeedTemplate.GoogleProducts;
    private string _currency = "EUR";
    private Guid? _salesChannelId;
    private bool _isEnabled = true;
    private string _defaultDeliveryTime = string.Empty;
    private string _defaultShippingCost = string.Empty;

    // Product selection (edit mode)
    private ObservableCollection<SelectableFeedProduct> _products = new();
    private string _productSearch = string.Empty;
    private int _productPage;
    private int _productTotalPages;

    // UI state
    private bool _isSaving;
    private string _errorMessage = string.Empty;

    public FeedEditModel(
        IFeedService feedService,
        ISalesChannelService salesChannelService,
        INavigator navigator,
        IStringLocalizer localizer,
        INotificationService notifications,
        ILogger<FeedEditModel> logger,
        FeedEditData? data = null)
        : base(logger)
    {
        _feedService = feedService;
        _salesChannelService = salesChannelService;
        _navigator = navigator;
        _localizer = localizer;
        _notifications = notifications;
        _feedId = data?.FeedId;

        TemplateOptions = new List<FeedTemplateOption>
        {
            new(FeedTemplate.GoogleProducts, _localizer["FeedTemplate.GoogleProducts"]),
            new(FeedTemplate.Idealo, _localizer["FeedTemplate.Idealo"]),
            new(FeedTemplate.Pinterest, _localizer["FeedTemplate.Pinterest"])
        };

        StartInitialization();
    }

    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        await LoadSalesChannelsAsync(ct);

        if (_feedId.HasValue)
        {
            await LoadFeedAsync(ct);
            await LoadProductPageAsync(0, ct);
        }
    }

    #region Basic fields

    public bool IsEditMode => _feedId.HasValue;

    public string Title => IsEditMode
        ? _localizer["FeedEditPage.TitleEdit"]
        : _localizer["FeedEditPage.TitleNew"];

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public FeedTemplate Template
    {
        get => _template;
        set
        {
            if (SetProperty(ref _template, value))
            {
                OnPropertyChanged(nameof(ShowIdealoSettings));
            }
        }
    }

    public string Currency
    {
        get => _currency;
        set => SetProperty(ref _currency, value);
    }

    public Guid? SelectedSalesChannelId
    {
        get => _salesChannelId;
        set => SetProperty(ref _salesChannelId, value);
    }

    public bool IsEnabled
    {
        get => _isEnabled;
        set => SetProperty(ref _isEnabled, value);
    }

    public string DefaultDeliveryTime
    {
        get => _defaultDeliveryTime;
        set => SetProperty(ref _defaultDeliveryTime, value);
    }

    public string DefaultShippingCost
    {
        get => _defaultShippingCost;
        set => SetProperty(ref _defaultShippingCost, value);
    }

    /// <summary>idealo has extra per-offer defaults (delivery time / shipping cost).</summary>
    public bool ShowIdealoSettings => Template == FeedTemplate.Idealo;

    /// <summary>Available feed-template options for the ComboBox.</summary>
    public IReadOnlyList<FeedTemplateOption> TemplateOptions { get; }

    /// <summary>Shopware6/WooCommerce channels usable to build product deep-links (plus a "none" option).</summary>
    public ObservableCollection<SalesChannelOption> SalesChannelOptions { get; } = new();

    #endregion

    #region Products (edit mode)

    public ObservableCollection<SelectableFeedProduct> Products
    {
        get => _products;
        set => SetProperty(ref _products, value);
    }

    public string ProductSearch
    {
        get => _productSearch;
        set => SetProperty(ref _productSearch, value);
    }

    /// <summary>Products are only configurable for an existing feed (the API is keyed by feed id).</summary>
    public bool ShowProducts => IsEditMode;

    /// <summary>Create mode: prompt the user to save first before configuring products.</summary>
    public bool ShowProductsSaveFirstHint => !IsEditMode;

    public bool HasProducts => Products.Count > 0;

    public int ProductPageDisplay => _productPage + 1;
    public int ProductTotalPages => _productTotalPages;

    public string ProductPageInfo => _productTotalPages <= 0
        ? _localizer["Pagination.NoResults"]
        : string.Format(_localizer["Pagination.PageInfo"], _productPage + 1, _productTotalPages);

    public bool CanGoPreviousProductPage => _productPage > 0;
    public bool CanGoNextProductPage => _productPage + 1 < _productTotalPages;

    private async Task LoadProductPageAsync(int page, CancellationToken ct)
    {
        if (!_feedId.HasValue)
        {
            return;
        }

        var parameters = new QueryParameters
        {
            PageNumber = Math.Max(0, page),
            PageSize = 25,
            SearchString = string.IsNullOrWhiteSpace(ProductSearch) ? null : ProductSearch,
            SalesBy = "Name Ascending"
        };

        var response = await _feedService.GetFeedProductsAsync(_feedId.Value, parameters, ct);

        // Detach change handlers on the outgoing rows before replacing them.
        foreach (var existing in Products)
        {
            existing.PropertyChanged -= OnProductRowChanged;
        }

        var rows = new ObservableCollection<SelectableFeedProduct>();
        foreach (var dto in response.Data)
        {
            // Reflect a pending edit if the user already toggled this product on another page.
            var isActive = _pendingProductChanges.TryGetValue(dto.ProductId, out var pending)
                ? pending
                : dto.IsActive;

            var row = new SelectableFeedProduct
            {
                ProductId = dto.ProductId,
                Sku = dto.Sku,
                Name = dto.Name,
                Price = dto.Price,
                ServerIsActive = dto.IsActive,
                IsActive = isActive
            };
            row.PropertyChanged += OnProductRowChanged;
            rows.Add(row);
        }

        _productPage = response.CurrentPage;
        _productTotalPages = response.TotalPages;
        Products = rows;

        OnPropertyChanged(nameof(HasProducts));
        OnPropertyChanged(nameof(ProductPageDisplay));
        OnPropertyChanged(nameof(ProductTotalPages));
        OnPropertyChanged(nameof(ProductPageInfo));
        OnPropertyChanged(nameof(CanGoPreviousProductPage));
        OnPropertyChanged(nameof(CanGoNextProductPage));
    }

    private void OnProductRowChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is not SelectableFeedProduct row || e.PropertyName != nameof(SelectableFeedProduct.IsActive))
        {
            return;
        }

        // Track only rows that differ from the server's stored state; matching rows are removed
        // so the delta payload stays minimal.
        if (row.IsActive == row.ServerIsActive)
        {
            _pendingProductChanges.Remove(row.ProductId);
        }
        else
        {
            _pendingProductChanges[row.ProductId] = row.IsActive;
        }
    }

    public async Task SearchProductsAsync()
    {
        if (!_feedId.HasValue)
        {
            return;
        }

        await LoadProductPageAsync(0, CancellationToken.None);
    }

    public async Task GoToNextProductPageAsync()
    {
        if (CanGoNextProductPage)
        {
            await LoadProductPageAsync(_productPage + 1, CancellationToken.None);
        }
    }

    public async Task GoToPreviousProductPageAsync()
    {
        if (CanGoPreviousProductPage)
        {
            await LoadProductPageAsync(_productPage - 1, CancellationToken.None);
        }
    }

    /// <summary>Sets the inclusion flag for every product on the current page.</summary>
    public void SetAllOnCurrentPage(bool isActive)
    {
        foreach (var product in Products)
        {
            product.IsActive = isActive;
        }
    }

    #endregion

    #region UI state

    public bool IsSaving
    {
        get => _isSaving;
        private set
        {
            if (SetProperty(ref _isSaving, value))
            {
                OnPropertyChanged(nameof(IsLoading));
                OnPropertyChanged(nameof(IsNotLoading));
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    public bool IsLoading => IsInitializing || IsSaving;
    public bool IsNotLoading => !IsLoading;

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool CanSave => !IsLoading
        && !string.IsNullOrWhiteSpace(Name)
        && !string.IsNullOrWhiteSpace(Currency);

    #endregion

    private async Task LoadSalesChannelsAsync(CancellationToken ct)
    {
        SalesChannelOptions.Clear();
        // First entry: no linked channel (SalesChannelId is optional).
        SalesChannelOptions.Add(new SalesChannelOption(null, _localizer["FeedEditPage.NoSalesChannel"]));

        try
        {
            var parameters = new QueryParameters { PageSize = 1000 };
            var response = await _salesChannelService.GetSalesChannelsAsync(parameters, ct);

            foreach (var channel in response.Data.Where(IsLinkableChannel))
            {
                SalesChannelOptions.Add(new SalesChannelOption(channel.Id, channel.Name));
            }
        }
        catch (Exception)
        {
            // A failed channel lookup must not block feed editing — the dropdown just stays at "none".
        }
    }

    /// <summary>Only Shopware6 / WooCommerce channels can produce product deep-links for a feed.</summary>
    private static bool IsLinkableChannel(asERP.Domain.Dtos.SalesChannel.SalesChannelListDto channel)
        => channel.SalesChannelType is SalesChannelType.Shopware6
            or SalesChannelType.WooCommerce
            or SalesChannelType.WooCommerceDatabase;

    private async Task LoadFeedAsync(CancellationToken ct)
    {
        if (!_feedId.HasValue)
        {
            return;
        }

        var feed = await _feedService.GetFeedAsync(_feedId.Value, ct);
        if (feed is null)
        {
            return;
        }

        Name = feed.Name;
        Template = feed.Template;
        Currency = string.IsNullOrWhiteSpace(feed.Currency) ? "EUR" : feed.Currency;
        SelectedSalesChannelId = feed.SalesChannelId;
        IsEnabled = feed.IsEnabled;
        DefaultDeliveryTime = feed.DefaultDeliveryTime ?? string.Empty;
        DefaultShippingCost = feed.DefaultShippingCost?.ToString(CultureInfo.CurrentCulture) ?? string.Empty;
    }

    public async Task SaveAsync(CancellationToken ct = default)
    {
        if (!CanSave)
        {
            return;
        }

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            decimal? shippingCost = null;
            if (!string.IsNullOrWhiteSpace(DefaultShippingCost) &&
                decimal.TryParse(DefaultShippingCost, NumberStyles.Number, CultureInfo.CurrentCulture, out var parsed))
            {
                shippingCost = parsed;
            }

            var input = new FeedInputDto
            {
                Id = _feedId ?? Guid.Empty,
                Name = Name.Trim(),
                Template = Template,
                Currency = Currency.Trim(),
                SalesChannelId = SelectedSalesChannelId,
                IsEnabled = IsEnabled,
                DefaultDeliveryTime = string.IsNullOrWhiteSpace(DefaultDeliveryTime) ? null : DefaultDeliveryTime.Trim(),
                DefaultShippingCost = shippingCost
            };

            var isNew = !_feedId.HasValue;
            Guid feedId;

            if (_feedId.HasValue)
            {
                input.Id = _feedId.Value;
                await _feedService.UpdateFeedAsync(_feedId.Value, input, ct);
                feedId = _feedId.Value;
            }
            else
            {
                feedId = await _feedService.CreateFeedAsync(input, ct);
            }

            // Persist product-inclusion deltas (only present in edit mode, where the list was shown).
            if (_pendingProductChanges.Count > 0 && feedId != Guid.Empty)
            {
                var update = new FeedProductSelectionUpdateDto
                {
                    Changes = _pendingProductChanges
                        .Select(kv => new FeedProductSelectionChange { ProductId = kv.Key, IsActive = kv.Value })
                        .ToList()
                };
                await _feedService.UpdateFeedProductsAsync(feedId, update, ct);
                _pendingProductChanges.Clear();
            }

            _notifications.Show(
                string.Format(_localizer[isNew ? "FeedEditPage.ToastCreated" : "FeedEditPage.ToastUpdated"], Name),
                NotificationSeverity.Success);

            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["FeedEditPage.SaveFailed"], ex.Message);
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

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName is nameof(Name) or nameof(Currency))
        {
            base.OnPropertyChanged(nameof(CanSave));
        }

        if (propertyName is nameof(IsInitializing))
        {
            base.OnPropertyChanged(nameof(IsLoading));
            base.OnPropertyChanged(nameof(IsNotLoading));
            base.OnPropertyChanged(nameof(CanSave));
        }
    }
}

/// <summary>A selectable feed-template option for the ComboBox.</summary>
public record FeedTemplateOption(FeedTemplate Value, string Display);

/// <summary>A sales-channel option for the (optional) linked-channel ComboBox.</summary>
public partial record SalesChannelOption(Guid? Id, string Name);

/// <summary>
/// A product row in the feed product-selection editor. <see cref="ServerIsActive"/> is the state
/// as loaded from the server; <see cref="IsActive"/> is the user's (possibly edited) choice.
/// </summary>
public class SelectableFeedProduct : INotifyPropertyChanged
{
    private bool _isActive;

    public Guid ProductId { get; init; }
    public string Sku { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public bool ServerIsActive { get; init; }

    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive != value)
            {
                _isActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
