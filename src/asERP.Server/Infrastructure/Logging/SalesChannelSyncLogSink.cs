using asERP.Domain.Enums;
using asERP.SalesChannels;
using asERP.SalesChannels.Logging;
using Serilog.Core;
using Serilog.Events;

namespace asERP.Server.Infrastructure.Logging;

/// <summary>
/// Serilog sink that captures log events emitted within a sales-channel sync scope and hands them to
/// the <see cref="ISalesChannelSyncLogBuffer"/> for persistence. An event qualifies only if it carries
/// the <c>SalesChannelId</c> scope property (pushed by <c>SyncDispatcher</c> via <c>ILogger.BeginScope</c>),
/// which means EF/framework logs and non-sync events are ignored — no recursion risk. Events below
/// Information are dropped, and so are events carrying a <see cref="ChannelTransportException"/>: what
/// is persisted here is served back to the tenant. Emit never throws.
/// </summary>
public sealed class SalesChannelSyncLogSink : ILogEventSink
{
    private readonly ISalesChannelSyncLogBuffer _buffer;

    public SalesChannelSyncLogSink(ISalesChannelSyncLogBuffer buffer)
    {
        _buffer = buffer;
    }

    public void Emit(LogEvent logEvent)
    {
        try
        {
            if (!TryGetGuid(logEvent, "SalesChannelId", out var salesChannelId))
            {
                return;
            }

            var level = MapLevel(logEvent.Level);
            if (level is null)
            {
                return;
            }

            // Everything captured here is tenant-visible: GET saleschannels/{id}/sync-logs serves the
            // rendered message AND the full exception text back to the same user who configured the
            // channel. A transport failure must not travel that way — the connect outcome for a host
            // and a port the tenant chose is exactly what ChannelTransportException withholds from
            // ChannelSyncRun.ErrorSummary, and persisting it here would hand it straight back through
            // another endpoint. The whole event is dropped rather than only its exception, so the
            // operator's own context in the message — the dialled target, the resolved TLS mode —
            // stays out too. Every other Serilog sink still receives the event in full; the operator
            // joins it to the run through SyncRunCorrelationId, which the client has as
            // ChannelSyncRunDto.CorrelationId.
            if (ChannelTransportException.Describes(logEvent.Exception))
            {
                return;
            }

            TryGetGuid(logEvent, "SyncRunCorrelationId", out var correlationId);
            var tenantId = TryGetGuid(logEvent, "SyncTenantId", out var t) ? t : (Guid?)null;
            var operation = TryGetEnum(logEvent, "SyncOperation", ChannelSyncOperation.ImportProducts);

            var message = logEvent.RenderMessage();
            if (message.Length > 4000)
            {
                message = message[..4000];
            }

            var exception = logEvent.Exception?.ToString();
            if (exception is { Length: > 8000 })
            {
                exception = exception[..8000];
            }

            _buffer.Enqueue(new SyncLogRecord(
                salesChannelId,
                tenantId,
                correlationId,
                operation,
                level.Value,
                message,
                exception,
                logEvent.Timestamp.UtcDateTime));
        }
        catch
        {
            // A logging sink must never throw and break the calling code path.
        }
    }

    private static ChannelSyncLogLevel? MapLevel(LogEventLevel level) => level switch
    {
        LogEventLevel.Information => ChannelSyncLogLevel.Information,
        LogEventLevel.Warning => ChannelSyncLogLevel.Warning,
        LogEventLevel.Error => ChannelSyncLogLevel.Error,
        LogEventLevel.Fatal => ChannelSyncLogLevel.Critical,
        _ => null, // Verbose / Debug are not persisted
    };

    private static bool TryGetGuid(LogEvent logEvent, string name, out Guid value)
    {
        if (logEvent.Properties.TryGetValue(name, out var pv) && pv is ScalarValue { Value: Guid g })
        {
            value = g;
            return true;
        }

        value = default;
        return false;
    }

    private static ChannelSyncOperation TryGetEnum(LogEvent logEvent, string name, ChannelSyncOperation fallback)
    {
        if (logEvent.Properties.TryGetValue(name, out var pv) && pv is ScalarValue { Value: ChannelSyncOperation op })
        {
            return op;
        }

        return fallback;
    }
}
