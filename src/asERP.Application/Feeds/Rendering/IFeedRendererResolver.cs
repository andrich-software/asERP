using asERP.Domain.Enums;

namespace asERP.Application.Feeds.Rendering;

public interface IFeedRendererResolver
{
    /// <summary>Returns the renderer for a template, or throws NotSupportedException if none is registered.</summary>
    IFeedRenderer Resolve(FeedTemplate template);
}
