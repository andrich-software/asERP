using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace asERP.Shipping.Orchestration;

/// <summary>
/// Background loop for shipping work: drains the label-creation outbox every tick and runs a
/// tracking-poll pass roughly once a minute. Each unit of work gets its own DI scope (and thus
/// its own DbContext), mirroring the SalesChannels orchestrator.
/// </summary>
public sealed class ShippingOrchestrator : BackgroundService
{
    private static readonly TimeSpan DefaultTickInterval = TimeSpan.FromSeconds(10);
    private const int PollEveryTicks = 6;

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<ShippingOrchestrator> _logger;
    private readonly TimeSpan _tickInterval;
    private long _tick;

    public ShippingOrchestrator(IServiceScopeFactory scopeFactory, ILogger<ShippingOrchestrator> logger)
        : this(scopeFactory, logger, DefaultTickInterval)
    {
    }

    // Test seam: shorter tick interval for integration tests.
    internal ShippingOrchestrator(IServiceScopeFactory scopeFactory, ILogger<ShippingOrchestrator> logger, TimeSpan tickInterval)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _tickInterval = tickInterval;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Shipping orchestrator started (tick interval {Interval}s)", _tickInterval.TotalSeconds);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await DrainLabelOutboxAsync(stoppingToken);

                if (++_tick % PollEveryTicks == 0)
                {
                    await PollTrackingAsync(stoppingToken);
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Shipping orchestrator tick failed");
            }

            try
            {
                await Task.Delay(_tickInterval, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }

        _logger.LogInformation("Shipping orchestrator stopped");
    }

    private async Task DrainLabelOutboxAsync(CancellationToken cancellationToken)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();
        var drainer = scope.ServiceProvider.GetRequiredService<ShippingLabelOutboxDrainer>();
        var processed = await drainer.DrainOnceAsync(cancellationToken);

        if (processed > 0)
        {
            _logger.LogInformation("Label outbox drainer processed {Count} rows", processed);
        }

        var returnDrainer = scope.ServiceProvider.GetRequiredService<ReturnLabelOutboxDrainer>();
        var returnProcessed = await returnDrainer.DrainOnceAsync(cancellationToken);

        if (returnProcessed > 0)
        {
            _logger.LogInformation("Return-label outbox drainer processed {Count} rows", returnProcessed);
        }
    }

    private async Task PollTrackingAsync(CancellationToken cancellationToken)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();
        var poller = scope.ServiceProvider.GetRequiredService<ShippingTrackingPoller>();
        var polled = await poller.PollOnceAsync(cancellationToken);

        if (polled > 0)
        {
            _logger.LogInformation("Tracking poller checked {Count} shipments", polled);
        }
    }
}
