using asERP.Domain.Enums;

namespace asERP.Application.Feeds.Rendering;

/// <summary>
/// Pinterest catalog feed. Pinterest ingests the Google RSS 2.0 specification, so it reuses the shared
/// <see cref="RssProductFeedRenderer"/> output.
/// </summary>
public class PinterestFeedRenderer : RssProductFeedRenderer
{
    public override FeedTemplate Template => FeedTemplate.Pinterest;
}
