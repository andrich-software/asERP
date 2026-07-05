namespace asERP.Server.Tray.Models;

/// <summary>
/// Tray-side view of %ProgramData%\asERP\settings.json. Mirrors the server's
/// DatabaseConfig / FileStorage sections and the ASP.NET Core "Urls" key —
/// deliberately duplicated (three properties) so the tray needs no asERP
/// project references.
/// </summary>
internal sealed class ServerSettings
{
    public const int DefaultPort = 5000;

    public string Provider { get; set; } = "Sqlite";

    public string ConnectionString { get; set; } = DefaultSqliteConnectionString;

    public string FileStorageRootPath { get; set; } = Path.Combine(AppPaths.DataDirectory, "files");

    public int Port { get; set; } = DefaultPort;

    public static string DefaultSqliteConnectionString =>
        $"Data Source={Path.Combine(AppPaths.DataDirectory, "aserp.db")}";

    public string BackupFileExtension => Provider.ToUpperInvariant() switch
    {
        "MSSQL" => ".bak",
        "POSTGRESQL" => ".dump",
        _ => ".db"
    };

    public static string ConnectionStringTemplate(string provider) => provider.ToUpperInvariant() switch
    {
        "POSTGRESQL" => "Host=localhost;Port=5432;Database=aserp;Username=aserp;Password=...",
        "MSSQL" => "Server=localhost;Database=aserp;User Id=aserp;Password=...;TrustServerCertificate=True",
        _ => DefaultSqliteConnectionString
    };
}
