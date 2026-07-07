using asERP.Client.Core.Models;
using asERP.Client.Features.Feeds.Services;
using asERP.Domain.Dtos.Feed;

namespace asERP.Client.Features.Feeds.Models;

/// <summary>
/// Model for the feed list page using the MVUX pattern.
/// Supports searching, sorting, and pagination.
/// </summary>
public partial record FeedListModel
{
    private readonly IFeedService _feedService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;

    public FeedListModel(
        IFeedService feedService,
        INavigator navigator,
        IStringLocalizer localizer)
    {
        _feedService = feedService;
        _navigator = navigator;
        _localizer = localizer;
    }

    /// <summary>The search query entered by the user.</summary>
    public IState<string> SearchQuery => State<string>.Value(this, () => string.Empty);

    /// <summary>Current page number (0-based).</summary>
    public IState<int> CurrentPage => State<int>.Value(this, () => 0);

    /// <summary>Number of items per page.</summary>
    public IState<int> PageSize => State<int>.Value(this, () => 25);

    /// <summary>Current sort order (e.g. "DateCreated Descending").</summary>
    public IState<string> SortOrder => State<string>.Value(this, () => "DateCreated Descending");

    /// <summary>The field currently sorted by; bound by the SortHeaderButton column headers.</summary>
    public IState<string> ActiveSortField => State<string>.Value(this, () => "DateCreated");

    /// <summary>Current sort direction; bound by the SortHeaderButton column headers.</summary>
    public IState<bool> SortAscending => State<bool>.Value(this, () => false);

    /// <summary>Pagination information from the last API response.</summary>
    public IState<FeedPaginationInfo> Pagination => State<FeedPaginationInfo>.Value(this, () => new FeedPaginationInfo());

    /// <summary>
    /// Feed of feeds from the API. Refreshes when SearchQuery, CurrentPage, PageSize, or SortOrder changes.
    /// </summary>
    public IListFeed<FeedListDto> Feeds => Feed
        .Combine(SearchQuery, CurrentPage, PageSize, SortOrder)
        .SelectAsync(async (combined, ct) =>
        {
            var (query, page, size, sortBy) = combined;

            var parameters = new QueryParameters
            {
                PageNumber = page,
                PageSize = size,
                SearchString = string.IsNullOrWhiteSpace(query) ? null : query,
                SalesBy = sortBy
            };

            var response = await _feedService.GetFeedsAsync(parameters, ct);

            await Pagination.UpdateAsync(_ => new FeedPaginationInfo(
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

    /// <summary>Navigate to the feed detail page.</summary>
    public async Task ViewFeed(FeedListDto feed)
    {
        await _navigator.NavigateDataAsync(this, new FeedDetailData(feed.Id));
    }

    /// <summary>Navigate to the create-feed page.</summary>
    public async Task CreateFeed()
    {
        await _navigator.NavigateDataAsync(this, new FeedEditData());
    }

    /// <summary>Go to the next page.</summary>
    public async ValueTask GoToNextPage(CancellationToken ct = default)
    {
        var pagination = await Pagination.Value(ct);
        if (pagination?.HasNextPage == true)
        {
            await CurrentPage.UpdateAsync(p => p + 1, ct);
        }
    }

    /// <summary>Go to the previous page.</summary>
    public async ValueTask GoToPreviousPage(CancellationToken ct = default)
    {
        var pagination = await Pagination.Value(ct);
        if (pagination?.HasPreviousPage == true)
        {
            await CurrentPage.UpdateAsync(p => Math.Max(0, p - 1), ct);
        }
    }

    /// <summary>Change the sort order.</summary>
    public async ValueTask SetSortOrder(string sortBy, CancellationToken ct = default)
    {
        await SortOrder.UpdateAsync(_ => sortBy, ct);
        await CurrentPage.UpdateAsync(_ => 0, ct);
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
        await SetSortOrder($"{field} {(ascending ? "Ascending" : "Descending")}", ct);
    }

    /// <summary>Change the page size.</summary>
    public async ValueTask SetPageSize(int pageSize, CancellationToken ct = default)
    {
        await PageSize.UpdateAsync(_ => pageSize, ct);
        await CurrentPage.UpdateAsync(_ => 0, ct);
    }
}

/// <summary>
/// Holds pagination state information for feeds.
/// </summary>
public record FeedPaginationInfo
{
    private readonly IStringLocalizer? _localizer;

    public FeedPaginationInfo()
    {
    }

    public FeedPaginationInfo(
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

    /// <summary>Display text for current page info (e.g. "Page 1 of 5").</summary>
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

    /// <summary>Display text for total count info (e.g. "25 feeds").</summary>
    public string CountInfo
    {
        get
        {
            if (TotalCount == 1)
            {
                return _localizer?["Pagination.FeedsSingular"] ?? "1 feed";
            }

            var format = _localizer?["Pagination.FeedsPlural"] ?? "{0} feeds";
            return string.Format(format, TotalCount);
        }
    }
}
