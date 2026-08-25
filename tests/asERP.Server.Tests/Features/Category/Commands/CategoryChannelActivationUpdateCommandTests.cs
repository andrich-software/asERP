using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Category.Commands;

/// <summary>
/// The batch activation endpoint: cell upserts, the server-side ancestor/descendant expansion
/// (tree consistency), delta semantics (no-ops don't count) and the export/delete outbox rows.
/// </summary>
public class CategoryChannelActivationUpdateCommandTests : TenantIsolatedTestBase
{
    private Guid _rootId;
    private Guid _childId;
    private Guid _grandchildId;
    private Guid _channelId;

    private async Task SeedAsync(SalesChannelType channelType = SalesChannelType.Shopware6)
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        _rootId = Guid.NewGuid();
        _childId = Guid.NewGuid();
        _grandchildId = Guid.NewGuid();
        _channelId = Guid.NewGuid();

        try
        {
            await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

            DbContext.SalesChannel.Add(new asERP.Domain.Entities.SalesChannel
            {
                Id = _channelId,
                Type = channelType,
                Name = "Activation Test Channel",
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
                    Id = _rootId,
                    Name = "Root",
                    Slug = "root",
                    TenantId = TenantConstants.TestTenant1Id
                },
                new asERP.Domain.Entities.Category
                {
                    Id = _childId,
                    Name = "Child",
                    Slug = "child",
                    ParentCategoryId = _rootId,
                    TenantId = TenantConstants.TestTenant1Id
                },
                new asERP.Domain.Entities.Category
                {
                    Id = _grandchildId,
                    Name = "Grandchild",
                    Slug = "grandchild",
                    ParentCategoryId = _childId,
                    TenantId = TenantConstants.TestTenant1Id
                });

            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    private static CategoryChannelActivationUpdateDto BuildUpdate(params (Guid CategoryId, Guid ChannelId, bool IsActive)[] changes) => new()
    {
        Changes = changes
            .Select(c => new CategoryChannelActivationChange
            {
                CategoryId = c.CategoryId,
                SalesChannelId = c.ChannelId,
                IsActive = c.IsActive
            })
            .ToList()
    };

    // AsNoTracking: requests run on their own scopes — tracked instances in the test context
    // would otherwise shadow the updated store rows.
    private async Task<List<CategorySalesChannel>> GetLinksAsync() =>
        await DbContext.CategorySalesChannel.IgnoreQueryFilters().AsNoTracking()
            .Where(l => l.SalesChannelId == _channelId)
            .ToListAsync();

    [Fact]
    public async Task ActivateRootCell_CreatesActiveRowAndEnqueuesExport()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync("/api/v1/Categories/channels", BuildUpdate((_rootId, _channelId, true)));

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<int>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertEqual(1, result.Data);

        var links = await GetLinksAsync();
        TestAssertions.AssertEqual(1, links.Count);
        TestAssertions.AssertTrue(links[0].IsActive);
        TestAssertions.AssertEqual(_rootId, links[0].CategoryId);

        var outboxRows = await DbContext.ChannelExportOutbox.IgnoreQueryFilters()
            .Where(o => o.SalesChannelId == _channelId && o.Operation == ChannelSyncOperation.ExportCategory)
            .ToListAsync();
        TestAssertions.AssertEqual(1, outboxRows.Count);
        TestAssertions.AssertEqual(_rootId, outboxRows[0].AggregateId);
    }

    [Fact]
    public async Task ActivateGrandchild_ActivatesAncestorsToo()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync("/api/v1/Categories/channels", BuildUpdate((_grandchildId, _channelId, true)));

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<int>>(response);
        TestAssertions.AssertEqual(3, result!.Data);

        var links = await GetLinksAsync();
        TestAssertions.AssertEqual(3, links.Count);
        TestAssertions.AssertTrue(links.All(l => l.IsActive));
        TestAssertions.AssertTrue(links.Any(l => l.CategoryId == _rootId));
        TestAssertions.AssertTrue(links.Any(l => l.CategoryId == _childId));
        TestAssertions.AssertTrue(links.Any(l => l.CategoryId == _grandchildId));
    }

    [Fact]
    public async Task DeactivateRoot_DeactivatesDescendantsAndEnqueuesDeletes()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // Arrange: whole chain active with remote ids (as if exported already).
        await PutAsJsonAsync("/api/v1/Categories/channels", BuildUpdate((_grandchildId, _channelId, true)));
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        foreach (var link in await DbContext.CategorySalesChannel.IgnoreQueryFilters()
                     .Where(l => l.SalesChannelId == _channelId).ToListAsync())
        {
            link.RemoteCategoryId = $"remote-{link.CategoryId:N}";
        }
        await DbContext.SaveChangesAsync();
        TenantContext.SetCurrentTenantId(currentTenant);

        var response = await PutAsJsonAsync("/api/v1/Categories/channels", BuildUpdate((_rootId, _channelId, false)));

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<int>>(response);
        TestAssertions.AssertEqual(3, result!.Data);

        var links = await GetLinksAsync();
        TestAssertions.AssertEqual(3, links.Count);
        TestAssertions.AssertTrue(links.All(l => !l.IsActive));

        var deleteRows = await DbContext.ChannelExportOutbox.IgnoreQueryFilters()
            .Where(o => o.SalesChannelId == _channelId && o.Operation == ChannelSyncOperation.DeleteCategory)
            .ToListAsync();
        TestAssertions.AssertEqual(3, deleteRows.Count);
    }

    [Fact]
    public async Task DeactivateCellWithoutRow_IsANoOp()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync("/api/v1/Categories/channels", BuildUpdate((_rootId, _channelId, false)));

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<int>>(response);
        TestAssertions.AssertEqual(0, result!.Data);
        TestAssertions.AssertEqual(0, (await GetLinksAsync()).Count);
    }

    [Fact]
    public async Task UnknownCategoryId_IsIgnored()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync("/api/v1/Categories/channels", BuildUpdate((Guid.NewGuid(), _channelId, true)));

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<int>>(response);
        TestAssertions.AssertEqual(0, result!.Data);
    }

    [Fact]
    public async Task CategoryFromOtherTenant_IsIgnored()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await PutAsJsonAsync("/api/v1/Categories/channels", BuildUpdate((_rootId, _channelId, true)));

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<int>>(response);
        TestAssertions.AssertEqual(0, result!.Data);
        TestAssertions.AssertEqual(0, (await GetLinksAsync()).Count);
    }

    [Fact]
    public async Task AsShopChannel_ActivatesRowButEnqueuesNothing()
    {
        await SeedAsync(SalesChannelType.AsShop);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync("/api/v1/Categories/channels", BuildUpdate((_rootId, _channelId, true)));

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var links = await GetLinksAsync();
        TestAssertions.AssertEqual(1, links.Count);
        TestAssertions.AssertTrue(links[0].IsActive);

        // The asShop connector declares no capabilities — the storefront reads the row directly,
        // so no outbox row may pile up.
        var outboxRows = await DbContext.ChannelExportOutbox.IgnoreQueryFilters()
            .Where(o => o.SalesChannelId == _channelId)
            .ToListAsync();
        TestAssertions.AssertEqual(0, outboxRows.Count);
    }
}
