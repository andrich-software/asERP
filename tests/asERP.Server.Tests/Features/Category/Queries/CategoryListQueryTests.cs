using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Category.Queries;

/// <summary>
/// The unpaginated category list: full tenant set with per-channel activation states and
/// product counts; strict tenant isolation.
/// </summary>
public class CategoryListQueryTests : TenantIsolatedTestBase
{
    private Guid _rootId;
    private Guid _childId;
    private Guid _channelId;
    private Guid _tenant2CategoryId;

    private async Task SeedAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        _rootId = Guid.NewGuid();
        _childId = Guid.NewGuid();
        _channelId = Guid.NewGuid();
        _tenant2CategoryId = Guid.NewGuid();

        try
        {
            await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

            DbContext.SalesChannel.Add(new asERP.Domain.Entities.SalesChannel
            {
                Id = _channelId,
                Type = SalesChannelType.AsShop,
                Name = "List Test Shop",
                Url = "https://shop.example.com",
                Username = "u",
                Password = "p",
                IsEnabled = true,
                TenantId = TenantConstants.TestTenant1Id,
                SyncState = new SalesChannelSyncState { TenantId = TenantConstants.TestTenant1Id }
            });

            DbContext.Category.AddRange(
                new asERP.Domain.Entities.Category
                {
                    Id = _rootId,
                    Name = "Root",
                    Slug = "root",
                    SortOrder = 1,
                    TenantId = TenantConstants.TestTenant1Id
                },
                new asERP.Domain.Entities.Category
                {
                    Id = _childId,
                    Name = "Child",
                    Slug = "child",
                    ParentCategoryId = _rootId,
                    SortOrder = 2,
                    TenantId = TenantConstants.TestTenant1Id
                },
                new asERP.Domain.Entities.Category
                {
                    Id = _tenant2CategoryId,
                    Name = "Tenant2 Category",
                    Slug = "tenant2-category",
                    TenantId = TenantConstants.TestTenant2Id
                });

            DbContext.CategorySalesChannel.Add(new CategorySalesChannel
            {
                Id = Guid.NewGuid(),
                CategoryId = _rootId,
                SalesChannelId = _channelId,
                IsActive = true,
                TenantId = TenantConstants.TestTenant1Id
            });

            DbContext.ProductCategory.Add(new ProductCategory
            {
                Id = Guid.NewGuid(),
                CategoryId = _childId,
                ProductId = Guid.NewGuid(),
                TenantId = TenantConstants.TestTenant1Id
            });

            await DbContext.SaveChangesAsync();
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    [Fact]
    public async Task GetCategories_ReturnsTenantSetWithChannelStatesAndProductCounts()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Categories");

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<List<CategoryListDto>>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(2, result.Data!.Count);

        var root = result.Data.First(c => c.Id == _rootId);
        TestAssertions.AssertEqual("Root", root.Name);
        TestAssertions.AssertNull(root.ParentCategoryId);
        TestAssertions.AssertEqual(0, root.ProductCount);
        TestAssertions.AssertEqual(1, root.Channels.Count);
        TestAssertions.AssertEqual(_channelId, root.Channels[0].SalesChannelId);
        TestAssertions.AssertTrue(root.Channels[0].IsActive);

        var child = result.Data.First(c => c.Id == _childId);
        TestAssertions.AssertEqual(_rootId, child.ParentCategoryId);
        TestAssertions.AssertEqual(1, child.ProductCount);
        TestAssertions.AssertEqual(0, child.Channels.Count);
    }

    [Fact]
    public async Task GetCategories_Tenant2_SeesOnlyOwnCategories()
    {
        await SeedAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync("/api/v1/Categories");

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<List<CategoryListDto>>>(response);
        TestAssertions.AssertNotNull(result?.Data);
        TestAssertions.AssertEqual(1, result!.Data!.Count);
        TestAssertions.AssertEqual(_tenant2CategoryId, result.Data[0].Id);
    }
}
