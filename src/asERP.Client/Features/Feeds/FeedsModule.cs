using asERP.Client.Core.Constants;
using asERP.Client.Features.Feeds.Models;
using asERP.Client.Features.Feeds.Services;
using asERP.Client.Features.Feeds.Views;

namespace asERP.Client.Features.Feeds;

/// <summary>
/// Module registration for the Feeds feature (product feeds: Google Products / Idealo / Pinterest).
/// </summary>
public static class FeedsModule
{
    /// <summary>
    /// Registers Feeds services with the DI container.
    /// </summary>
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        // FeedService: Transient - stateless, creates a new instance per request.
        services.AddTransient<IFeedService, FeedService>();

        // Page models
        services.AddTransient<FeedListModel>();
        services.AddTransient<FeedDetailModel>();
        services.AddTransient<FeedEditModel>();

        return services;
    }

    /// <summary>
    /// Registers Feeds views with the view registry.
    /// </summary>
    public static void RegisterViews(IViewRegistry views)
    {
        views.Register(
            new ViewMap<FeedListPage, FeedListModel>(),
            new ViewMap<FeedDetailPage, FeedDetailModel>(Data: new DataMap<FeedDetailData>()),
            new ViewMap<FeedEditPage, FeedEditModel>(Data: new DataMap<FeedEditData>())
        );
    }

    /// <summary>
    /// Gets the routes for the Feeds feature.
    /// </summary>
    public static IEnumerable<RouteMap> GetRoutes(IViewRegistry views)
    {
        yield return new RouteMap(Routes.FeedList, View: views.FindByViewModel<FeedListModel>());
        yield return new RouteMap(Routes.FeedDetail, View: views.FindByViewModel<FeedDetailModel>());
        yield return new RouteMap(Routes.FeedEdit, View: views.FindByViewModel<FeedEditModel>());
    }
}
