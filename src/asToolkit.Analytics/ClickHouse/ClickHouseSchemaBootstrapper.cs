using ClickHouse.Client.ADO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace asToolkit.Analytics.ClickHouse;

/// <summary>
/// Ensures the analytics database + tables exist (CREATE … IF NOT EXISTS) at startup. Runs in the
/// background and retries, so the server boots even when ClickHouse is briefly unavailable — analytics
/// is non-critical and must never block or crash the host. Mirrors the swallow-and-log posture of the
/// Grafana bootstrap in Program.cs.
/// </summary>
internal sealed class ClickHouseSchemaBootstrapper : BackgroundService
{
    private static readonly TimeSpan RetryDelay = TimeSpan.FromSeconds(15);
    private const int MaxAttempts = 10;

    private readonly IClickHouseConnectionFactory _connectionFactory;
    private readonly ILogger<ClickHouseSchemaBootstrapper> _logger;

    public ClickHouseSchemaBootstrapper(
        IClickHouseConnectionFactory connectionFactory,
        ILogger<ClickHouseSchemaBootstrapper> logger)
    {
        _connectionFactory = connectionFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        for (var attempt = 1; attempt <= MaxAttempts && !stoppingToken.IsCancellationRequested; attempt++)
        {
            try
            {
                var settings = await _connectionFactory.GetSettingsAsync(stoppingToken);
                if (!settings.Enabled)
                {
                    _logger.LogInformation("ClickHouse analytics disabled via settings — skipping schema bootstrap.");
                    return;
                }

                // 1) Ensure the database exists (connect to the server-level default database).
                await using (var serverConnection = await _connectionFactory.OpenConnectionAsync(useDefaultDatabase: true, stoppingToken))
                {
                    await ExecuteAsync(serverConnection, ClickHouseSchema.CreateDatabase(settings.Database), stoppingToken);
                }

                // 2) Ensure the tables exist (connect to the configured database).
                await using (var connection = await _connectionFactory.OpenConnectionAsync(useDefaultDatabase: false, stoppingToken))
                {
                    await ExecuteAsync(connection, ClickHouseSchema.CreateEventsTable(settings.Database), stoppingToken);
                    await ExecuteAsync(connection, ClickHouseSchema.CreateIdentitiesTable(settings.Database), stoppingToken);
                }

                _logger.LogInformation("ClickHouse analytics schema is ready (database '{Database}').", settings.Database);
                return;
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex,
                    "ClickHouse schema bootstrap attempt {Attempt}/{Max} failed: {Message}. Retrying in {Delay}s.",
                    attempt, MaxAttempts, ex.Message, RetryDelay.TotalSeconds);

                try
                {
                    await Task.Delay(RetryDelay, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }

        _logger.LogError("ClickHouse schema bootstrap gave up after {Max} attempts. Web analytics will not record events until ClickHouse is reachable and the server is restarted.", MaxAttempts);
    }

    private static async Task ExecuteAsync(ClickHouseConnection connection, string sql, CancellationToken cancellationToken)
    {
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        await command.ExecuteNonQueryAsync(cancellationToken);
    }
}
