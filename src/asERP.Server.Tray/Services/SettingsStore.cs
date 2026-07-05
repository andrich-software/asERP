using System.Text.Json;
using System.Text.Json.Nodes;
using asERP.Server.Tray.Models;

namespace asERP.Server.Tray.Services;

/// <summary>
/// Read-modify-write access to %ProgramData%\asERP\settings.json. Only the keys the
/// tray owns are patched; everything else (Serilog, DataProtection, …) is preserved
/// verbatim. Writes are atomic (temp file + replace).
/// </summary>
internal static class SettingsStore
{
    private static readonly JsonSerializerOptions WriteOptions = new() { WriteIndented = true };

    public static ServerSettings Load()
    {
        var settings = new ServerSettings();
        if (!File.Exists(AppPaths.SettingsFile))
        {
            return settings;
        }

        try
        {
            var root = JsonNode.Parse(File.ReadAllText(AppPaths.SettingsFile));
            if (root?["DatabaseConfig"] is JsonObject databaseConfig)
            {
                settings.Provider = databaseConfig["Provider"]?.GetValue<string>() ?? settings.Provider;
                settings.ConnectionString = databaseConfig["ConnectionString"]?.GetValue<string>() ?? settings.ConnectionString;
            }
            if (root?["FileStorage"]?["RootPath"]?.GetValue<string>() is { Length: > 0 } rootPath)
            {
                settings.FileStorageRootPath = rootPath;
            }
            if (root?["Urls"]?.GetValue<string>() is { Length: > 0 } urls)
            {
                settings.Port = ParsePort(urls) ?? settings.Port;
            }
        }
        catch (JsonException)
        {
            // Corrupt file — fall back to defaults; saving rewrites a valid file.
        }

        return settings;
    }

    public static void Save(ServerSettings settings)
    {
        JsonObject root = new();
        if (File.Exists(AppPaths.SettingsFile))
        {
            try
            {
                root = JsonNode.Parse(File.ReadAllText(AppPaths.SettingsFile)) as JsonObject ?? new JsonObject();
            }
            catch (JsonException)
            {
                root = new JsonObject();
            }
        }

        root["Urls"] = $"http://localhost:{settings.Port}";

        if (root["DatabaseConfig"] is not JsonObject databaseConfig)
        {
            databaseConfig = new JsonObject();
            root["DatabaseConfig"] = databaseConfig;
        }
        databaseConfig["Provider"] = settings.Provider;
        databaseConfig["ConnectionString"] = settings.ConnectionString;

        if (root["FileStorage"] is not JsonObject fileStorage)
        {
            fileStorage = new JsonObject();
            root["FileStorage"] = fileStorage;
        }
        fileStorage["RootPath"] = settings.FileStorageRootPath;

        Directory.CreateDirectory(AppPaths.DataDirectory);
        var tempFile = AppPaths.SettingsFile + ".tmp";
        File.WriteAllText(tempFile, root.ToJsonString(WriteOptions));
        if (File.Exists(AppPaths.SettingsFile))
        {
            File.Replace(tempFile, AppPaths.SettingsFile, destinationBackupFileName: null);
        }
        else
        {
            File.Move(tempFile, AppPaths.SettingsFile);
        }
    }

    internal static int? ParsePort(string urls)
    {
        var firstUrl = urls.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .FirstOrDefault();
        return firstUrl is not null && Uri.TryCreate(firstUrl, UriKind.Absolute, out var uri)
            ? uri.Port
            : null;
    }
}
