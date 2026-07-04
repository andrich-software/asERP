using asToolkit.Client.Features.Customers;
using asToolkit.Client.Features.Invoices.Models;
using asToolkit.Client.Features.Products.Models;
using asToolkit.Client.Features.Saless;
using asToolkit.Client.Features.Search.Services;
using asToolkit.Client.Features.Shippings;
using asToolkit.Domain.Dtos.Search;
using asToolkit.Domain.Enums;

namespace asToolkit.Client.Features.Search.Models;

/// <summary>
/// Model for the global search results page using the MVUX pattern.
/// Receives the query from navigation data and loads grouped results.
/// </summary>
public partial record SearchResultsModel
{
    private const int ResultsLimit = 50;

    private readonly ISearchService _searchService;
    private readonly INavigator _navigator;
    private readonly string _query;

    public SearchResultsModel(
        ISearchService searchService,
        INavigator navigator,
        SearchResultsData data)
    {
        _searchService = searchService;
        _navigator = navigator;
        _query = data.query ?? string.Empty;
    }

    /// <summary>The search term the results are for.</summary>
    public string Query => _query;

    /// <summary>Grouped search results loaded from the API.</summary>
    public IFeed<GlobalSearchResultDto> Results => Feed.Async(async ct =>
        await _searchService.SearchAsync(_query, ResultsLimit, ct));

    /// <summary>
    /// Navigate to the detail page matching the hit's entity type.
    /// </summary>
    public async Task NavigateToHit(GlobalSearchHitDto hit)
    {
        switch (hit.Type)
        {
            case SearchEntityType.Customer:
                await _navigator.NavigateDataAsync(this, new CustomerDetailData(hit.Id));
                break;
            case SearchEntityType.Sales:
                await _navigator.NavigateDataAsync(this, new SalesDetailData(hit.Id));
                break;
            case SearchEntityType.Invoice:
                await _navigator.NavigateDataAsync(this, new InvoiceDetailData(hit.Id));
                break;
            case SearchEntityType.Product:
                await _navigator.NavigateDataAsync(this, new ProductDetailData(hit.Id));
                break;
            case SearchEntityType.Shipping:
                await _navigator.NavigateDataAsync(this, new ShippingDetailData(hit.Id));
                break;
        }
    }
}
