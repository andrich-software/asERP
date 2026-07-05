namespace asERP.Application.Contracts.Services;

/// <summary>
/// Provider-native backup and restore of the configured database (database only —
/// stored files/images are not included). Used by the out-of-band CLI
/// (<c>asERP.Server.exe cli backup|restore</c>) which the Windows tray app drives.
/// </summary>
public interface IDatabaseBackupService
{
    /// <summary>
    /// Writes a provider-native backup of the configured database to <paramref name="targetFile"/>.
    /// Safe to run while the server is online for all providers.
    /// Limitation: for MSSQL the path is interpreted by the SQL Server host, so backups of a
    /// remote server are written to the remote machine's disk.
    /// </summary>
    Task BackupAsync(string targetFile, CancellationToken cancellationToken = default);

    /// <summary>
    /// Overwrites the configured database with the backup in <paramref name="sourceFile"/>.
    /// The server process must be stopped (SQLite holds the database file open; MSSQL restore
    /// requires no competing connections) — call only from the out-of-band CLI.
    /// </summary>
    Task RestoreAsync(string sourceFile, CancellationToken cancellationToken = default);

    /// <summary>Provider-native file extension for new backups: ".db" | ".bak" | ".dump".</summary>
    string BackupFileExtension { get; }
}
