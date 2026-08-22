using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Services;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.ShopDomain.Commands.ShopDomainUpdate;

public class ShopDomainUpdateHandler : IRequestHandler<ShopDomainUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<ShopDomainUpdateHandler> _logger;
    private readonly IShopDomainRepository _shopDomainRepository;
    private readonly IMediator _mediator;

    public ShopDomainUpdateHandler(
        IAppLogger<ShopDomainUpdateHandler> logger,
        IShopDomainRepository shopDomainRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shopDomainRepository = shopDomainRepository ?? throw new ArgumentNullException(nameof(shopDomainRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(ShopDomainUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating shop domain with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        var validator = new ShopDomainUpdateValidator(_shopDomainRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(ShopDomainUpdateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            var existingShopDomain = await _shopDomainRepository.GetByIdAsync(request.Id);
            if (existingShopDomain == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Shop domain with ID {request.Id} not found");
                return result;
            }

            // A binding never moves between channels — delete and recreate instead.
            if (existingShopDomain.SalesChannelId != request.SalesChannelId)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add("A shop domain cannot be moved to another sales channel.");
                return result;
            }

            // Validator guarantees the host is normalizable.
            ShopHostNormalizer.TryNormalize(request.Host, out var normalizedHost);

            var siblings = await _shopDomainRepository.Entities
                .Where(d => d.SalesChannelId == existingShopDomain.SalesChannelId && d.Id != existingShopDomain.Id)
                .ToListAsync(cancellationToken);

            // Exactly one primary per channel: unmarking the current primary directly would leave
            // the channel without a redirect target — the primary moves by marking another row.
            if (!request.IsPrimary && existingShopDomain.IsPrimary && siblings.Count > 0)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add("Mark another domain as primary instead of unmarking the current one.");
                return result;
            }

            if (request.IsPrimary && !existingShopDomain.IsPrimary)
            {
                foreach (var sibling in siblings.Where(s => s.IsPrimary))
                {
                    sibling.IsPrimary = false;
                    await _shopDomainRepository.UpdateAsync(sibling);
                }
            }

            existingShopDomain.Host = normalizedHost;
            existingShopDomain.Port = request.Port;
            // A channel's only binding stays primary regardless of the submitted flag.
            existingShopDomain.IsPrimary = request.IsPrimary || siblings.Count == 0;
            existingShopDomain.RedirectToPrimary = request.RedirectToPrimary;

            await _shopDomainRepository.UpdateAsync(existingShopDomain);

            // Let the storefront host resolver drop its cached host map immediately.
            await _mediator.Publish(
                new ShopDomainChangedNotification(existingShopDomain.SalesChannelId, existingShopDomain.TenantId),
                cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = existingShopDomain.Id;

            _logger.LogInformation("Successfully updated shop domain with ID: {Id}", existingShopDomain.Id);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while updating the shop domain.",
                "Error updating shop domain {Id}.", request.Id);
        }

        return result;
    }
}
