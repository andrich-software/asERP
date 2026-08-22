using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Shop.Hosting;

namespace asERP.Shop.NotificationHandlers;

/// <summary>
/// Drops the host resolver's cached host map when domain bindings change, so admin edits take
/// effect immediately instead of after the 30s TTL.
/// </summary>
public class ShopDomainChangedNotificationHandler : INotificationHandler<ShopDomainChangedNotification>
{
    private readonly IShopHostResolver _resolver;

    public ShopDomainChangedNotificationHandler(IShopHostResolver resolver)
    {
        _resolver = resolver;
    }

    public Task Handle(ShopDomainChangedNotification notification, CancellationToken cancellationToken)
    {
        _resolver.Invalidate();
        return Task.CompletedTask;
    }
}
