namespace asERP.Persistence.Services.Backup;

public class BackupOptions
{
    public const string Section = "BackupConfig";

    /// <summary>
    /// Directory containing pg_dump/pg_restore. When unset, the tools are resolved via PATH.
    /// Only relevant for the PostgreSQL provider.
    /// </summary>
    public string? PgToolsPath { get; set; }
}
