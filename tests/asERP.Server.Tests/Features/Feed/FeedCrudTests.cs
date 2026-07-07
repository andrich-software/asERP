#nullable disable
using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Feed;

/// <summary>
/// CRUD, tenant isolation and validation for the authenticated Feeds API (/api/v1/feeds), plus the
/// per-feed product selection (all products included by default; an exclusion row opts one out).
/// </summary>
public class FeedCrudTests : TenantIsolatedTestBase
{
    private async Task<asERP.Domain.Entities.Feed> SeedFeedAsync(Guid tenantId, string name, FeedTemplate template = FeedTemplate.GoogleProducts, bool enabled = true)
    {
        var feed = new asERP.Domain.Entities.Feed
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            Name = name,
            Template = template,
            Currency = "EUR",
            IsEnabled = enabled,
        };
        DbContext.Feed.Add(feed);
        await DbContext.SaveChangesAsync();
        return feed;
    }

    private async Task<asERP.Domain.Entities.Product> SeedProductAsync(Guid tenantId, string sku, string name, decimal price = 9.99m)
    {
        var product = new asERP.Domain.Entities.Product
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            Sku = sku,
            Name = name,
            Price = price,
            TaxClassId = Guid.NewGuid(),
        };
        DbContext.Product.Add(product);
        await DbContext.SaveChangesAsync();
        return product;
    }

    private async Task<asERP.Domain.Entities.SalesChannel> SeedChannelAsync(Guid tenantId, SalesChannelType type, string name)
    {
        var channel = new asERP.Domain.Entities.SalesChannel
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            Type = type,
            Name = name,
            Url = "https://shop.example.com",
            Username = string.Empty,
            Password = string.Empty,
        };
        DbContext.SalesChannel.Add(channel);
        await DbContext.SaveChangesAsync();
        return channel;
    }

    [Fact]
    public async Task Create_WithValidTenant_PersistsFeedForThatTenant()
    {
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = new FeedInputDto { Name = "Google Feed", Template = FeedTemplate.GoogleProducts, Currency = "EUR" };
        var response = await PostAsJsonAsync("/api/v1/feeds", input);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        Assert.True(result.Succeeded);
        Assert.NotEqual(Guid.Empty, result.Data);

        var persisted = await DbContext.Feed.IgnoreQueryFilters().FirstOrDefaultAsync(f => f.Id == result.Data);
        Assert.NotNull(persisted);
        Assert.Equal(TenantConstants.TestTenant1Id, persisted.TenantId);
    }

    [Fact]
    public async Task List_IsTenantIsolated()
    {
        await SeedFeedAsync(TenantConstants.TestTenant1Id, "Feed T1");
        await SeedFeedAsync(TenantConstants.TestTenant2Id, "Feed T2");

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync("/api/v1/feeds");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<PaginatedResult<FeedListDto>>(response);
        Assert.Single(result.Data);
        Assert.Equal("Feed T1", result.Data[0].Name);
    }

    [Fact]
    public async Task GetDetails_CrossTenant_Returns404()
    {
        var t2Feed = await SeedFeedAsync(TenantConstants.TestTenant2Id, "Foreign Feed");

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/feeds/{t2Feed.Id}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task List_WithoutTenantHeader_ReturnsEmpty()
    {
        await SeedFeedAsync(TenantConstants.TestTenant1Id, "Feed T1");
        RemoveTenantHeader();

        var response = await Client.GetAsync("/api/v1/feeds");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<PaginatedResult<FeedListDto>>(response);
        Assert.Empty(result.Data);
    }

    [Fact]
    public async Task List_WithMalformedTenantHeader_Returns401()
    {
        SetInvalidTenantHeaderValue("not-a-guid");

        var response = await Client.GetAsync("/api/v1/feeds");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Update_ChangesNameAndTemplate()
    {
        var feed = await SeedFeedAsync(TenantConstants.TestTenant1Id, "Original");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = new FeedInputDto { Id = feed.Id, Name = "Renamed", Template = FeedTemplate.Pinterest, Currency = "USD" };
        var response = await PutAsJsonAsync($"/api/v1/feeds/{feed.Id}", input);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        // AsNoTracking: the seeded feed is tracked in this test scope; force a fresh read of the
        // server-committed values from the shared InMemory store instead of the stale tracked instance.
        var persisted = await DbContext.Feed.IgnoreQueryFilters().AsNoTracking().FirstAsync(f => f.Id == feed.Id);
        Assert.Equal("Renamed", persisted.Name);
        Assert.Equal(FeedTemplate.Pinterest, persisted.Template);
        Assert.Equal("USD", persisted.Currency);
    }

    [Fact]
    public async Task Delete_RemovesFeedAndItsChildren()
    {
        var feed = await SeedFeedAsync(TenantConstants.TestTenant1Id, "Doomed");
        DbContext.FeedProduct.Add(new asERP.Domain.Entities.FeedProduct
        {
            Id = Guid.NewGuid(), TenantId = TenantConstants.TestTenant1Id, FeedId = feed.Id, ProductId = Guid.NewGuid(), IsActive = false
        });
        DbContext.FeedLog.Add(new asERP.Domain.Entities.FeedLog
        {
            Id = Guid.NewGuid(), TenantId = TenantConstants.TestTenant1Id, FeedId = feed.Id, IpAddress = "1.2.3.4"
        });
        await DbContext.SaveChangesAsync();

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.DeleteAsync($"/api/v1/feeds/{feed.Id}");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.False(await DbContext.Feed.IgnoreQueryFilters().AnyAsync(f => f.Id == feed.Id));
        Assert.Equal(0, await DbContext.FeedProduct.IgnoreQueryFilters().CountAsync(fp => fp.FeedId == feed.Id));
        Assert.Equal(0, await DbContext.FeedLog.IgnoreQueryFilters().CountAsync(l => l.FeedId == feed.Id));
    }

    [Fact]
    public async Task Create_LinkedToNonShopwareWooChannel_Returns400()
    {
        var channel = await SeedChannelAsync(TenantConstants.TestTenant1Id, SalesChannelType.PointOfSale, "POS");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = new FeedInputDto { Name = "Bad link", Template = FeedTemplate.GoogleProducts, Currency = "EUR", SalesChannelId = channel.Id };
        var response = await PostAsJsonAsync("/api/v1/feeds", input);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Create_LinkedToWooCommerceChannel_Succeeds()
    {
        var channel = await SeedChannelAsync(TenantConstants.TestTenant1Id, SalesChannelType.WooCommerce, "Woo");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var input = new FeedInputDto { Name = "Good link", Template = FeedTemplate.GoogleProducts, Currency = "EUR", SalesChannelId = channel.Id };
        var response = await PostAsJsonAsync("/api/v1/feeds", input);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task ProductSelection_AllProductsActiveByDefault()
    {
        var feed = await SeedFeedAsync(TenantConstants.TestTenant1Id, "Feed");
        await SeedProductAsync(TenantConstants.TestTenant1Id, "SKU-A", "Prod A");
        await SeedProductAsync(TenantConstants.TestTenant1Id, "SKU-B", "Prod B");

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/feeds/{feed.Id}/products");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<PaginatedResult<FeedProductSelectionDto>>(response);
        Assert.Equal(2, result.Data.Count);
        Assert.All(result.Data, p => Assert.True(p.IsActive));
    }

    [Fact]
    public async Task ProductSelection_DeselectExcludesProductAndLowersCount()
    {
        var feed = await SeedFeedAsync(TenantConstants.TestTenant1Id, "Feed");
        var keep = await SeedProductAsync(TenantConstants.TestTenant1Id, "SKU-KEEP", "Keep");
        var drop = await SeedProductAsync(TenantConstants.TestTenant1Id, "SKU-DROP", "Drop");

        SetTenantHeader(TenantConstants.TestTenant1Id);

        var update = new FeedProductSelectionUpdateDto
        {
            Changes = new List<FeedProductSelectionChange> { new() { ProductId = drop.Id, IsActive = false } }
        };
        var putResponse = await PutAsJsonAsync($"/api/v1/feeds/{feed.Id}/products", update);
        Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);

        var listResponse = await Client.GetAsync($"/api/v1/feeds/{feed.Id}/products");
        var list = await ReadResponseAsync<PaginatedResult<FeedProductSelectionDto>>(listResponse);
        Assert.True(list.Data.Single(p => p.ProductId == keep.Id).IsActive);
        Assert.False(list.Data.Single(p => p.ProductId == drop.Id).IsActive);

        var detailResponse = await Client.GetAsync($"/api/v1/feeds/{feed.Id}");
        var detail = await ReadResponseAsync<Result<FeedDetailDto>>(detailResponse);
        Assert.Equal(1, detail.Data.ProductCount);
    }
}
