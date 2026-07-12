#if __DESKTOP__
using System.Diagnostics;
using asERP.Client.Core.Notifications;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.Resources;

namespace asERP.Client.Core.Updates;

/// <summary>
/// Auto-updater for the installed Windows desktop client. Started once by the Shell; checks
/// GitHub Releases at startup and every 24 hours, offers the update via ContentDialog, then
/// downloads the installer and runs it silently (the installer closes and relaunches the app).
///
/// Only active when the app runs from the Inno Setup layout ({app}\Client\ next to the
/// uninstaller) — portable-zip and dev runs must never be switched to the installer.
/// </summary>
internal static class ClientUpdater
{
    private static readonly TimeSpan CheckInterval = TimeSpan.FromHours(24);

    private static Microsoft.UI.Dispatching.DispatcherQueueTimer? _timer;
    private static bool _started;
    private static bool _busy;
    private static Version? _declinedVersion;

    /// <summary>
    /// True when the app runs from the Inno Setup layout ({app}\Client\ next to the uninstaller)
    /// on Windows and can therefore update itself with the installer.
    /// </summary>
    public static bool IsInstalled => IsSelfUpdateSupported();

    /// <summary>Starts the periodic update check. No-op when self-update is not applicable.</summary>
    public static void Start(FrameworkElement host)
    {
        if (_started || !IsSelfUpdateSupported())
        {
            return;
        }
        _started = true;

        _timer = host.DispatcherQueue.CreateTimer();
        _timer.Interval = CheckInterval;
        _timer.IsRepeating = true;
        _timer.Tick += (_, _) => _ = CheckAsync(host);
        _timer.Start();

        _ = CheckAsync(host);
    }

    private static bool IsSelfUpdateSupported()
    {
        if (!OperatingSystem.IsWindows())
        {
            return false;
        }

        try
        {
            // Installed layout is {app}\Client\asERP.Client.exe with Inno's uninstaller in {app}.
            var appDir = Path.GetDirectoryName(Path.TrimEndingDirectorySeparator(AppContext.BaseDirectory));
            return appDir is not null && Directory.EnumerateFiles(appDir, "unins*.exe").Any();
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Runs entirely on the UI thread (Start and the timer tick both originate there),
    /// so the dialogs below can be shown directly.
    /// </summary>
    private static async Task CheckAsync(FrameworkElement host)
    {
        if (_busy)
        {
            return;
        }
        _busy = true;
        try
        {
            var latest = await ClientUpdateChecker.GetLatestAsync();
            if (latest is null
                || latest.Version <= ClientUpdateChecker.CurrentVersion
                || latest.Version == _declinedVersion
                || host.XamlRoot is null)
            {
                return;
            }

            await OfferAsync(host, latest);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ClientUpdater] Update check failed: {ex.Message}");
        }
        finally
        {
            _busy = false;
        }
    }

    /// <summary>
    /// Fetches the newest installer release and installs it immediately — no "install now?"
    /// prompt; callers ask in their own UI (e.g. the login overlay's update-required banner).
    /// Shows the download progress dialog, then exits the app for the silent install + relaunch.
    /// </summary>
    public static async Task UpdateNowAsync(FrameworkElement host)
    {
        if (_busy || host.XamlRoot is null)
        {
            return;
        }
        _busy = true;
        try
        {
            var loader = ResourceLoader.GetForViewIndependentUse();

            var latest = await ClientUpdateChecker.GetLatestAsync();
            if (latest is null)
            {
                ShowErrorToast(Localize(loader, "AppUpdate.DownloadFailed"));
                return;
            }
            if (latest.Version <= ClientUpdateChecker.CurrentVersion)
            {
                // Nothing newer released yet (e.g. the server's minimum is ahead of the
                // latest published installer) — installing the same version won't help.
                ShowErrorToast(Localize(loader, "AppUpdate.NoUpdateFound"));
                return;
            }

            await DownloadAndInstallAsync(host, latest, loader);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ClientUpdater] Immediate update failed: {ex.Message}");
        }
        finally
        {
            _busy = false;
        }
    }

    private static string Localize(ResourceLoader loader, string key)
        => loader.GetString(key) ?? key;

    private static async Task OfferAsync(FrameworkElement host, ClientReleaseInfo release)
    {
        var loader = ResourceLoader.GetForViewIndependentUse();

        var dialog = new ContentDialog
        {
            Title = Localize(loader, "AppUpdate.Title"),
            Content = string.Format(Localize(loader, "AppUpdate.Message"),
                release.Version, ClientUpdateChecker.CurrentVersion),
            PrimaryButtonText = Localize(loader, "AppUpdate.InstallNow"),
            CloseButtonText = Localize(loader, "AppUpdate.Later"),
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = host.XamlRoot,
            Style = Application.Current.Resources["ContentDialogStyle"] as Style
        };

        if (await dialog.ShowAsync() != ContentDialogResult.Primary)
        {
            // Don't nag on the next periodic tick; the next app start asks again.
            _declinedVersion = release.Version;
            return;
        }

        await DownloadAndInstallAsync(host, release, loader);
    }

    private static async Task DownloadAndInstallAsync(
        FrameworkElement host, ClientReleaseInfo release, ResourceLoader loader)
    {
        var progressDialog = new ContentDialog
        {
            Title = Localize(loader, "AppUpdate.Title"),
            Content = new StackPanel
            {
                Spacing = 12,
                Children =
                {
                    new TextBlock
                    {
                        Text = Localize(loader, "AppUpdate.Downloading"),
                        TextWrapping = TextWrapping.Wrap
                    },
                    new ProgressBar { IsIndeterminate = true }
                }
            },
            XamlRoot = host.XamlRoot,
            Style = Application.Current.Resources["ContentDialogStyle"] as Style
        };
        _ = progressDialog.ShowAsync();

        string installerPath;
        try
        {
            installerPath = await ClientUpdateChecker.DownloadAsync(release);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ClientUpdater] Download failed: {ex.Message}");
            progressDialog.Hide();
            ShowErrorToast(Localize(loader, "AppUpdate.DownloadFailed"));
            return;
        }

        progressDialog.Hide();

        try
        {
            // /AUTOLAUNCH=1 makes the installer relaunch the client after the silent upgrade
            // (see installer/asERP.Client.Setup.iss). The admin-manifested installer raises
            // the UAC prompt via ShellExecute.
            Process.Start(new ProcessStartInfo(installerPath, "/SILENT /AUTOLAUNCH=1")
            {
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            // Includes the user dismissing the UAC prompt (Win32Exception 1223).
            Console.WriteLine($"[ClientUpdater] Installer start failed: {ex.Message}");
            ShowErrorToast(Localize(loader, "AppUpdate.InstallFailed"));
            return;
        }

        // Exit so the installer can replace the binaries.
        Application.Current.Exit();
    }

    private static void ShowErrorToast(string message)
        => App.Current?.Host?.Services?.GetService<INotificationService>()
            ?.Show(message, NotificationSeverity.Error);
}
#endif
