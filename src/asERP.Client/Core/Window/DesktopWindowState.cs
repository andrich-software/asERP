#if __DESKTOP__
using System;
using System.Globalization;
using Microsoft.UI.Windowing;
using Windows.Foundation.Collections;
using Windows.Graphics;
using Windows.Storage;

namespace asERP.Client.Core.Window;

/// <summary>
/// Persists the desktop window's position, size and (on Windows) maximized state to
/// <see cref="ApplicationData.Current.LocalSettings"/> and restores them on the next launch.
///
/// All persisted coordinates are in <b>physical pixels</b> — the unit reported by
/// <see cref="AppWindow.Position"/> / <see cref="AppWindow.Size"/> and <c>DisplayArea.WorkArea</c> —
/// so no DPI conversion is needed on the round-trip.
///
/// <para><b>Display changes</b> (e.g. a notebook unplugged from an external monitor — the saved
/// position then points at a screen that is no longer attached) are handled per platform:</para>
/// <list type="bullet">
///   <item><b>Windows:</b> the <c>DisplayArea</c> APIs are implemented, so the saved rectangle is
///   clamped onto the work area of the nearest currently-attached display before it is applied
///   (see <see cref="NearestWorkArea"/>). Windows does not relocate off-screen windows on its own,
///   so this explicit clamp is what keeps the window visible.</item>
///   <item><b>macOS (and other Skia heads):</b> every <c>DisplayArea</c> lookup is an Uno stub that
///   throws, but the macOS window server itself constrains a window placed off-screen back onto a
///   visible display. The poll below then captures that corrected position and persists it, so the
///   next launch is already on-screen. (Verified: a deliberate move to (6000,4000) was relocated by
///   macOS to a fully visible position.)</item>
/// </list>
/// </summary>
internal static class DesktopWindowState
{
    private const string KeyX = "Window.X";
    private const string KeyY = "Window.Y";
    private const string KeyWidth = "Window.Width";
    private const string KeyHeight = "Window.Height";
    private const string KeyMaximized = "Window.IsMaximized";

    // Don't restore a window smaller than this — guards against a corrupt/tiny saved size.
    private const int MinWidth = 800;
    private const int MinHeight = 600;

    // How often the window geometry is sampled while the app runs (cheap; only writes on change).
    private static readonly TimeSpan PollInterval = TimeSpan.FromMilliseconds(1000);
    private static System.Threading.Timer? _saveTimer;

    // Last known "normal" (non-maximized) bounds — saved for the next launch even while maximized,
    // so un-maximizing after a restore returns the window to a sensible size.
    private static RectInt32 _lastNormalBounds;
    private static bool _isMaximized;

    // Snapshot of what was last written, so the poll only touches disk on an actual change.
    private static (int X, int Y, int W, int H, bool Max)? _lastPersisted;

    /// <summary>
    /// Restores the saved bounds onto <paramref name="window"/>, falling back to the given default
    /// size (centred on the nearest display) when nothing was saved yet. Applied after a short delay
    /// because <see cref="Window.AppWindow"/> is not reliably available at <c>OnLaunched</c> time.
    /// </summary>
    public static void RestoreAndTrack(Microsoft.UI.Xaml.Window window, int defaultWidth, int defaultHeight)
    {
        // macOS Retina reports physical pixels, so the logical default must be scaled to match the
        // saved (physical) values — keeps parity with the previous initial-size behaviour.
        var scale = OperatingSystem.IsMacOS() ? 2 : 1;

        TryApply(window, defaultWidth * scale, defaultHeight * scale, attempt: 0);
    }

    // AppWindow is not reliably available at OnLaunched time, so retry a few times before giving up.
    private const int MaxApplyAttempts = 8;
    private static readonly TimeSpan ApplyRetryDelay = TimeSpan.FromMilliseconds(500);
    private static System.Threading.Timer? _applyTimer;

