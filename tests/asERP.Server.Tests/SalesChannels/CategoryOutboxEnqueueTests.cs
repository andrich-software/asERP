using System.Text.Json;
using asERP.Application.Notifications;
using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.NotificationHandlers;
using asERP.SalesChannels.Orchestration;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// The three category notification handlers must route domain changes into the export outbox:
/// category edits → ExportCategory fan-out, activation toggles → ExportCategory/DeleteCategory,
/// deletion snapshots → DeleteCategory with payload, assignment changes → UpdateProductCategories.
/// Exercises the handlers directly, mirroring the other SalesChannels handler-level tests.
/// </summary>
public class CategoryOutboxEnqueueTests : TenantIsolatedTestBase
{
    private async Task<Guid> SeedChannelAsync(bool exportCategories = true, bool enabled = true)
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        var salesChannelId = Guid.NewGuid();
        try
        {
            DbContext.SalesChannel.Add(new SalesChannel
            {
                Id = salesChannelId,
                Type = SalesChannelType.Shopware6,
                Name = "Category Outbox Test Channel",
                Url = "https://shop.example.com",
                Username = "key",
                Password = "secret",
                IsEnabled = enabled,
                ExportCategories = exportCategories,
                TenantId = TenantConstants.TestTenant1Id
            });
            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }

