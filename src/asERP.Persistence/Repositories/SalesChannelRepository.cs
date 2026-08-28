using System.Linq.Expressions;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Dtos.WebAnalytics;
using asERP.Domain.Entities;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using SalesChannelDeletionSummary = asERP.Domain.Dtos.SalesChannel.SalesChannelDeletionSummary;

namespace asERP.Persistence.Repositories;

public class SalesChannelRepository : GenericRepository<SalesChannel>, ISalesChannelRepository
{
    public SalesChannelRepository(ApplicationDbContext context, ITenantContext tenantContext) : base(context, tenantContext)
    {

    }

    public async Task<SalesChannel> GetDetails(Guid id)
    {
        // Tenant isolation via the global query filter.
        var salesChannel = await Context.SalesChannel
            .Include(s => s.Warehouses)
            .Include(s => s.CarrierMappings)
                .ThenInclude(m => m.ShippingProvider)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (salesChannel == null)
        {
            throw new NotFoundException("SalesChannel not found", id);
        }

        return salesChannel;
    }

    public async Task<List<SalesChannelTrackingRef>> GetEnabledTrackingChannelsAsync(CancellationToken cancellationToken = default)
    {
        // Anonymous, cross-tenant lookup for the ingest hot path: bypass the tenant query filter.
        // Only channels that are tracking-enabled and have a configured token hash are returned.
        return await Context.SalesChannel
            .IgnoreQueryFilters()
            .AsNoTracking()
            .Where(s => s.TrackingEnabled
                        && s.TenantId != null
                        && s.TrackingTokenHash != null
                        && s.TrackingTokenHash != "")
            .Select(s => new SalesChannelTrackingRef
            {
                SalesChannelId = s.Id,
                TenantId = s.TenantId!.Value,
                TrackingTokenHash = s.TrackingTokenHash!
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> SalesChannelIsUniqueAsync(SalesChannel salesChannel, Guid? id = null)
    {
        if (id == null)
        {
            return await Context.SalesChannel
                .AnyAsync(s => s.Name == salesChannel.Name) ? false : true;
        }

        return await Context.SalesChannel
            .AnyAsync(s => s.Name == salesChannel.Name && s.Id != id) ? false : true;
    }

    public override async Task UpdateAsync(SalesChannel entity)
    {
        // Snapshot the desired warehouse IDs up front. When the caller already loaded the entity
        // tracked (e.g. via GetDetails), EF identity resolution makes the query below return the
        // *same* instance, so clearing existing.Warehouses would also clear entity.Warehouses and
        // we would lose the IDs we are about to re-apply. Copy them before any mutation.
        var desiredWarehouseIds = entity.Warehouses?.Select(w => w.Id).ToList() ?? new List<Guid>();

        // Get the existing entity with its warehouses
        var existing = await Context.SalesChannel
            .Include(s => s.Warehouses)
            .Include(s => s.CarrierMappings)
            .FirstOrDefaultAsync(s => s.Id == entity.Id);

        if (existing == null)
        {
            throw new InvalidOperationException($"SalesChannel with ID {entity.Id} not found for update");
        }

        // Update scalar properties
        Context.Entry(existing).CurrentValues.SetValues(entity);

        // Update warehouse relationships. Batch-load all desired warehouses in one query instead of
        // issuing a FindAsync per id.
        existing.Warehouses.Clear();
        if (desiredWarehouseIds.Count > 0)
        {
            var warehouses = await Context.Warehouse
                .Where(w => desiredWarehouseIds.Contains(w.Id))
                .ToListAsync();
            foreach (var warehouse in warehouses)
            {
                existing.Warehouses.Add(warehouse);
            }
        }

        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Diffs the submitted carrier translations against the stored rows instead of clearing and
    /// recreating them, so an unchanged mapping keeps its id. New rows get an explicit id — the
    /// generic update graph must not be relied on for child inserts.
    /// </summary>
    public async Task ReplaceCarrierMappingsAsync(
        Guid salesChannelId,
        IReadOnlyList<SalesChannelCarrierMappingInputDto> mappings)
    {
        // Last one wins on a duplicated code — the unique index would reject the batch otherwise.
        var desiredByCode = (mappings ?? [])
            .Select(m => (Code: NormalizeCarrierCode(m.RemoteCarrierCode), m.ShippingProviderId))
            .Where(m => !string.IsNullOrEmpty(m.Code) && m.ShippingProviderId != Guid.Empty)
            .GroupBy(m => m.Code, StringComparer.Ordinal)
            .ToDictionary(g => g.Key, g => g.Last().ShippingProviderId, StringComparer.Ordinal);

        var existing = await Context.SalesChannelCarrierMapping
            .Where(m => m.SalesChannelId == salesChannelId)
            .ToListAsync();

        foreach (var current in existing)
        {
            var code = NormalizeCarrierCode(current.RemoteCarrierCode);
            if (desiredByCode.TryGetValue(code, out var providerId))
            {
                current.RemoteCarrierCode = code;
                current.ShippingProviderId = providerId;
                desiredByCode.Remove(code);
            }
            else
            {
                Context.SalesChannelCarrierMapping.Remove(current);
            }
        }

        foreach (var (code, providerId) in desiredByCode)
        {
            Context.SalesChannelCarrierMapping.Add(new SalesChannelCarrierMapping
            {
                Id = Guid.NewGuid(),
                SalesChannelId = salesChannelId,
                RemoteCarrierCode = code,
                ShippingProviderId = providerId,
            });
        }

        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Carrier codes are matched case-insensitively but stored normalized, so the unique index
    /// behaves the same on the case-sensitive and case-insensitive providers.
    /// </summary>
    internal static string NormalizeCarrierCode(string? code)
        => (code ?? string.Empty).Trim().ToLowerInvariant();

    /// <summary>
    /// A channel must never be removed on its own: category links carry a RESTRICT foreign key (the
    /// delete would fail outright) and several channel-scoped tables have no foreign key at all and
    /// would silently orphan. Delegates so no caller can take a half-cleaned path through the
    /// generic contract.
    /// </summary>
    public override async Task DeleteAsync(SalesChannel entity)
    {
        await DeleteWithDependentsAsync(entity.Id);
    }

    public async Task<SalesChannelDeletionSummary> DeleteWithDependentsAsync(Guid id)
    {
        var existingEntity = await Context.SalesChannel
            .Include(s => s.Warehouses)
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (existingEntity == null)
        {
            throw new InvalidOperationException($"SalesChannel with ID {id} not found for deletion");
        }

        // Tenant ownership check — THE authorization gate of the whole cleanup. Everything below is
        // addressed by SalesChannelId alone and deliberately ignores the tenant query filter, so a
        // dependent row with a missing or wrong TenantId is cleaned up too instead of surviving as
        // an invisible orphan.
        var currentTenantId = TenantContext.GetCurrentTenantId();
        EnsureDeletableByCurrentTenant(existingEntity.TenantId, currentTenantId);

        // The InMemory test provider supports neither transactions nor ExecuteDelete/ExecuteUpdate and
        // takes the tracked path below. On the real providers the whole cleanup commits as one unit, so
        // a failure can no longer leave the channel alive with its shop domains already gone.
        var relational = Context.Database.IsRelational();

        await using var transaction = relational
            ? await Context.Database.BeginTransactionAsync()
            : null;

        var now = DateTime.UtcNow;
        int shopDomains, categoryLinks, customerLinks, productLinks, oauthStates, syncRows;
        int detachedImages, detachedFeeds;

        if (relational)
        {
            // Set-based and change-tracker-free on purpose: the export interceptor would otherwise
            // publish a notification per deleted link row for a channel that is about to vanish.
            shopDomains = await Context.ShopDomain.IgnoreQueryFilters()
                .Where(d => d.SalesChannelId == id).ExecuteDeleteAsync();
            await Context.SalesChannelCarrierMapping.IgnoreQueryFilters()
                .Where(m => m.SalesChannelId == id).ExecuteDeleteAsync();
            categoryLinks = await Context.CategorySalesChannel.IgnoreQueryFilters()
                .Where(l => l.SalesChannelId == id).ExecuteDeleteAsync();
            customerLinks = await Context.CustomerSalesChannel.IgnoreQueryFilters()
                .Where(l => l.SalesChannelId == id).ExecuteDeleteAsync();
            productLinks = await Context.ProductSalesChannel.IgnoreQueryFilters()
                .Where(l => l.SalesChannelId == id).ExecuteDeleteAsync();
            oauthStates = await Context.OAuthState
                .Where(s => s.SalesChannelId == id).ExecuteDeleteAsync();

            syncRows = await Context.ChannelExportOutbox.IgnoreQueryFilters()
                .Where(o => o.SalesChannelId == id).ExecuteDeleteAsync();
            syncRows += await Context.ChannelSyncLog.IgnoreQueryFilters()
                .Where(l => l.SalesChannelId == id).ExecuteDeleteAsync();
            syncRows += await Context.ChannelSyncRun.IgnoreQueryFilters()
                .Where(r => r.SalesChannelId == id).ExecuteDeleteAsync();
            syncRows += await Context.SalesChannelSyncState.IgnoreQueryFilters()
                .Where(s => s.SalesChannelId == id).ExecuteDeleteAsync();
            syncRows += await Context.SalesChannelOperationState.IgnoreQueryFilters()
                .Where(s => s.SalesChannelId == id).ExecuteDeleteAsync();

            // Images and feeds outlive the channel — only their now-meaningless origin is cleared.
            detachedImages = await Context.ProductImage.IgnoreQueryFilters()
                .Where(i => i.SalesChannelId == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(i => i.SalesChannelId, (Guid?)null)
                    .SetProperty(i => i.RemoteImageId, (string?)null)
                    .SetProperty(i => i.DateModified, now));
            detachedFeeds = await Context.Feed.IgnoreQueryFilters()
                .Where(f => f.SalesChannelId == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(f => f.SalesChannelId, (Guid?)null)
                    .SetProperty(f => f.DateModified, now));

            DetachTrackedDependents(id);
        }
        else
        {
            shopDomains = await RemoveRangeAsync(Context.ShopDomain, d => d.SalesChannelId == id);
            await RemoveRangeAsync(Context.SalesChannelCarrierMapping, m => m.SalesChannelId == id);
            categoryLinks = await RemoveRangeAsync(Context.CategorySalesChannel, l => l.SalesChannelId == id);
            customerLinks = await RemoveRangeAsync(Context.CustomerSalesChannel, l => l.SalesChannelId == id);
            productLinks = await RemoveRangeAsync(Context.ProductSalesChannel, l => l.SalesChannelId == id);
            oauthStates = await RemoveRangeAsync(Context.OAuthState, s => s.SalesChannelId == id);

            syncRows = await RemoveRangeAsync(Context.ChannelExportOutbox, o => o.SalesChannelId == id);
            syncRows += await RemoveRangeAsync(Context.ChannelSyncLog, l => l.SalesChannelId == id);
            syncRows += await RemoveRangeAsync(Context.ChannelSyncRun, r => r.SalesChannelId == id);
            syncRows += await RemoveRangeAsync(Context.SalesChannelSyncState, s => s.SalesChannelId == id);
            syncRows += await RemoveRangeAsync(Context.SalesChannelOperationState, s => s.SalesChannelId == id);

            var images = await Context.ProductImage.IgnoreQueryFilters()
                .Where(i => i.SalesChannelId == id).ToListAsync();
            foreach (var image in images)
            {
                image.SalesChannelId = null;
                image.RemoteImageId = null;
            }
            detachedImages = images.Count;

            var feeds = await Context.Feed.IgnoreQueryFilters()
                .Where(f => f.SalesChannelId == id).ToListAsync();
            foreach (var feed in feeds)
            {
                feed.SalesChannelId = null;
            }
            detachedFeeds = feeds.Count;
        }

        // The many-to-many warehouse assignments go through the tracked graph on both paths.
        existingEntity.Warehouses.Clear();
        Context.Remove(existingEntity);
        await Context.SaveChangesAsync();

        if (transaction is not null)
        {
            await transaction.CommitAsync();
        }

        return new SalesChannelDeletionSummary
        {
            TenantId = existingEntity.TenantId,
            ShopDomains = shopDomains,
            CategoryLinks = categoryLinks,
            CustomerLinks = customerLinks,
            ProductLinks = productLinks,
            OAuthStates = oauthStates,
            SyncRows = syncRows,
            DetachedProductImages = detachedImages,
            DetachedFeeds = detachedFeeds,
        };
    }

    /// <summary>
    /// Drops rows this context had already loaded and that the set-based cleanup has just deleted or
    /// rewritten. ExecuteDelete/ExecuteUpdate bypass the change tracker, so such an entry would still
    /// be tracked with its old channel reference — and EF then refuses to sever that (required,
    /// non-cascading) relationship when the channel itself is removed.
    /// </summary>
    private void DetachTrackedDependents(Guid salesChannelId)
    {
        var stale = Context.ChangeTracker.Entries()
            .Where(e => e.Entity is not SalesChannel)
            .Where(e =>
            {
                var property = e.Metadata.FindProperty("SalesChannelId");
                return property is not null && Equals(e.CurrentValues[property], salesChannelId);
            })
            .ToList();

        foreach (var entry in stale)
        {
            entry.State = EntityState.Detached;
        }
    }

    /// <summary>Tracked fallback for the InMemory provider, which has no ExecuteDelete.</summary>
    private async Task<int> RemoveRangeAsync<TEntity>(DbSet<TEntity> set, Expression<Func<TEntity, bool>> predicate)
        where TEntity : class
    {
        var rows = await set.IgnoreQueryFilters().Where(predicate).ToListAsync();
        set.RemoveRange(rows);
        return rows.Count;
    }
}
