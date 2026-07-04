using asERP.Client.Core.Models;
using asERP.Client.Features.ProductAttributes.Services;
using asERP.Domain.Dtos.ProductAttribute;

namespace asERP.Client.Features.ProductAttributes.Models;

/// <summary>
/// Model for product attribute list page using MVUX pattern.
/// Supports searching, sorting, pagination, and navigation to detail view.
/// </summary>
public partial record ProductAttributeListModel
{
    private readonly IProductAttributeService _productAttributeService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;

    public ProductAttributeListModel(
        IProductAttributeService productAttributeService,
        INavigator navigator,
        IStringLocalizer localizer)
    {
        _productAttributeService = productAttributeService;
        _navigator = navigator;
        _localizer = localizer;
    }

    /// <summary>
    /// Navigate to product attribute detail page.
    /// </summary>
    public async ValueTask NavigateToDetail(Guid productAttributeId, CancellationToken ct = default)
    {
        await _navigator.NavigateDataAsync(this, new ProductAttributeDetailData(productAttributeId));
    }

    /// <summary>
    /// Navigate to create new product attribute page.
    /// </summary>
    public async ValueTask NavigateToCreate(CancellationToken ct = default)
    {
        await _navigator.NavigateDataAsync(this, new ProductAttributeEditData());
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
    /// Pagination information from the last API response.
    /// </summary>
    public IState<ProductAttributePaginationInfo> Pagination => State<ProductAttributePaginationInfo>.Value(this, () => new ProductAttributePaginationInfo());

    /// <summary>
    /// Feed of product attributes from the API.
    /// Automatically refreshes when SearchQuery, CurrentPage, or SortSales changes.
    /// </summary>
    public IListFeed<ProductAttributeListDto> ProductAttributes => Feed
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

            var response = await _productAttributeService.GetProductAttributesAsync(parameters, ct);

            // Update pagination info
            await Pagination.UpdateAsync(_ => new ProductAttributePaginationInfo(
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
/// Holds pagination state information for product attributes.
/// </summary>
public record ProductAttributePaginationInfo
{
    private readonly IStringLocalizer? _localizer;

    public ProductAttributePaginationInfo()
    {
    }

    public ProductAttributePaginationInfo(
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
    /// Display text for total count info (e.g., "25 product attributes").
    /// </summary>
    public string CountInfo
    {
        get
        {
            if (TotalCount == 1)
            {
                return _localizer?["Pagination.ProductAttributesSingular"] ?? "1 product attribute";
            }

            var format = _localizer?["Pagination.ProductAttributesPlural"] ?? "{0} product attributes";
            return string.Format(format, TotalCount);
        }
    }
}
