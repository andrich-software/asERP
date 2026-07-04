using asERP.Domain.Enums;
using asERP.SalesChannels.Logging;
using Serilog.Core;
using Serilog.Events;

namespace asERP.Server.Infrastructure.Logging;

/// <summary>
/// Serilog sink that captures log events emitted within a sales-channel sync scope and hands them to
/// the <see cref="ISalesChannelSyncLogBuffer"/> for persistence. An event qualifies only if it carries
/// the <c>SalesChannelId</c> scope property (pushed by <c>SyncDispatcher</c> via <c>ILogger.BeginScope</c>),
/// which means EF/framework logs and non-sync events are ignored — no recursion risk. Events below
/// Information are dropped. Emit never throws.
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
