using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedProductSelectionUpdate;

public class FeedProductSelectionUpdateHandler : IRequestHandler<FeedProductSelectionUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<FeedProductSelectionUpdateHandler> _logger;
    private readonly IFeedRepository _feedRepository;

    public FeedProductSelectionUpdateHandler(IAppLogger<FeedProductSelectionUpdateHandler> logger, IFeedRepository feedRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _feedRepository = feedRepository ?? throw new ArgumentNullException(nameof(feedRepository));
    }

    public async Task<Result<Guid>> Handle(FeedProductSelectionUpdateCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<Guid>();

        // Existence + tenant ownership check (GetByIdAsync is tenant-filtered).
        var feed = await _feedRepository.GetByIdAsync(request.FeedId, asNoTracking: true);
        if (feed == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Feed.NotFound, $"Feed with ID {request.FeedId} not found");
            return result;
        }

        await _feedRepository.ApplyProductSelectionAsync(request.FeedId, request.Changes, cancellationToken);

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = request.FeedId;

        return result;
    }
}
