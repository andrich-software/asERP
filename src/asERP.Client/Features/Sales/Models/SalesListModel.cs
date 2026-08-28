using asERP.Client.Core.Constants;
using asERP.Client.Core.Models;
using asERP.Client.Features.Saless.Services;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;

namespace asERP.Client.Features.Saless.Models;

/// <summary>
/// Model for sales list page using MVUX pattern.
/// Supports searching, quick filters, sorting, and pagination.
/// </summary>
public partial record SalesListModel
{
    private readonly ISalesService _salesService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;

    public SalesListModel(
        ISalesService salesService,
        INavigator navigator,
        IStringLocalizer localizer,
        SalesListData? data = null)
    {
        _salesService = salesService;
        _navigator = navigator;
        _localizer = localizer;
        InitialQuickFilter = data?.QuickFilter ?? SalesQuickFilter.All;
    }

    /// <summary>
    /// Quick filter pre-activated via navigation data (e.g. from the dashboard to-do card);
    /// the page code-behind reads it to highlight the matching filter chip.
    /// </summary>
    public SalesQuickFilter InitialQuickFilter { get; }

    /// <summary>
    /// Search text + quick filter as a single state, so the list feed stays a
    /// four-way Feed.Combine (nested combine tuples fight the MVUX generator).
    /// </summary>
    public IState<SalesListFilter> Filter => State<SalesListFilter>.Value(this, () => new SalesListFilter(QuickFilter: InitialQuickFilter));

    /// <summary>
    /// Current page number (0-based).
    /// </summary>
    public IState<int> CurrentPage => State<int>.Value(this, () => 0);

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public IState<int> PageSize => State<int>.Value(this, () => 25);

    /// <summary>
    /// Current sort sales (e.g., "DateSalesed Descending").
    /// </summary>
    public IState<string> SortSales => State<string>.Value(this, () => "DateSalesed Descending");

    /// <summary>
    /// The field currently sorted by; bound by the SortHeaderButton column headers.
    /// </summary>
    public IState<string> ActiveSortField => State<string>.Value(this, () => "DateSalesed");

    /// <summary>
    /// Current sort direction; bound by the SortHeaderButton column headers.
    /// </summary>
    public IState<bool> SortAscending => State<bool>.Value(this, () => false);

    /// <summary>
    /// Pagination information from the last API response.
    /// </summary>
    public IState<SalesPaginationInfo> Pagination => State<SalesPaginationInfo>.Value(this, () => new SalesPaginationInfo(_localizer));

    /// <summary>
    /// Feed of saless from the API.
    /// Automatically refreshes when the filter, page, page size, or sort changes.
    /// </summary>
    public IListFeed<SalesListDto> Saless => Feed
        .Combine(Filter, CurrentPage, PageSize, SortSales)
        .SelectAsync(async (combined, ct) =>
        {
            var (filter, page, size, salesBy) = combined;
            filter ??= new SalesListFilter();

            var parameters = new QueryParameters
            {
                PageNumber = page,
                PageSize = size,
                SearchString = string.IsNullOrWhiteSpace(filter.SearchQuery) ? null : filter.SearchQuery,
                SalesBy = salesBy
            };

            var response = await _salesService.GetSalessAsync(parameters, filter.QuickFilter, ct);

            // Update pagination info
            await Pagination.UpdateAsync(_ => new SalesPaginationInfo(
                response.CurrentPage,
                response.TotalPages,
                response.TotalCount,
                response.PageSize,
                response.HasPreviousPage,
                response.HasNextPage,
                _localizer), ct);

            return response.Data.ToImmutableList();
        })
        .AsListFeed();

    /// <summary>
    /// Update the search query; resets to the first page.
    /// </summary>
    public async ValueTask SetSearch(string query, CancellationToken ct = default)
    {
        await ResetPageAsync(ct);
        await Filter.UpdateAsync(f => (f ?? new SalesListFilter()) with { SearchQuery = query }, ct);
    }

    /// <summary>
    /// Switch the quick filter (filter buttons above the table); resets to the first page.
    /// <paramref name="searchQuery"/> folds a search still waiting out its debounce into the same
    /// state change, so clicking a chip never drops what the user has already typed.
    /// </summary>
    public async ValueTask SetQuickFilter(SalesQuickFilter quickFilter, string? searchQuery = null, CancellationToken ct = default)
    {
        await ResetPageAsync(ct);
        await Filter.UpdateAsync(f =>
        {
            var current = f ?? new SalesListFilter();
            return current with { QuickFilter = quickFilter, SearchQuery = searchQuery ?? current.SearchQuery };
        }, ct);
    }

    /// <summary>
    /// Jumps back to the first page, but only when we are not already there: every published state
    /// change re-runs the list feed and cancels the request still in flight for the previous one.
    /// </summary>
    private async ValueTask ResetPageAsync(CancellationToken ct)
    {
        if (await CurrentPage.Value(ct) != 0)
        {
            await CurrentPage.UpdateAsync(_ => 0, ct);
        }
    }

    /// <summary>
    /// Navigate to sales detail page.
    /// </summary>
    public async Task ViewSales(SalesListDto sales)
    {
        await _navigator.NavigateDataAsync(this, new SalesDetailData(sales.Id));
    }

    /// <summary>
    /// Navigate to create new sales page.
    /// </summary>
    public async Task CreateSales()
    {
        await _navigator.NavigateRouteAsync(this, Routes.SalesCreate);
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
    /// Change the page size.
    /// </summary>
    public async ValueTask SetPageSize(int pageSize, CancellationToken ct = default)
    {
        await PageSize.UpdateAsync(_ => pageSize, ct);
        await CurrentPage.UpdateAsync(_ => 0, ct); // Reset to first page when page size changes
    }
}

/// <summary>
/// Combined list filter: search text plus the selected quick filter button.
/// </summary>
public record SalesListFilter(string SearchQuery = "", SalesQuickFilter QuickFilter = SalesQuickFilter.All);

/// <summary>
/// Holds pagination state information for saless.
/// </summary>
public record SalesPaginationInfo
{
    private readonly IStringLocalizer? _localizer;

    public SalesPaginationInfo()
    {
    }

    /// <summary>Initial state before the first load: no counts yet, but the localizer, so the
    /// placeholder texts ("No results", count label) are localized instead of English fallbacks.</summary>
    public SalesPaginationInfo(IStringLocalizer localizer) => _localizer = localizer;

    public SalesPaginationInfo(
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
    /// Display text for total count info (e.g., "25 saless").
    /// </summary>
    public string CountInfo
    {
        get
        {
            if (TotalCount == 1)
            {
                return _localizer?["Pagination.SalessSingular"] ?? "1 sales";
            }

            var format = _localizer?["Pagination.SalessPlural"] ?? "{0} saless";
            return string.Format(format, TotalCount);
        }
    }
}
