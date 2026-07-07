using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Extensions;
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

        var result = new Result<Guid>();

        try
        {
            var feed = await _feedRepository.GetByIdAsync(request.Id);
            if (feed == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Feed with ID {request.Id} not found");
                return result;
            }

            // Repository removes the feed's FeedProduct/FeedLog children explicitly.
            await _feedRepository.DeleteAsync(feed);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.NoContent;
            result.Data = feed.Id;

            _logger.LogInformation("Successfully deleted feed with ID: {Id}", feed.Id);
        }
        catch (NotFoundException)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.NotFound;
            result.Messages.Add($"Feed with ID {request.Id} not found");
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while deleting the feed.",
                "Error deleting feed {Id}.", request.Id);
        }

        return result;
    }
}
