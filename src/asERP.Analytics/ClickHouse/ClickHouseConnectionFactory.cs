using System.Data.Common;
using ClickHouse.Client.ADO;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Models.Analytics;
using Microsoft.Extensions.DependencyInjection;

namespace asERP.Analytics.ClickHouse;

/// <summary>
/// Singleton connection factory. Reads <c>ClickHouse.*</c> settings via a short-lived service scope
/// (settings live in the relational DB and are scoped), caching them for a few seconds so neither the
/// per-second batch flush nor dashboard queries hammer the settings table.
/// </summary>
internal sealed class ClickHouseConnectionFactory : IClickHouseConnectionFactory
{
    private static readonly TimeSpan CacheTtl = TimeSpan.FromSeconds(30);

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly SemaphoreSlim _gate = new(1, 1);

    private ClickHouseSettings? _cached;
    private DateTime _cachedAtUtc = DateTime.MinValue;

    public ClickHouseConnectionFactory(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<ClickHouseSettings> GetSettingsAsync(CancellationToken cancellationToken = default)
    {
        // UtcNow is fine here — this is runtime caching, not anything persisted/replayed.
        if (_cached is not null && DateTime.UtcNow - _cachedAtUtc < CacheTtl)
        {
            return _cached;
        }

        await _gate.WaitAsync(cancellationToken);
        try
        {
            if (_cached is not null && DateTime.UtcNow - _cachedAtUtc < CacheTtl)
            {
                return _cached;
            }

            using var scope = _scopeFactory.CreateScope();
            var settingsService = scope.ServiceProvider.GetRequiredService<ISettingsService>();
            _cached = await settingsService.GetClickHouseSettingsAsync();
            _cachedAtUtc = DateTime.UtcNow;
            return _cached;
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task<ClickHouseConnection> OpenConnectionAsync(bool useDefaultDatabase = false, CancellationToken cancellationToken = default)
    {
        var settings = await GetSettingsAsync(cancellationToken);
        var connection = new ClickHouseConnection(BuildConnectionString(settings, useDefaultDatabase));
        await connection.OpenAsync(cancellationToken);
        return connection;
    }

    private static string BuildConnectionString(ClickHouseSettings settings, bool useDefaultDatabase)
    {
        // DbConnectionStringBuilder handles value quoting/escaping (passwords with special chars).
        var builder = new DbConnectionStringBuilder
        {
            ["Host"] = settings.Host,
            ["Port"] = settings.Port,
            ["Username"] = settings.User,
            ["Password"] = settings.Password,
            ["Database"] = useDefaultDatabase ? "default" : settings.Database
        };

        if (settings.UseTls)
        {
            builder["Protocol"] = "https";
        }

        return builder.ConnectionString;
    }
}
