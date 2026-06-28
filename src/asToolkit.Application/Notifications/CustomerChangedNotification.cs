using asToolkit.Application.Mediator;

namespace asToolkit.Application.Notifications;

public sealed record CustomerChangedNotification(Guid CustomerId, Guid? TenantId, CustomerChangeKind Kind) : INotification;

public enum CustomerChangeKind
{
    Created = 0,
    Updated = 1,
    Deleted = 2,
}
