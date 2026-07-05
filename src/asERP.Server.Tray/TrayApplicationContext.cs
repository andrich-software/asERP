using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using asERP.Server.Tray.Forms;
using asERP.Server.Tray.Services;

namespace asERP.Server.Tray;

internal enum ServerState
{
    NotInstalled,
    Stopped,
    Pending,
    Running,
    RunningUnhealthy
}

internal sealed class TrayApplicationContext : ApplicationContext
{
    private static readonly TimeSpan UpdateCheckInterval = TimeSpan.FromHours(24);
    private const int HealthCheckEveryNthTick = 5;

    private readonly NotifyIcon _icon;
    private readonly System.Windows.Forms.Timer _pollTimer = new() { Interval = 3000 };
    private readonly System.Windows.Forms.Timer _updateTimer = new();
    private readonly ServiceControlService _service = new(AppPaths.ServiceName);
    private readonly HealthClient _health = new();
    private readonly Dictionary<ServerState, Icon> _stateIcons;

    private readonly ToolStripMenuItem _statusItem;
    private readonly ToolStripMenuItem _startItem;
    private readonly ToolStripMenuItem _stopItem;
    private readonly ToolStripMenuItem _restartItem;

    private ServerState _state = ServerState.NotInstalled;
    private bool _lastHealthResult = true;
    private int _tickCounter;
    private bool _actionRunning;
    private ReleaseInfo? _pendingUpdate;

