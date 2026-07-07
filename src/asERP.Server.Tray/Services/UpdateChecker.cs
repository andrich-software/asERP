using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace asERP.Server.Tray.Services;

internal sealed record ReleaseInfo(Version Version, string AssetName, string DownloadUrl);

/// <summary>
/// Checks GitHub Releases for a newer server installer. Server releases use the tag
/// prefix "server-v" — the repository shares its releases with the desktop client
/// ("v" tags), so /releases/latest must NOT be used.
/// </summary>
internal sealed class UpdateChecker
{
    private const string Owner = "andrich-software";
    private const string Repository = "asERP";
    private const string TagPrefix = "server-v";

    private static readonly HttpClient Http = CreateClient();

    private static HttpClient CreateClient()
    {
        var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
        client.DefaultRequestHeaders.UserAgent.ParseAdd("asERP-Server-Tray");
        return client;
    }

    public static Version CurrentVersion
    {
        get
        {
            var fileVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            return Version.TryParse(fileVersion, out var version) ? version : new Version(0, 0, 0, 0);
        }
    }

    /// <summary>Returns the newest server release, or null when none is found / the API is unreachable.</summary>
    public async Task<ReleaseInfo?> GetLatestAsync()
    {
        List<GithubRelease>? releases;
        try
        {
            releases = await Http.GetFromJsonAsync<List<GithubRelease>>(
                $"https://api.github.com/repos/{Owner}/{Repository}/releases?per_page=20");
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            return null;
        }

        return releases?
            .Where(release => release is { Draft: false, Prerelease: false }
                              && release.TagName.StartsWith(TagPrefix, StringComparison.Ordinal))
            .Select(release => (Release: release,
                Parsed: Version.TryParse(release.TagName[TagPrefix.Length..], out var version) ? version : null))
            .Where(candidate => candidate.Parsed is not null)
            .OrderByDescending(candidate => candidate.Parsed)
            .Select(candidate =>
            {
                var asset = candidate.Release.Assets.FirstOrDefault(a =>
                    a.Name.StartsWith("asERP-Server-Setup-", StringComparison.OrdinalIgnoreCase)
                    && a.Name.EndsWith(".exe", StringComparison.OrdinalIgnoreCase));
                return asset is null
                    ? null
                    : new ReleaseInfo(candidate.Parsed!, asset.Name, asset.BrowserDownloadUrl);
            })
            .FirstOrDefault(info => info is not null);
    }

    /// <summary>Downloads the installer to %TEMP% and returns its path.</summary>
    public async Task<string> DownloadAsync(ReleaseInfo release, IProgress<string>? progress)
    {
        var targetPath = Path.Combine(Path.GetTempPath(), release.AssetName);
        progress?.Report($"Downloading {release.AssetName}…");

        using var response = await Http.GetAsync(release.DownloadUrl, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        await using (var target = File.Create(targetPath))
        {
            await response.Content.CopyToAsync(target);
        }

        var expectedLength = response.Content.Headers.ContentLength;
        if (expectedLength is > 0 && new FileInfo(targetPath).Length != expectedLength)
        {
            throw new InvalidOperationException("Downloaded installer is incomplete.");
        }

        progress?.Report("Download completed.");
        return targetPath;
    }

    /// <summary>Launches the installer (silent upgrade); its admin manifest raises the UAC prompt.</summary>
    public static void RunInstaller(string installerPath)
    {
        Process.Start(new ProcessStartInfo(installerPath, "/SILENT")
        {
            UseShellExecute = true
        });
    }

    private sealed record GithubRelease(
        [property: JsonPropertyName("tag_name")] string TagName,
        [property: JsonPropertyName("draft")] bool Draft,
        [property: JsonPropertyName("prerelease")] bool Prerelease,
        [property: JsonPropertyName("assets")] List<GithubAsset> Assets);

    private sealed record GithubAsset(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("browser_download_url")] string BrowserDownloadUrl);
}
