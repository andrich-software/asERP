using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Models;
using asERP.SalesChannels.Repositories;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Full-sweep category import reconcile: create/update by remote id, link-by-name matching,
/// parents-first ordering, orphan deactivation and the empty-sweep guard.
/// </summary>
public class CategoryImportRepositoryTests : TenantIsolatedTestBase
{
    private Guid _channelId;

    private async Task SeedChannelAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        _channelId = Guid.NewGuid();
        try
        {
            DbContext.SalesChannel.Add(new SalesChannel
            {
                Id = _channelId,
                Type = SalesChannelType.WooCommerce,
                Name = "Category Import Test Channel",
                Url = "https://shop.example.com",
                Username = "key",
                Password = "secret",
                IsEnabled = true,
                ImportCategories = true,
                TenantId = TenantConstants.TestTenant1Id,
                SyncState = new SalesChannelSyncState { TenantId = TenantConstants.TestTenant1Id }
            });
            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }

        SetTenantHeader(TenantConstants.TestTenant1Id);
    }

    private CategoryImportRepository CreateRepository() =>
        new(NullLogger<CategoryImportRepository>.Instance, DbContext);

    private static SalesChannelImportCategory Remote(string id, string name, string? parentId = null, string? slug = null) => new()
    {
        RemoteCategoryId = id,
        Name = name,
        ParentRemoteCategoryId = parentId,
        Slug = slug ?? string.Empty
    };

    [Fact]
    public async Task Import_CreatesTreeWithParentLinks_EvenWhenChildrenAreListedFirst()
    {
        await SeedChannelAsync();

        // Child before parent — the repository must order parents first itself.
        var result = await CreateRepository().ImportOrUpdateFromSalesChannel(
            _channelId,
            new[]
            {
                Remote("11", "Shirts", parentId: "10"),
                Remote("10", "Bekleidung"),
            },
            CancellationToken.None);

        TestAssertions.AssertEqual(2, result.ItemsProcessed);
        TestAssertions.AssertEqual(0, result.ItemsFailed);

        var categories = await DbContext.Category.IgnoreQueryFilters().ToListAsync();
        TestAssertions.AssertEqual(2, categories.Count);
        var parent = categories.First(c => c.Name == "Bekleidung");
        var child = categories.First(c => c.Name == "Shirts");
        TestAssertions.AssertNull(parent.ParentCategoryId);
        TestAssertions.AssertEqual(parent.Id, child.ParentCategoryId);
        TestAssertions.AssertEqual("bekleidung", parent.Slug);

        var links = await DbContext.CategorySalesChannel.IgnoreQueryFilters()
            .Where(l => l.SalesChannelId == _channelId)
            .ToListAsync();
        TestAssertions.AssertEqual(2, links.Count);
        TestAssertions.AssertTrue(links.All(l => l.IsActive));
        TestAssertions.AssertTrue(links.Any(l => l.RemoteCategoryId == "10"));
        TestAssertions.AssertTrue(links.Any(l => l.RemoteCategoryId == "11"));
    }

    [Fact]
    public async Task Import_UpdatesExistingMappedCategoryByRemoteId()
    {
        await SeedChannelAsync();
        var repository = CreateRepository();

        await repository.ImportOrUpdateFromSalesChannel(
            _channelId, new[] { Remote("10", "Alt") }, CancellationToken.None);
        var categoryId = (await DbContext.Category.IgnoreQueryFilters().SingleAsync()).Id;

        var result = await repository.ImportOrUpdateFromSalesChannel(
            _channelId, new[] { Remote("10", "Neu", slug: "neu") }, CancellationToken.None);

        TestAssertions.AssertEqual(1, result.ItemsProcessed);
        var category = await DbContext.Category.IgnoreQueryFilters().SingleAsync();
        TestAssertions.AssertEqual(categoryId, category.Id);
        TestAssertions.AssertEqual("Neu", category.Name);
        TestAssertions.AssertEqual("neu", category.Slug);
    }

    [Fact]
    public async Task Import_LinksExistingCategoryByNameInsteadOfDuplicating()
    {
        await SeedChannelAsync();

        var existingId = Guid.NewGuid();
        DbContext.Category.Add(new asERP.Domain.Entities.Category
        {
            Id = existingId,
            Name = "Bekleidung",
            Slug = "bekleidung",
            TenantId = TenantConstants.TestTenant1Id
        });
        await DbContext.SaveChangesAsync();

        var result = await CreateRepository().ImportOrUpdateFromSalesChannel(
            _channelId, new[] { Remote("10", "Bekleidung") }, CancellationToken.None);

        TestAssertions.AssertEqual(1, result.ItemsProcessed);
        TestAssertions.AssertEqual(1, await DbContext.Category.IgnoreQueryFilters().CountAsync());
        var link = await DbContext.CategorySalesChannel.IgnoreQueryFilters().SingleAsync();
        TestAssertions.AssertEqual(existingId, link.CategoryId);
        TestAssertions.AssertEqual("10", link.RemoteCategoryId);
        TestAssertions.AssertTrue(link.IsActive);
    }

    [Fact]
    public async Task Import_DeactivatesOrphanedLinksOnFullSweep()
    {
        await SeedChannelAsync();
        var repository = CreateRepository();

        await repository.ImportOrUpdateFromSalesChannel(
            _channelId, new[] { Remote("10", "Bleibt"), Remote("20", "Verschwindet") }, CancellationToken.None);

        await repository.ImportOrUpdateFromSalesChannel(
            _channelId, new[] { Remote("10", "Bleibt") }, CancellationToken.None);

        var links = await DbContext.CategorySalesChannel.IgnoreQueryFilters()
            .Where(l => l.SalesChannelId == _channelId)
            .ToListAsync();
        var kept = links.Single(l => l.RemoteCategoryId == "10");
        var orphan = links.Single(l => l.RemoteCategoryId == null);
        TestAssertions.AssertTrue(kept.IsActive);
        TestAssertions.AssertFalse(orphan.IsActive);
    }

    [Fact]
    public async Task Import_EmptySweep_DoesNotDeactivateAnything()
    {
        await SeedChannelAsync();
        var repository = CreateRepository();

        await repository.ImportOrUpdateFromSalesChannel(
            _channelId, new[] { Remote("10", "Bleibt") }, CancellationToken.None);

        // A broken fetch delivering nothing must never mass-deactivate the tree.
        await repository.ImportOrUpdateFromSalesChannel(
            _channelId, Array.Empty<SalesChannelImportCategory>(), CancellationToken.None);

        var link = await DbContext.CategorySalesChannel.IgnoreQueryFilters().SingleAsync();
        TestAssertions.AssertTrue(link.IsActive);
        TestAssertions.AssertEqual("10", link.RemoteCategoryId);
    }

    [Fact]
    public void SortParentsFirst_HandlesCyclesWithoutHanging()
    {
        var cyclic = new[]
        {
            Remote("1", "A", parentId: "2"),
            Remote("2", "B", parentId: "1"),
            Remote("3", "Root"),
        };

        var sorted = CategoryImportRepository.SortParentsFirst(cyclic);

        TestAssertions.AssertEqual(3, sorted.Count);
        TestAssertions.AssertEqual("3", sorted[0].RemoteCategoryId);
    }
}
