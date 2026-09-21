using asERP.Domain.Constants;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// The four readers of <c>ChannelSyncRun.ErrorSummary</c> — GET sync-runs, GET sync-runs/{runId},
/// GET sync-status (as LastErrorSummary) and the POST sync/{operation} response — plus GET sync-logs,
/// which serves the captured exception text of the same run. All carry a bare <c>[Authorize]</c>, so
/// whatever a connector writes into those columns is readable by any authenticated user of the owning
/// tenant; these tests pin that the text they hand back is the sanitised one, and that the two readers
/// which used to select by route id alone now refuse another tenant's channel.
/// </summary>
public class SalesChannelSyncRunReaderTests : TenantIsolatedTestBase
{
    // Stands in for what a connector now produces for an unreachable host: no target, no outcome.
    private const string SanitizedSummary =
        "Could not connect to the MySQL server with these settings. The server log holds the details.";

    private async Task<(Guid ChannelId, Guid RunId)> SeedFailedRunAsync(Guid tenantId, string? errorSummary)
    {
        var channel = await DbContext.SalesChannel
            .IgnoreQueryFilters()
            .FirstAsync(c => c.TenantId == tenantId);

        var run = new ChannelSyncRun
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            SalesChannelId = channel.Id,
            Operation = ChannelSyncOperation.ImportProducts,
            TriggerSource = ChannelSyncTriggerSource.Manual,
            Status = ChannelSyncRunStatus.Failed,
            StartedAt = DateTime.UtcNow.AddMinutes(-1),
            FinishedAt = DateTime.UtcNow,
            ErrorSummary = errorSummary,
            CorrelationId = Guid.NewGuid(),
        };

