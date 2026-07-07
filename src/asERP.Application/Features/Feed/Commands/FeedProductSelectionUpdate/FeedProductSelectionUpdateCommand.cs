using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedProductSelectionUpdate;

/// <summary>
/// Applies a batch of product inclusion changes to a feed. Only changed rows are sent.
/// </summary>
public class FeedProductSelectionUpdateCommand : IRequest<Result<Guid>>
{
    public Guid FeedId { get; set; }
    public List<FeedProductSelectionChange> Changes { get; set; } = new();
}
