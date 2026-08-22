using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Services;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.ShopDomain.Commands.ShopDomainCreate;

public class ShopDomainCreateHandler : IRequestHandler<ShopDomainCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<ShopDomainCreateHandler> _logger;
    private readonly IShopDomainRepository _shopDomainRepository;
    private readonly ISalesChannelRepository _salesChannelRepository;
    private readonly IMediator _mediator;

    public ShopDomainCreateHandler(
        IAppLogger<ShopDomainCreateHandler> logger,
        IShopDomainRepository shopDomainRepository,
        ISalesChannelRepository salesChannelRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shopDomainRepository = shopDomainRepository ?? throw new ArgumentNullException(nameof(shopDomainRepository));
        _salesChannelRepository = salesChannelRepository ?? throw new ArgumentNullException(nameof(salesChannelRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(ShopDomainCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating shop domain {Host} for sales channel {SalesChannelId}",
            request.Host, request.SalesChannelId);

        var result = new Result<Guid>();

        var validator = new ShopDomainCreateValidator(_salesChannelRepository, _shopDomainRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(ShopDomainCreateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Validator guarantees the host is normalizable.
            ShopHostNormalizer.TryNormalize(request.Host, out var normalizedHost);

            var siblings = await _shopDomainRepository.Entities
                .Where(d => d.SalesChannelId == request.SalesChannelId)
                .ToListAsync(cancellationToken);

            // Exactly one primary per channel: the first binding always becomes primary; an
            // explicit primary request demotes the current one.
            var makePrimary = request.IsPrimary || !siblings.Any(s => s.IsPrimary);
            if (request.IsPrimary)
            {
                foreach (var sibling in siblings.Where(s => s.IsPrimary))
                {
                    sibling.IsPrimary = false;
                    await _shopDomainRepository.UpdateAsync(sibling);
                }
            }

            var shopDomainToCreate = new Domain.Entities.ShopDomain
            {
                SalesChannelId = request.SalesChannelId,
                Host = normalizedHost,
                Port = request.Port,
                IsPrimary = makePrimary,
                RedirectToPrimary = request.RedirectToPrimary
            };

            await _shopDomainRepository.CreateAsync(shopDomainToCreate);

            // Let the storefront host resolver drop its cached host map immediately.
            await _mediator.Publish(
                new ShopDomainChangedNotification(request.SalesChannelId, shopDomainToCreate.TenantId),
                cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = shopDomainToCreate.Id;

            _logger.LogInformation("Successfully created shop domain with ID: {Id}", shopDomainToCreate.Id);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while creating the shop domain.",
                "Error creating shop domain {Host}.", request.Host);
        }

        return result;
    }
}
