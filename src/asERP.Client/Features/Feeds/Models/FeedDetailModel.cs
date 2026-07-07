using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Models;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Feeds.Services;
using asERP.Domain.Dtos.Feed;

namespace asERP.Client.Features.Feeds.Models;

/// <summary>
/// Navigation data for FeedDetailModel.
/// </summary>
public record FeedDetailData(Guid FeedId);

/// <summary>
/// Model for the feed detail page using the MVUX pattern.
/// Loads the feed detail eagerly; the Log and Products tab feeds are gated on first
/// selection via <see cref="LogsRequested"/> / <see cref="ProductsRequested"/> so the
/// expensive paged queries only run once the user opens those tabs.
/// </summary>
public partial record FeedDetailModel
{
    private readonly IFeedService _feedService;
    private readonly INavigator _navigator;
    private readonly INotificationService _notifications;
    private readonly IStringLocalizer _localizer;
    private readonly Guid _feedId;

    public FeedDetailModel(
        IFeedService feedService,
        INavigator navigator,
        INotificationService notifications,
        IStringLocalizer localizer,
        FeedDetailData data)
    {
        _feedService = feedService;
        _navigator = navigator;
        _notifications = notifications;
        _localizer = localizer;
        _feedId = data.FeedId;
    }

    /// <summary>Feed that loads the feed details (PublicUrl is filled by the server).</summary>
    public IFeed<FeedDetailDto> FeedDetail => Feed.Async(async ct =>
    {
        var feed = await _feedService.GetFeedAsync(_feedId, ct);
        return feed ?? throw new InvalidOperationException($"Feed {_feedId} not found");
    });

    #region Log tab (paged, gated)

    /// <summary>Set true when the Log tab is first selected, unlocking the log query.</summary>
    public IState<bool> LogsRequested => State<bool>.Value(this, () => false);

    /// <summary>Current log page (0-based).</summary>
    public IState<int> LogPage => State<int>.Value(this, () => 0);

    /// <summary>Pagination info from the last log query.</summary>
    public IState<FeedPaginationInfo> LogPagination => State<FeedPaginationInfo>.Value(this, () => new FeedPaginationInfo());

    /// <summary>Public-access log entries for this feed (newest first).</summary>
    public IListFeed<FeedLogDto> Logs => Feed
        .Combine(LogsRequested, LogPage)
        .SelectAsync(async (combined, ct) =>
        {
            var (requested, page) = combined;
            if (!requested)
            {
                return ImmutableList<FeedLogDto>.Empty;
            }

            var parameters = new QueryParameters
            {
                PageNumber = page,
                PageSize = 50,
                SalesBy = "DateCreated Descending"
            };

            var response = await _feedService.GetFeedLogsAsync(_feedId, parameters, ct);

            await LogPagination.UpdateAsync(_ => new FeedPaginationInfo(
                response.CurrentPage, response.TotalPages, response.TotalCount,
                response.PageSize, response.HasPreviousPage, response.HasNextPage, _localizer), ct);

            return response.Data.ToImmutableList();
        })
        .AsListFeed();

    public async ValueTask EnsureLogsLoaded(CancellationToken ct = default)
        => await LogsRequested.UpdateAsync(_ => true, ct);

    public async ValueTask GoToNextLogPage(CancellationToken ct = default)
    {
        var pagination = await LogPagination.Value(ct);
        if (pagination?.HasNextPage == true)
        {
            await LogPage.UpdateAsync(p => p + 1, ct);
        }
    }

    public async ValueTask GoToPreviousLogPage(CancellationToken ct = default)
    {
        var pagination = await LogPagination.Value(ct);
        if (pagination?.HasPreviousPage == true)
        {
            await LogPage.UpdateAsync(p => Math.Max(0, p - 1), ct);
        }
    }

    #endregion

    #region Products tab (paged, searchable, sortable, gated)

    /// <summary>Set true when the Products tab is first selected, unlocking the product query.</summary>
    public IState<bool> ProductsRequested => State<bool>.Value(this, () => false);

