using asERP.Client.Core.Constants;
using asERP.Client.Core.Models;
using asERP.Client.Features.Products.Services;
using asERP.Client.Features.SalesChannels.Services;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Enums;

namespace asERP.Client.Features.Products.Models;

/// <summary>
/// Model for product list page using MVUX pattern.
/// Supports searching, sorting, and pagination.
/// </summary>
public partial record ProductListModel
{
    private readonly IProductService _productService;
    private readonly ISalesChannelService _salesChannelService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;

    public ProductListModel(
        IProductService productService,
        ISalesChannelService salesChannelService,
        INavigator navigator,
        IStringLocalizer localizer)
    {
        _productService = productService;
        _salesChannelService = salesChannelService;
        _navigator = navigator;
        _localizer = localizer;
    }

    // Polling baseline: the newest completed product-import run we have already accounted for.
    // Lets PollForCompletedImportAsync detect server-side background imports the client never triggered.
    private Guid? _lastCompletedImportRunId;
    private bool _importPollPrimed;

    /// <summary>
    /// The search query entered by the user.
    /// </summary>
    public IState<string> SearchQuery => State<string>.Value(this, () => string.Empty);

    /// <summary>
    /// Current page number (0-based).
    /// </summary>
    public IState<int> CurrentPage => State<int>.Value(this, () => 0);

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public IState<int> PageSize => State<int>.Value(this, () => 25);

    /// <summary>
    /// Current sort sales (e.g., "Name Ascending").
    /// </summary>
    public IState<string> SortSales => State<string>.Value(this, () => "Name Ascending");

    /// <summary>
    /// The field currently sorted by; bound by the SortHeaderButton column headers.
    /// </summary>
    public IState<string> ActiveSortField => State<string>.Value(this, () => "Name");

    /// <summary>
    /// Current sort direction; bound by the SortHeaderButton column headers.
    /// </summary>
    public IState<bool> SortAscending => State<bool>.Value(this, () => true);

    /// <summary>
    /// Contextual empty state when the product list is empty (null while products exist).
    /// Set from the Products feed; rendered declaratively by the page.
    /// </summary>
    public IState<ProductEmptyStateInfo?> EmptyState => State<ProductEmptyStateInfo?>.Value(this, () => null);

    /// <summary>
    /// When true, variant child products are included in the list.
    /// Bound to the "Varianten anzeigen" toggle.
    /// </summary>
    public IState<bool> IncludeVariants => State<bool>.Value(this, () => false);

    /// <summary>
    /// Pagination information from the last API response.
    /// </summary>
    public IState<ProductPaginationInfo> Pagination => State<ProductPaginationInfo>.Value(this, () => new ProductPaginationInfo());

    /// <summary>
    /// Feed of products from the API.
    /// Automatically refreshes when SearchQuery, CurrentPage, or SortSales changes.
    /// </summary>
    public IListFeed<ProductListItemModel> Products => Feed
        .Combine(SearchQuery, CurrentPage, PageSize, SortSales, IncludeVariants)
        .SelectAsync(async (combined, ct) =>
        {
            var (query, page, size, salesBy, includeVariants) = combined;

            var parameters = new QueryParameters
            {
                PageNumber = page,
                PageSize = size,
                SearchString = string.IsNullOrWhiteSpace(query) ? null : query,
                SalesBy = salesBy,
                IncludeVariants = includeVariants
            };

            var response = await _productService.GetProductsAsync(parameters, ct);

            // Update pagination info
            await Pagination.UpdateAsync(_ => new ProductPaginationInfo(
                response.CurrentPage,
                response.TotalPages,
                response.TotalCount,
                response.PageSize,
                response.HasPreviousPage,
                response.HasNextPage,
                _localizer), ct);

            // Contextual empty state: only resolved when the list is actually empty.
            var emptyState = response.TotalCount == 0 ? await GetEmptyStateAsync(ct) : null;
            await EmptyState.UpdateAsync(_ => emptyState, ct);

            // Thumbnails are NOT loaded here: rows appear immediately and each realized
            // row loads its thumbnail lazily via ThumbnailLoader (with caching).
            return response.Data.Select(d => new ProductListItemModel(d)).ToImmutableList();
        })
        .AsListFeed();

    /// <summary>
    /// Navigate to product detail page.
    /// </summary>
    public async Task ViewProduct(ProductListDto product)
    {
        await _navigator.NavigateDataAsync(this, new ProductDetailData(product.Id));
    }

    /// <summary>
    /// Navigate to create new product page.
    /// </summary>
    public async Task CreateProduct()
    {
        await _navigator.NavigateRouteAsync(this, Routes.ProductCreate);
    }

    /// <summary>
    /// Navigate to the sales channel overview — the action behind most empty-state buttons.
    /// </summary>
    public async Task OpenSalesChannels()
    {
        await _navigator.NavigateRouteAsync(this, Routes.SalesChannelOverview);
    }