        return salesChannelId;
    }

    private async Task<Guid> SeedCategoryAsync()
    {
        var categoryId = Guid.NewGuid();
        DbContext.Category.Add(new asERP.Domain.Entities.Category
        {
            Id = categoryId,
            Name = "Outbox Category",
            Slug = "outbox-category",
            TenantId = TenantConstants.TestTenant1Id
        });
        await DbContext.SaveChangesAsync();
        return categoryId;
    }

    private async Task<Guid> SeedLinkAsync(Guid categoryId, Guid salesChannelId, bool isActive, string? remoteId = null)
    {
        var linkId = Guid.NewGuid();
        DbContext.CategorySalesChannel.Add(new CategorySalesChannel
        {
            Id = linkId,
            CategoryId = categoryId,
            SalesChannelId = salesChannelId,
            IsActive = isActive,
            RemoteCategoryId = remoteId,
            TenantId = TenantConstants.TestTenant1Id
        });
        await DbContext.SaveChangesAsync();
        return linkId;
    }

    private ChannelExportOutboxEnqueuer CreateEnqueuer()
    {
        // Empty registry: the enqueuer fails open for types without a registered connector.
        var registry = new SalesChannelConnectorRegistry(Array.Empty<ISalesChannelConnector>());
        return new ChannelExportOutboxEnqueuer(DbContext, registry, NullLogger<ChannelExportOutboxEnqueuer>.Instance);
    }

    private async Task<List<ChannelExportOutbox>> GetRowsAsync(Guid salesChannelId, ChannelSyncOperation operation) =>
        await DbContext.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.SalesChannelId == salesChannelId && o.Operation == operation)
            .ToListAsync();

    [Fact]
    public async Task CategoryChanged_EnqueuesExportForActiveChannelsOnly()
    {
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var activeChannel = await SeedChannelAsync();
        var inactiveChannel = await SeedChannelAsync();
        var categoryId = await SeedCategoryAsync();
        await SeedLinkAsync(categoryId, activeChannel, isActive: true);
        await SeedLinkAsync(categoryId, inactiveChannel, isActive: false);

        var handler = new CategoryChangedNotificationHandler(DbContext, CreateEnqueuer());
        await handler.Handle(
            new CategoryChangedNotification(categoryId, TenantConstants.TestTenant1Id, CategoryChangeKind.Updated),
            CancellationToken.None);

        var exportRows = await GetRowsAsync(activeChannel, ChannelSyncOperation.ExportCategory);
        TestAssertions.AssertEqual(1, exportRows.Count);
        TestAssertions.AssertEqual(categoryId, exportRows[0].AggregateId);
        TestAssertions.AssertEqual(ChannelOutboxAggregateType.Category, exportRows[0].AggregateType);
        TestAssertions.AssertEqual(0, (await GetRowsAsync(inactiveChannel, ChannelSyncOperation.ExportCategory)).Count);
    }

    [Fact]
    public async Task CategoryChanged_ChannelWithoutExportCategories_DoesNotEnqueue()
    {
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var channelId = await SeedChannelAsync(exportCategories: false);
        var categoryId = await SeedCategoryAsync();
        await SeedLinkAsync(categoryId, channelId, isActive: true);

        var handler = new CategoryChangedNotificationHandler(DbContext, CreateEnqueuer());
        await handler.Handle(
            new CategoryChangedNotification(categoryId, TenantConstants.TestTenant1Id, CategoryChangeKind.Updated),
            CancellationToken.None);

        TestAssertions.AssertEqual(0, (await GetRowsAsync(channelId, ChannelSyncOperation.ExportCategory)).Count);
    }

    [Fact]
    public async Task CategoryDeleted_EnqueuesRemoteDeleteFromSnapshot()
    {
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var channelId = await SeedChannelAsync();
        var categoryId = Guid.NewGuid();
        var linkId = Guid.NewGuid();

        var handler = new CategoryChangedNotificationHandler(DbContext, CreateEnqueuer());
        await handler.Handle(
            new CategoryChangedNotification(
                categoryId,
                TenantConstants.TestTenant1Id,
                CategoryChangeKind.Deleted,
                new[] { new CategoryDeleteSnapshot(channelId, linkId, "remote-42", IsActive: true) }),
            CancellationToken.None);

        var deleteRows = await GetRowsAsync(channelId, ChannelSyncOperation.DeleteCategory);
        TestAssertions.AssertEqual(1, deleteRows.Count);
        var payload = JsonSerializer.Deserialize<CategoryDeletePayload>(deleteRows[0].PayloadJson);
        TestAssertions.AssertNotNull(payload);
        TestAssertions.AssertEqual("remote-42", payload!.RemoteCategoryId);
    }

    [Fact]
    public async Task CategoryDeleted_SnapshotWithoutRemoteId_DoesNotEnqueue()
    {
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var channelId = await SeedChannelAsync();

        var handler = new CategoryChangedNotificationHandler(DbContext, CreateEnqueuer());
        await handler.Handle(
            new CategoryChangedNotification(
                Guid.NewGuid(),
                TenantConstants.TestTenant1Id,
                CategoryChangeKind.Deleted,
                new[] { new CategoryDeleteSnapshot(channelId, Guid.NewGuid(), RemoteCategoryId: null, IsActive: true) }),
            CancellationToken.None);

        TestAssertions.AssertEqual(0, (await GetRowsAsync(channelId, ChannelSyncOperation.DeleteCategory)).Count);
    }

    [Fact]
    public async Task ActivationToggledOn_EnqueuesExportCategory()
    {
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var channelId = await SeedChannelAsync();
        var categoryId = await SeedCategoryAsync();
        var linkId = await SeedLinkAsync(categoryId, channelId, isActive: true);

        var handler = new CategorySalesChannelChangedNotificationHandler(DbContext, CreateEnqueuer());
        await handler.Handle(
            new CategorySalesChannelChangedNotification(linkId, categoryId, channelId, TenantConstants.TestTenant1Id),
            CancellationToken.None);

        TestAssertions.AssertEqual(1, (await GetRowsAsync(channelId, ChannelSyncOperation.ExportCategory)).Count);
        TestAssertions.AssertEqual(0, (await GetRowsAsync(channelId, ChannelSyncOperation.DeleteCategory)).Count);
    }

    [Fact]
    public async Task ActivationToggledOff_EnqueuesDeleteCategory()
    {
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var channelId = await SeedChannelAsync();
        var categoryId = await SeedCategoryAsync();
        var linkId = await SeedLinkAsync(categoryId, channelId, isActive: false, remoteId: "remote-7");

        var handler = new CategorySalesChannelChangedNotificationHandler(DbContext, CreateEnqueuer());
        await handler.Handle(
            new CategorySalesChannelChangedNotification(linkId, categoryId, channelId, TenantConstants.TestTenant1Id),
            CancellationToken.None);

        TestAssertions.AssertEqual(0, (await GetRowsAsync(channelId, ChannelSyncOperation.ExportCategory)).Count);
        TestAssertions.AssertEqual(1, (await GetRowsAsync(channelId, ChannelSyncOperation.DeleteCategory)).Count);
    }

    [Fact]
    public async Task ProductCategoriesChanged_EnqueuesUpdateForLinkedChannelsOnly()
    {
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var linkedChannel = await SeedChannelAsync();
        var unlinkedChannel = await SeedChannelAsync();
        var productId = Guid.NewGuid();

        DbContext.ProductSalesChannel.Add(new ProductSalesChannel
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            SalesChannelId = linkedChannel,
            RemoteProductId = "123",
            IsListed = true,
            TenantId = TenantConstants.TestTenant1Id
        });
        // No remote id → the channel does not know the product, nothing to push.
        DbContext.ProductSalesChannel.Add(new ProductSalesChannel
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            SalesChannelId = unlinkedChannel,
            RemoteProductId = null,
            IsListed = true,
            TenantId = TenantConstants.TestTenant1Id
        });
        await DbContext.SaveChangesAsync();

        var handler = new ProductCategoriesChangedNotificationHandler(DbContext, CreateEnqueuer());
        await handler.Handle(
            new ProductCategoriesChangedNotification(productId, TenantConstants.TestTenant1Id),
            CancellationToken.None);

        var rows = await GetRowsAsync(linkedChannel, ChannelSyncOperation.UpdateProductCategories);
        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(productId, rows[0].AggregateId);
        TestAssertions.AssertEqual(ChannelOutboxAggregateType.Product, rows[0].AggregateType);
        TestAssertions.AssertEqual(0, (await GetRowsAsync(unlinkedChannel, ChannelSyncOperation.UpdateProductCategories)).Count);
    }
}
