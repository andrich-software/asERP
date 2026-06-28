using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Entities;
using asToolkit.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {

    }

    public async Task<Product?> GetBySkuAsync(string sku)
    {
        // IgnoreQueryFilters so the global EF filter (whose closure may evaluate to a different
        // tenant at query time) cannot silently exclude a product that belongs to the current tenant.
        // Same pattern as GetByIdAsync in GenericRepository.
        var query = Context.Product.IgnoreQueryFilters().Where(p => p.Sku == sku);

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }
        else
        {
            query = query.Where(x => x.TenantId == null);
        }

        return await query.Include(ps => ps.ProductSalesChannels).FirstOrDefaultAsync();
    }

    public async Task<Product?> GetWithDetailsAsync(Guid id)
    {
        var query = Context.Product.IgnoreQueryFilters().Where(p => p.Id == id);

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }
        else
        {
            query = query.Where(x => x.TenantId == null);
        }

        return await query
            .Include(ps => ps.ProductSalesChannels)
            .Include(ps => ps.ProductStocks)
            .Include(ps => ps.Manufacturer)
            .Include(p => p.VariantAxes.OrderBy(a => a.SortOrder))
                .ThenInclude(a => a.ProductAttribute)
                    .ThenInclude(attr => attr!.Values)
            .Include(p => p.Variants.OrderBy(v => v.VariantSortOrder).ThenBy(v => v.Sku))
                .ThenInclude(v => v.VariantOptions)
                    .ThenInclude(o => o.ProductAttributeValue)
                        .ThenInclude(av => av!.ProductAttribute)
            .Include(p => p.VariantOptions)
                .ThenInclude(o => o.ProductAttributeValue)
                    .ThenInclude(av => av!.ProductAttribute)
            .Include(p => p.Images.OrderBy(i => i.SortOrder))
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<List<Product>> GetVariantsAsync(Guid parentProductId)
    {
        var query = Context.Product.IgnoreQueryFilters().Where(p => p.ParentProductId == parentProductId);

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue)
        {
            query = query.Where(x => x.TenantId == null || x.TenantId == currentTenantId.Value);
        }
        else
        {
            query = query.Where(x => x.TenantId == null);
        }

        return await query
            .Include(p => p.VariantOptions)
                .ThenInclude(o => o.ProductAttributeValue)
                    .ThenInclude(av => av!.ProductAttribute)
            .OrderBy(p => p.VariantSortOrder).ThenBy(p => p.Sku)
            .ToListAsync();
    }

    public async Task DeleteWithDependentsAsync(Product product)
    {
        // Verify existence and tenant ownership like GenericRepository.DeleteAsync does
        var existingProduct = await Context.Product.IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == product.Id);

        if (existingProduct == null)
        {
            throw new InvalidOperationException($"Entity with ID {product.Id} not found for deletion");
        }

        var currentTenantId = TenantContext.GetCurrentTenantId();
        if (currentTenantId.HasValue && existingProduct.TenantId != null && existingProduct.TenantId != currentTenantId)
        {
            throw new UnauthorizedAccessException("Cannot delete entity from different tenant");
        }

        // For variant parents: delete all child variants first
        var variantIds = await Context.Product
            .Where(p => p.ParentProductId == existingProduct.Id)
            .Select(p => p.Id)
            .ToListAsync();

        foreach (var variantId in variantIds)
        {
            await RemoveProductDependentsAsync(variantId);
            Context.Product.RemoveRange(Context.Product.Where(p => p.Id == variantId));
        }

        await RemoveProductDependentsAsync(existingProduct.Id);
        Context.Product.Remove(existingProduct);

        await Context.SaveChangesAsync();
    }

    public void AddVariantAxis(ProductVariantAxis axis) => Context.ProductVariantAxis.Add(axis);

    public void RemoveVariantAxis(ProductVariantAxis axis) => Context.ProductVariantAxis.Remove(axis);

    public void AddVariantOption(ProductVariantOption option) => Context.ProductVariantOption.Add(option);

    public void RemoveVariantOption(ProductVariantOption option) => Context.ProductVariantOption.Remove(option);

    private async Task RemoveProductDependentsAsync(Guid productId)
    {
        Context.ProductVariantOption.RemoveRange(
            await Context.ProductVariantOption.Where(o => o.ProductId == productId).ToListAsync());

        Context.ProductVariantAxis.RemoveRange(
            await Context.ProductVariantAxis.Where(a => a.ParentProductId == productId).ToListAsync());

        Context.ProductSalesChannel.RemoveRange(
            await Context.ProductSalesChannel.IgnoreQueryFilters().Where(psc => psc.ProductId == productId).ToListAsync());

        Context.ProductStock.RemoveRange(
            await Context.ProductStock.Where(ps => ps.ProductId == productId).ToListAsync());

        Context.ProductImage.RemoveRange(
            await Context.ProductImage.Where(pi => pi.ProductId == productId).ToListAsync());
    }

    public async Task<bool> UpdateStockAsync(Guid productId, Guid warehouseId, int newStock)
    {
        var productStock = await Context.ProductStock.FirstOrDefaultAsync(ps => ps.ProductId == productId && ps.WarehouseId == warehouseId);

        if (productStock == null)
        {
            return false;
        }

        productStock.Stock = newStock;
        await Context.SaveChangesAsync();

        return true;
    }

    public override async Task<bool> IsUniqueAsync(Product entity, Guid? id = null)
    {
        var currentTenantId = TenantContext.GetCurrentTenantId();

        var query = Context.Product.AsQueryable();

        // Add tenant isolation
        if (currentTenantId.HasValue)
        {
            query = query.Where(p => p.TenantId == currentTenantId.Value);
        }

        // Check for duplicate SKU
        query = query.Where(p => p.Sku == entity.Sku);

        // Exclude entity with provided id (for updates)
        if (id.HasValue)
        {
            query = query.Where(p => p.Id != id.Value);
        }

        var exists = await query.AnyAsync();
        return !exists;
    }
}