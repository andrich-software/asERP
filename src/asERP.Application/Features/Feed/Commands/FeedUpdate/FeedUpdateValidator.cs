using asERP.Application.Contracts.Persistence;

namespace asERP.Application.Features.Feed.Commands.FeedUpdate;

public class FeedUpdateValidator : FeedInputValidator<FeedUpdateCommand>
{
    public FeedUpdateValidator(ISalesChannelRepository salesChannelRepository)
        : base(salesChannelRepository)
    {
    }
}
