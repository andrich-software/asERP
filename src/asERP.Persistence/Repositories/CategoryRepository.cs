using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<bool> HasChildrenAsync(Guid id)
    {
        return await Context.Category.AnyAsync(c => c.ParentCategoryId == id);
    }

    public async Task<List<CategorySalesChannel>> GetChannelLinksAsync(Guid categoryId)
    {
        return await Context.CategorySalesChannel
            .Where(l => l.CategoryId == categoryId)
            .Include(l => l.SalesChannel)
            .ToListAsync();
    }

    public async Task DeleteWithDependentsAsync(Guid id)
    {
        var existing = await Context.Category.IgnoreQueryFilters()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (existing == null)
        {
            throw new InvalidOperationException($"Entity with ID {id} not found for deletion");
        }

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue && existing.TenantId != null && existing.TenantId != currentTenantId)
        {
            throw new UnauthorizedAccessException("Cannot delete entity from different tenant");
        }

        var productLinks = await Context.ProductCategory
            .Where(pc => pc.CategoryId == existing.Id)
            .ToListAsync();
        var channelLinks = await Context.CategorySalesChannel
            .Where(cs => cs.CategoryId == existing.Id)
            .ToListAsync();

        Context.ProductCategory.RemoveRange(productLinks);
        Context.CategorySalesChannel.RemoveRange(channelLinks);
        Context.Category.Remove(existing);
        await Context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<CategorySalesChannel>> ApplyChannelActivationAsync(
        IReadOnlyList<CategoryChannelActivationChange> changes,
        CancellationToken cancellationToken = default)
    {
        if (changes.Count == 0)
        {
            return [];
        }

        // Last write wins per (category, channel) cell; cells outside the tenant's data are ignored.
        var desired = changes
            .GroupBy(c => (c.CategoryId, c.SalesChannelId))
            .ToDictionary(g => g.Key, g => g.Last().IsActive);

        var categoryIds = desired.Keys.Select(k => k.CategoryId).Distinct().ToList();
        var channelIds = desired.Keys.Select(k => k.SalesChannelId).Distinct().ToList();

        var validCategoryIds = (await Context.Category
                .Where(c => categoryIds.Contains(c.Id))
                .Select(c => c.Id)
                .ToListAsync(cancellationToken))
            .ToHashSet();
        var validChannelIds = (await Context.SalesChannel
                .Where(s => channelIds.Contains(s.Id))
                .Select(s => s.Id)
                .ToListAsync(cancellationToken))
            .ToHashSet();

        var existingRows = (await Context.CategorySalesChannel
                .Where(l => categoryIds.Contains(l.CategoryId) && channelIds.Contains(l.SalesChannelId))
                .ToListAsync(cancellationToken))
            .ToDictionary(l => (l.CategoryId, l.SalesChannelId));

        var effective = new List<CategorySalesChannel>();

        foreach (var ((categoryId, channelId), isActive) in desired)
        {
            if (!validCategoryIds.Contains(categoryId) || !validChannelIds.Contains(channelId))
            {
                continue;
            }

            if (existingRows.TryGetValue((categoryId, channelId), out var row))
            {
                if (row.IsActive == isActive)
                {
                    continue;
                }

                row.IsActive = isActive;
                effective.Add(row);
            }
            else
            {
                if (!isActive)
                {
                    // No row means inactive already — nothing to persist or export.
                    continue;
                }

                var created = new CategorySalesChannel
                {
                    CategoryId = categoryId,
                    SalesChannelId = channelId,
                    IsActive = true
                };
                Context.CategorySalesChannel.Add(created);
                effective.Add(created);
            }
        }

        await Context.SaveChangesAsync(cancellationToken);
        return effective;
    }

    public override async Task<bool> IsUniqueAsync(Category entity, Guid? id = null)
    {
        var currentTenantId = TenantContext.GetCurrentTenantId();

        var query = Context.Category.AsQueryable();

        if (currentTenantId.HasValue)
        {
            query = query.Where(c => c.TenantId == currentTenantId.Value);
        }

        query = query.Where(c => c.Name == entity.Name && c.ParentCategoryId == entity.ParentCategoryId);

        if (id.HasValue)
        {
            query = query.Where(c => c.Id != id.Value);
        }

        var exists = await query.AnyAsync();
        return !exists;
    }
}
