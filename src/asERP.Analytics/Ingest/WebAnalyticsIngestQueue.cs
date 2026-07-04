using System.Threading.Channels;
using asERP.Domain.Dtos.WebAnalytics;

namespace asERP.Analytics.Ingest;

/// <summary>
/// Bounded in-memory queue between the anonymous ingest endpoint (many writers) and the single
/// background batch writer (one reader). Overflow drops the newest beacon (<see cref="BoundedChannelFullMode.DropWrite"/>)
/// rather than blocking the request thread — analytics loss is acceptable; a stalled shop beacon is not.
/// Singleton; holds no scoped dependencies.
/// </summary>
internal sealed class WebAnalyticsIngestQueue
{
    private const int Capacity = 50_000;

    private readonly Channel<WebAnalyticsEvent> _channel = Channel.CreateBounded<WebAnalyticsEvent>(
        new BoundedChannelOptions(Capacity)
        {
            FullMode = BoundedChannelFullMode.DropWrite,
            SingleReader = true,
            SingleWriter = false
        });

    /// <summary>Non-blocking enqueue; returns false when the queue is full (beacon dropped).</summary>
    public bool TryWrite(WebAnalyticsEvent evt) => _channel.Writer.TryWrite(evt);

    public ChannelReader<WebAnalyticsEvent> Reader => _channel.Reader;

    /// <summary>Marks the queue complete so the writer can drain and exit on shutdown.</summary>
    public void Complete() => _channel.Writer.TryComplete();
}