        DbContext.ChannelSyncRun.Add(run);
        await DbContext.SaveChangesAsync();
        return (channel.Id, run.Id);
    }

    // --- What the readers hand back ----------------------------------------------------------------

    [Fact]
    public async Task SyncRunsList_ReturnsTheStoredSummary()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var (channelId, _) = await SeedFailedRunAsync(TenantConstants.TestTenant1Id, SanitizedSummary);

        var response = await Client.GetAsync($"/api/v1/saleschannels/{channelId}/sync-runs");

        TestAssertions.AssertHttpSuccess(response);
        var body = await ReadResponseStringAsync(response);
        Assert.Contains("The server log holds the details.", body, StringComparison.Ordinal);
    }

    [Fact]
    public async Task SingleSyncRun_ReturnsTheStoredSummary_AndTheCorrelationIdToJoinTheLogOn()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var (channelId, runId) = await SeedFailedRunAsync(TenantConstants.TestTenant1Id, SanitizedSummary);

        var response = await Client.GetAsync($"/api/v1/saleschannels/{channelId}/sync-runs/{runId}");

        TestAssertions.AssertHttpSuccess(response);
        var run = await ReadResponseAsync<ChannelSyncRunDto>(response);
        Assert.Equal(SanitizedSummary, run.ErrorSummary);
        // The operator's half of the trade: this is the value the server log carries as
        // SyncRunCorrelationId, so a support request can name the run that failed.
        Assert.NotEqual(Guid.Empty, run.CorrelationId);
    }

    [Fact]
    public async Task SyncStatus_ReturnsTheStoredSummaryAsLastErrorSummary()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var (channelId, _) = await SeedFailedRunAsync(TenantConstants.TestTenant1Id, SanitizedSummary);

        var response = await Client.GetAsync($"/api/v1/saleschannels/{channelId}/sync-status");

        TestAssertions.AssertHttpSuccess(response);
        var body = await ReadResponseStringAsync(response);
        Assert.Contains("The server log holds the details.", body, StringComparison.Ordinal);
    }

    [Fact]
    public async Task ManualSync_EchoesTheSummaryOfTheRunItCoalescesOnto()
    {
        // The fourth reader: the 202 body carries the ErrorSummary of whichever run the trigger
        // adopted, so the same column is exposed once more on the write path.
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var channel = await DbContext.SalesChannel
            .IgnoreQueryFilters()
            .FirstAsync(c => c.TenantId == TenantConstants.TestTenant1Id);

        DbContext.ChannelSyncRun.Add(new ChannelSyncRun
        {
            Id = Guid.NewGuid(),
            TenantId = TenantConstants.TestTenant1Id,
            SalesChannelId = channel.Id,
            Operation = ChannelSyncOperation.ImportProducts,
            TriggerSource = ChannelSyncTriggerSource.Manual,
            Status = ChannelSyncRunStatus.Queued,
            StartedAt = DateTime.UtcNow,
            ErrorSummary = SanitizedSummary,
            CorrelationId = Guid.NewGuid(),
        });
        await DbContext.SaveChangesAsync();

        var response = await Client.PostAsync($"/api/v1/saleschannels/{channel.Id}/sync/products", null);

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<SalesChannelSyncResultDto>(response);
        Assert.Equal(SanitizedSummary, result.ErrorSummary);
    }

    // --- Cross-tenant ------------------------------------------------------------------------------
    //
    // These endpoints used to select by route id with the EF global query filter as their only guard,
    // while their siblings resolved the channel through FindTenantChannelAsync first. The filter alone
    // answers a foreign channel id with an empty 200 on the list readers; the ownership check answers
    // 404 — so the status asserted below is the new guard talking, not the filter. The check also
    // covers what the filter by design does not: a row whose TenantId is null is visible to every
    // tenant.

    [Fact]
    public async Task SyncRunsList_OfAnotherTenantsChannel_IsRefused()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var (foreignChannelId, _) = await SeedFailedRunAsync(TenantConstants.TestTenant2Id, "tenant-2 secret");

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/saleschannels/{foreignChannelId}/sync-runs");

        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        Assert.DoesNotContain("tenant-2 secret", await ReadResponseStringAsync(response), StringComparison.Ordinal);
    }

    [Fact]
    public async Task SingleSyncRun_OfAnotherTenantsChannel_IsRefused()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var (foreignChannelId, foreignRunId) = await SeedFailedRunAsync(TenantConstants.TestTenant2Id, "tenant-2 secret");

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/saleschannels/{foreignChannelId}/sync-runs/{foreignRunId}");

        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        Assert.DoesNotContain("tenant-2 secret", await ReadResponseStringAsync(response), StringComparison.Ordinal);
    }

    [Fact]
    public async Task SyncLogs_OfAnotherTenantsChannel_AreRefused()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var foreignChannel = await DbContext.SalesChannel
            .IgnoreQueryFilters()
            .FirstAsync(c => c.TenantId == TenantConstants.TestTenant2Id);

        DbContext.ChannelSyncLog.Add(new ChannelSyncLog
        {
            Id = Guid.NewGuid(),
            TenantId = TenantConstants.TestTenant2Id,
            SalesChannelId = foreignChannel.Id,
            CorrelationId = Guid.NewGuid(),
            Operation = ChannelSyncOperation.ImportProducts,
            Level = ChannelSyncLogLevel.Error,
            Message = "tenant-2 secret",
            Timestamp = DateTime.UtcNow,
        });
        await DbContext.SaveChangesAsync();

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/saleschannels/{foreignChannel.Id}/sync-logs");

        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        Assert.DoesNotContain("tenant-2 secret", await ReadResponseStringAsync(response), StringComparison.Ordinal);
    }

    [Fact]
    public async Task DeadLetterOutbox_OfAnotherTenantsChannel_IsRefused()
    {
        // ChannelExportOutbox.LastError is written from ExportResult.Fail(ex.Message) — the same
        // failure text as a sync run's, by the export route.
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var foreignChannelId = await SeedDeadLetterAsync(TenantConstants.TestTenant2Id, "tenant-2 secret");

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/saleschannels/{foreignChannelId}/outbox/dead-letter");

        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        Assert.DoesNotContain("tenant-2 secret", await ReadResponseStringAsync(response), StringComparison.Ordinal);
    }

    [Fact]
    public async Task RetryingAnotherTenantsDeadLetterRow_IsRefusedAndChangesNothing()
    {
        // The seeded row carries a normal TenantId, so the global filter already refused this before
        // the ownership check existed — the check is defence in depth for a null-TenantId row, which
        // nothing can persist any more. Pinned because this one is a mutation: a row the filter let
        // through would be re-queued, not merely read.
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var foreignChannelId = await SeedDeadLetterAsync(TenantConstants.TestTenant2Id, "tenant-2 secret");
        var row = await DbContext.ChannelExportOutbox.IgnoreQueryFilters()
            .FirstAsync(o => o.SalesChannelId == foreignChannelId);

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.PostAsync(
            $"/api/v1/saleschannels/{foreignChannelId}/outbox/{row.Id}/retry", null);

        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);

        DbContext.ChangeTracker.Clear();
        var after = await DbContext.ChannelExportOutbox.IgnoreQueryFilters().FirstAsync(o => o.Id == row.Id);
        Assert.Equal(ChannelOutboxStatus.DeadLetter, after.Status);
        Assert.Equal("tenant-2 secret", after.LastError);
    }

    private async Task<Guid> SeedDeadLetterAsync(Guid tenantId, string lastError)
    {
        var channel = await DbContext.SalesChannel
            .IgnoreQueryFilters()
            .FirstAsync(c => c.TenantId == tenantId);

        DbContext.ChannelExportOutbox.Add(new ChannelExportOutbox
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            SalesChannelId = channel.Id,
            Operation = ChannelSyncOperation.ExportProduct,
            AggregateType = ChannelOutboxAggregateType.Product,
            AggregateId = Guid.NewGuid(),
            IdempotencyKey = $"export:product:{Guid.NewGuid()}:{channel.Id}",
            AttemptCount = 10,
            NextAttemptAt = DateTime.UtcNow,
            Status = ChannelOutboxStatus.DeadLetter,
            LastError = lastError,
        });
        await DbContext.SaveChangesAsync();
        return channel.Id;
    }

    [Fact]
    public async Task SyncRunsList_OfAChannelThatDoesNotExist_AnswersLikeAForeignOne()
    {
        // Same status for "not yours" and "not there" — otherwise the reader enumerates channel ids.
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/saleschannels/{Guid.NewGuid()}/sync-runs");

        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}
