using asERP.Client.Core.Models;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Shippings.Services;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Enums;

namespace asERP.Client.Features.Shippings.Models;

/// <summary>
/// Model for the tenant-wide shipment list page using the MVUX pattern.
/// Supports searching, status/problem filtering, sorting, and pagination.
/// </summary>
public partial record ShippingListModel
{
    private readonly IShippingService _shippingService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly INotificationService _notifications;

    public ShippingListModel(
        IShippingService shippingService,
        INavigator navigator,
        IStringLocalizer localizer,
        INotificationService notifications)
    {
        _shippingService = shippingService;
        _navigator = navigator;
        _localizer = localizer;
        _notifications = notifications;
    }

    /// <summary>
    /// Search + status + problems filter as a single state, so the list feed stays a
    /// four-way Feed.Combine (nested combine tuples fight the MVUX generator).
    /// </summary>
    public IState<ShippingListFilter> Filter => State<ShippingListFilter>.Value(this, () => new ShippingListFilter());

    /// <summary>
    /// Current page number (0-based).
    /// </summary>
    public IState<int> CurrentPage => State<int>.Value(this, () => 0);

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public IState<int> PageSize => State<int>.Value(this, () => 25);

    /// <summary>
    /// Current sort clause (e.g. "ShippedAt Descending").
    /// </summary>
    public IState<string> SortSales => State<string>.Value(this, () => "ShippedAt Descending");

    /// <summary>
    /// The field currently sorted by; bound by the SortHeaderButton column headers.
    /// </summary>
    public IState<string> ActiveSortField => State<string>.Value(this, () => "ShippedAt");

    /// <summary>
    /// Current sort direction; bound by the SortHeaderButton column headers.
    /// </summary>
    public IState<bool> SortAscending => State<bool>.Value(this, () => false);

    /// <summary>
    /// Pagination information from the last API response.
    /// </summary>
    public IState<ShippingPaginationInfo> Pagination =>
        State<ShippingPaginationInfo>.Value(this, () => new ShippingPaginationInfo());

    /// <summary>
    /// Feed of shipments from the API.
    /// Automatically refreshes when the filter, page, page size, or sort changes.
    /// </summary>
    public IListFeed<ShipmentListItemDto> Shippings => Feed
        .Combine(Filter, CurrentPage, PageSize, SortSales)
        .SelectAsync(async (combined, ct) =>
        {
            var (filter, page, size, salesBy) = combined;
            filter ??= new ShippingListFilter();

            var parameters = new QueryParameters
            {
                PageNumber = page,
                PageSize = size,
                SearchString = string.IsNullOrWhiteSpace(filter.SearchQuery) ? null : filter.SearchQuery,
                SalesBy = salesBy
            };

            var response = await _shippingService.GetShippingsAsync(
                parameters,
                status: filter.StatusFilter == 0 ? null : (ShippingStatus)filter.StatusFilter,
                problemsOnly: filter.ProblemsOnly,
                ct: ct);

            // Update pagination info
            await Pagination.UpdateAsync(_ => new ShippingPaginationInfo(
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
    /// Navigate to the shipment detail page.
    /// </summary>
    public async Task ViewShipping(ShipmentListItemDto shipping)
    {
        await _navigator.NavigateDataAsync(this, new ShippingDetailData(shipping.Id));
    }

    /// <summary>
    /// Update the search query; resets to the first page.
    /// </summary>
    public async ValueTask SetSearch(string query, CancellationToken ct = default)
    {
        await CurrentPage.UpdateAsync(_ => 0, ct);
        await Filter.UpdateAsync(f => (f ?? new ShippingListFilter()) with { SearchQuery = query }, ct);
    }

    /// <summary>
    /// Update the status filter (0 = all statuses); resets to the first page.
    /// </summary>
    public async ValueTask SetStatusFilter(int status, CancellationToken ct = default)
    {
        await CurrentPage.UpdateAsync(_ => 0, ct);
        await Filter.UpdateAsync(f => (f ?? new ShippingListFilter()) with { StatusFilter = status }, ct);
    }

    /// <summary>
    /// Toggle the problems-only filter; resets to the first page.
    /// </summary>
    public async ValueTask SetProblemsOnly(bool problemsOnly, CancellationToken ct = default)
    {
        await CurrentPage.UpdateAsync(_ => 0, ct);
        await Filter.UpdateAsync(f => (f ?? new ShippingListFilter()) with { ProblemsOnly = problemsOnly }, ct);
    }

    /// <summary>
    /// Toast shown after the tracking number was copied to the clipboard (copy happens in the view).
    /// </summary>
    public void NotifyTrackingCopied()
    {
        _notifications.Show(_localizer["ShippingListPage.TrackingCopied"].Value, NotificationSeverity.Success);
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
    /// Change the sort clause.
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
/// Combined list filter: search text, status (0 = all, otherwise the ShippingStatus int
/// value), and the problems-only toggle.
/// </summary>
public record ShippingListFilter(string SearchQuery = "", int StatusFilter = 0, bool ProblemsOnly = false);

/// <summary>
/// Holds pagination state information for shipments.
/// </summary>
public record ShippingPaginationInfo
{
    private readonly IStringLocalizer? _localizer;

    public ShippingPaginationInfo()
    {
    }

    public ShippingPaginationInfo(
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
    /// Display text for total count info (e.g., "25 shipments").
    /// </summary>
    public string CountInfo
    {
        get
        {
            if (TotalCount == 1)
            {
                return _localizer?["Pagination.ShippingsSingular"] ?? "1 shipment";
            }

            var format = _localizer?["Pagination.ShippingsPlural"] ?? "{0} shipments";
            return string.Format(format, TotalCount);
        }
    }
}
