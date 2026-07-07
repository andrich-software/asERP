using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedDetail;

public class FeedDetailQuery : IRequest<Result<FeedDetailDto>>
{
    public Guid Id { get; set; }
}
