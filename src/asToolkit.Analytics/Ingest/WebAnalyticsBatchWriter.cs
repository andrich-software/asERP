using ClickHouse.Client.Copy;
using asToolkit.Analytics.ClickHouse;
using asToolkit.Domain.Dtos.WebAnalytics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace asToolkit.Analytics.Ingest;

/// <summary>
/// Drains the ingest queue and bulk-inserts batches into ClickHouse (≈1 insert/second — ClickHouse
/// dislikes many tiny inserts). Events that carry a known customer (cid) also upsert the vid→cid
/// identity map. ClickHouse being unavailable only affects this background loop — the ingest endpoint
/// touches the in-memory queue only, so beacons are never blocked.
/// </summary>
internal sealed class WebAnalyticsBatchWriter : BackgroundService
{
    private const int BatchSize = 2000;
    private const int MaxFlushAttempts = 3;
    private static readonly TimeSpan FlushInterval = TimeSpan.FromSeconds(1);
    private static readonly TimeSpan RetryDelay = TimeSpan.FromSeconds(2);

    private readonly WebAnalyticsIngestQueue _queue;
    private readonly IClickHouseConnectionFactory _connectionFactory;
    private readonly ILogger<WebAnalyticsBatchWriter> _logger;

    public WebAnalyticsBatchWriter(
        WebAnalyticsIngestQueue queue,
        IClickHouseConnectionFactory connectionFactory,
        ILogger<WebAnalyticsBatchWriter> logger)
    {
        _queue = queue;
        _connectionFactory = connectionFactory;
        _logger = logger;
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        // Let the reader observe completion so the loop can drain and exit.
        _queue.Complete();
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var reader = _queue.Reader;
        var batch = new List<WebAnalyticsEvent>(BatchSize);

        try
        {
            while (await reader.WaitToReadAsync(stoppingToken))
            {
                batch.Clear();
                while (batch.Count < BatchSize && reader.TryRead(out var first))
                {
                    batch.Add(first);
                }
                if (batch.Count == 0)
                {
                    continue;
                }

                // Accumulate more within the flush window to coalesce into one insert.
                var flushAt = DateTime.UtcNow + FlushInterval;
                while (batch.Count < BatchSize)
                {
                    var remaining = flushAt - DateTime.UtcNow;
                    if (remaining <= TimeSpan.Zero)
                    {
                        break;
                    }

                    using var windowCts = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
                    windowCts.CancelAfter(remaining);
                    try
                    {
                        if (!await reader.WaitToReadAsync(windowCts.Token))
                        {
                            break;
                        }
                        while (batch.Count < BatchSize && reader.TryRead(out var more))
                        {
                            batch.Add(more);
                        }
                    }
                    catch (OperationCanceledException) when (!stoppingToken.IsCancellationRequested)
                    {
                        break; // flush window elapsed
                    }
                }

                await FlushWithRetryAsync(batch, stoppingToken);
            }
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // Shutting down — fall through to a final best-effort drain.
        }

        await DrainRemainingAsync();
    }

    private async Task FlushWithRetryAsync(IReadOnlyList<WebAnalyticsEvent> batch, CancellationToken token)
    {
        for (var attempt = 1; attempt <= MaxFlushAttempts; attempt++)
        {
            try
            {
                await FlushAsync(batch, token);
                return;
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested)
            {
                return;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Web analytics flush attempt {Attempt}/{Max} failed ({Count} events).",
                    attempt, MaxFlushAttempts, batch.Count);
                if (attempt < MaxFlushAttempts)
                {
                    try
                    {
                        await Task.Delay(RetryDelay, token);
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                }
            }
        }

        _logger.LogError("Web analytics flush gave up after {Max} attempts — dropping {Count} events.",
            MaxFlushAttempts, batch.Count);
    }

    private async Task DrainRemainingAsync()
    {
        var leftovers = new List<WebAnalyticsEvent>();
        while (_queue.Reader.TryRead(out var evt))
        {
            leftovers.Add(evt);
        }
        if (leftovers.Count == 0)
        {
            return;
        }

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        try
        {
            await FlushAsync(leftovers, cts.Token);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Final web analytics drain failed — {Count} events lost.", leftovers.Count);
        }
    }

    private async Task FlushAsync(IReadOnlyList<WebAnalyticsEvent> batch, CancellationToken token)
    {
        var settings = await _connectionFactory.GetSettingsAsync(token);
        if (!settings.Enabled)
        {
            return; // pipeline disabled — drop silently
        }

        await using var connection = await _connectionFactory.OpenConnectionAsync(useDefaultDatabase: false, token);

        using (var eventsBulk = new ClickHouseBulkCopy(connection)
        {
            DestinationTableName = "web_events",
            ColumnNames = ClickHouseSchema.EventColumns,
            BatchSize = batch.Count
        })
        {
            await eventsBulk.InitAsync();
            await eventsBulk.WriteToServerAsync(batch.Select(ToEventRow), token);
        }

        // Stitch known-customer events into the vid→cid identity map (ReplacingMergeTree, latest wins).
        var identityRows = batch
            .Where(e => e.Cid.Length > 0 && e.Vid.Length > 0)
            .Select(ToIdentityRow)
            .ToList();

        if (identityRows.Count > 0)
        {
            using var idBulk = new ClickHouseBulkCopy(connection)
            {
                DestinationTableName = "web_identities",
                ColumnNames = ClickHouseSchema.IdentityColumns,
                BatchSize = identityRows.Count
            };
            await idBulk.InitAsync();
            await idBulk.WriteToServerAsync(identityRows, token);
        }
    }

    private static object[] ToEventRow(WebAnalyticsEvent e) => new object[]
    {
        e.TenantId,
        e.SalesChannelId,
        e.EventTime,
        e.EventType,
        e.EventName,
        e.SessionId,
        e.Vid,
        e.Cid,
        e.Url,
        e.Path,
        e.Title,
        e.Referrer,
        e.Hostname,
        (ushort)e.ScreenWidth,
        (ushort)e.ScreenHeight,
        (ushort)e.ViewportWidth,
        (ushort)e.ViewportHeight,
        (byte)e.ScrollDepth,
        e.Language,
        e.Country,
        e.IpMasked,
        e.UaBrowser,
        e.UaOs,
        e.UaDevice,
        e.UtmSource,
        e.UtmMedium,
        e.UtmCampaign,
        e.UtmTerm,
        e.UtmContent,
        e.Gclid,
        e.Gbraid,
        e.Wbraid,
        e.GadSource,
        e.Msclkid,
        e.Fbclid,
        e.ProductRef,
        e.ProductName,
        e.Value,
        e.Currency
    };

    private static object[] ToIdentityRow(WebAnalyticsEvent e) => new object[]
    {
        e.TenantId,
        e.SalesChannelId,
        e.Vid,
        e.Cid,
        e.EventTime
    };
}
