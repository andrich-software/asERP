using asERP.Domain.Entities;
using asERP.Domain.Services;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Contracts;
using asERP.SalesChannels.Models;
using asERP.SalesChannels.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Repositories;

/// <summary>
/// Full-sweep reconcile of a channel's remote category tree into local categories and
/// <see cref="CategorySalesChannel"/> links (the category analogue of ProductImageImportService's
/// reconcile-by-remote-key pattern).
///
/// Matching order per remote category: (a) existing link by (SalesChannelId, RemoteCategoryId) —
/// update fields; (b) existing local category by (Name, resolved parent) — link it instead of
/// duplicating the tree; (c) create category + link. Links whose remote category disappeared are
/// deactivated and unmapped — but only when the sweep delivered a non-empty set, so a broken fetch
/// can never mass-deactivate a tree.
/// </summary>
public class CategoryImportRepository : ICategoryImportRepository
{
    private readonly ILogger<CategoryImportRepository> _logger;
    private readonly ApplicationDbContext _context;

    public CategoryImportRepository(ILogger<CategoryImportRepository> logger, ApplicationDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<SyncResult> ImportOrUpdateFromSalesChannel(
        Guid salesChannelId,
        IReadOnlyList<SalesChannelImportCategory> remoteCategories,
        CancellationToken cancellationToken)
    {
        var links = await _context.CategorySalesChannel
            .Where(l => l.SalesChannelId == salesChannelId)
            .ToListAsync(cancellationToken);
        var linkByRemoteId = links
            .Where(l => !string.IsNullOrEmpty(l.RemoteCategoryId))
            .ToDictionary(l => l.RemoteCategoryId!);

        var localCategories = await _context.Category.ToListAsync(cancellationToken);
        var localById = localCategories.ToDictionary(c => c.Id);

        var processed = 0;
        var failed = 0;
        var localIdByRemoteId = new Dictionary<string, Guid>();
        string? firstError = null;

        foreach (var remote in SortParentsFirst(remoteCategories))
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var name = ChannelText.DecodeEntities(remote.Name);

                // Parent already processed in this sweep (parents-first order); an unresolvable
                // parent (outside the delivered set) degrades the node to a root instead of failing.
                Guid? parentLocalId = null;
                if (!string.IsNullOrEmpty(remote.ParentRemoteCategoryId)
                    && localIdByRemoteId.TryGetValue(remote.ParentRemoteCategoryId, out var mappedParentId))
                {
                    parentLocalId = mappedParentId;
                }

                if (linkByRemoteId.TryGetValue(remote.RemoteCategoryId, out var existingLink))
                {
                    if (localById.TryGetValue(existingLink.CategoryId, out var linkedCategory))
                    {
                        linkedCategory.Name = name;
                        linkedCategory.Slug = string.IsNullOrWhiteSpace(remote.Slug)
                            ? CategorySlugGenerator.Generate(name)
                            : remote.Slug;
                        linkedCategory.Description = remote.Description;
                        linkedCategory.SortOrder = remote.SortOrder;
                        linkedCategory.ParentCategoryId = parentLocalId;
                        existingLink.IsActive = true;
                        existingLink.LastSyncedAt = DateTime.UtcNow;
                        localIdByRemoteId[remote.RemoteCategoryId] = linkedCategory.Id;
                        processed++;
                        continue;
                    }

                    // Link row without its category (corrupt data) — drop it and fall through to re-create.
                    _context.CategorySalesChannel.Remove(existingLink);
                    links.Remove(existingLink);
                    linkByRemoteId.Remove(remote.RemoteCategoryId);
                }

                // Match an existing local category by name + resolved parent so re-linking an
                // already-maintained ERP tree does not duplicate it.
                var matchByName = localCategories.FirstOrDefault(c =>
                    c.ParentCategoryId == parentLocalId
                    && string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));

                Category category;
                if (matchByName is not null)
                {
                    category = matchByName;
                }
                else
                {
                    category = new Category
                    {
                        Name = name,
                        Slug = string.IsNullOrWhiteSpace(remote.Slug) ? CategorySlugGenerator.Generate(name) : remote.Slug,
                        Description = remote.Description,
                        SortOrder = remote.SortOrder,
                        ParentCategoryId = parentLocalId
                    };
                    _context.Category.Add(category);
                    localCategories.Add(category);
                    localById[category.Id] = category;
                }

                var existingLinkForCategory = links.FirstOrDefault(l => l.CategoryId == category.Id);
                if (existingLinkForCategory is not null)
                {
                    existingLinkForCategory.IsActive = true;
                    existingLinkForCategory.RemoteCategoryId = remote.RemoteCategoryId;
                    existingLinkForCategory.LastSyncedAt = DateTime.UtcNow;
                    linkByRemoteId[remote.RemoteCategoryId] = existingLinkForCategory;
                }
                else
                {
                    var newLink = new CategorySalesChannel
                    {
                        CategoryId = category.Id,
                        Category = category,
                        SalesChannelId = salesChannelId,
                        IsActive = true,
                        RemoteCategoryId = remote.RemoteCategoryId,
                        LastSyncedAt = DateTime.UtcNow
                    };
                    _context.CategorySalesChannel.Add(newLink);
                    links.Add(newLink);
                    linkByRemoteId[remote.RemoteCategoryId] = newLink;
                }

                localIdByRemoteId[remote.RemoteCategoryId] = category.Id;
                processed++;
            }
            catch (Exception ex)
            {
                failed++;
                firstError ??= ex.Message;
                _logger.LogError(ex, "Failed to import category {RemoteId} ({Name})", remote.RemoteCategoryId, remote.Name);
            }
        }

        // Orphaned links: mapped remotely but no longer delivered. Only trust a non-empty sweep —
        // an empty result more likely means a broken fetch than a wiped shop.
        if (remoteCategories.Count > 0)
        {
            foreach (var orphan in links.Where(l =>
                         !string.IsNullOrEmpty(l.RemoteCategoryId)
                         && !localIdByRemoteId.ContainsKey(l.RemoteCategoryId!)))
            {
                _logger.LogInformation(
                    "Category link {CategoryId} no longer exists on channel {ChannelId} — deactivating",
                    orphan.CategoryId, salesChannelId);
                orphan.IsActive = false;
                orphan.RemoteCategoryId = null;
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

        return failed == 0
            ? new SyncResult(processed, 0)
            : new SyncResult(processed, failed, firstError);
    }

    /// <summary>
    /// Orders the remote set parents-before-children (Kahn-style peeling). Nodes whose parent is
    /// missing from the set — or stuck in a cycle — are appended at the end and imported as roots.
    /// </summary>
    internal static List<SalesChannelImportCategory> SortParentsFirst(IReadOnlyList<SalesChannelImportCategory> categories)
    {
        var remaining = categories.ToList();
        var sorted = new List<SalesChannelImportCategory>(remaining.Count);
        var emitted = new HashSet<string>();

        bool IsReady(SalesChannelImportCategory c) =>
            string.IsNullOrEmpty(c.ParentRemoteCategoryId)
            || emitted.Contains(c.ParentRemoteCategoryId)
            || categories.All(other => other.RemoteCategoryId != c.ParentRemoteCategoryId);

        while (remaining.Count > 0)
        {
            var ready = remaining.Where(IsReady).ToList();
            if (ready.Count == 0)
            {
                // Cycle in the remote data — emit the rest as-is (they degrade to roots).
                sorted.AddRange(remaining);
                break;
            }

            foreach (var node in ready)
            {
                sorted.Add(node);
                emitted.Add(node.RemoteCategoryId);
                remaining.Remove(node);
            }
        }

        return sorted;
    }
}
