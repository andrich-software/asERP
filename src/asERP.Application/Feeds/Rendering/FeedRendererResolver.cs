using asERP.Domain.Enums;

namespace asERP.Application.Feeds.Rendering;

public class FeedRendererResolver : IFeedRendererResolver
{
    private readonly IReadOnlyDictionary<FeedTemplate, IFeedRenderer> _byTemplate;

    public FeedRendererResolver(IEnumerable<IFeedRenderer> renderers)
    {
        _byTemplate = renderers.ToDictionary(r => r.Template);
    }

    public IFeedRenderer Resolve(FeedTemplate template)
    {
        if (_byTemplate.TryGetValue(template, out var renderer))
        {
            return renderer;
        }

        throw new NotSupportedException($"No feed renderer is registered for template '{template}'.");
    }
}
