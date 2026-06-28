using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Persistence.Repositories;

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