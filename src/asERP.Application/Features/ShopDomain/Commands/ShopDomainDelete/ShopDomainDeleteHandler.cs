using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.ShopDomain.Commands.ShopDomainDelete;

public class ShopDomainDeleteHandler : IRequestHandler<ShopDomainDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<ShopDomainDeleteHandler> _logger;
    private readonly IShopDomainRepository _shopDomainRepository;
    private readonly IMediator _mediator;

    public ShopDomainDeleteHandler(
        IAppLogger<ShopDomainDeleteHandler> logger,
        IShopDomainRepository shopDomainRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shopDomainRepository = shopDomainRepository ?? throw new ArgumentNullException(nameof(shopDomainRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(ShopDomainDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting shop domain with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        var validator = new ShopDomainDeleteValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in delete request for {0}: {1}",
                nameof(ShopDomainDeleteCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            var shopDomain = await _shopDomainRepository.GetByIdAsync(request.Id);
            if (shopDomain == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Shop domain with ID {request.Id} not found");
                return result;
            }

            await _shopDomainRepository.DeleteAsync(shopDomain);

            // Exactly one primary per channel: deleting the primary promotes the first remaining
            // binding so redirects always have a target.
            if (shopDomain.IsPrimary)
            {
                var successor = await _shopDomainRepository.Entities
                    .Where(d => d.SalesChannelId == shopDomain.SalesChannelId)
                    .OrderBy(d => d.Host).ThenBy(d => d.Port)
                    .FirstOrDefaultAsync(cancellationToken);

                if (successor != null)
                {
                    successor.IsPrimary = true;
                    await _shopDomainRepository.UpdateAsync(successor);
                }
            }

            // Let the storefront host resolver drop its cached host map immediately.
            await _mediator.Publish(
                new ShopDomainChangedNotification(shopDomain.SalesChannelId, shopDomain.TenantId),
                cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.NoContent;
            result.Data = shopDomain.Id;

            _logger.LogInformation("Successfully deleted shop domain with ID: {Id}", shopDomain.Id);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while deleting the shop domain.",
                "Error deleting shop domain {Id}.", request.Id);
        }

        return result;
    }
}
