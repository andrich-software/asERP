using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace asERP.Persistence.Interceptors;

/// <summary>
/// EF Core save-changes interceptor that fans domain mutations out as notifications. Picks up
/// every Add/Update/Delete on Product, ProductSalesChannel, ProductStock, Sales and Customer
/// regardless of whether the caller went through a CQRS command-handler or wrote to the DbContext
/// directly. Notifications are published after SaveChanges succeeds, so a failed save never
/// produces phantom outbox rows. SavedChangesAsync runs inside the SaveChanges call stack but
/// after EF has released its concurrency guard and committed the implicit transaction — handlers
/// may therefore query and re-save on the same scoped DbContext (pinned by the interceptor
/// pipeline tests in asERP.Server.Tests). Writes that bypass the change tracker
/// (ExecuteUpdate/ExecuteDelete) and synchronous SaveChanges are invisible to this interceptor;
/// those paths must publish explicitly (see StockLedgerService).
///
/// This is the safety-net half of the export pipeline; CQRS handlers are still free to publish
/// richer notifications themselves (e.g. <c>SalesChangeKind.StatusChanged</c>), and the outbox
/// enqueuer's idempotency-key coalesces both paths.
///
/// IMediator is resolved lazily so this interceptor can also be activated in bootstrap/migration
/// contexts where no Application-layer services are registered. In that case notifications are
/// silently skipped.
/// </summary>
public sealed class ChannelExportNotificationInterceptor : SaveChangesInterceptor
{
    private readonly IServiceProvider _services;
    private readonly ILogger<ChannelExportNotificationInterceptor> _logger;
    private List<INotification>? _pending;

    public ChannelExportNotificationInterceptor(IServiceProvider services, ILogger<ChannelExportNotificationInterceptor> logger)
    {
        _services = services;
        _logger = logger;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return ValueTask.FromResult(result);
        }

        _pending = CollectNotifications(eventData.Context.ChangeTracker);
        return ValueTask.FromResult(result);
    }

    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        if (_pending is null || _pending.Count == 0)
        {
            return result;
        }

        var notifications = _pending;
        _pending = null;

        foreach (var notification in notifications)
        {
            try
            {
                await PublishAsync(notification, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Notification handler failed for {Type}", notification.GetType().Name);
            }
        }

        return result;
    }

    public override void SaveChangesFailed(DbContextErrorEventData eventData)
    {
        _pending = null;
    }

    public override Task SaveChangesFailedAsync(DbContextErrorEventData eventData, CancellationToken cancellationToken = default)
    {
        _pending = null;
        return Task.CompletedTask;
    }

    private static List<INotification> CollectNotifications(ChangeTracker changeTracker)
    {
        var notifications = new List<INotification>();

        // A product delete removes the product and its sales-channel links in one SaveChanges.
        // Capture the soon-to-be-deleted links now (grouped by product) so the delist can still
        // address the remote item after the rows are gone.
        var deletedLinksByProduct = changeTracker.Entries<ProductSalesChannel>()
            .Where(e => e.State == EntityState.Deleted)
            .Select(e => e.Entity)
            .GroupBy(psc => psc.ProductId)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var entry in changeTracker.Entries())
        {
            if (entry.State is not (EntityState.Added or EntityState.Modified or EntityState.Deleted))
            {
                continue;
            }

            switch (entry.Entity)
            {
                case Product product:
                    IReadOnlyList<ProductDelistSnapshot>? delistSnapshots = null;
                    if (entry.State == EntityState.Deleted
                        && deletedLinksByProduct.TryGetValue(product.Id, out var links))
                    {
                        delistSnapshots = links
                            .Select(psc => new ProductDelistSnapshot(
                                psc.SalesChannelId, psc.Id, product.Sku,
                                psc.RemoteProductId, psc.ExternalListingId, psc.IsListed))
                            .ToList();
                    }

                    notifications.Add(new ProductChangedNotification(
                        product.Id, product.TenantId, MapProductKind(entry.State), delistSnapshots));
                    break;

                case ProductSalesChannel psc:
                    notifications.Add(new ProductSalesChannelChangedNotification(
                        psc.Id, psc.ProductId, psc.SalesChannelId, psc.TenantId));
                    break;

                case ProductStock stock:
                    notifications.Add(new StockChangedNotification(
                        stock.ProductId, stock.WarehouseId, stock.TenantId));
                    break;

                case Sales sales:
                    notifications.Add(new SalesChangedNotification(
                        sales.Id, sales.TenantId, MapSalesKind(entry, sales)));
                    break;

                case Customer customer:
                    notifications.Add(new CustomerChangedNotification(
                        customer.Id, customer.TenantId, MapCustomerKind(entry.State)));
                    break;
            }
        }

        return notifications;
    }

    private async Task PublishAsync(INotification notification, CancellationToken cancellationToken)
    {
        var mediator = _services.GetService<IMediator>();
        if (mediator is null)
            return;

        switch (notification)
        {
            case ProductChangedNotification n:
                await mediator.Publish(n, cancellationToken);
                break;
            case ProductSalesChannelChangedNotification n:
                await mediator.Publish(n, cancellationToken);
                break;
            case StockChangedNotification n:
                await mediator.Publish(n, cancellationToken);
                break;
            case SalesChangedNotification n:
                await mediator.Publish(n, cancellationToken);
                break;
            case CustomerChangedNotification n:
                await mediator.Publish(n, cancellationToken);
                break;
        }
    }

    private static ProductChangeKind MapProductKind(EntityState state) => state switch
    {
        EntityState.Added => ProductChangeKind.Created,
        EntityState.Deleted => ProductChangeKind.Deleted,
        _ => ProductChangeKind.Updated,
    };

    /// <summary>
    /// Orders are never hard-deleted in the normal flow — a cancel or refund arrives here as a
    /// plain status update. Derive the kind from the status transition, otherwise handlers that
    /// act only on <see cref="SalesChangeKind.Cancelled"/>/<see cref="SalesChangeKind.Refunded"/>
    /// (e.g. POS stock compensation) never fire via the safety net.
    /// </summary>
    private static SalesChangeKind MapSalesKind(EntityEntry entry, Sales sales)
    {
        switch (entry.State)
        {
            case EntityState.Added:
                return SalesChangeKind.Created;
            case EntityState.Deleted:
                return SalesChangeKind.Cancelled;
        }

        var oldStatus = entry.OriginalValues.GetValue<SalesStatus>(nameof(Sales.Status));
        return sales.Status switch
        {
            SalesStatus.Cancelled when oldStatus != SalesStatus.Cancelled => SalesChangeKind.Cancelled,
            SalesStatus.Refunded when oldStatus != SalesStatus.Refunded => SalesChangeKind.Refunded,
            _ => SalesChangeKind.StatusChanged,
        };
    }

    private static CustomerChangeKind MapCustomerKind(EntityState state) => state switch
    {
        EntityState.Added => CustomerChangeKind.Created,
        EntityState.Deleted => CustomerChangeKind.Deleted,
        _ => CustomerChangeKind.Updated,
    };
}
