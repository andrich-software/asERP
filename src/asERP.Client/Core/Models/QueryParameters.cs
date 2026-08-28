namespace asERP.Client.Core.Models;

/// <summary>
/// Parameters for paginated API queries.
/// Uses the same naming convention as the server API.
/// </summary>
public record QueryParameters
{
    /// <summary>
    /// Page number (0-based).
    /// </summary>
    public int PageNumber { get; init; }

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public int PageSize { get; init; } = 20;

    /// <summary>
    /// Search term to filter results.
    /// </summary>
    public string? SearchString { get; init; }

    /// <summary>
    /// Sort sales (e.g., "Name Ascending", "DateCreated Descending").
    /// Multiple sort fields can be separated by commas.
    /// </summary>
    public string? SalesBy { get; init; }

    /// <summary>
    /// Optional SalesChannel filter. When set, only results for this channel are returned.
    /// </summary>
    public Guid? SalesChannelId { get; init; }

    /// <summary>
    /// When true, variant child products are included in product list results.
    /// Only honored by the products endpoint; ignored elsewhere.
    /// </summary>
    public bool IncludeVariants { get; init; }

    /// <summary>
    /// When true, only products below their minimum stock in at least one warehouse are returned.
    /// Only honored by the products endpoint; ignored elsewhere.
    /// </summary>
    public bool LowStockOnly { get; init; }

    /// <summary>
    /// Builds the query string for API requests.
    /// </summary>
    public string ToQueryString()
    {
        var parameters = new List<string>
        {
            $"pageNumber={PageNumber}",
            $"pageSize={PageSize}"
        };

        if (!string.IsNullOrWhiteSpace(SearchString))
        {
            parameters.Add($"searchString={Uri.EscapeDataString(SearchString)}");
        }

        if (!string.IsNullOrWhiteSpace(SalesBy))
        {
            parameters.Add($"salesBy={Uri.EscapeDataString(SalesBy)}");
        }

        if (SalesChannelId.HasValue)
        {
            parameters.Add($"salesChannelId={SalesChannelId.Value}");
        }

        if (IncludeVariants)
        {
            parameters.Add("includeVariants=true");
        }

        if (LowStockOnly)
        {
            parameters.Add("lowStockOnly=true");
        }

        return string.Join("&", parameters);
    }

    /// <summary>
    /// Creates a new QueryParameters with the next page.
    /// </summary>
    public QueryParameters NextPage() => this with { PageNumber = PageNumber + 1 };

    /// <summary>
    /// Creates a new QueryParameters with the previous page.
    /// </summary>
    public QueryParameters PreviousPage() => this with { PageNumber = Math.Max(0, PageNumber - 1) };

    /// <summary>
    /// Creates a new QueryParameters with a specific page.
    /// </summary>
    public QueryParameters WithPage(int page) => this with { PageNumber = Math.Max(0, page) };

    /// <summary>
    /// Creates a new QueryParameters with a search term.
    /// </summary>
    public QueryParameters WithSearch(string? search) => this with { SearchString = search, PageNumber = 0 };

    /// <summary>
    /// Creates a new QueryParameters with a sort sales.
    /// </summary>
    public QueryParameters WithSalesBy(string? salesBy) => this with { SalesBy = salesBy, PageNumber = 0 };
}
