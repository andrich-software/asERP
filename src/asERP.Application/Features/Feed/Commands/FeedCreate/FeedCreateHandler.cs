using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedCreate;

public class FeedCreateHandler : IRequestHandler<FeedCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<FeedCreateHandler> _logger;
    private readonly IFeedRepository _feedRepository;
    private readonly ISalesChannelRepository _salesChannelRepository;

    public FeedCreateHandler(
        IAppLogger<FeedCreateHandler> logger,
        IFeedRepository feedRepository,
        ISalesChannelRepository salesChannelRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _feedRepository = feedRepository ?? throw new ArgumentNullException(nameof(feedRepository));
        _salesChannelRepository = salesChannelRepository ?? throw new ArgumentNullException(nameof(salesChannelRepository));
    }

    public async Task<Result<Guid>> Handle(FeedCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new feed with name: {Name}", request.Name);

        var result = new Result<Guid>();

        var validator = new FeedCreateValidator(_salesChannelRepository);
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
            var feed = MapToEntity(request);
            await _feedRepository.CreateAsync(feed);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = feed.Id;

            _logger.LogInformation("Successfully created feed with ID: {Id}", feed.Id);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while creating the feed.",
                "Error creating feed {Name}.", request.Name);
        }

        return result;
    }

    private static Domain.Entities.Feed MapToEntity(FeedCreateCommand c) => new()
    {
        Name = c.Name,
        Template = c.Template,
        Currency = string.IsNullOrWhiteSpace(c.Currency) ? "EUR" : c.Currency.Trim().ToUpperInvariant(),
        SalesChannelId = c.SalesChannelId,
        IsEnabled = c.IsEnabled,
        DefaultDeliveryTime = c.DefaultDeliveryTime,
        DefaultShippingCost = c.DefaultShippingCost,
    };
}
