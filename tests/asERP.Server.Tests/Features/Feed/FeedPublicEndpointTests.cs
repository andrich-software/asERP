#nullable disable
using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Feed;

/// <summary>
/// The anonymous public feed endpoint (/feed/{id}). No auth or X-Tenant-Id: the tenant is resolved
/// server-side from the feed row. Covers rendering, access logging, 404s and tenant scoping.
/// </summary>
public class FeedPublicEndpointTests : TenantIsolatedTestBase
{
    private async Task<asERP.Domain.Entities.Feed> SeedFeedAsync(Guid tenantId, string name, FeedTemplate template, bool enabled = true)
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

    private async Task<asERP.Domain.Entities.Product> SeedProductAsync(Guid tenantId, string sku, string name)
    {
        var product = new asERP.Domain.Entities.Product
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            Sku = sku,
            Name = name,
            Price = 12.34m,
            TaxClassId = Guid.NewGuid(),
        };
        DbContext.Product.Add(product);
        await DbContext.SaveChangesAsync();
        return product;
    }

    private void GoAnonymous()
    {
        SimulateUnauthenticatedRequest();
        RemoveTenantHeader();
    }

    [Fact]
    public async Task GoogleFeed_RendersRssXml_AndLogsAccess()
    {
        var feed = await SeedFeedAsync(TenantConstants.TestTenant1Id, "Google", FeedTemplate.GoogleProducts);
        await SeedProductAsync(TenantConstants.TestTenant1Id, "SKU-XML-1", "Xml Product");
        GoAnonymous();

        var response = await Client.GetAsync($"/feed/{feed.Id}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/xml", response.Content.Headers.ContentType?.MediaType);
        var body = await ReadResponseStringAsync(response);
        Assert.Contains("<rss", body);
        Assert.Contains("http://base.google.com/ns/1.0", body);
        Assert.Contains("SKU-XML-1", body);
        Assert.Contains("12.34 EUR", body);

        var logCount = await DbContext.FeedLog.IgnoreQueryFilters().CountAsync(l => l.FeedId == feed.Id);
        Assert.True(logCount >= 1);
    }

    [Fact]
    public async Task IdealoFeed_RendersCsv()
    {
        var feed = await SeedFeedAsync(TenantConstants.TestTenant1Id, "Idealo", FeedTemplate.Idealo);
        await SeedProductAsync(TenantConstants.TestTenant1Id, "SKU-CSV-1", "Csv Product");
        GoAnonymous();

        var response = await Client.GetAsync($"/feed/{feed.Id}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("text/csv", response.Content.Headers.ContentType?.MediaType);
        var body = await ReadResponseStringAsync(response);
        Assert.Contains("sku,title,brand", body);
        Assert.Contains("SKU-CSV-1", body);
    }

    [Fact]
    public async Task UnknownFeedId_Returns404()
    {
        GoAnonymous();

        var response = await Client.GetAsync($"/feed/{Guid.NewGuid()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DisabledFeed_Returns404()
    {
        var feed = await SeedFeedAsync(TenantConstants.TestTenant1Id, "Disabled", FeedTemplate.GoogleProducts, enabled: false);
        GoAnonymous();

        var response = await Client.GetAsync($"/feed/{feed.Id}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task ExcludedProduct_IsNotInOutput()
    {
        var feed = await SeedFeedAsync(TenantConstants.TestTenant1Id, "Google", FeedTemplate.GoogleProducts);
        await SeedProductAsync(TenantConstants.TestTenant1Id, "KEEP-SKU", "Keep");
        var drop = await SeedProductAsync(TenantConstants.TestTenant1Id, "DROP-SKU", "Drop");
        DbContext.FeedProduct.Add(new asERP.Domain.Entities.FeedProduct
        {
            Id = Guid.NewGuid(), TenantId = TenantConstants.TestTenant1Id, FeedId = feed.Id, ProductId = drop.Id, IsActive = false
        });
        await DbContext.SaveChangesAsync();
        GoAnonymous();

        var body = await ReadResponseStringAsync(await Client.GetAsync($"/feed/{feed.Id}"));

        Assert.Contains("KEEP-SKU", body);
        Assert.DoesNotContain("DROP-SKU", body);
    }

    [Fact]
    public async Task Feed_OnlyIncludesOwningTenantsProducts()
    {
        var feed = await SeedFeedAsync(TenantConstants.TestTenant1Id, "Google", FeedTemplate.GoogleProducts);
        await SeedProductAsync(TenantConstants.TestTenant1Id, "T1-ONLY-SKU", "Tenant 1 Product");
        await SeedProductAsync(TenantConstants.TestTenant2Id, "T2-ONLY-SKU", "Tenant 2 Product");
        GoAnonymous();

        var body = await ReadResponseStringAsync(await Client.GetAsync($"/feed/{feed.Id}"));

        Assert.Contains("T1-ONLY-SKU", body);
        Assert.DoesNotContain("T2-ONLY-SKU", body);
    }
}