    public TrayApplicationContext()
    {
        _stateIcons = new Dictionary<ServerState, Icon>
        {
            [ServerState.NotInstalled] = CreateStatusIcon(Color.Firebrick),
            [ServerState.Stopped] = CreateStatusIcon(Color.Gray),
            [ServerState.Pending] = CreateStatusIcon(Color.SteelBlue),
            [ServerState.Running] = CreateStatusIcon(Color.ForestGreen),
            [ServerState.RunningUnhealthy] = CreateStatusIcon(Color.Goldenrod)
        };

        var menu = new ContextMenuStrip();
        _statusItem = new ToolStripMenuItem("Status: unknown") { Enabled = false };
        _startItem = new ToolStripMenuItem("Start service", null, async (_, _) => await RunServiceActionAsync(_service.StartAsync, "start"));
        _stopItem = new ToolStripMenuItem("Stop service", null, async (_, _) => await RunServiceActionAsync(_service.StopAsync, "stop"));
        _restartItem = new ToolStripMenuItem("Restart service", null, async (_, _) => await RunServiceActionAsync(_service.RestartAsync, "restart"));

        menu.Items.Add(_statusItem);
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(_startItem);
        menu.Items.Add(_stopItem);
        menu.Items.Add(_restartItem);
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(new ToolStripMenuItem("Settings…", null, (_, _) => ShowSettings()));
        menu.Items.Add(new ToolStripMenuItem("Create backup…", null, (_, _) => CreateBackup()));
        menu.Items.Add(new ToolStripMenuItem("Restore backup…", null, (_, _) => RestoreBackup()));
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(new ToolStripMenuItem("Open logs folder", null, (_, _) => OpenLogsFolder()));
        menu.Items.Add(new ToolStripMenuItem("Check for updates", null, async (_, _) => await CheckForUpdatesAsync(manual: true)));
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(new ToolStripMenuItem("Exit", null, (_, _) => ExitThread()));

        _icon = new NotifyIcon
        {
            ContextMenuStrip = menu,
            Icon = _stateIcons[ServerState.NotInstalled],
            Text = "asERP Server",
            Visible = true
        };
        _icon.BalloonTipClicked += OnBalloonTipClicked;

        _pollTimer.Tick += async (_, _) => await RefreshStatusAsync();
        _pollTimer.Start();

        _updateTimer.Interval = (int)UpdateCheckInterval.TotalMilliseconds;
        _updateTimer.Tick += async (_, _) => await CheckForUpdatesAsync(manual: false);
        _updateTimer.Start();

        _ = RefreshStatusAsync();
        _ = CheckForUpdatesAsync(manual: false);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _pollTimer.Dispose();
            _updateTimer.Dispose();
            _icon.Visible = false;
            _icon.Dispose();
            foreach (var icon in _stateIcons.Values)
            {
                icon.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    private async Task RefreshStatusAsync()
    {
        if (_actionRunning)
        {
            return;
        }

        var status = _service.QueryStatus();
        var state = status switch
        {
            null => ServerState.NotInstalled,
            ServiceControllerStatus.Running => ServerState.Running,
            ServiceControllerStatus.Stopped => ServerState.Stopped,
            _ => ServerState.Pending
        };

        if (state == ServerState.Running)
        {
            // The HTTP probe is heavier than the SCM query — run it on every 5th tick only.
            if (_tickCounter++ % HealthCheckEveryNthTick == 0)
            {
                _lastHealthResult = await _health.IsHealthyAsync(SettingsStore.Load().Port);
            }
            if (!_lastHealthResult)
            {
                state = ServerState.RunningUnhealthy;
            }
        }
        else
        {
            _lastHealthResult = true;
            _tickCounter = 0;
        }

        ApplyState(state);
    }

    private void ApplyState(ServerState state)
    {
        var previous = _state;
        _state = state;

        var statusText = state switch
        {
            ServerState.NotInstalled => "not installed",
            ServerState.Stopped => "stopped",
            ServerState.Pending => "starting/stopping…",
            ServerState.Running => $"running (port {SettingsStore.Load().Port})",
            ServerState.RunningUnhealthy => "running, unhealthy",
            _ => "unknown"
        };

        _statusItem.Text = $"Status: {statusText}";
        _icon.Icon = _stateIcons[state];
        _icon.Text = TrimTooltip($"asERP Server: {statusText}");

        _startItem.Enabled = state is ServerState.Stopped && !_actionRunning;
        _stopItem.Enabled = state is ServerState.Running or ServerState.RunningUnhealthy && !_actionRunning;
        _restartItem.Enabled = state is ServerState.Running or ServerState.RunningUnhealthy && !_actionRunning;

        // Notify only on transitions into a bad state — not on every poll.
        if (previous != state && state is ServerState.NotInstalled or ServerState.RunningUnhealthy
            && previous != ServerState.NotInstalled)
        {
            _icon.ShowBalloonTip(5000, "asERP Server", $"Service is {statusText}.", ToolTipIcon.Warning);
        }
    }

    // NotifyIcon.Text is limited to 127 characters.
    private static string TrimTooltip(string text) => text.Length <= 127 ? text : text[..127];

    private async Task RunServiceActionAsync(Func<Task> action, string actionName)
    {
        if (_actionRunning)
        {
            return;
        }

        _actionRunning = true;
        ApplyState(ServerState.Pending);
        try
        {
            await action();
        }
        catch (OperationCanceledException)
        {
            // User dismissed the UAC prompt — nothing to report.
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not {actionName} the asERP service: {ex.Message}",
                "asERP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _actionRunning = false;
        }
        await RefreshStatusAsync();
    }

    private void ShowSettings()
    {
        using var form = new SettingsForm(SettingsStore.Load());
        form.ShowDialog();
        if (!form.SettingsChanged || _service.QueryStatus() != ServiceControllerStatus.Running)
        {
            return;
        }

        var restart = MessageBox.Show(
            "Restart the asERP Server service now to apply the changed settings?",
            "asERP Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (restart == DialogResult.Yes)
        {
            _ = RunServiceActionAsync(_service.RestartAsync, "restart");
        }
    }

    private void CreateBackup()
    {
        var settings = SettingsStore.Load();
        Directory.CreateDirectory(AppPaths.BackupsDirectory);

        using var dialog = new SaveFileDialog
        {
            Title = "Create database backup",
            InitialDirectory = AppPaths.BackupsDirectory,
            FileName = $"asERP-backup-{DateTime.Now:yyyyMMdd-HHmm}{settings.BackupFileExtension}",
            Filter = $"asERP backup (*{settings.BackupFileExtension})|*{settings.BackupFileExtension}|All files (*.*)|*.*"
        };
        if (dialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        ProgressForm.Run(null, "Creating backup", async progress =>
        {
            progress.Report($"Backing up the {settings.Provider} database…");
            var (exitCode, output) = await ServerCliRunner.RunAsync(progress, "backup", dialog.FileName);
            if (exitCode != 0)
            {
                throw new InvalidOperationException(
                    string.IsNullOrWhiteSpace(output) ? "Backup failed." : output);
            }
        });
    }

    private void RestoreBackup()
    {
        var settings = SettingsStore.Load();

        using var dialog = new OpenFileDialog
        {
            Title = "Restore database backup",
            InitialDirectory = Directory.Exists(AppPaths.BackupsDirectory)
                ? AppPaths.BackupsDirectory
                : AppPaths.DataDirectory,
            Filter = $"asERP backup (*{settings.BackupFileExtension})|*{settings.BackupFileExtension}|All files (*.*)|*.*"
        };
        if (dialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        var confirmed = MessageBox.Show(
            "Restoring a backup REPLACES ALL CURRENT DATA in the configured database.\n\n" +
            "The asERP Server service will be stopped during the restore and started again afterwards.\n\n" +
            "Continue?",
            "Restore backup", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        if (confirmed != DialogResult.Yes)
        {
            return;
        }

        var wasRunning = _service.QueryStatus() == ServiceControllerStatus.Running;

        ProgressForm.Run(null, "Restoring backup", async progress =>
        {
            if (wasRunning)
            {
                progress.Report("Stopping the asERP Server service…");
                await _service.StopAsync();
            }

            progress.Report($"Restoring '{Path.GetFileName(dialog.FileName)}'…");
            var (exitCode, output) = await ServerCliRunner.RunAsync(progress, "restore", dialog.FileName);
            if (exitCode != 0)
            {
                throw new InvalidOperationException(
                    (string.IsNullOrWhiteSpace(output) ? "Restore failed." : output) +
                    "\nThe service was left stopped — check the logs folder for details.");
            }

            progress.Report("Starting the asERP Server service…");
            await _service.StartAsync();

            progress.Report("Waiting for the server to become healthy…");
            if (!await _health.WaitUntilHealthyAsync(SettingsStore.Load().Port, TimeSpan.FromSeconds(30)))
            {
                throw new InvalidOperationException(
                    "The service was started but /health did not report healthy within 30 seconds — " +
                    "check the logs folder.");
            }
        });
        _ = RefreshStatusAsync();
    }

    private static void OpenLogsFolder()
    {
        Directory.CreateDirectory(AppPaths.LogsDirectory);
        Process.Start("explorer.exe", AppPaths.LogsDirectory);
    }

    private async Task CheckForUpdatesAsync(bool manual)
    {
        var latest = await new UpdateChecker().GetLatestAsync();
        if (latest is null || latest.Version <= UpdateChecker.CurrentVersion)
        {
            if (manual)
            {
                MessageBox.Show(
                    latest is null
                        ? "Could not reach the update server."
                        : $"asERP Server is up to date (version {UpdateChecker.CurrentVersion}).",
                    "Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return;
        }

        _pendingUpdate = latest;
        if (manual)
        {
            OfferUpdate(latest);
        }
        else
        {
            _icon.ShowBalloonTip(10000, "asERP Server update",
                $"Version {latest.Version} is available — click to install.", ToolTipIcon.Info);
        }
    }

    private void OnBalloonTipClicked(object? sender, EventArgs e)
    {
        if (_pendingUpdate is not null)
        {
            OfferUpdate(_pendingUpdate);
        }
    }

    private void OfferUpdate(ReleaseInfo release)
    {
        var install = MessageBox.Show(
            $"Install asERP Server {release.Version} now?\n\n" +
            "The installer will stop the service, update the binaries and start it again. " +
            "Your data and settings are preserved.",
            "asERP Server update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (install != DialogResult.Yes)
        {
            return;
        }

        string? installerPath = null;
        var downloaded = ProgressForm.Run(null, "Downloading update", async progress =>
        {
            installerPath = await new UpdateChecker().DownloadAsync(release, progress);
        });

        if (!downloaded || installerPath is null)
        {
            return;
        }

        try
        {
            UpdateChecker.RunInstaller(installerPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not start the installer: {ex.Message}",
                "asERP Server update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Exit so the installer can replace the tray binaries.
        ExitThread();
    }

    private static Icon CreateStatusIcon(Color color)
    {
        using var bitmap = new Bitmap(16, 16);
        using (var graphics = Graphics.FromImage(bitmap))
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.Transparent);
            using var brush = new SolidBrush(color);
            graphics.FillEllipse(brush, 1, 1, 14, 14);
            using var pen = new Pen(Color.FromArgb(90, 0, 0, 0));
            graphics.DrawEllipse(pen, 1, 1, 14, 14);
        }

        var iconHandle = bitmap.GetHicon();
        try
        {
            using var unmanagedIcon = Icon.FromHandle(iconHandle);
            return (Icon)unmanagedIcon.Clone();
        }
        finally
        {
            DestroyIcon(iconHandle);
        }
    }

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool DestroyIcon(IntPtr handle);
}
