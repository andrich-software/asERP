using Microsoft.Data.SqlClient;

namespace asERP.Persistence.Services.Backup;

internal sealed class MssqlBackupStrategy
{
    public async Task BackupAsync(string connectionString, string targetFile, CancellationToken cancellationToken)
    {
        var databaseName = GetDatabaseName(connectionString);

        await using var connection = new SqlConnection(BuildMasterConnectionString(connectionString));
        await connection.OpenAsync(cancellationToken);

        await using var command = connection.CreateCommand();
        // COPY_ONLY keeps any DBA-managed backup chain (differential base / log chain) intact.
        command.CommandText = BuildBackupCommandText(databaseName);
        command.Parameters.AddWithValue("@path", targetFile);
        command.CommandTimeout = 0;
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async Task RestoreAsync(string connectionString, string sourceFile, CancellationToken cancellationToken)
    {
        var databaseName = GetDatabaseName(connectionString);
        var quoted = QuoteIdentifier(databaseName);

        await using var connection = new SqlConnection(BuildMasterConnectionString(connectionString));
        await connection.OpenAsync(cancellationToken);

        await ExecuteAsync(connection,
            $"ALTER DATABASE {quoted} SET SINGLE_USER WITH ROLLBACK IMMEDIATE",
            cancellationToken);
        try
        {
            await using var restore = connection.CreateCommand();
            restore.CommandText = $"RESTORE DATABASE {quoted} FROM DISK = @path WITH REPLACE";
            restore.Parameters.AddWithValue("@path", sourceFile);
            restore.CommandTimeout = 0;
            await restore.ExecuteNonQueryAsync(cancellationToken);
        }
        finally
        {
            await ExecuteAsync(connection, $"ALTER DATABASE {quoted} SET MULTI_USER", cancellationToken);
        }
    }

    internal static string BuildBackupCommandText(string databaseName) =>
        $"BACKUP DATABASE {QuoteIdentifier(databaseName)} TO DISK = @path WITH INIT, COPY_ONLY";

    internal static string BuildMasterConnectionString(string connectionString) =>
        new SqlConnectionStringBuilder(connectionString) { InitialCatalog = "master" }.ConnectionString;

    internal static string GetDatabaseName(string connectionString)
    {
        var databaseName = new SqlConnectionStringBuilder(connectionString).InitialCatalog;
        return string.IsNullOrWhiteSpace(databaseName)
            ? throw new InvalidOperationException("MSSQL connection string does not specify a database.")
            : databaseName;
    }

    internal static string QuoteIdentifier(string identifier) =>
        $"[{identifier.Replace("]", "]]")}]";

    private static async Task ExecuteAsync(SqlConnection connection, string sql, CancellationToken cancellationToken)
    {
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.CommandTimeout = 0;
        await command.ExecuteNonQueryAsync(cancellationToken);
    }
}
