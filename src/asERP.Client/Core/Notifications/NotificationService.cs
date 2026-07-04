namespace asERP.Client.Core.Notifications;

/// <summary>
/// Default <see cref="INotificationService"/> — a thin event bus. It does no UI work itself;
/// the notification host (in the Shell) subscribes and renders the toasts on the UI thread.
/// </summary>
public sealed class NotificationService : INotificationService
{
    public event EventHandler<Notification>? NotificationRaised;

    public void Show(Notification notification)
    {
        ArgumentNullException.ThrowIfNull(notification);
        NotificationRaised?.Invoke(this, notification);
    }

    public void Show(string message, NotificationSeverity severity = NotificationSeverity.Info, string? title = null)
        => Show(new Notification(message, severity, title));
}
