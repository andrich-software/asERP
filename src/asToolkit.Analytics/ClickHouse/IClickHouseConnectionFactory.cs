using ClickHouse.Client.ADO;
using asToolkit.Application.Models.Analytics;

namespace asToolkit.Analytics.ClickHouse;

/// <summary>
/// Creates ClickHouse connections from the runtime-configured settings (internal docker service by
/// default, or an external ClickHouse). Settings are cached briefly so the hot write/read paths don't
/// re-read the database every time. Singleton — reads scoped settings via a service scope internally.
/// </summary>
internal interface IClickHouseConnectionFactory
{
    /// <summary>Current (cached) settings, including the master <c>Enabled</c> switch and target database.</summary>
    Task<ClickHouseSettings> GetSettingsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Opens a connection to the configured database (or the server-level <c>default</c> database when
    /// <paramref name="useDefaultDatabase"/> is true — used by the bootstrapper to run CREATE DATABASE).
    /// The caller owns disposal.
    /// </summary>
    Task<ClickHouseConnection> OpenConnectionAsync(bool useDefaultDatabase = false, CancellationToken cancellationToken = default);
}
