using System.Diagnostics;

namespace asERP.Server.Tray.Services;

/// <summary>
/// Runs out-of-band commands of the server binary (<c>asERP.Server.exe cli …</c>).
/// The CLI reads the same %ProgramData%\asERP\settings.json layer as the service,
/// so backup/restore/test-connection operate on the configured database.
/// </summary>
internal static class ServerCliRunner
{
    public static Task<(int ExitCode, string Output)> RunAsync(
        IProgress<string>? progress, params string[] cliArguments)
        => RunAsync(progress, environment: null, cliArguments);

    /// <summary>
    /// Runs a CLI command, optionally injecting extra environment variables into the
    /// child process. Used to pass secrets (e.g. superadmin email/password) out of band
    /// so they never appear in the process command line.
    /// </summary>
    public static async Task<(int ExitCode, string Output)> RunAsync(
        IProgress<string>? progress, IReadOnlyDictionary<string, string>? environment, params string[] cliArguments)
    {
        if (!File.Exists(AppPaths.ServerExePath))
        {
            throw new FileNotFoundException(
                $"asERP server binary not found at '{AppPaths.ServerExePath}'.", AppPaths.ServerExePath);
        }

        var startInfo = new ProcessStartInfo(AppPaths.ServerExePath)
        {
            WorkingDirectory = Path.GetDirectoryName(AppPaths.ServerExePath)!,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        startInfo.ArgumentList.Add("cli");
        foreach (var argument in cliArguments)
        {
            startInfo.ArgumentList.Add(argument);
        }
        startInfo.Environment["DOTNET_ENVIRONMENT"] = "Production";
        if (environment is not null)
        {
            foreach (var (key, value) in environment)
            {
                startInfo.Environment[key] = value;
            }
        }

        using var process = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Failed to start the asERP server binary.");

        var outputLines = new List<string>();
        void OnLine(string? line)
        {
            if (line is null)
            {
                return;
            }
            lock (outputLines)
            {
                outputLines.Add(line);
            }
            progress?.Report(line);
        }

        process.OutputDataReceived += (_, e) => OnLine(e.Data);
        process.ErrorDataReceived += (_, e) => OnLine(e.Data);
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        await process.WaitForExitAsync();

        lock (outputLines)
        {
            return (process.ExitCode, string.Join(Environment.NewLine, outputLines));
        }
    }
}
