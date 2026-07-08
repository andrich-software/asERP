using asERP.Client.Core.Models;
using asERP.Client.Features.Superadmin.Services;
using asERP.Domain.Dtos.Country;

namespace asERP.Client.Features.Superadmin.Models;

/// <summary>
/// Model for the superadmin country list page using the MVUX pattern.
/// Supports searching, sorting, pagination, and navigation to create/edit.
/// Only accessible to users with the Superadmin role.
/// </summary>
public partial record SuperadminCountryListModel
{
    private readonly ISuperadminCountryService _countryService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;

    public SuperadminCountryListModel(
        ISuperadminCountryService countryService,
        INavigator navigator,
        IStringLocalizer localizer)
    {
        _countryService = countryService;
        _navigator = navigator;
        _localizer = localizer;
    }

    /// <summary>
    /// Navigate to the create-new-country page.
    /// </summary>
    public async ValueTask NavigateToCreate(CancellationToken ct = default)
    {
        await _navigator.NavigateDataAsync(this, new SuperadminCountryEditData());
    }

    /// <summary>
    /// Navigate to the edit page for the given country.
    /// </summary>
    public async ValueTask NavigateToEdit(Guid countryId, CancellationToken ct = default)
    {
        await _navigator.NavigateDataAsync(this, new SuperadminCountryEditData(countryId));
    }

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
    public IState<int> PageSize => State<int>.Value(this, () => 100);

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
    /// Pagination information from the last API response.
    /// </summary>
    public IState<SuperadminCountryPaginationInfo> Pagination => State<SuperadminCountryPaginationInfo>.Value(this, () => new SuperadminCountryPaginationInfo());

    /// <summary>
    /// Feed of countries from the API.
    /// Automatically refreshes when SearchQuery, CurrentPage, PageSize, or SortSales changes.
    /// </summary>
    public IListFeed<CountryListDto> Countries => Feed
        .Combine(SearchQuery, CurrentPage, PageSize, SortSales)
        .SelectAsync(async (combined, ct) =>
        {
            var (query, page, size, salesBy) = combined;

            var parameters = new QueryParameters
            {
                PageNumber = page,
                PageSize = size,
                SearchString = string.IsNullOrWhiteSpace(query) ? null : query,
                SalesBy = salesBy
            };

            var response = await _countryService.GetCountriesAsync(parameters, ct);

            // Update pagination info
            await Pagination.UpdateAsync(_ => new SuperadminCountryPaginationInfo(
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
/// Holds pagination state information for countries.
/// </summary>
public record SuperadminCountryPaginationInfo
{
    private readonly IStringLocalizer? _localizer;

    public SuperadminCountryPaginationInfo()
    {
    }

    public SuperadminCountryPaginationInfo(
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
    /// Display text for total count info (e.g., "25 countries").
    /// </summary>
    public string CountInfo
    {
        get
        {
            if (TotalCount == 1)
            {
                return _localizer?["Pagination.CountriesSingular"] ?? "1 country";
            }

            var format = _localizer?["Pagination.CountriesPlural"] ?? "{0} countries";
            return string.Format(format, TotalCount);
        }
    }
}
