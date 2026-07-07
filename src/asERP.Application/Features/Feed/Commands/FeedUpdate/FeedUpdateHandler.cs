using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedUpdate;

public class FeedUpdateHandler : IRequestHandler<FeedUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<FeedUpdateHandler> _logger;
    private readonly IFeedRepository _feedRepository;
    private readonly ISalesChannelRepository _salesChannelRepository;

    public FeedUpdateHandler(
        IAppLogger<FeedUpdateHandler> logger,
        IFeedRepository feedRepository,
        ISalesChannelRepository salesChannelRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _feedRepository = feedRepository ?? throw new ArgumentNullException(nameof(feedRepository));
        _salesChannelRepository = salesChannelRepository ?? throw new ArgumentNullException(nameof(salesChannelRepository));
    }

    public async Task<Result<Guid>> Handle(FeedUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating feed with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        var validator = new FeedUpdateValidator(_salesChannelRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
            return result;
        }

        try
        {
            Domain.Entities.Feed existing;
            try
            {
                existing = await _feedRepository.GetDetails(request.Id);
            }
            catch (NotFoundException)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Feed with ID {request.Id} not found");
                return result;
            }

            existing.Name = request.Name;
            existing.Template = request.Template;
            existing.Currency = string.IsNullOrWhiteSpace(request.Currency) ? "EUR" : request.Currency.Trim().ToUpperInvariant();
            existing.SalesChannelId = request.SalesChannelId;
            existing.IsEnabled = request.IsEnabled;
            existing.DefaultDeliveryTime = request.DefaultDeliveryTime;
            existing.DefaultShippingCost = request.DefaultShippingCost;

            await _feedRepository.UpdateAsync(existing);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = existing.Id;

            _logger.LogInformation("Successfully updated feed with ID: {Id}", existing.Id);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while updating the feed.",
                "Error updating feed {Id}.", request.Id);
        }

        return result;
    }
}
