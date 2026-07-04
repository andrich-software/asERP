using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class ProductAttributeRepository : GenericRepository<ProductAttribute>, IProductAttributeRepository
{
    public ProductAttributeRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<ProductAttribute?> GetWithValuesAsync(Guid id)
    {
        var query = Context.ProductAttribute.Where(a => a.Id == id);

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return await query
            .Include(a => a.Values.OrderBy(v => v.SortOrder).ThenBy(v => v.Value))
            .FirstOrDefaultAsync();
    }

    public async Task<ProductAttribute?> GetByNameAsync(string name)
    {
        var query = Context.ProductAttribute.Where(a => a.Name == name);

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }

        return await query
            .Include(a => a.Values)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> IsInUseAsync(Guid id)
    {
        var usedAsAxis = await Context.ProductVariantAxis.AnyAsync(a => a.ProductAttributeId == id);
        if (usedAsAxis)
        {
            return true;
        }

        return await Context.ProductVariantOption
            .AnyAsync(o => o.ProductAttributeValue!.ProductAttributeId == id);
    }

    public async Task<bool> IsValueInUseAsync(Guid valueId)
    {
        return await Context.ProductVariantOption.AnyAsync(o => o.ProductAttributeValueId == valueId);
    }

    public void AddValue(ProductAttributeValue value)
    {
        Context.ProductAttributeValue.Add(value);
    }

    public void RemoveValue(ProductAttributeValue value)
    {
        Context.ProductAttributeValue.Remove(value);
    }

    public async Task DeleteWithValuesAsync(ProductAttribute attribute)
    {
        var existing = await Context.ProductAttribute.IgnoreQueryFilters()
            .FirstOrDefaultAsync(a => a.Id == attribute.Id);

        if (existing == null)
        {
            throw new InvalidOperationException($"Entity with ID {attribute.Id} not found for deletion");
        }

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue && existing.TenantId != null && existing.TenantId != currentTenantId)
        {
            throw new UnauthorizedAccessException("Cannot delete entity from different tenant");
        }

        var values = await Context.ProductAttributeValue
            .Where(v => v.ProductAttributeId == existing.Id)
            .ToListAsync();

        Context.ProductAttributeValue.RemoveRange(values);
        Context.ProductAttribute.Remove(existing);
        await Context.SaveChangesAsync();
    }

    public override async Task<bool> IsUniqueAsync(ProductAttribute entity, Guid? id = null)
    {
        var currentTenantId = TenantContext.GetCurrentTenantId();

        var query = Context.ProductAttribute.AsQueryable();

        if (currentTenantId.HasValue)
        {
            query = query.Where(a => a.TenantId == currentTenantId.Value);
        }

        query = query.Where(a => a.Name == entity.Name);

        if (id.HasValue)
        {
            query = query.Where(a => a.Id != id.Value);
        }

        var exists = await query.AnyAsync();
        return !exists;
    }
}
