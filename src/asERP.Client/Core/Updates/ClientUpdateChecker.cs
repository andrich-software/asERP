#if __DESKTOP__
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace asERP.Client.Core.Updates;

internal sealed record ClientReleaseInfo(Version Version, string AssetName, string DownloadUrl);

/// <summary>
/// Checks GitHub Releases for a newer desktop-client installer. Client installer releases use
/// the tag prefix "setup-v" — the repository shares its releases with the server ("server-v")
/// and the portable desktop archives ("v"), so /releases/latest must NOT be used.
/// Mirrors src/asERP.Server.Tray/Services/UpdateChecker.cs — keep the two in sync.
/// </summary>
internal static class ClientUpdateChecker
{
    private const string Owner = "andrich-software";
    private const string Repository = "asERP";
    private const string TagPrefix = "setup-v";

    private static readonly HttpClient Http = CreateClient();

    private static HttpClient CreateClient()
    {
        var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
        client.DefaultRequestHeaders.UserAgent.ParseAdd("asERP-Desktop");
        return client;
    }

    public static Version CurrentVersion
    {
        get
        {
            var processPath = Environment.ProcessPath;
            var fileVersion = processPath is null
                ? null
                : FileVersionInfo.GetVersionInfo(processPath).FileVersion;
            return Version.TryParse(fileVersion, out var version) ? version : new Version(0, 0, 0, 0);
        }
    }

    /// <summary>Returns the newest client installer release, or null when none is found / the API is unreachable.</summary>
    public static async Task<ClientReleaseInfo?> GetLatestAsync()
    {
        List<GithubRelease>? releases;
        try
        {
            // per_page=100 (API max): server and portable-zip releases share the list, so a burst
            // of those must not push the newest "setup-v" release out of the window.
            releases = await Http.GetFromJsonAsync<List<GithubRelease>>(
                $"https://api.github.com/repos/{Owner}/{Repository}/releases?per_page=100");
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
                    a.Name.StartsWith("asERP-Desktop-Setup-", StringComparison.OrdinalIgnoreCase)
                    && a.Name.EndsWith(".exe", StringComparison.OrdinalIgnoreCase));
                return asset is null
                    ? null
                    : new ClientReleaseInfo(candidate.Parsed!, asset.Name, asset.BrowserDownloadUrl);
            })
            .FirstOrDefault(info => info is not null);
    }

    /// <summary>Downloads the installer to %TEMP% and returns its path.</summary>
    public static async Task<string> DownloadAsync(ClientReleaseInfo release)
    {
        var targetPath = Path.Combine(Path.GetTempPath(), release.AssetName);

        // ResponseHeadersRead: the 30s client timeout only bounds time-to-headers,
        // not the (potentially long) body download of the self-contained installer.
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

        return targetPath;
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
#endif
