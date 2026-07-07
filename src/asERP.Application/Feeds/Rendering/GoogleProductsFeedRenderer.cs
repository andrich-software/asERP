using asERP.Domain.Enums;

namespace asERP.Application.Feeds.Rendering;

/// <summary>Google Merchant Center RSS 2.0 feed.</summary>
public class GoogleProductsFeedRenderer : RssProductFeedRenderer
{
    public override FeedTemplate Template => FeedTemplate.GoogleProducts;
}
