namespace asERP.Client.Core.Notifications;

/// <summary>
/// Severity of an app-level notification — drives the toast's color and icon.
/// </summary>
public enum NotificationSeverity
{
    Info,
    Success,
    Warning,
    Error
}

/// <summary>
/// A transient, app-wide notification (toast). Raised from anywhere via
/// <see cref="INotificationService"/> and rendered by the notification host in the Shell.
/// </summary>
/// <param name="Message">The body text shown to the user.</param>
/// <param name="Severity">Controls color/icon.</param>
/// <param name="Title">Optional bold title shown above the message.</param>
/// <param name="Duration">How long the toast stays visible before auto-dismiss. Null = default.</param>
public sealed record Notification(
    string Message,
    NotificationSeverity Severity = NotificationSeverity.Info,
    string? Title = null,
    TimeSpan? Duration = null);

/// <summary>
/// App-wide notification bus. Registered as a singleton so background work (e.g. a sales-channel
/// import kicked off after navigation) can surface success/failure to the user even though the
/// originating page is gone. The Shell hosts a single subscriber that renders the toasts.
/// </summary>
public interface INotificationService
{
    /// <summary>Raised on every <see cref="Show(Notification)"/> call. The host marshals to the UI thread.</summary>
    event EventHandler<Notification>? NotificationRaised;

    /// <summary>Surface a notification to the user.</summary>
    void Show(Notification notification);

    /// <summary>Convenience overload — surface a simple message at the given severity.</summary>
    void Show(string message, NotificationSeverity severity = NotificationSeverity.Info, string? title = null);
}
