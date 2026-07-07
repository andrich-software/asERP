using asERP.Application.Contracts.Persistence;

namespace asERP.Application.Features.Feed.Commands.FeedCreate;

public class FeedCreateValidator : FeedInputValidator<FeedCreateCommand>
{
    public FeedCreateValidator(ISalesChannelRepository salesChannelRepository)
        : base(salesChannelRepository)
    {
    }
}
