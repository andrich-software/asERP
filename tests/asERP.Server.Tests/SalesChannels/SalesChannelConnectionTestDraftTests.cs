using asERP.Domain.Constants;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Covers the ad-hoc connection test endpoint (POST /saleschannels/test-connection) used by the
/// create wizard: it validates user-entered credentials against the connector before the channel
/// exists, returns the connector verdict instead of throwing, and persists nothing.
/// </summary>
public class SalesChannelConnectionTestDraftTests : TenantIsolatedTestBase
{
    private static SalesChannelConnectionTestInputDto UnreachableShopware6Input() => new()
    {
        SalesChannelType = SalesChannelType.Shopware6,
        // Nothing listens on port 9 — the connector's HTTP call fails fast and is reported
        // as an unsuccessful test result, not as an exception.
        Url = "https://127.0.0.1:9/api",
        Username = "user",
        Password = "secret",
    };

    [Fact]
    public async Task UnreachableChannel_Returns200WithFailedVerdict()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/saleschannels/test-connection", UnreachableShopware6Input());

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<SalesChannelConnectionTestResultDto>(response);
        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.False(string.IsNullOrWhiteSpace(result.Message));
    }

    [Fact]
    public async Task DraftTest_PersistsNoChannelAndNoSyncRun()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var channelsBefore = await DbContext.SalesChannel.IgnoreQueryFilters().CountAsync();
        var runsBefore = await DbContext.ChannelSyncRun.IgnoreQueryFilters().CountAsync();

        var response = await PostAsJsonAsync("/api/v1/saleschannels/test-connection", UnreachableShopware6Input());

        TestAssertions.AssertHttpSuccess(response);
        Assert.Equal(channelsBefore, await DbContext.SalesChannel.IgnoreQueryFilters().CountAsync());
        Assert.Equal(runsBefore, await DbContext.ChannelSyncRun.IgnoreQueryFilters().CountAsync());
    }

    // Note: no unauthenticated-rejection test — the Testing host maps all controllers with
    // AllowAnonymous (see Program.cs), so the [Authorize] guard on the controller is not
    // exercisable through the test harness.
}
