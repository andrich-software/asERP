using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedDetail;

public class FeedDetailHandler : IRequestHandler<FeedDetailQuery, Result<FeedDetailDto>>
{
    private readonly IAppLogger<FeedDetailHandler> _logger;
    private readonly IFeedRepository _feedRepository;

    public FeedDetailHandler(IAppLogger<FeedDetailHandler> logger, IFeedRepository feedRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _feedRepository = feedRepository ?? throw new ArgumentNullException(nameof(feedRepository));
    }

    public async Task<Result<FeedDetailDto>> Handle(FeedDetailQuery request, CancellationToken cancellationToken)
    {
        var result = new Result<FeedDetailDto>();

        try
        {
            var feed = await _feedRepository.GetDetails(request.Id);

            var data = new FeedDetailDto
            {
                Id = feed.Id,
                Name = feed.Name,
                Template = feed.Template,
                Currency = feed.Currency,
                IsEnabled = feed.IsEnabled,
                SalesChannelId = feed.SalesChannelId,
                SalesChannelName = feed.SalesChannel?.Name,
                DefaultDeliveryTime = feed.DefaultDeliveryTime,
                DefaultShippingCost = feed.DefaultShippingCost,
                LastAccessedAt = await _feedRepository.GetLastAccessedAtAsync(feed.Id, cancellationToken),
                ProductCount = await _feedRepository.GetIncludedProductCountAsync(feed.Id, cancellationToken),
                DateCreated = feed.DateCreated,
                DateModified = feed.DateModified,
                // PublicUrl is filled in by the controller from the request host.
            };

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = data;
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
                "An error occurred while retrieving the feed.",
                "Error retrieving feed {Id}.", request.Id);
        }

        return result;
    }
}