    private static void TryApply(Microsoft.UI.Xaml.Window window, int defaultWidth, int defaultHeight, int attempt)
    {
        window.DispatcherQueue.TryEnqueue(() =>
        {
            try
            {
                if (window.AppWindow is null)
                {
                    if (attempt < MaxApplyAttempts)
                    {
                        _applyTimer?.Dispose();
                        _applyTimer = new System.Threading.Timer(
                            _ => TryApply(window, defaultWidth, defaultHeight, attempt + 1),
                            null, ApplyRetryDelay, System.Threading.Timeout.InfiniteTimeSpan);
                    }
                    return;
                }

                ApplyState(window, defaultWidth, defaultHeight);
                StartTracking(window);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DesktopWindowState] Restore failed: {ex.Message}");
            }
        });
    }

    private static void ApplyState(Microsoft.UI.Xaml.Window window, int defaultWidth, int defaultHeight)
    {
        var appWindow = window.AppWindow!;
        var values = ApplicationData.Current.LocalSettings.Values;
        // Evaluate all four (no short-circuit) so the locals are definitely assigned.
        var gotWidth = TryGetInt(values, KeyWidth, out var width);
        var gotHeight = TryGetInt(values, KeyHeight, out var height);
        var gotX = TryGetInt(values, KeyX, out var x);
        var gotY = TryGetInt(values, KeyY, out var y);
        var hasSaved = gotWidth && gotHeight && gotX && gotY;

        RectInt32 desired = hasSaved
            ? Rect(x, y, Math.Max(width, MinWidth), Math.Max(height, MinHeight))
            : CenteredDefault(appWindow, defaultWidth, defaultHeight);

        var bounds = EnsureVisible(appWindow, desired);

        appWindow.Move(new PointInt32 { X = bounds.X, Y = bounds.Y });
        appWindow.Resize(new SizeInt32 { Width = bounds.Width, Height = bounds.Height });
        _lastNormalBounds = bounds;

        // Re-maximize last so the restore-down target is the bounds we just set. Only on Windows —
        // see CaptureBounds for why the maximized flag is not trustworthy on other Skia heads.
        var wantMaximized = TryGetBool(values, KeyMaximized, out var max) && max;
        if (wantMaximized && OperatingSystem.IsWindows() && appWindow.Presenter is OverlappedPresenter presenter)
        {
            presenter.Maximize();
            _isMaximized = true;
        }
    }

    private static RectInt32 CenteredDefault(AppWindow appWindow, int width, int height)
    {
        var work = NearestWorkArea(appWindow, Rect(0, 0, width, height));
        var x = work.X + Math.Max(0, (work.Width - width) / 2);
        var y = work.Y + Math.Max(0, (work.Height - height) / 2);
        return Rect(x, y, width, height);
    }

    private static RectInt32 Rect(int x, int y, int width, int height) =>
        new() { X = x, Y = y, Width = width, Height = height };

    /// <summary>
    /// Clamps <paramref name="rect"/> so it sits fully inside the work area of the display nearest to
    /// it. When the display the window was last on is gone (external → internal), the resolved work
    /// area is that of a currently-attached screen, so the window can never open off-screen.
    /// </summary>
    private static RectInt32 EnsureVisible(AppWindow appWindow, RectInt32 rect)
    {
        var work = NearestWorkArea(appWindow, rect);

        var width = Math.Clamp(rect.Width, MinWidth, work.Width);
        var height = Math.Clamp(rect.Height, MinHeight, work.Height);
        var x = Math.Clamp(rect.X, work.X, work.X + work.Width - width);
        var y = Math.Clamp(rect.Y, work.Y, work.Y + work.Height - height);

        return Rect(x, y, width, height);
    }

    /// <summary>
    /// Resolves the work area to clamp against. Several <see cref="DisplayArea"/> lookups are stubbed
    /// (throw <see cref="NotImplementedException"/>) on Uno's Skia heads, so each candidate is tried
    /// defensively and the first that yields a usable rectangle wins:
    /// <list type="number">
    ///   <item>the display the window currently sits on (<see cref="DisplayArea.GetFromWindowId"/>),</item>
    ///   <item>the attached display whose work area overlaps <paramref name="rect"/> the most,</item>
    ///   <item>the primary display,</item>
    ///   <item>as a last resort, the rectangle itself (no clamping).</item>
    /// </list>
    /// </summary>
    private static RectInt32 NearestWorkArea(AppWindow appWindow, RectInt32 rect)
    {
        if (TryGetWorkArea(() => DisplayArea.GetFromWindowId(appWindow.Id, DisplayAreaFallback.Nearest), out var fromWindow))
        {
            return fromWindow;
        }

        if (TryGetWorkArea(() => BestOverlap(rect), out var fromOverlap))
        {
            return fromOverlap;
        }

        if (TryGetWorkArea(() => DisplayArea.Primary, out var fromPrimary))
        {
            return fromPrimary;
        }

        return rect;
    }

    /// <summary>Picks the attached display whose work area overlaps <paramref name="rect"/> the most.</summary>
    private static DisplayArea? BestOverlap(RectInt32 rect)
    {
        DisplayArea? best = null;
        long bestArea = -1;
        foreach (var area in DisplayArea.FindAll())
        {
            var w = area.WorkArea;
            var overlapW = Math.Max(0, Math.Min(rect.X + rect.Width, w.X + w.Width) - Math.Max(rect.X, w.X));
            var overlapH = Math.Max(0, Math.Min(rect.Y + rect.Height, w.Y + w.Height) - Math.Max(rect.Y, w.Y));
            long overlap = (long)overlapW * overlapH;
            if (overlap > bestArea)
            {
                bestArea = overlap;
                best = area;
            }
        }
        return best;
    }

    private static bool TryGetWorkArea(Func<DisplayArea?> resolve, out RectInt32 workArea)
    {
        workArea = default;
        try
        {
            var area = resolve()?.WorkArea;
            if (area is { Width: > 0, Height: > 0 } w)
            {
                workArea = w;
                return true;
            }
        }
        catch (NotImplementedException) { /* Uno stub on this head — try the next candidate. */ }
        catch (Exception ex) { Console.WriteLine($"[DesktopWindowState] WorkArea lookup failed: {ex.Message}"); }
        return false;
    }

    private static void StartTracking(Microsoft.UI.Xaml.Window window)
    {
        // AppWindow.Changed is stubbed on some Skia heads (notably macOS), so instead of relying on
        // it we poll the window geometry on the UI thread and write only when it actually changed.
        _saveTimer = new System.Threading.Timer(_ =>
            window.DispatcherQueue.TryEnqueue(() =>
            {
                if (window.AppWindow is { } w)
                {
                    CaptureBounds(w);
                    PersistIfChanged();
                }
            }),
            null, PollInterval, PollInterval);

        // Immediate, synchronous flush on close so the final state is never lost to the poll gap.
        window.Closed += (_, _) =>
        {
            _saveTimer?.Dispose();
            _saveTimer = null;
            if (window.AppWindow is { } w)
            {
                CaptureBounds(w);
            }
            Persist();
        };
    }

    private static void CaptureBounds(AppWindow appWindow)
    {
        // OverlappedPresenter.State is only reliable on Windows. macOS (and other Skia heads) report a
        // perfectly normal window as "Maximized", which would both wrongly force-maximize on the next
        // launch and — worse — freeze live-bounds capture (the guard below would never run). So only
        // honour the presenter state on Windows; everywhere else always record the live geometry.
        var presenter = appWindow.Presenter as OverlappedPresenter;
        var trustState = OperatingSystem.IsWindows() && presenter is not null;

        _isMaximized = trustState && presenter!.State == OverlappedPresenterState.Maximized;
        var isMinimized = trustState && presenter!.State == OverlappedPresenterState.Minimized;

        // Don't let a maximized/minimized rectangle become the next launch's "restored" size.
        if (!_isMaximized && !isMinimized)
        {
            _lastNormalBounds = Rect(
                appWindow.Position.X, appWindow.Position.Y,
                appWindow.Size.Width, appWindow.Size.Height);
        }
    }

    private static void PersistIfChanged()
    {
        var snapshot = (_lastNormalBounds.X, _lastNormalBounds.Y, _lastNormalBounds.Width, _lastNormalBounds.Height, _isMaximized);
        if (_lastPersisted == snapshot)
        {
            return;
        }
        Persist();
    }

    private static void Persist()
    {
        try
        {
            var values = ApplicationData.Current.LocalSettings.Values;
            values[KeyX] = _lastNormalBounds.X.ToString(CultureInfo.InvariantCulture);
            values[KeyY] = _lastNormalBounds.Y.ToString(CultureInfo.InvariantCulture);
            values[KeyWidth] = _lastNormalBounds.Width.ToString(CultureInfo.InvariantCulture);
            values[KeyHeight] = _lastNormalBounds.Height.ToString(CultureInfo.InvariantCulture);
            values[KeyMaximized] = _isMaximized ? "true" : "false";
            _lastPersisted = (_lastNormalBounds.X, _lastNormalBounds.Y, _lastNormalBounds.Width, _lastNormalBounds.Height, _isMaximized);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[DesktopWindowState] Persist failed: {ex.Message}");
        }
    }

    private static bool TryGetInt(IPropertySet values, string key, out int result)
    {
        result = 0;
        return values.TryGetValue(key, out var raw)
            && raw is not null
            && int.TryParse(raw.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
    }

    private static bool TryGetBool(IPropertySet values, string key, out bool result)
    {
        result = false;
        return values.TryGetValue(key, out var raw)
            && raw is not null
            && bool.TryParse(raw.ToString(), out result);
    }
}
#endif
