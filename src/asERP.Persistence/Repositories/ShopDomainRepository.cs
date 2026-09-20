using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Dtos.Shop;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class ShopDomainRepository : GenericRepository<ShopDomain>, IShopDomainRepository
{
    public ShopDomainRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<List<ShopHostBindingRef>> GetActiveBindingsAsync(CancellationToken cancellationToken = default)
    {
        // Anonymous, cross-tenant lookup for the storefront hot path: bypass the tenant query filter.
        var rows = await Context.ShopDomain
            .IgnoreQueryFilters()
            .AsNoTracking()
            .Where(d => d.TenantId != null
                        && d.SalesChannel!.Type == SalesChannelType.AsShop
                        && d.SalesChannel.IsEnabled)
            .Select(d => new
            {
                d.SalesChannelId,
                TenantId = d.TenantId!.Value,
                d.Host,
                d.Port,
                d.IsPrimary,
                d.RedirectToPrimary,
                d.SalesChannel!.TrackingEnabled
            })
            .ToListAsync(cancellationToken);

        // Resolve each channel's primary host in memory (bindings per channel are a handful of rows).
        // Fallback when no row is flagged primary: the first host, so redirects always have a target.
        var primaryHostByChannel = rows
            .GroupBy(r => r.SalesChannelId)
            .ToDictionary(
                g => g.Key,
                g => (g.FirstOrDefault(r => r.IsPrimary) ?? g.First()).Host);

        return rows
            .Select(r => new ShopHostBindingRef
            {
                SalesChannelId = r.SalesChannelId,
                TenantId = r.TenantId,
                Host = r.Host,
                Port = r.Port,
                IsPrimary = r.IsPrimary,
                RedirectToPrimary = r.RedirectToPrimary,
                TrackingEnabled = r.TrackingEnabled,
                PrimaryHost = primaryHostByChannel[r.SalesChannelId]
            })
            .ToList();
    }

    public async Task<bool> HostIsUniqueAsync(string host, int port, Guid salesChannelId, Guid? id = null)
    {
        // Cross-tenant on purpose: the host is the security boundary that maps an anonymous request
        // to a tenant, and ShopHostResolver matches an exact-port row before falling back to the
        // port-0 row of the same host. A foreign channel owning ANY row for this host — whatever the
        // port — could therefore shadow it, so the whole host is claimed, not just the (Host, Port)
        // pair. Extra ports stay allowed inside the owning channel; the unique (Host, Port) index
        // remains the backstop for the exact pair.
        return !await Context.ShopDomain
            .IgnoreQueryFilters()
            .AnyAsync(d => d.Host == host
                           && (id == null || d.Id != id)
                           && (d.Port == port || d.SalesChannelId != salesChannelId));
    }
}
