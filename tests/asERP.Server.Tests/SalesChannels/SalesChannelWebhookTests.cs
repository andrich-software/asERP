using System.Net;
using System.Security.Cryptography;
using System.Text;
using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Covers the anonymous webhook ingest endpoint: a correctly signed webhook enqueues a Queued import
/// run (never importing the payload directly), invalid signatures are rejected, channels without a
/// configured secret behave like unknown channels, and the tenant is resolved from the channel row.
/// </summary>
public class SalesChannelWebhookTests : TenantIsolatedTestBase
{
    private const string Secret = "test-webhook-secret";

    private async Task<SalesChannel> SeedChannelAsync(string? secret = Secret)
    {
        var channel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            TenantId = TenantConstants.TestTenant1Id,
            Type = SalesChannelType.WooCommerce,
            Name = "webhook-shop",
            Url = "https://shop.example/wp-json/wc/v3",
            Username = "key",
            Password = "secret",
            IsEnabled = true,
            WebhookSecret = secret,
        };
        DbContext.SalesChannel.Add(channel);
        await DbContext.SaveChangesAsync();
        return channel;
    }

    private static StringContent SignedBody(string body, string secret)
    {
        var content = new StringContent(body, Encoding.UTF8, "application/json");
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        content.Headers.Add("X-WC-Webhook-Signature", Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(body))));
        return content;
    }

    [Fact]
    public async Task ValidWooSignature_EnqueuesQueuedSalesRun_WithChannelTenant()
    {
        var channel = await SeedChannelAsync();
        SimulateUnauthenticatedRequest();
        RemoveTenantHeader();

        var response = await Client.PostAsync($"/api/v1/webhooks/saleschannels/{channel.Id}/order", SignedBody("{\"id\":123}", Secret));

        TestAssertions.AssertHttpSuccess(response);
        var run = await DbContext.ChannelSyncRun.IgnoreQueryFilters()
            .SingleAsync(r => r.SalesChannelId == channel.Id);
        Assert.Equal(ChannelSyncRunStatus.Queued, run.Status);
        Assert.Equal(ChannelSyncOperation.ImportSaless, run.Operation);
        Assert.Equal(ChannelSyncTriggerSource.Event, run.TriggerSource);
        // Tenant comes from the channel row, never from headers (there were none).
        Assert.Equal(TenantConstants.TestTenant1Id, run.TenantId);
    }

    [Fact]
    public async Task ProductEvent_EnqueuesStockMirrorRun()
    {
        var channel = await SeedChannelAsync();
        SimulateUnauthenticatedRequest();
        RemoveTenantHeader();

        var response = await Client.PostAsync($"/api/v1/webhooks/saleschannels/{channel.Id}/product", SignedBody("{}", Secret));

        TestAssertions.AssertHttpSuccess(response);
        var run = await DbContext.ChannelSyncRun.IgnoreQueryFilters()
            .SingleAsync(r => r.SalesChannelId == channel.Id);
        Assert.Equal(ChannelSyncOperation.ImportStock, run.Operation);
    }

    [Fact]
    public async Task DuplicateWebhooks_CoalesceIntoOneQueuedRun()
    {
        var channel = await SeedChannelAsync();
        SimulateUnauthenticatedRequest();
        RemoveTenantHeader();

        await Client.PostAsync($"/api/v1/webhooks/saleschannels/{channel.Id}/order", SignedBody("{\"id\":1}", Secret));
        await Client.PostAsync($"/api/v1/webhooks/saleschannels/{channel.Id}/order", SignedBody("{\"id\":2}", Secret));

        Assert.Equal(1, await DbContext.ChannelSyncRun.IgnoreQueryFilters()
            .CountAsync(r => r.SalesChannelId == channel.Id && r.Status == ChannelSyncRunStatus.Queued));
    }

    [Fact]
    public async Task InvalidSignature_Returns401_AndEnqueuesNothing()
    {
        var channel = await SeedChannelAsync();
        SimulateUnauthenticatedRequest();
        RemoveTenantHeader();

        var response = await Client.PostAsync($"/api/v1/webhooks/saleschannels/{channel.Id}/order", SignedBody("{}", "wrong-secret"));

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Equal(0, await DbContext.ChannelSyncRun.IgnoreQueryFilters().CountAsync(r => r.SalesChannelId == channel.Id));
    }

    [Fact]
    public async Task ChannelWithoutSecret_Returns404()
    {
        var channel = await SeedChannelAsync(secret: null);
        SimulateUnauthenticatedRequest();
        RemoveTenantHeader();

        var response = await Client.PostAsync($"/api/v1/webhooks/saleschannels/{channel.Id}/order", SignedBody("{}", Secret));

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task TokenHeader_IsAcceptedAsAlternativeToSignature()
    {
        var channel = await SeedChannelAsync();
        SimulateUnauthenticatedRequest();
        RemoveTenantHeader();

        var content = new StringContent("{}", Encoding.UTF8, "application/json");
        content.Headers.Add("X-Webhook-Token", Secret);
        var response = await Client.PostAsync($"/api/v1/webhooks/saleschannels/{channel.Id}/order", content);

        TestAssertions.AssertHttpSuccess(response);
    }
}