    public IState<string> ProductSearch => State<string>.Value(this, () => string.Empty);
    public IState<int> ProductPage => State<int>.Value(this, () => 0);
    public IState<string> ProductSort => State<string>.Value(this, () => "Name Ascending");
    public IState<string> ProductActiveSortField => State<string>.Value(this, () => "Name");
    public IState<bool> ProductSortAscending => State<bool>.Value(this, () => true);
    public IState<FeedPaginationInfo> ProductPagination => State<FeedPaginationInfo>.Value(this, () => new FeedPaginationInfo());

    /// <summary>Read-only product selection for this feed (catalog metadata + inclusion flag).</summary>
    public IListFeed<FeedProductSelectionDto> Products => Feed
        .Combine(ProductsRequested, ProductSearch, ProductPage, ProductSort)
        .SelectAsync(async (combined, ct) =>
        {
            var (requested, search, page, sortBy) = combined;
            if (!requested)
            {
                return ImmutableList<FeedProductSelectionDto>.Empty;
            }

            var parameters = new QueryParameters
            {
                PageNumber = page,
                PageSize = 25,
                SearchString = string.IsNullOrWhiteSpace(search) ? null : search,
                SalesBy = sortBy
            };

            var response = await _feedService.GetFeedProductsAsync(_feedId, parameters, ct);

            await ProductPagination.UpdateAsync(_ => new FeedPaginationInfo(
                response.CurrentPage, response.TotalPages, response.TotalCount,
                response.PageSize, response.HasPreviousPage, response.HasNextPage, _localizer), ct);

            return response.Data.ToImmutableList();
        })
        .AsListFeed();

    public async ValueTask EnsureProductsLoaded(CancellationToken ct = default)
        => await ProductsRequested.UpdateAsync(_ => true, ct);

    public async ValueTask SetProductSearch(string search, CancellationToken ct = default)
    {
        await ProductPage.UpdateAsync(_ => 0, ct);
        await ProductSearch.UpdateAsync(_ => search, ct);
    }

    public async ValueTask GoToNextProductPage(CancellationToken ct = default)
    {
        var pagination = await ProductPagination.Value(ct);
        if (pagination?.HasNextPage == true)
        {
            await ProductPage.UpdateAsync(p => p + 1, ct);
        }
    }

    public async ValueTask GoToPreviousProductPage(CancellationToken ct = default)
    {
        var pagination = await ProductPagination.Value(ct);
        if (pagination?.HasPreviousPage == true)
        {
            await ProductPage.UpdateAsync(p => Math.Max(0, p - 1), ct);
        }
    }

    public async ValueTask ToggleProductSort(string field, CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(field))
        {
            return;
        }

        var currentField = await ProductActiveSortField.Value(ct) ?? string.Empty;
        var ascending = currentField == field ? !(await ProductSortAscending.Value(ct)) : true;

        await ProductActiveSortField.UpdateAsync(_ => field, ct);
        await ProductSortAscending.UpdateAsync(_ => ascending, ct);
        await ProductPage.UpdateAsync(_ => 0, ct);
        await ProductSort.UpdateAsync(_ => $"{field} {(ascending ? "Ascending" : "Descending")}", ct);
    }

    #endregion

    /// <summary>Navigate to the edit page for this feed.</summary>
    public async Task EditFeed()
    {
        await _navigator.NavigateDataAsync(this, new FeedEditData(_feedId));
    }

    /// <summary>Delete this feed and navigate back to the list on success. Returns true on success.</summary>
    public async Task<bool> DeleteFeed()
    {
        try
        {
            await _feedService.DeleteFeedAsync(_feedId);
            _notifications.Show(_localizer["FeedDetailPage.DeleteSuccess"].Value, NotificationSeverity.Success);
            await _navigator.NavigateBackAsync(this);
            return true;
        }
        catch (ApiException ex)
        {
            _notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
            return false;
        }
    }

    /// <summary>Navigate back to the feed list.</summary>
    public async Task GoBack()
    {
        await _navigator.NavigateBackAsync(this);
    }
}
