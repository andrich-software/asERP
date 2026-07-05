using asERP.Application.Contracts.Persistence;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace asERP.Persistence.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly ApplicationDbContext _context;

    public TenantRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Tenant> Entities => _context.Tenant;

    public async Task<Guid> CreateAsync(Tenant entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateAsync(Tenant entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Tenant entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Tenant>> GetAllAsync()
    {
        return await _context.Tenant
            .Include(t => t.UserTenants)
            .OrderBy(t => t.Name)
            .ToListAsync();
    }

    public async Task<Tenant?> GetByIdAsync(Guid id, bool asNoTracking = false)
    {
        if (asNoTracking)
        {
            return await _context.Tenant
                .AsNoTracking()
                .Include(t => t.UserTenants)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        return await _context.Tenant
            .Include(t => t.UserTenants)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Tenant.AsNoTracking().AnyAsync(e => e.Id == id);
    }

    public async Task<bool> ExistsGloballyAsync(Guid id)
    {
        return await _context.Tenant.IgnoreQueryFilters().AsNoTracking().AnyAsync(e => e.Id == id);
    }

    public async Task<bool> IsUniqueAsync(Tenant entity, Guid? id = null)
    {
        // Tenants are unique by Name
        var query = _context.Tenant.AsQueryable();

        if (id.HasValue)
        {
            query = query.Where(t => t.Id != id.Value);
        }

        return !await query.AnyAsync(t => t.Name == entity.Name);
    }

    public void Attach(Tenant entity)
    {
        _context.Set<Tenant>().Attach(entity);
    }

    public void AttachRange(IEnumerable<Tenant> entities)
    {
        _context.Set<Tenant>().AttachRange(entities);
    }

    public IQueryable<TCt> GetContext<TCt>() where TCt : class => _context.Set<TCt>();

    // Transaction support methods
    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Add(Tenant entity)
    {
        _context.Set<Tenant>().Add(entity);
    }

    public async Task DeleteTenantWithCascadeAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            // Delete all tenant-related data (respecting foreign key constraints — children first).
            // Cascades are deliberately not configured across the schema, so every dependent set must
            // be deleted explicitly and in FK-safe order. Uses ExecuteDeleteAsync for bulk deletion.

            // --- Returns (children first) ---
            await _context.ReturnShipmentItemSerialNumber
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ReturnShipmentItem
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ReturnLabelOutbox
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ReturnShipment
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Sales items & serials ---
            await _context.SalesItemSerialNumber
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SalesItem
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SalesHistory
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Shipping (labels before shipments) ---
            await _context.ShippingLabelOutbox
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.Shipping
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Invoices ---
            await _context.InvoiceItem
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.Invoice
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Sales ---
            await _context.Sales
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Customers ---
            await _context.CustomerSalesChannel
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.CustomerAddress
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.Customer
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Stock movements (reference sales items/products) ---
            await _context.StockMovement
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Product graph (children before Product) ---
            await _context.ProductImage
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ProductVariantOption
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ProductVariantAxis
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ProductAttributeValue
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ProductAttribute
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ProductStock
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ProductSalesChannel
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.GoodsReceipt
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.Product
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Channels (export outbox & sync logs/runs before SalesChannel) ---
            await _context.ChannelExportOutbox
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ChannelSyncLog
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ChannelSyncRun
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SalesChannel
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Warehouse & tax ---
            await _context.Warehouse
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.TaxClass
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Shipping providers (rate countries & rates before providers) ---
            await _context.ShippingProviderRateCountry
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ShippingProviderRate
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.ShippingProvider
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- AI ---
            await _context.AiPrompt
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.AiModel
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Manufacturer & tenant-scoped countries ---
            await _context.Manufacturer
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.Country
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Tenant-owned settings (BaseEntityWithoutTenant, explicit TenantId FK) ---
            await _context.TenantEmailSettings
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.TenantOAuthAppSettings
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- UserTenant (cascade delete is configured, but delete explicitly for clarity) ---
            await _context.UserTenant
                .IgnoreQueryFilters()
                .Where(x => x.TenantId == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            // --- Tenant (final delete) ---
            await _context.Tenant
                .IgnoreQueryFilters()
                .Where(x => x.Id == tenantId)
                .ExecuteDeleteAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
