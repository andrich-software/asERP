using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShopDomain;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.ShopDomain.Queries.ShopDomainList;

public class ShopDomainListHandler : IRequestHandler<ShopDomainListQuery, Result<List<ShopDomainListDto>>>
{
    private readonly IAppLogger<ShopDomainListHandler> _logger;
    private readonly IShopDomainRepository _shopDomainRepository;

    public ShopDomainListHandler(
        IAppLogger<ShopDomainListHandler> logger,
        IShopDomainRepository shopDomainRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shopDomainRepository = shopDomainRepository ?? throw new ArgumentNullException(nameof(shopDomainRepository));
    }

    public async Task<Result<List<ShopDomainListDto>>> Handle(ShopDomainListQuery request, CancellationToken cancellationToken)
    {
        var result = new Result<List<ShopDomainListDto>>();

        try
        {
            // Tenant isolation via the global query filter.
            var shopDomains = await _shopDomainRepository.Entities
                .Where(d => d.SalesChannelId == request.SalesChannelId)
                .OrderByDescending(d => d.IsPrimary)
                .ThenBy(d => d.Host)
                .ThenBy(d => d.Port)
                .Select(d => new ShopDomainListDto
                {
                    Id = d.Id,
                    SalesChannelId = d.SalesChannelId,
                    Host = d.Host,
                    Port = d.Port,
                    IsPrimary = d.IsPrimary,
                    RedirectToPrimary = d.RedirectToPrimary
                })
                .ToListAsync(cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = shopDomains;
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while listing shop domains.",
                "Error listing shop domains for sales channel {SalesChannelId}.", request.SalesChannelId);
        }

        return result;
    }
}
