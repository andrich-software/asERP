namespace asERP.Persistence.Configurations.Options;

public class DatabaseOptions
{
    public const string Section = "DatabaseConfig";

    public string Provider { get; set; } = "SQLite";
    public string ConnectionString { get; set; } = string.Empty;

    public string GetConnectionString() => string.IsNullOrEmpty(ConnectionString)
        ? throw new InvalidOperationException("No connection string configured")
        : ConnectionString;
}
