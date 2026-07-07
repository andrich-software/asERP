using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class FeedRepository : GenericRepository<Feed>, IFeedRepository
{
    public FeedRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<Feed> GetDetails(Guid id)
    {
        // Tenant isolation via the global query filter. Tracked so the update handler can mutate it.
        var feed = await Context.Feed
            .Include(f => f.SalesChannel)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (feed == null)
        {
            throw new NotFoundException("Feed not found", id);
        }

        return feed;
    }

    public async Task<Feed?> GetPublicByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        // Anonymous, cross-tenant resolution for the public endpoint: bypass the tenant query filter.
        return await Context.Feed
            .IgnoreQueryFilters()
            .Include(f => f.SalesChannel)
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
    }

    public async Task<DateTime?> GetLastAccessedAtAsync(Guid feedId, CancellationToken cancellationToken = default)
    {
        return await Context.FeedLog
            .Where(l => l.FeedId == feedId)
            .OrderByDescending(l => l.DateCreated)
            .Select(l => (DateTime?)l.DateCreated)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<int> GetIncludedProductCountAsync(Guid feedId, CancellationToken cancellationToken = default)
    {
        // Every product is included unless an exclusion row (IsActive == false) exists for it.
        var total = await Context.Product.CountAsync(cancellationToken);
        var excluded = await Context.FeedProduct.CountAsync(fp => fp.FeedId == feedId && !fp.IsActive, cancellationToken);
        return total - excluded;
    }

    public async Task ApplyProductSelectionAsync(Guid feedId, IReadOnlyList<FeedProductSelectionChange> changes, CancellationToken cancellationToken = default)
    {
        if (changes.Count == 0)
        {
            return;
        }

        // Last write wins per product; ignore products outside the tenant catalog.
        var desired = changes
            .GroupBy(c => c.ProductId)
            .ToDictionary(g => g.Key, g => g.Last().IsActive);

        var ids = desired.Keys.ToList();

        var validIds = (await Context.Product
                .Where(p => ids.Contains(p.Id))
                .Select(p => p.Id)
                .ToListAsync(cancellationToken))
            .ToHashSet();

        var existingByProduct = (await Context.FeedProduct
                .Where(fp => fp.FeedId == feedId && ids.Contains(fp.ProductId))
                .ToListAsync(cancellationToken))
            .ToDictionary(fp => fp.ProductId);

        foreach (var (productId, isActive) in desired)
        {
            if (!validIds.Contains(productId))
            {
                continue;
            }

            if (existingByProduct.TryGetValue(productId, out var row))
            {
                row.IsActive = isActive;
            }
            else
            {
                Context.FeedProduct.Add(new FeedProduct
                {
                    FeedId = feedId,
                    ProductId = productId,
                    IsActive = isActive
                });
            }
        }

        await Context.SaveChangesAsync(cancellationToken);
    }

    public override async Task DeleteAsync(Feed entity)
    {
        // Cascade is declared in the EF config too, but the project rule is to delete children
        // explicitly rather than rely on provider cascade behavior.
        var existing = await Context.Feed
            .IgnoreQueryFilters()
            .Include(f => f.FeedProducts)
            .Include(f => f.FeedLogs)
            .FirstOrDefaultAsync(f => f.Id == entity.Id);

        if (existing == null)
        {
            throw new InvalidOperationException($"Feed with ID {entity.Id} not found for deletion");
        }

        var currentTenantId = TenantContext.GetCurrentTenantId();
        EnsureDeletableByCurrentTenant(existing.TenantId, currentTenantId);

        Context.FeedProduct.RemoveRange(existing.FeedProducts);
        Context.FeedLog.RemoveRange(existing.FeedLogs);
        Context.Remove(existing);
        await Context.SaveChangesAsync();
    }
}
