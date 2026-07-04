using asERP.Client.Core.Constants;
using asERP.Client.Features.Search.Models;
using asERP.Client.Features.Search.Services;
using asERP.Client.Features.Search.Views;

namespace asERP.Client.Features.Search;

/// <summary>
/// Module registration for the global Search feature.
/// </summary>
public static class SearchModule
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<ISearchService, SearchService>();
        services.AddTransient<SearchResultsModel>();
        return services;
    }

    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<SearchResultsPage, SearchResultsModel>(Data: new DataMap<SearchResultsData>())
        );
    }

    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.SearchResults, View: views.FindByViewModel<SearchResultsModel>());
    }
}

/// <summary>
/// Navigation data for the search results page.
/// </summary>
public record SearchResultsData(string query);
