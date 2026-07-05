using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;

namespace asERP.Server.Infrastructure.Configuration;

/// <summary>
/// Layers an operator-editable settings file (written by the Windows installer / tray app)
/// over appsettings.json. Resolution order for the file path:
/// 1. ASERP_SETTINGS_PATH environment variable (any OS — explicit intent, always honored),
/// 2. %ProgramData%\asERP\settings.json on Windows (unless the fallback is disabled — the
///    server disables it for Development/Testing so an installed asERP service does not
///    hijack local dev runs on the same machine).
/// The source is inserted AFTER the last JSON source (appsettings.{Environment}.json) and
/// BEFORE environment variables / command line, so ASPNETCORE_* overrides still win.
/// </summary>
public static class ExternalSettings
{
    public const string PathEnvVar = "ASERP_SETTINGS_PATH";

    public static void AddTo(IConfigurationBuilder configuration, bool allowProgramDataFallback = true)
    {
        var path = Resolve(allowProgramDataFallback);
        if (path is not null && File.Exists(path))
        {
            AddFile(configuration, path);
        }
    }

    public static string? Resolve(bool allowProgramDataFallback = true)
    {
        var explicitPath = Environment.GetEnvironmentVariable(PathEnvVar);
        if (!string.IsNullOrWhiteSpace(explicitPath))
        {
            return explicitPath;
        }

        if (!allowProgramDataFallback || !OperatingSystem.IsWindows())
        {
            return null;
        }

        return Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            "asERP", "settings.json");
    }

    public static void AddFile(IConfigurationBuilder configuration, string path)
    {
        var fullPath = Path.GetFullPath(path);
        var source = new JsonConfigurationSource
        {
            Path = Path.GetFileName(fullPath),
            FileProvider = new PhysicalFileProvider(Path.GetDirectoryName(fullPath)!),
            Optional = true,
            // Provider / path changes require a service restart anyway; a hot reload
            // of a half-written file during a tray save would do more harm than good.
            ReloadOnChange = false
        };

        var lastJson = -1;
        for (var i = 0; i < configuration.Sources.Count; i++)
        {
            if (configuration.Sources[i] is JsonConfigurationSource)
            {
                lastJson = i;
            }
        }

        if (lastJson >= 0)
        {
            configuration.Sources.Insert(lastJson + 1, source);
        }
        else
        {
            configuration.Add(source);
        }
    }
}
