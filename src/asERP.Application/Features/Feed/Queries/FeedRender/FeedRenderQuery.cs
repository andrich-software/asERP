using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedRender;

/// <summary>
/// Renders a feed to bytes for the public endpoint. The caller resolves the feed and sets the tenant
/// context first; <see cref="PublicBaseUrl"/> is the request's absolute "scheme://host" used to build
/// image and feed URLs.
/// </summary>
public class FeedRenderQuery : IRequest<Result<FeedRenderResult>>
{
    public Guid FeedId { get; set; }
    public string PublicBaseUrl { get; set; }

    public FeedRenderQuery(Guid feedId, string publicBaseUrl)
    {
        FeedId = feedId;
        PublicBaseUrl = publicBaseUrl;
    }
}
