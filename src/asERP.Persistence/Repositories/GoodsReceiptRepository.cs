using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace asERP.Persistence.Repositories;

public class GoodsReceiptRepository : GenericRepository<GoodsReceipt>, IGoodsReceiptRepository
{
    public GoodsReceiptRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {
    }

    public async Task<GoodsReceipt?> GetByIdWithDetailsAsync(Guid id)
    {
        return await Context.GoodsReceipt
            .Include(gr => gr.Product)
            .Include(gr => gr.Warehouse)
            .FirstOrDefaultAsync(gr => gr.Id == id);
    }

    public async Task<ProductStock?> GetProductStockAsync(Guid productId, Guid warehouseId)
    {
        return await Context.ProductStock
            .FirstOrDefaultAsync(ps => ps.ProductId == productId && ps.WarehouseId == warehouseId);
    }

    public async Task UpdateProductStockAsync(ProductStock productStock)
    {
        Context.ProductStock.Update(productStock);
        await Context.SaveChangesAsync();
    }

    public async Task CreateProductStockAsync(ProductStock productStock)
    {
        await Context.ProductStock.AddAsync(productStock);
        await Context.SaveChangesAsync();
    }

    public async Task<int> IncrementProductStockAsync(Guid productId, Guid warehouseId, double delta)
    {
        // InMemory (tests) doesn't support ExecuteUpdate — fall back to a tracked read-modify-write.
        if (Context.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
        {
            var tracked = await Context.ProductStock
                .FirstOrDefaultAsync(ps => ps.ProductId == productId && ps.WarehouseId == warehouseId);
            if (tracked == null)
            {
                return 0;
            }

            tracked.Stock += delta;
            await Context.SaveChangesAsync();
            return 1;
        }

        // Relational providers: single atomic UPDATE ... SET Stock = Stock + delta.
        return await Context.ProductStock
            .Where(ps => ps.ProductId == productId && ps.WarehouseId == warehouseId)
            .ExecuteUpdateAsync(setters => setters.SetProperty(ps => ps.Stock, ps => ps.Stock + delta));
    }
}
