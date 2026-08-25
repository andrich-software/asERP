using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Category.Commands;

/// <summary>
/// Category deletion: children block the delete, dependents (product assignments + channel links)
/// are cascaded explicitly, and remote deletes are enqueued from the pre-delete snapshot.
/// </summary>
public class CategoryDeleteCommandTests : TenantIsolatedTestBase
{
    private async Task<(Guid parentId, Guid leafId, Guid channelId)> SeedAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        var parentId = Guid.NewGuid();
        var leafId = Guid.NewGuid();
        var channelId = Guid.NewGuid();

        try
        {
            await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

            // Shopware6 supports category export, so the real connector registry lets the
            // enqueuer write outbox rows for this channel.
            DbContext.SalesChannel.Add(new asERP.Domain.Entities.SalesChannel
            {
                Id = channelId,
                Type = SalesChannelType.Shopware6,
                Name = "Category Delete Test Channel",
                Url = "https://shop.example.com",
                Username = "key",
                Password = "secret",
                IsEnabled = true,
                ExportCategories = true,
                TenantId = TenantConstants.TestTenant1Id,
                SyncState = new SalesChannelSyncState { TenantId = TenantConstants.TestTenant1Id }
            });

            DbContext.Category.AddRange(
                new asERP.Domain.Entities.Category
                {
                    Id = parentId,
                    Name = "Parent",
                    Slug = "parent",
                    TenantId = TenantConstants.TestTenant1Id
                },
                new asERP.Domain.Entities.Category
                {
                    Id = leafId,
                    Name = "Leaf",
                    Slug = "leaf",
                    ParentCategoryId = parentId,
                    TenantId = TenantConstants.TestTenant1Id
                });

            DbContext.CategorySalesChannel.Add(new CategorySalesChannel
            {
                Id = Guid.NewGuid(),
                CategoryId = leafId,
                SalesChannelId = channelId,
                IsActive = true,
                RemoteCategoryId = "remote-123",
                TenantId = TenantConstants.TestTenant1Id
            });

            DbContext.ProductCategory.Add(new ProductCategory
            {
                Id = Guid.NewGuid(),
                CategoryId = leafId,
                ProductId = Guid.NewGuid(),
                TenantId = TenantConstants.TestTenant1Id
            });

            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }

        return (parentId, leafId, channelId);
    }

    [Fact]
    public async Task DeleteLeafCategory_RemovesCategoryAndDependents()
    {
        var (_, leafId, _) = await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/Categories/{leafId}");

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        TestAssertions.AssertFalse(await DbContext.Category.IgnoreQueryFilters().AnyAsync(c => c.Id == leafId));
        TestAssertions.AssertFalse(await DbContext.CategorySalesChannel.IgnoreQueryFilters().AnyAsync(l => l.CategoryId == leafId));
        TestAssertions.AssertFalse(await DbContext.ProductCategory.IgnoreQueryFilters().AnyAsync(pc => pc.CategoryId == leafId));
    }

    [Fact]
    public async Task DeleteLeafCategory_EnqueuesRemoteDeleteWithSnapshotPayload()
    {
        var (_, leafId, channelId) = await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/Categories/{leafId}");

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var outboxRows = await DbContext.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.SalesChannelId == channelId && o.Operation == ChannelSyncOperation.DeleteCategory)
            .ToListAsync();
        TestAssertions.AssertEqual(1, outboxRows.Count);
        TestAssertions.AssertEqual(leafId, outboxRows[0].AggregateId);
        TestAssertions.AssertEqual(ChannelOutboxAggregateType.Category, outboxRows[0].AggregateType);
        TestAssertions.AssertTrue(outboxRows[0].PayloadJson.Contains("remote-123"));
    }

    [Fact]
    public async Task DeleteCategoryWithChildren_ShouldReturnBadRequest()
    {
        var (parentId, leafId, _) = await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/Categories/{parentId}");

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        TestAssertions.AssertTrue(await DbContext.Category.IgnoreQueryFilters().AnyAsync(c => c.Id == parentId));
        TestAssertions.AssertTrue(await DbContext.Category.IgnoreQueryFilters().AnyAsync(c => c.Id == leafId));
    }

    [Fact]
    public async Task DeleteNonExistentCategory_ShouldReturnNotFound()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/Categories/{Guid.NewGuid()}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeleteCategoryFromOtherTenant_ShouldReturnNotFound()
    {
        var (_, leafId, _) = await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.DeleteAsync($"/api/v1/Categories/{leafId}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
        TestAssertions.AssertTrue(await DbContext.Category.IgnoreQueryFilters().AnyAsync(c => c.Id == leafId));
    }
}
