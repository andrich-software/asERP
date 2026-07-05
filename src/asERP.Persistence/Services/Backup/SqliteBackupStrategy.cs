using Microsoft.Data.Sqlite;

namespace asERP.Persistence.Services.Backup;

internal sealed class SqliteBackupStrategy
{
    // First 16 bytes of every SQLite database file ("SQLite format 3\0").
    private static readonly byte[] SqliteHeader = "SQLite format 3\0"u8.ToArray();

    public async Task BackupAsync(string connectionString, string targetFile, CancellationToken cancellationToken)
    {
        // VACUUM INTO refuses to overwrite an existing file.
        if (File.Exists(targetFile))
        {
            File.Delete(targetFile);
        }

        await using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        // Online-safe consistent snapshot (WAL-aware), produces a single file without sidecars.
        command.CommandText = "VACUUM INTO @path";
        command.Parameters.AddWithValue("@path", targetFile);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public Task RestoreAsync(string connectionString, string sourceFile, CancellationToken cancellationToken)
    {
        if (!IsSqliteDatabase(sourceFile))
        {
            throw new InvalidOperationException(
                $"'{sourceFile}' is not a SQLite database file — refusing to restore.");
        }

        var databasePath = new SqliteConnectionStringBuilder(connectionString).DataSource;

        // The caller guarantees the server is stopped; clear this process's pooled
        // connections and stale WAL/SHM sidecars so the copied file is authoritative.
        SqliteConnection.ClearAllPools();
        foreach (var sidecar in new[] { databasePath + "-wal", databasePath + "-shm" })
        {
            if (File.Exists(sidecar))
            {
                File.Delete(sidecar);
            }
        }

        File.Copy(sourceFile, databasePath, overwrite: true);
        return Task.CompletedTask;
    }

    internal static bool IsSqliteDatabase(string file)
    {
        using var stream = File.OpenRead(file);
        var header = new byte[SqliteHeader.Length];
        return stream.Read(header, 0, header.Length) == header.Length
               && header.AsSpan().SequenceEqual(SqliteHeader);
    }
}
