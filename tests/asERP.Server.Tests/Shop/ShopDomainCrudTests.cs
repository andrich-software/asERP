using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.ShopDomain;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Shop;

/// <summary>
/// CRUD + tenant isolation for the shop domain bindings API (/api/v1/shopdomains).
/// Host uniqueness is deliberately GLOBAL (cross-tenant) — the host is the security boundary
/// of anonymous tenant resolution.
/// </summary>
public class ShopDomainCrudTests : TenantIsolatedTestBase
{
    private async Task<SalesChannel> SeedChannelAsync(Guid tenantId, SalesChannelType type = SalesChannelType.AsShop)
    {
        TenantContext.SetCurrentTenantId(tenantId);

        var channel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            Name = $"{type} {Guid.NewGuid():N}",
            Type = type,
            TenantId = tenantId,
            SyncState = new SalesChannelSyncState { TenantId = tenantId }
        };

        DbContext.SalesChannel.Add(channel);
        await DbContext.SaveChangesAsync();
        return channel;
    }

    private static ShopDomainInputDto DomainInput(Guid salesChannelId, string host, int port = 0) => new()
    {
        SalesChannelId = salesChannelId,
        Host = host,
        Port = port,
        IsPrimary = false,
        RedirectToPrimary = true
    };

    [Fact]
    public async Task Create_NormalizesHostAndMakesFirstDomainPrimary()
    {
        var channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(channel.Id, "HTTPS://MeinShop.DE/"));

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        var domain = await DbContext.ShopDomain.AsNoTracking().SingleAsync(d => d.Id == result.Data);
        Assert.Equal("meinshop.de", domain.Host);
        Assert.True(domain.IsPrimary);
        Assert.Equal(TenantConstants.TestTenant1Id, domain.TenantId);
    }

    [Fact]
    public async Task Create_SecondDomainWithPrimaryFlag_DemotesFirst()
    {
        var channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(channel.Id, "erster.local"));

        var input = DomainInput(channel.Id, "zweiter.local");
        input.IsPrimary = true;
        var response = await PostAsJsonAsync("/api/v1/shopdomains", input);

        TestAssertions.AssertHttpSuccess(response);
        var domains = await DbContext.ShopDomain.AsNoTracking()
            .Where(d => d.SalesChannelId == channel.Id).ToListAsync();
        Assert.Equal(2, domains.Count);
        Assert.True(domains.Single(d => d.Host == "zweiter.local").IsPrimary);
        Assert.False(domains.Single(d => d.Host == "erster.local").IsPrimary);
    }

    [Theory]
    [InlineData("kein host")]
    [InlineData("shop.local:8080")]
    [InlineData("shop.local/pfad")]
    [InlineData("")]
    public async Task Create_InvalidHost_ReturnsBadRequest(string host)
    {
        var channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(channel.Id, host));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Create_OnNonShopChannel_ReturnsBadRequest()
    {
        var posChannel = await SeedChannelAsync(TenantConstants.TestTenant1Id, SalesChannelType.PointOfSale);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(posChannel.Id, "poshost.local"));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Create_DuplicateHost_IsRejectedGloballyAcrossTenants()
    {
        var tenant1Channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        var tenant2Channel = await SeedChannelAsync(TenantConstants.TestTenant2Id);

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var first = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(tenant1Channel.Id, "einzigartig.local"));
        TestAssertions.AssertHttpSuccess(first);

        // The SAME host on another tenant's channel must be rejected — one host, one shop, globally.
        SetTenantHeader(TenantConstants.TestTenant2Id);
        var second = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(tenant2Channel.Id, "einzigartig.local"));

        Assert.Equal(HttpStatusCode.BadRequest, second.StatusCode);
    }

    [Theory]
    // Shadow bindings on a host another channel already owns: wildcard vs. exact port, exact vs.
    // wildcard, and two different exact ports. Every shape resolves to the same host at request
    // time (ShopHostResolver prefers the exact-port row, else the port-0 row), so every shape
    // must be rejected — otherwise the foreign row hijacks the victim's storefront traffic.
    [InlineData(0, 443)]
    [InlineData(443, 0)]
    [InlineData(443, 80)]
    public async Task Create_ShadowBindingOnForeignTenantsHost_IsRejected(int ownerPort, int shadowPort)
    {
        var host = $"schatten-{ownerPort}-{shadowPort}.local";
        var tenant1Channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        var tenant2Channel = await SeedChannelAsync(TenantConstants.TestTenant2Id);

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var owner = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(tenant1Channel.Id, host, ownerPort));
        TestAssertions.AssertHttpSuccess(owner);

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var shadow = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(tenant2Channel.Id, host, shadowPort));

        Assert.Equal(HttpStatusCode.BadRequest, shadow.StatusCode);
        Assert.False(await DbContext.ShopDomain.AsNoTracking().IgnoreQueryFilters()
            .AnyAsync(d => d.Host == host && d.SalesChannelId == tenant2Channel.Id));
    }

    [Fact]
    public async Task Update_ToForeignTenantsHostOnAnotherPort_IsRejected()
    {
        var tenant1Channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        var tenant2Channel = await SeedChannelAsync(TenantConstants.TestTenant2Id);

        SetTenantHeader(TenantConstants.TestTenant1Id);
        TestAssertions.AssertHttpSuccess(
            await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(tenant1Channel.Id, "belegt.local", 443)));

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var createResponse = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(tenant2Channel.Id, "eigen.local"));
        var created = await ReadResponseAsync<Result<Guid>>(createResponse);

        var update = DomainInput(tenant2Channel.Id, "belegt.local", 80);
        update.Id = created.Data;
        update.IsPrimary = true;
        var response = await PutAsJsonAsync($"/api/v1/shopdomains/{created.Data}", update);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        var domain = await DbContext.ShopDomain.AsNoTracking().SingleAsync(d => d.Id == created.Data);
        Assert.Equal("eigen.local", domain.Host);
    }

    [Fact]
    public async Task Create_AdditionalPortOnOwnChannelsHost_IsAllowed()
    {
        var channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        TestAssertions.AssertHttpSuccess(
            await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(channel.Id, "mehrfach.local")));

        // The host already belongs to this channel — a second port on it is no takeover.
        var response = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(channel.Id, "mehrfach.local", 8080));

        TestAssertions.AssertHttpSuccess(response);
        Assert.Equal(2, await DbContext.ShopDomain.AsNoTracking()
            .CountAsync(d => d.Host == "mehrfach.local" && d.SalesChannelId == channel.Id));
    }

    [Fact]
    public async Task Create_OnForeignTenantsChannel_IsRejected()
    {
        var tenant1Channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);

        // Tenant 2 must not be able to bind a domain to tenant 1's channel — the channel is
        // invisible through the tenant filter, so validation reports it as non-existent.
        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(tenant1Channel.Id, "fremd.local"));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task List_ReturnsOnlyOwnTenantsDomains()
    {
        var tenant1Channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(tenant1Channel.Id, "sichtbar.local"));

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await Client.GetAsync($"/api/v1/shopdomains?salesChannelId={tenant1Channel.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<List<ShopDomainListDto>>>(response);
        Assert.NotNull(result.Data);
        Assert.Empty(result.Data);
    }

    [Fact]
    public async Task Update_ChangesHostAndKeepsNormalization()
    {
        var channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var createResponse = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(channel.Id, "alt.local"));
        var created = await ReadResponseAsync<Result<Guid>>(createResponse);

        var update = DomainInput(channel.Id, "NEU.LOCAL");
        update.Id = created.Data;
        update.IsPrimary = true;
        var response = await PutAsJsonAsync($"/api/v1/shopdomains/{created.Data}", update);

        TestAssertions.AssertHttpSuccess(response);
        var domain = await DbContext.ShopDomain.AsNoTracking().SingleAsync(d => d.Id == created.Data);
        Assert.Equal("neu.local", domain.Host);
        Assert.True(domain.IsPrimary);
    }

    [Fact]
    public async Task Delete_OfForeignTenantsDomain_ReturnsNotFound()
    {
        var tenant1Channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var createResponse = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(tenant1Channel.Id, "geschuetzt.local"));
        var created = await ReadResponseAsync<Result<Guid>>(createResponse);

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await Client.DeleteAsync($"/api/v1/shopdomains/{created.Data}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        SetTenantHeader(TenantConstants.TestTenant1Id);
        Assert.True(await DbContext.ShopDomain.AsNoTracking().AnyAsync(d => d.Id == created.Data));
    }

    [Fact]
    public async Task Delete_OfPrimaryDomain_PromotesRemainingDomain()
    {
        var channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var firstResponse = await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(channel.Id, "primaer.local"));
        var first = await ReadResponseAsync<Result<Guid>>(firstResponse);
        await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(channel.Id, "nachfolger.local"));

        var response = await Client.DeleteAsync($"/api/v1/shopdomains/{first.Data}");

        TestAssertions.AssertHttpSuccess(response);
        var remaining = await DbContext.ShopDomain.AsNoTracking()
            .Where(d => d.SalesChannelId == channel.Id).ToListAsync();
        var successor = Assert.Single(remaining);
        Assert.Equal("nachfolger.local", successor.Host);
        Assert.True(successor.IsPrimary);
    }

    [Fact]
    public async Task SalesChannelDelete_RemovesItsDomains()
    {
        var channel = await SeedChannelAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        await PostAsJsonAsync("/api/v1/shopdomains", DomainInput(channel.Id, "wegdamit.local"));

        var response = await Client.DeleteAsync($"/api/v1/saleschannels/{channel.Id}");

        TestAssertions.AssertHttpSuccess(response);
        Assert.False(await DbContext.ShopDomain.AsNoTracking()
            .IgnoreQueryFilters().AnyAsync(d => d.SalesChannelId == channel.Id));
    }
}
