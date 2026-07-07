using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedLogCreate;

/// <summary>
/// Records an anonymous access to a feed. Sent from the public endpoint after the tenant context has been
/// set from the feed, so the log row is stamped with the feed's tenant.
/// </summary>
public class FeedLogCreateCommand : IRequest<Result<Guid>>
{
    public Guid FeedId { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
}
