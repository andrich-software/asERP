using asERP.Client.Core.Notifications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.UI;

namespace asERP.Client.Features.Shell.Views;

/// <summary>
/// Renders app-wide toast notifications. Subscribes to the singleton <see cref="INotificationService"/>
/// and shows a stack of auto-dismissing toasts in the bottom-right corner. Lives once, at the top of
/// the Shell's visual tree, so notifications survive page navigation (e.g. a background import that
/// finishes after the edit page is gone).
/// </summary>
public sealed partial class NotificationHost : UserControl
{
    /// <summary>Default time a toast stays visible before auto-dismiss.</summary>
    private static readonly TimeSpan DefaultDuration = TimeSpan.FromSeconds(6);

    // Segoe MDL2 / Fluent icon glyphs.
    private const string GlyphSuccess = ""; // Completed
    private const string GlyphWarning = ""; // Warning
    private const string GlyphError = "";   // ErrorBadge
    private const string GlyphInfo = "";    // Info
    private const string GlyphClose = "";   // Cancel

    private readonly DispatcherQueue _dispatcher;
    private DispatcherQueueTimer? _subscribeTimer;
    private INotificationService? _notifications;

    public NotificationHost()
    {
        this.InitializeComponent();
        _dispatcher = DispatcherQueue.GetForCurrentThread();

        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        // The host is created by XAML while the Shell is navigated to — at that point App.Host
        // (and thus the DI container) is not assigned yet, so we cannot resolve the service
        // synchronously. Poll briefly until the container is ready, then subscribe once.
        if (TrySubscribe())
        {
            return;
        }

        _subscribeTimer = _dispatcher.CreateTimer();
        _subscribeTimer.Interval = TimeSpan.FromMilliseconds(250);
        _subscribeTimer.IsRepeating = true;
        _subscribeTimer.Tick += (_, _) =>
        {
            if (TrySubscribe())
            {
                _subscribeTimer?.Stop();
            }
        };
        _subscribeTimer.Start();
    }

    private bool TrySubscribe()
    {
        if (_notifications is not null)
        {
            return true;
        }

        // App.Host is null until OnLaunched finishes the initial navigation. Access it null-safely
        // (App.Services would throw while Host is still null).
        var services = App.Current?.Host?.Services;
        _notifications = services?.GetService<INotificationService>();
        if (_notifications is null)
        {
            return false;
        }

        _notifications.NotificationRaised += OnNotificationRaised;
        return true;
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        _subscribeTimer?.Stop();
        _subscribeTimer = null;

        if (_notifications is not null)
        {
            _notifications.NotificationRaised -= OnNotificationRaised;
        }
    }

    private void OnNotificationRaised(object? sender, Notification notification)
    {
        // The event may be raised from a background thread (e.g. a fire-and-forget import task),
        // so always marshal the UI work onto the dispatcher.
        if (_dispatcher.HasThreadAccess)
        {
            AddToast(notification);
        }
        else
        {
            _dispatcher.TryEnqueue(() => AddToast(notification));
        }
    }

    private void AddToast(Notification notification)
    {
        var (background, glyph) = StyleFor(notification.Severity);
        var foreground = new SolidColorBrush(Colors.White);

        var border = new Border
        {
            Background = new SolidColorBrush(background),
            CornerRadius = new CornerRadius(8),
            Padding = new Thickness(14, 12, 10, 12),
            Translation = new System.Numerics.Vector3(0, 0, 16)
        };
        border.Shadow = new ThemeShadow();

        var grid = new Grid();
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

        var icon = new FontIcon
        {
            Glyph = glyph,
            FontSize = 18,
            Foreground = foreground,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 1, 12, 0)
        };
        Grid.SetColumn(icon, 0);
        grid.Children.Add(icon);

        var textStack = new StackPanel { VerticalAlignment = VerticalAlignment.Center };
        if (!string.IsNullOrWhiteSpace(notification.Title))
        {
            textStack.Children.Add(new TextBlock
            {
                Text = notification.Title,
                Foreground = foreground,
                FontWeight = FontWeights.SemiBold,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 0, 0, 2)
            });
        }

        textStack.Children.Add(new TextBlock
        {
            Text = notification.Message,
            Foreground = foreground,
            TextWrapping = TextWrapping.Wrap
        });
        Grid.SetColumn(textStack, 1);
        grid.Children.Add(textStack);

        var closeButton = new Button
        {
            Content = new FontIcon { Glyph = GlyphClose, FontSize = 12, Foreground = foreground },
            Background = new SolidColorBrush(Colors.Transparent),
            BorderThickness = new Thickness(0),
            Padding = new Thickness(6),
            Margin = new Thickness(8, -4, -4, 0),
            VerticalAlignment = VerticalAlignment.Top
        };
        Grid.SetColumn(closeButton, 2);
        grid.Children.Add(closeButton);

        border.Child = grid;

        // Auto-dismiss timer. Closing manually stops it so it does not fire twice.
        var timer = _dispatcher.CreateTimer();
        timer.Interval = notification.Duration ?? DefaultDuration;
        timer.IsRepeating = false;

        void Remove()
        {
            timer.Stop();
            ToastPanel.Children.Remove(border);
        }

        timer.Tick += (_, _) => Remove();
        closeButton.Click += (_, _) => Remove();

        ToastPanel.Children.Add(border);
        timer.Start();
    }

    private static (Color Background, string Glyph) StyleFor(NotificationSeverity severity) => severity switch
    {
        NotificationSeverity.Success => (Color.FromArgb(0xFF, 0x16, 0xA3, 0x4A), GlyphSuccess),
        NotificationSeverity.Warning => (Color.FromArgb(0xFF, 0xD9, 0x77, 0x06), GlyphWarning),
        NotificationSeverity.Error => (Color.FromArgb(0xFF, 0xDC, 0x26, 0x26), GlyphError),
        _ => (Color.FromArgb(0xFF, 0x25, 0x63, 0xEB), GlyphInfo),
    };
}
