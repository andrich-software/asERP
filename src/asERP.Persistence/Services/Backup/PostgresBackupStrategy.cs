using System.ComponentModel;
using System.Diagnostics;
using Npgsql;

namespace asERP.Persistence.Services.Backup;

/// <summary>
/// PostgreSQL has no in-SQL backup statement — shells out to pg_dump/pg_restore.
/// Tools are resolved via <see cref="BackupOptions.PgToolsPath"/> or PATH; the password
/// is passed via the PGPASSWORD environment variable so it never appears in argv.
/// </summary>
internal sealed class PostgresBackupStrategy(BackupOptions options)
{
    public Task BackupAsync(string connectionString, string targetFile, CancellationToken cancellationToken)
    {
        var builder = new NpgsqlConnectionStringBuilder(connectionString);
        return RunToolAsync("pg_dump", BuildDumpArguments(builder, targetFile), builder.Password, cancellationToken);
    }

    public Task RestoreAsync(string connectionString, string sourceFile, CancellationToken cancellationToken)
    {
        var builder = new NpgsqlConnectionStringBuilder(connectionString);
        return RunToolAsync("pg_restore", BuildRestoreArguments(builder, sourceFile), builder.Password, cancellationToken);
    }

    internal static List<string> BuildDumpArguments(NpgsqlConnectionStringBuilder builder, string targetFile) =>
    [
        "--format=custom",
        $"--file={targetFile}",
        .. BuildConnectionArguments(builder)
    ];

    internal static List<string> BuildRestoreArguments(NpgsqlConnectionStringBuilder builder, string sourceFile) =>
    [
        // Drop and recreate objects inside the existing database — no drop-database
        // dance needed; works as long as only the (stopped) server was connected.
        "--clean",
        "--if-exists",
        "--no-owner",
        .. BuildConnectionArguments(builder),
        sourceFile
    ];

    private static List<string> BuildConnectionArguments(NpgsqlConnectionStringBuilder builder)
    {
        var arguments = new List<string>();
        if (!string.IsNullOrEmpty(builder.Host))
        {
            arguments.Add($"--host={builder.Host}");
        }
        if (builder.Port > 0)
        {
            arguments.Add($"--port={builder.Port}");
        }
        if (!string.IsNullOrEmpty(builder.Username))
        {
            arguments.Add($"--username={builder.Username}");
        }
        if (string.IsNullOrEmpty(builder.Database))
        {
            throw new InvalidOperationException("PostgreSQL connection string does not specify a database.");
        }
        arguments.Add($"--dbname={builder.Database}");
        return arguments;
    }

    private async Task RunToolAsync(string toolName, List<string> arguments, string? password, CancellationToken cancellationToken)
    {
        var startInfo = new ProcessStartInfo(ResolveToolPath(toolName))
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        foreach (var argument in arguments)
        {
            startInfo.ArgumentList.Add(argument);
        }
        if (!string.IsNullOrEmpty(password))
        {
            startInfo.Environment["PGPASSWORD"] = password;
        }

        Process process;
        try
        {
            process = Process.Start(startInfo)
                      ?? throw new InvalidOperationException($"Failed to start '{toolName}'.");
        }
        catch (Win32Exception ex)
        {
            throw new InvalidOperationException(
                $"'{toolName}' not found. Install the PostgreSQL client tools or set " +
                $"{BackupOptions.Section}:{nameof(BackupOptions.PgToolsPath)} in settings.json.", ex);
        }

        using (process)
        {
            var stderrTask = process.StandardError.ReadToEndAsync(cancellationToken);
            _ = process.StandardOutput.ReadToEndAsync(cancellationToken);
            await process.WaitForExitAsync(cancellationToken);

            if (process.ExitCode != 0)
            {
                var stderr = await stderrTask;
                throw new InvalidOperationException(
                    $"'{toolName}' failed with exit code {process.ExitCode}: {Tail(stderr)}");
            }
        }
    }

    private string ResolveToolPath(string toolName) =>
        string.IsNullOrWhiteSpace(options.PgToolsPath)
            ? toolName
            : Path.Combine(options.PgToolsPath, OperatingSystem.IsWindows() ? toolName + ".exe" : toolName);

    private static string Tail(string text, int maxLength = 2000) =>
        text.Length <= maxLength ? text : "…" + text[^maxLength..];
}
