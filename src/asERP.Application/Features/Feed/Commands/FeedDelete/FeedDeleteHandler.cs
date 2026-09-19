using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedDelete;

public class FeedDeleteHandler : IRequestHandler<FeedDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<FeedDeleteHandler> _logger;
    private readonly IFeedRepository _feedRepository;

    public FeedDeleteHandler(IAppLogger<FeedDeleteHandler> logger, IFeedRepository feedRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _feedRepository = feedRepository ?? throw new ArgumentNullException(nameof(feedRepository));
    }

    public async Task<Result<Guid>> Handle(FeedDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting feed with ID: {Id}", request.Id);

        try
        {
            var feed = await _feedRepository.GetByIdAsync(request.Id);
            if (feed == null)
            {
                return Result<Guid>.NotFound(ErrorCodes.Feed.NotFound, $"Feed with ID {request.Id} not found");
            }

            // Repository removes the feed's FeedProduct/FeedLog children explicitly.
            await _feedRepository.DeleteAsync(feed);

            _logger.LogInformation("Successfully deleted feed with ID: {Id}", feed.Id);
            return Result<Guid>.NoContent(feed.Id);
        }
        catch (NotFoundException)
        {
            return Result<Guid>.NotFound(ErrorCodes.Feed.NotFound, $"Feed with ID {request.Id} not found");
        }

    }
}
