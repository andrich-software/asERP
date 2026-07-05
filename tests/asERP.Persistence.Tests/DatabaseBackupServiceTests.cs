using asERP.Persistence.Configurations.Options;
using asERP.Persistence.Services.Backup;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using Npgsql;

namespace asERP.Persistence.Tests;

public class DatabaseBackupServiceTests : IDisposable
{
    private readonly string _tempDir;

    public DatabaseBackupServiceTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "asERP-backup-tests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        // Windows keeps SQLite files locked while pooled connections are alive.
        SqliteConnection.ClearAllPools();
        try
        {
            Directory.Delete(_tempDir, recursive: true);
        }
        catch (IOException)
        {
            // Best-effort cleanup of temp files.
        }
    }

    private string TempFile(string name) => Path.Combine(_tempDir, name);

    private static DatabaseBackupService CreateService(string provider, string connectionString, string? pgToolsPath = null) =>
        new(Options.Create(new DatabaseOptions { Provider = provider, ConnectionString = connectionString }),
            Options.Create(new BackupOptions { PgToolsPath = pgToolsPath }));

    private static void CreateSqliteDatabase(string path, params string[] itemNames)
    {
        using var connection = new SqliteConnection($"Data Source={path}");
        connection.Open();
        using (var create = connection.CreateCommand())
        {
            create.CommandText = "CREATE TABLE IF NOT EXISTS Item (Name TEXT NOT NULL)";
            create.ExecuteNonQuery();
        }
        foreach (var name in itemNames)
        {
            using var insert = connection.CreateCommand();
            insert.CommandText = "INSERT INTO Item (Name) VALUES (@name)";
            insert.Parameters.AddWithValue("@name", name);
            insert.ExecuteNonQuery();
        }
    }

    private static List<string> ReadItems(string path)
    {
        using var connection = new SqliteConnection($"Data Source={path};Mode=ReadOnly");
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Name FROM Item ORDER BY Name";
        using var reader = command.ExecuteReader();
        var items = new List<string>();
        while (reader.Read())
        {
            items.Add(reader.GetString(0));
        }
        return items;
    }

    [Fact]
    public async Task SqliteBackup_WritesConsistentSnapshot()
    {
        var databaseFile = TempFile("source.db");
        var backupFile = TempFile("backup.db");
        CreateSqliteDatabase(databaseFile, "alpha", "beta");

        var service = CreateService("Sqlite", $"Data Source={databaseFile}");
        await service.BackupAsync(backupFile);

        Assert.True(File.Exists(backupFile));
        Assert.True(SqliteBackupStrategy.IsSqliteDatabase(backupFile));
        Assert.Equal(new List<string> { "alpha", "beta" }, ReadItems(backupFile));
    }

    [Fact]
    public async Task SqliteBackup_OverwritesExistingTargetFile()
    {
        var databaseFile = TempFile("source.db");
        var backupFile = TempFile("backup.db");
        CreateSqliteDatabase(databaseFile, "alpha");
        await File.WriteAllTextAsync(backupFile, "stale content");

        var service = CreateService("Sqlite", $"Data Source={databaseFile}");
        await service.BackupAsync(backupFile);

        Assert.Equal(new List<string> { "alpha" }, ReadItems(backupFile));
    }

    [Fact]
    public async Task SqliteRestore_RestoresContentAndRemovesSidecars()
    {
        var databaseFile = TempFile("live.db");
        var backupFile = TempFile("backup.db");
        CreateSqliteDatabase(databaseFile, "original");

        var service = CreateService("Sqlite", $"Data Source={databaseFile}");
        await service.BackupAsync(backupFile);

        // Mutate the live database after the backup and plant stale WAL/SHM sidecars.
        CreateSqliteDatabase(databaseFile, "added-later");
        SqliteConnection.ClearAllPools();
        await File.WriteAllBytesAsync(databaseFile + "-wal", [1, 2, 3]);
        await File.WriteAllBytesAsync(databaseFile + "-shm", [4, 5, 6]);

        await service.RestoreAsync(backupFile);

        Assert.Equal(new List<string> { "original" }, ReadItems(databaseFile));
        Assert.False(File.Exists(databaseFile + "-wal"));
        Assert.False(File.Exists(databaseFile + "-shm"));
    }

    [Fact]
    public async Task SqliteRestore_RefusesNonSqliteFile()
    {
        var databaseFile = TempFile("live.db");
        var bogusBackup = TempFile("not-a-database.db");
        CreateSqliteDatabase(databaseFile, "original");
        await File.WriteAllTextAsync(bogusBackup, "this is not a SQLite database");

        var service = CreateService("Sqlite", $"Data Source={databaseFile}");

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.RestoreAsync(bogusBackup));
        Assert.Equal(new List<string> { "original" }, ReadItems(databaseFile));
    }

    [Fact]
    public async Task Restore_MissingSourceFile_Throws()
    {
        var service = CreateService("Sqlite", $"Data Source={TempFile("live.db")}");

        await Assert.ThrowsAsync<FileNotFoundException>(() => service.RestoreAsync(TempFile("does-not-exist.db")));
    }

    [Fact]
    public async Task UnknownProvider_Throws()
    {
        var service = CreateService("Oracle", "whatever");

        Assert.Throws<ArgumentException>(() => service.BackupFileExtension);
        await Assert.ThrowsAsync<ArgumentException>(() => service.BackupAsync(TempFile("backup.bin")));
    }

    [Theory]
    [InlineData("Sqlite", ".db")]
    [InlineData("SQLITE", ".db")]
    [InlineData("MSSQL", ".bak")]
    [InlineData("mssql", ".bak")]
    [InlineData("PostgreSQL", ".dump")]
    [InlineData("POSTGRESQL", ".dump")]
    public void BackupFileExtension_MatchesProvider_CaseInsensitive(string provider, string expectedExtension)
    {
        var service = CreateService(provider, "irrelevant");

        Assert.Equal(expectedExtension, service.BackupFileExtension);
    }

    [Fact]
    public void Mssql_QuoteIdentifier_EscapesClosingBrackets()
    {
        Assert.Equal("[weird]]db]", MssqlBackupStrategy.QuoteIdentifier("weird]db"));
        Assert.Equal(
            "BACKUP DATABASE [weird]]db] TO DISK = @path WITH INIT, COPY_ONLY",
            MssqlBackupStrategy.BuildBackupCommandText("weird]db"));
    }

    [Fact]
    public void Mssql_MasterConnectionString_SwitchesDatabaseOnly()
    {
        var master = MssqlBackupStrategy.BuildMasterConnectionString(
            "Server=localhost;Database=aserp;User Id=sa;Password=secret;TrustServerCertificate=True");

        Assert.Contains("Initial Catalog=master", master);
        Assert.Contains("Data Source=localhost", master);
    }

    [Fact]
    public void Mssql_GetDatabaseName_MissingDatabase_Throws()
    {
        Assert.Throws<InvalidOperationException>(() =>
            MssqlBackupStrategy.GetDatabaseName("Server=localhost;User Id=sa;Password=secret"));
    }

    [Fact]
    public void Postgres_BuildDumpArguments_UsesConnectionParts_WithoutPassword()
    {
        var builder = new NpgsqlConnectionStringBuilder(
            "Host=dbhost;Port=5433;Database=aserp;Username=erp;Password=secret");

        var arguments = PostgresBackupStrategy.BuildDumpArguments(builder, "/tmp/out.dump");

        Assert.Equal(
            ["--format=custom", "--file=/tmp/out.dump", "--host=dbhost", "--port=5433", "--username=erp", "--dbname=aserp"],
            arguments);
        Assert.DoesNotContain(arguments, argument => argument.Contains("secret"));
    }

    [Fact]
    public void Postgres_BuildRestoreArguments_CleansExistingObjects()
    {
        var builder = new NpgsqlConnectionStringBuilder("Host=localhost;Database=aserp;Username=erp");

        var arguments = PostgresBackupStrategy.BuildRestoreArguments(builder, "/tmp/in.dump");

        Assert.Equal(
            ["--clean", "--if-exists", "--no-owner", "--host=localhost", "--port=5432", "--username=erp", "--dbname=aserp", "/tmp/in.dump"],
            arguments);
    }

    [Fact]
    public void Postgres_MissingDatabase_Throws()
    {
        var builder = new NpgsqlConnectionStringBuilder("Host=localhost;Username=erp");

        Assert.Throws<InvalidOperationException>(() =>
            PostgresBackupStrategy.BuildDumpArguments(builder, "/tmp/out.dump"));
    }

    [Fact]
    public async Task Postgres_MissingTools_ThrowsHelpfulError()
    {
        var service = CreateService(
            "PostgreSQL",
            "Host=localhost;Database=aserp;Username=erp;Password=secret",
            pgToolsPath: TempFile("no-such-tools-dir"));

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => service.BackupAsync(TempFile("backup.dump")));

        Assert.Contains("pg_dump", exception.Message);
        Assert.Contains("PgToolsPath", exception.Message);
    }
}
