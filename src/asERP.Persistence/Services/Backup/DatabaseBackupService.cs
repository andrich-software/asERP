using asERP.Application.Contracts.Services;
using asERP.Persistence.Configurations.Options;
using Microsoft.Extensions.Options;

namespace asERP.Persistence.Services.Backup;

/// <summary>
/// Dispatches <see cref="IDatabaseBackupService"/> calls to the provider-native strategy,
/// mirroring the provider switch in <see cref="PersistenceServiceRegistration"/>.
/// </summary>
public class DatabaseBackupService(
    IOptions<DatabaseOptions> databaseOptions,
    IOptions<BackupOptions> backupOptions) : IDatabaseBackupService
{
    private readonly DatabaseOptions _databaseOptions = databaseOptions.Value;
    private readonly BackupOptions _backupOptions = backupOptions.Value;

    public string BackupFileExtension => _databaseOptions.Provider.ToUpperInvariant() switch
    {
        "SQLITE" => ".db",
        "MSSQL" => ".bak",
        "POSTGRESQL" => ".dump",
        _ => throw UnsupportedProvider()
    };

    public async Task BackupAsync(string targetFile, CancellationToken cancellationToken = default)
    {
        var targetDirectory = Path.GetDirectoryName(Path.GetFullPath(targetFile));
        if (!string.IsNullOrEmpty(targetDirectory))
        {
            Directory.CreateDirectory(targetDirectory);
        }

        var connectionString = _databaseOptions.GetConnectionString();
        switch (_databaseOptions.Provider.ToUpperInvariant())
        {
            case "SQLITE":
                await new SqliteBackupStrategy().BackupAsync(connectionString, targetFile, cancellationToken);
                break;
            case "MSSQL":
                await new MssqlBackupStrategy().BackupAsync(connectionString, targetFile, cancellationToken);
                break;
            case "POSTGRESQL":
                await new PostgresBackupStrategy(_backupOptions).BackupAsync(connectionString, targetFile, cancellationToken);
                break;
            default:
                throw UnsupportedProvider();
        }
    }

    public async Task RestoreAsync(string sourceFile, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(sourceFile))
        {
            throw new FileNotFoundException($"Backup file '{sourceFile}' does not exist.", sourceFile);
        }

        var connectionString = _databaseOptions.GetConnectionString();
        switch (_databaseOptions.Provider.ToUpperInvariant())
        {
            case "SQLITE":
                await new SqliteBackupStrategy().RestoreAsync(connectionString, sourceFile, cancellationToken);
                break;
            case "MSSQL":
                await new MssqlBackupStrategy().RestoreAsync(connectionString, sourceFile, cancellationToken);
                break;
            case "POSTGRESQL":
                await new PostgresBackupStrategy(_backupOptions).RestoreAsync(connectionString, sourceFile, cancellationToken);
                break;
            default:
                throw UnsupportedProvider();
        }
    }

    private ArgumentException UnsupportedProvider() =>
        new($"Unsupported database provider: {_databaseOptions.Provider}");
}
