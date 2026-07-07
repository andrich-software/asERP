using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
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

        try
        {
            // Existence + tenant ownership check (GetByIdAsync is tenant-filtered).
            var feed = await _feedRepository.GetByIdAsync(request.FeedId, asNoTracking: true);
            if (feed == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Feed with ID {request.FeedId} not found");
                return result;
            }

            await _feedRepository.ApplyProductSelectionAsync(request.FeedId, request.Changes, cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = request.FeedId;
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while updating the feed product selection.",
                "Error updating product selection for feed {Id}.", request.FeedId);
        }

        return result;
    }
}
