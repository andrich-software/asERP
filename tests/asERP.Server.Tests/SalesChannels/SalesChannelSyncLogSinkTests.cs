using asERP.Domain.Enums;
using asERP.SalesChannels;
using asERP.SalesChannels.Logging;
using asERP.Server.Infrastructure.Logging;
using Serilog.Events;
using Serilog.Parsing;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// What this sink persists is not an internal log: <c>ChannelSyncLog</c> rows are served back by
/// <c>GET saleschannels/{id}/sync-logs</c>, message and full exception text included, to the same
/// authenticated tenant user who configured the channel. So the sink is the second place — next to
/// <c>ChannelSyncRun.ErrorSummary</c> — where a connect outcome for a caller-chosen host would reach
/// the caller. Transport failures are dropped here; everything a remote system said about the data
/// stays, because that is the diagnostic the sync-log view exists for.
/// </summary>
public class SalesChannelSyncLogSinkTests
{
    private static readonly MessageTemplateParser TemplateParser = new();
    private static readonly Guid ChannelId = Guid.NewGuid();
    private static readonly Guid CorrelationId = Guid.NewGuid();

    private static LogEvent Event(Exception? exception, string message = "sync line")
        => new(
            DateTimeOffset.UtcNow,
            LogEventLevel.Error,
            exception,
            TemplateParser.Parse(message),
            [
                new LogEventProperty("SalesChannelId", new ScalarValue(ChannelId)),
                new LogEventProperty("SyncRunCorrelationId", new ScalarValue(CorrelationId)),
                new LogEventProperty("SyncOperation", new ScalarValue(ChannelSyncOperation.ImportProducts)),
            ]);

    private static List<SyncLogRecord> Capture(LogEvent logEvent)
    {
        var buffer = new SalesChannelSyncLogBuffer();
        new SalesChannelSyncLogSink(buffer).Emit(logEvent);

        var drained = new List<SyncLogRecord>();
        buffer.Drain(drained, 10);
        return drained;
    }

    [Fact]
    public void TransportFailure_IsNotPersistedWhereTheTenantCanReadIt()
    {
        var transport = new ChannelTransportException(
            "Could not connect to the MySQL server with these settings.",
            new InvalidOperationException("Access denied for user 'root'@'10.0.0.7' (using password: YES)"));

        Assert.Empty(Capture(Event(transport)));
    }

    [Fact]
    public void TransportFailureWrappedInAnotherException_IsStillNotPersisted()
    {
        // The dispatcher's own catch-all re-logs whatever escaped a connector, so the marker has to
        // survive being wrapped on the way up.
        var wrapped = new InvalidOperationException(
            "Sync dispatch failed",
            new ChannelTransportException("generic", new Exception("Connection refused 10.0.0.7:22")));

        Assert.Empty(Capture(Event(wrapped)));
    }

    [Fact]
    public void RemoteApplicationError_KeepsItsFullText()
    {
        // The shop answered and rejected the data. It says nothing about which hosts exist or which
        // ports are open, and it is exactly what the sync-log view is for — so it stays verbatim.
        var remote = new InvalidOperationException("woocommerce_product_invalid_sku: SKU 'A-1' already exists");

        var record = Assert.Single(Capture(Event(remote)));

        Assert.NotNull(record.Exception);
        Assert.Contains("already exists", record.Exception, StringComparison.Ordinal);
    }

    [Fact]
    public void OrdinaryProgressLine_IsStillCaptured()
    {
        var record = Assert.Single(Capture(Event(exception: null, "imported 12 products")));

        Assert.Equal("imported 12 products", record.Message);
        Assert.Null(record.Exception);
    }

    /// <summary>
    /// The operator's join: the sink carries <c>SyncRunCorrelationId</c> through as the record's
    /// correlation id, which is the same value <c>ChannelSyncRunDto.CorrelationId</c> gives the
    /// client — so a run and the lines it produced can be tied together on either side.
    /// </summary>
    [Fact]
    public void CapturedLine_CarriesTheRunsCorrelationId()
    {
        var record = Assert.Single(Capture(Event(exception: null)));

        Assert.Equal(CorrelationId, record.CorrelationId);
        Assert.Equal(ChannelId, record.SalesChannelId);
    }
}
