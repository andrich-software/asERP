using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannel.Commands.SalesChannelDelete;

public class SalesChannelDeleteHandler : IRequestHandler<SalesChannelDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<SalesChannelDeleteHandler> _logger;
    private readonly ISalesChannelRepository _salesChannelRepository;
    private readonly IWebAnalyticsPurgeService _webAnalyticsPurgeService;
    private readonly IMediator _mediator;

    public SalesChannelDeleteHandler(
        IAppLogger<SalesChannelDeleteHandler> logger,
        ISalesChannelRepository salesChannelRepository,
        IWebAnalyticsPurgeService webAnalyticsPurgeService,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesChannelRepository = salesChannelRepository ?? throw new ArgumentNullException(nameof(salesChannelRepository));
        _webAnalyticsPurgeService = webAnalyticsPurgeService ?? throw new ArgumentNullException(nameof(webAnalyticsPurgeService));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(SalesChannelDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting sales channel with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new SalesChannelDeleteValidator(_salesChannelRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in delete request for {0}: {1}",
                nameof(SalesChannelDeleteCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Get entity from database first
            var salesChannel = await _salesChannelRepository.GetByIdAsync(request.Id);

            if (salesChannel == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"SalesChannel with ID {request.Id} not found");
                _logger.LogWarning("Sales channel {Id} not found", request.Id);
                return result;
            }

            // The repository removes the channel together with everything that is worthless without
            // it, in one transaction (repo rule: explicit cascade, never EF cascade defaults).
            var summary = await _salesChannelRepository.DeleteWithDependentsAsync(salesChannel.Id);

            if (summary.ShopDomains > 0)
            {
                // Let the storefront host resolver drop its cached host map immediately.
                await _mediator.Publish(
                    new ShopDomainChangedNotification(salesChannel.Id, summary.TenantId),
                    cancellationToken);
            }

            // Analytics lives outside the ERP database and has no foreign key to it — best effort,
            // never fails the delete.
            await _webAnalyticsPurgeService.PurgeSalesChannelAsync(salesChannel.Id, cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.NoContent;
            result.Data = salesChannel.Id;

            _logger.LogInformation(
                "Successfully deleted sales channel with ID: {Id} (removed {ShopDomains} shop domains, "
                + "{CategoryLinks} category links, {CustomerLinks} customer links, {ProductLinks} product links, "
                + "{OAuthStates} OAuth states, {SyncRows} sync/outbox rows; detached {Images} product images "
                + "and {Feeds} feeds)",
                salesChannel.Id, summary.ShopDomains, summary.CategoryLinks, summary.CustomerLinks,
                summary.ProductLinks, summary.OAuthStates, summary.SyncRows,
                summary.DetachedProductImages, summary.DetachedFeeds);
        }
        catch (asERP.Application.Exceptions.NotFoundException)
        {
            // Sales channel not found
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.NotFound;
            result.Messages.Add($"SalesChannel with ID {request.Id} not found");
            _logger.LogWarning("Sales channel {Id} not found", request.Id);
        }
        catch (Exception ex) when (ex.Message.Contains("does not exist") || ex.Message.Contains("not found"))
        {
            // Handle race condition: Entity was deleted between check and delete
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.NotFound;
            result.Messages.Add($"SalesChannel with ID {request.Id} not found");
            _logger.LogWarning("Sales channel {Id} was deleted by concurrent operation: {ExceptionType} - {Message}", request.Id, ex.GetType().Name, ex.Message);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while deleting the sales channel.",
                "Error deleting sales channel {Id}.", request.Id);
        }

        return result;
    }
}
