using maERP.Client.Core.Constants;
using maERP.Client.Features.Search.Models;
using maERP.Client.Features.Search.Services;
using maERP.Client.Features.Search.Views;

namespace maERP.Client.Features.Search;

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
