using asERP.Domain.Enums;

namespace asERP.Application.Feeds.Rendering;

/// <summary>
/// Renders a feed's products into a concrete platform format (XML/CSV). One implementation per
/// <see cref="FeedTemplate"/>; resolved via <see cref="IFeedRendererResolver"/>. A future custom-template
/// renderer plugs in here without touching the pipeline.
/// </summary>
public interface IFeedRenderer
{
    FeedTemplate Template { get; }

    /// <summary>HTTP Content-Type for the rendered output (incl. charset).</summary>
    string ContentType { get; }

    /// <summary>File extension without the dot (e.g. "xml", "csv").</summary>
    string FileNameSuffix { get; }

    Task<byte[]> RenderAsync(FeedRenderContext context, CancellationToken cancellationToken = default);
}
