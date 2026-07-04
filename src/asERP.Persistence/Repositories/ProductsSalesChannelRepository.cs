using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class ProductSalesChannelRepository : GenericRepository<ProductSalesChannel>, IProductSalesChannelRepository
{
    public ProductSalesChannelRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<ProductSalesChannel?> GetByRemoteProductIdAsync(string remoteProductId, Guid salesChannelId = default)
    {
        var query = Context.ProductSalesChannel
            .Where(p => p.RemoteProductId == remoteProductId);

        if (salesChannelId != default)
        {
            query = query.Where(p => p.SalesChannelId == salesChannelId);
        }

        return await query.FirstOrDefaultAsync();
    }
}