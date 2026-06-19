namespace maERP.Application.Models.Analytics;

/// <summary>
/// ClickHouse connection settings, read from the <c>Setting</c> entity (keys <c>ClickHouse.*</c>) so an
/// external ClickHouse can be configured at runtime. Defaults target the bundled docker-compose service.
/// </summary>
public class ClickHouseSettings
{
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 8123;
    public string Database { get; set; } = "maerp_analytics";
    public string User { get; set; } = "maerp";
    public string Password { get; set; } = string.Empty;

    /// <summary>Use HTTPS for the ClickHouse HTTP interface (external/managed ClickHouse).</summary>
    public bool UseTls { get; set; }

    /// <summary>Master switch — when false the analytics pipeline stays dormant (no schema, no writes).</summary>
    public bool Enabled { get; set; } = true;
}