    /// <summary>
    /// Polls sales-channel sync history and reports whether a NEW product-import run has completed
    /// (Success/PartialFailure) since the last poll. Used by the view to auto-refresh on server-side
    /// background imports the client never triggered (the orchestrator's scheduled runs). The first
    /// call only establishes the baseline and returns false, so loading the page never triggers a
    /// spurious refresh. Best-effort — returns false on any error.
    /// </summary>
    public async Task<bool> PollForCompletedImportAsync(CancellationToken ct = default)
    {
        try
        {
            var channels = await _salesChannelService.GetSalesChannelsAsync(
                new QueryParameters { PageSize = 200 }, ct);
            var importChannels = channels.Data.Where(c => c.ImportProducts).ToList();
            if (importChannels.Count == 0)
            {
                return false;
            }

            var productRuns = new List<ChannelSyncRunDto>();
            foreach (var channel in importChannels)
            {
                var channelRuns = await _salesChannelService.GetSyncRunsAsync(channel.Id, take: 5, offset: 0, ct);
                productRuns.AddRange(channelRuns.Where(r => r.Operation == ChannelSyncOperation.ImportProducts));
            }

            var latestCompleted = productRuns
                .Where(r => r.Status is ChannelSyncRunStatus.Success or ChannelSyncRunStatus.PartialFailure)
                .OrderByDescending(r => r.FinishedAt ?? r.StartedAt)
                .FirstOrDefault();
            var latestId = latestCompleted?.Id;

            // First poll: remember the current state, don't refresh.
            if (!_importPollPrimed)
            {
                _importPollPrimed = true;
                _lastCompletedImportRunId = latestId;
                return false;
            }

            if (latestId.HasValue && latestId != _lastCompletedImportRunId)
            {
                _lastCompletedImportRunId = latestId;
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Determines why the product list is empty so the view can show a helpful, actionable message
    /// instead of a bare "no products". Distinguishes: no import channel configured, an import
    /// currently running, the last import failed, or simply nothing imported yet. Best-effort —
    /// falls back to a generic message if the channel API is unavailable.
    /// </summary>
    private async Task<ProductEmptyStateInfo> GetEmptyStateAsync(CancellationToken ct = default)
    {
        try
        {
            var channels = await _salesChannelService.GetSalesChannelsAsync(
                new QueryParameters { PageSize = 200 }, ct);
            var importChannels = channels.Data.Where(c => c.ImportProducts).ToList();

            if (importChannels.Count == 0)
            {
                return new ProductEmptyStateInfo(
                    "",
                    _localizer["ProductListPage.EmptyNoChannelTitle"],
                    _localizer["ProductListPage.EmptyNoChannelMessage"],
                    _localizer["ProductListPage.EmptySetupChannelAction"],
                    ProductEmptyStateAction.OpenSalesChannels);
            }

            // Look at recent product-import runs across the import-enabled channels.
            var productRuns = new List<ChannelSyncRunDto>();
            foreach (var channel in importChannels)
            {
                var channelRuns = await _salesChannelService.GetSyncRunsAsync(channel.Id, take: 5, offset: 0, ct);
                productRuns.AddRange(channelRuns.Where(r => r.Operation == ChannelSyncOperation.ImportProducts));
            }

            if (productRuns.Any(r => r.Status == ChannelSyncRunStatus.Running))
            {
                return new ProductEmptyStateInfo(
                    "",
                    _localizer["ProductListPage.EmptyImportingTitle"],
                    _localizer["ProductListPage.EmptyImportingMessage"],
                    _localizer["ProductListPage.EmptyRefreshAction"],
                    ProductEmptyStateAction.Refresh);
            }

            var latest = productRuns.OrderByDescending(r => r.StartedAt).FirstOrDefault();
            if (latest is { Status: ChannelSyncRunStatus.Failed })
            {
                return new ProductEmptyStateInfo(
                    "",
                    _localizer["ProductListPage.EmptyFailedTitle"],
                    _localizer["ProductListPage.EmptyFailedMessage"],
                    _localizer["ProductListPage.EmptyOpenSalesChannelsAction"],
                    ProductEmptyStateAction.OpenSalesChannels);
            }

            // Import channel(s) configured, nothing failed — just no products yet.
            return new ProductEmptyStateInfo(
                "",
                _localizer["ProductListPage.EmptyNoProductsTitle"],
                _localizer["ProductListPage.EmptyNoProductsMessage"],
                _localizer["ProductListPage.EmptyOpenSalesChannelsAction"],
                ProductEmptyStateAction.OpenSalesChannels);
        }
        catch
        {
            // Could not determine the context — show a plain, non-actionable empty state.
            return new ProductEmptyStateInfo(
                "",
                _localizer["ProductListPage.EmptyNoProductsTitle"],
                _localizer["ProductListPage.EmptyNoProductsMessage"],
                null,
                ProductEmptyStateAction.None);
        }
    }

    /// <summary>
    /// Go to the next page.
    /// </summary>
    public async ValueTask GoToNextPage(CancellationToken ct = default)
    {
        var pagination = await Pagination.Value(ct);
        if (pagination?.HasNextPage == true)
        {
            await CurrentPage.UpdateAsync(p => p + 1, ct);
        }
    }

    /// <summary>
    /// Go to the previous page.
    /// </summary>
    public async ValueTask GoToPreviousPage(CancellationToken ct = default)
    {
        var pagination = await Pagination.Value(ct);
        if (pagination?.HasPreviousPage == true)
        {
            await CurrentPage.UpdateAsync(p => Math.Max(0, p - 1), ct);
        }
    }

    /// <summary>
    /// Go to a specific page.
    /// </summary>
    public async ValueTask GoToPage(int page, CancellationToken ct = default)
    {
        var pagination = await Pagination.Value(ct);
        if (pagination != null && page >= 0 && page < pagination.TotalPages)
        {
            await CurrentPage.UpdateAsync(_ => page, ct);
        }
    }

    /// <summary>
    /// Change the sort sales.
    /// </summary>
    public async ValueTask SetSortSales(string salesBy, CancellationToken ct = default)
    {
        await SortSales.UpdateAsync(_ => salesBy, ct);
        await CurrentPage.UpdateAsync(_ => 0, ct); // Reset to first page when sorting changes
    }

    /// <summary>
    /// Toggles sorting for a column header: same field flips direction, a new field starts ascending.
    /// </summary>
    public async ValueTask ToggleSort(string field, CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(field))
        {
            return;
        }

        var currentField = await ActiveSortField.Value(ct) ?? string.Empty;
        var ascending = currentField == field ? !(await SortAscending.Value(ct)) : true;

        await ActiveSortField.UpdateAsync(_ => field, ct);
        await SortAscending.UpdateAsync(_ => ascending, ct);
        await SetSortSales($"{field} {(ascending ? "Ascending" : "Descending")}", ct);
    }

    /// <summary>
    /// Toggle whether variant child products are included in the list.
    /// </summary>
    public async ValueTask SetIncludeVariants(bool includeVariants, CancellationToken ct = default)
    {
        await IncludeVariants.UpdateAsync(_ => includeVariants, ct);
        await CurrentPage.UpdateAsync(_ => 0, ct);
    }

    /// <summary>
    /// Change the page size.
    /// </summary>
    public async ValueTask SetPageSize(int pageSize, CancellationToken ct = default)
    {
        await PageSize.UpdateAsync(_ => pageSize, ct);
        await CurrentPage.UpdateAsync(_ => 0, ct); // Reset to first page when page size changes
    }
}

/// <summary>
/// Holds pagination state information for products.
/// </summary>
public record ProductPaginationInfo
{
    private readonly IStringLocalizer? _localizer;

    public ProductPaginationInfo()
    {
    }

    public ProductPaginationInfo(
        int currentPage,
        int totalPages,
        int totalCount,
        int pageSize,
        bool hasPreviousPage,
        bool hasNextPage,
        IStringLocalizer localizer)
    {
        CurrentPage = currentPage;
        TotalPages = totalPages;
        TotalCount = totalCount;
        PageSize = pageSize;
        HasPreviousPage = hasPreviousPage;
        HasNextPage = hasNextPage;
        _localizer = localizer;
    }

    public int CurrentPage { get; init; }
    public int TotalPages { get; init; }
    public int TotalCount { get; init; }
    public int PageSize { get; init; }
    public bool HasPreviousPage { get; init; }
    public bool HasNextPage { get; init; }

    /// <summary>
    /// Display text for current page info (e.g., "Page 1 of 5").
    /// </summary>
    public string PageInfo
    {
        get
        {
            if (TotalPages <= 0)
            {
                return _localizer?["Pagination.NoResults"] ?? "No results";
            }

            var format = _localizer?["Pagination.PageInfo"] ?? "Page {0} of {1}";
            return string.Format(format, CurrentPage + 1, TotalPages);
        }
    }

    /// <summary>
    /// Display text for total count info (e.g., "25 products").
    /// </summary>
    public string CountInfo
    {
        get
        {
            if (TotalCount == 1)
            {
                return _localizer?["Pagination.ProductsSingular"] ?? "1 product";
            }

            var format = _localizer?["Pagination.ProductsPlural"] ?? "{0} products";
            return string.Format(format, TotalCount);
        }
    }
}

/// <summary>
/// Navigation data for product detail page.
/// </summary>
public record ProductDetailData(Guid productId);

/// <summary>What the empty-state action button does.</summary>
public enum ProductEmptyStateAction
{
    None,
    OpenSalesChannels,
    Refresh
}

/// <summary>
/// Describes the contextual empty state shown when the product list is empty.
/// </summary>
/// <param name="Glyph">Segoe MDL2 glyph for the empty-state icon.</param>
/// <param name="Title">Short headline.</param>
/// <param name="Message">Explanatory text.</param>
/// <param name="ActionLabel">Label for the optional action button (null = no button).</param>
/// <param name="Action">What the action button does.</param>
public record ProductEmptyStateInfo(
    string Glyph,
    string Title,
    string Message,
    string? ActionLabel,
    ProductEmptyStateAction Action);
