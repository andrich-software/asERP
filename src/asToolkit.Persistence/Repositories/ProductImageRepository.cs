using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Persistence.Repositories;

public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
{
    public ProductImageRepository(ApplicationDbContext context, ITenantContext tenantContext)
        : base(context, tenantContext)
    {
    }

    public async Task<List<ProductImage>> GetByProductIdAsync(Guid productId)
    {
        var query = Context.ProductImage.Where(i => i.ProductId == productId);

        // Apply manual tenant filtering, mirroring ProductRepository.
        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return await query.OrderBy(i => i.SortOrder).ToListAsync();
    }

    public async Task<int> GetMaxSortOrderAsync(Guid productId)
    {
        var query = Context.ProductImage.Where(i => i.ProductId == productId);

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        // Max over an empty set throws for int; project to int? and coalesce.
        return await query.MaxAsync(i => (int?)i.SortOrder) ?? -1;
    }
}
