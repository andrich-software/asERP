using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Interceptors;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.NotificationHandlers;
using asERP.SalesChannels.Orchestration;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Interceptors;

/// <summary>
/// Full-pipeline tests for the channel-export safety net: a plain <c>DbContext.SaveChangesAsync</c>
/// must fan out through <see cref="ChannelExportNotificationInterceptor"/> to the SalesChannels
/// notification handlers and produce outbox rows. DI mirrors the production wiring (scoped
/// interceptor attached in <c>AddDbContext</c>, handlers resolving the same scoped
/// ApplicationDbContext) — unlike the handler-level tests that invoke the handlers directly and
/// therefore bypass the interceptor. This pins the EF behavior the safety net relies on:
/// SavedChangesAsync runs after the save completed and outside EF's concurrency critical section,
/// so handlers may query and re-save on the very context that triggered the save.
/// <see cref="ChannelExportInterceptorSqliteTests"/> covers the same pipeline on a relational
/// provider, which the InMemory provider could otherwise mask.
/// </summary>
public class ChannelExportNotificationInterceptorTests
{
    private static ServiceProvider BuildServiceProvider(Action<IServiceCollection>? configure = null)
    {
        var services = new ServiceCollection();
        var databaseName = Guid.NewGuid().ToString();

        services.AddLogging();
        services.AddScoped<ITenantContext, TestTenantContext>();
        services.AddScoped<IMediator, CustomMediator>();
        services.AddScoped<ChannelExportNotificationInterceptor>();
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            options.UseInMemoryDatabase(databaseName);
            options.AddInterceptors(serviceProvider.GetRequiredService<ChannelExportNotificationInterceptor>());
        });

        services.AddScoped<ChannelExportOutboxEnqueuer>();
        // SalesChangedNotificationHandler routes cancellations through the connector registry —
        // mirror the production wiring (registry over all registered connectors; none by default).
        // Without this the handler cannot be constructed and CustomMediator.Publish fails before
        // ANY handler (including test recorders) runs.
        services.AddScoped<ISalesChannelConnectorRegistry>(sp =>
            new SalesChannelConnectorRegistry(sp.GetServices<ISalesChannelConnector>()));
        services.AddScoped<INotificationHandler<SalesChangedNotification>, SalesChangedNotificationHandler>();
        services.AddScoped<INotificationHandler<ProductChangedNotification>, ProductChangedNotificationHandler>();
        services.AddScoped<INotificationHandler<ProductSalesChannelChangedNotification>, ProductSalesChannelChangedNotificationHandler>();
        services.AddScoped<INotificationHandler<StockChangedNotification>, StockChangedNotificationHandler>();

        configure?.Invoke(services);

        return services.BuildServiceProvider();
    }

    private static SalesChannel NewChannel(
        bool exportSales = false,
        bool exportProducts = false,
        bool exportStock = false)
        => new()
        {
            Id = Guid.NewGuid(),
            Type = SalesChannelType.WooCommerce,
            Name = "Interceptor Test Channel",
            Url = "https://shop.example.com",
            Username = "key",
            Password = "secret",
            IsEnabled = true,
            ExportSaless = exportSales,
            ExportProducts = exportProducts,
            ExportStock = exportStock,
            Warehouses = new List<Warehouse>(),
            TenantId = TenantConstants.TestTenant1Id
        };

    /// <summary>Seeding itself runs through the interceptor — drop the rows it produced so the
    /// assertions only see what the act-phase SaveChanges enqueued.</summary>
    private static async Task ClearOutboxAsync(ApplicationDbContext context)
    {
        var rows = await context.ChannelExportOutbox.IgnoreQueryFilters().ToListAsync();
        context.ChannelExportOutbox.RemoveRange(rows);
        await context.SaveChangesAsync();
    }

    [Fact]
    public async Task SalesStatusChange_SavedDirectlyOnContext_EnqueuesUpdateSalesOutboxRow()
    {
        await using var provider = BuildServiceProvider();
        await using var scope = provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var channel = NewChannel(exportSales: true);
        var sales = new Sales
        {
            Id = Guid.NewGuid(),
            SalesChannelId = channel.Id,
            Status = SalesStatus.Processing,
            TenantId = TenantConstants.TestTenant1Id
        };
        context.SalesChannel.Add(channel);
        context.Sales.Add(sales);
        await context.SaveChangesAsync();
        await ClearOutboxAsync(context);

        // A plain progress update with no explicit publish anywhere — the interceptor alone must
        // export. (A cancel is deliberately NOT exported as UpdateSales; it routes to the opt-in
        // CancelSales operation — covered by ChannelExportInterceptorSqliteTests.)
        sales.Status = SalesStatus.Completed;
        await context.SaveChangesAsync();

        var rows = await context.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.AggregateId == sales.Id && o.Operation == ChannelSyncOperation.UpdateSales)
            .ToListAsync();

        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(channel.Id, rows[0].SalesChannelId);
        TestAssertions.AssertEqual(ChannelOutboxStatus.Pending, rows[0].Status);
    }

    [Fact]
    public async Task ProductUpdate_SavedDirectlyOnContext_EnqueuesExportProductOutboxRow()
    {
        await using var provider = BuildServiceProvider();
        await using var scope = provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var channel = NewChannel(exportProducts: true);
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Sku = "INTERCEPT-SKU-1",
            Name = "Interceptor Product",
            TaxClassId = Guid.NewGuid(),
            TenantId = TenantConstants.TestTenant1Id
        };
        var link = new ProductSalesChannel
        {
            Id = Guid.NewGuid(),
            ProductId = product.Id,
            SalesChannelId = channel.Id,
            IsListed = true,
            TenantId = TenantConstants.TestTenant1Id
        };
        context.SalesChannel.Add(channel);
        context.Product.Add(product);
        context.ProductSalesChannel.Add(link);
        await context.SaveChangesAsync();
        await ClearOutboxAsync(context);

        product.Name = "Renamed Product";
        await context.SaveChangesAsync();

        var rows = await context.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.AggregateId == product.Id && o.Operation == ChannelSyncOperation.ExportProduct)
            .ToListAsync();

        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(channel.Id, rows[0].SalesChannelId);
    }

    [Fact]
    public async Task ProductDelete_SavedDirectlyOnContext_EnqueuesDelistWithSnapshotPayload()
    {
        await using var provider = BuildServiceProvider();
        await using var scope = provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        const string remoteId = "REMOTE-777";
        var channel = NewChannel(exportProducts: true);
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Sku = "INTERCEPT-SKU-2",
            Name = "Doomed Product",
            TaxClassId = Guid.NewGuid(),
            TenantId = TenantConstants.TestTenant1Id
        };
        var link = new ProductSalesChannel
        {
            Id = Guid.NewGuid(),
            ProductId = product.Id,
            SalesChannelId = channel.Id,
            IsListed = true,
            RemoteProductId = remoteId,
            TenantId = TenantConstants.TestTenant1Id
        };
        context.SalesChannel.Add(channel);
        context.Product.Add(product);
        context.ProductSalesChannel.Add(link);
        await context.SaveChangesAsync();
        await ClearOutboxAsync(context);

        // Product and its channel links go in one SaveChanges — the interceptor must snapshot the
        // remote id before the rows are gone and hand it to the delist handler.
        context.ProductSalesChannel.Remove(link);
        context.Product.Remove(product);
        await context.SaveChangesAsync();

        var rows = await context.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.AggregateId == product.Id && o.Operation == ChannelSyncOperation.DelistProduct)
            .ToListAsync();

        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(channel.Id, rows[0].SalesChannelId);
        TestAssertions.AssertTrue(rows[0].PayloadJson.Contains(remoteId));
    }

    [Fact]
    public async Task StockChange_SavedDirectlyOnContext_EnqueuesUpdateStockOutboxRow()
    {
        await using var provider = BuildServiceProvider();
        await using var scope = provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var warehouse = new Warehouse
        {
            Id = Guid.NewGuid(),
            Name = "Interceptor Warehouse",
            TenantId = TenantConstants.TestTenant1Id
        };
        var channel = NewChannel(exportStock: true);
        channel.Warehouses.Add(warehouse);
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Sku = "INTERCEPT-SKU-3",
            Name = "Stocked Product",
            TaxClassId = Guid.NewGuid(),
            TenantId = TenantConstants.TestTenant1Id
        };
        var link = new ProductSalesChannel
        {
            Id = Guid.NewGuid(),
            ProductId = product.Id,
            SalesChannelId = channel.Id,
            IsListed = true,
            TenantId = TenantConstants.TestTenant1Id
        };
        var stock = new ProductStock
        {
            Id = Guid.NewGuid(),
            ProductId = product.Id,
            WarehouseId = warehouse.Id,
            Stock = 10,
            TenantId = TenantConstants.TestTenant1Id
        };
        context.SalesChannel.Add(channel);
        context.Product.Add(product);
        context.ProductSalesChannel.Add(link);
        context.ProductStock.Add(stock);
        await context.SaveChangesAsync();
        await ClearOutboxAsync(context);

        stock.Stock = 7;
        await context.SaveChangesAsync();

        var rows = await context.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.AggregateId == product.Id && o.Operation == ChannelSyncOperation.UpdateStock)
            .ToListAsync();

        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(channel.Id, rows[0].SalesChannelId);
    }

    [Fact]
    public async Task SalesStatusTransitions_PublishKindDerivedFromStatus()
    {
        var recorder = new RecordingSalesHandler();
        await using var provider = BuildServiceProvider(services =>
        {
            services.AddSingleton(recorder);
            services.AddScoped<INotificationHandler<SalesChangedNotification>>(sp =>
                sp.GetRequiredService<RecordingSalesHandler>());
        });
        await using var scope = provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var channel = NewChannel(exportSales: true);
        var sales = new Sales
        {
            Id = Guid.NewGuid(),
            SalesChannelId = channel.Id,
            Status = SalesStatus.Pending,
            TenantId = TenantConstants.TestTenant1Id
        };
        context.SalesChannel.Add(channel);
        context.Sales.Add(sales);
        await context.SaveChangesAsync();
        recorder.Kinds.Clear();

        sales.Status = SalesStatus.Processing;
        await context.SaveChangesAsync();
        sales.Status = SalesStatus.Refunded;
        await context.SaveChangesAsync();

        TestAssertions.AssertEqual(2, recorder.Kinds.Count);
        TestAssertions.AssertEqual(SalesChangeKind.StatusChanged, recorder.Kinds[0]);
        TestAssertions.AssertEqual(SalesChangeKind.Refunded, recorder.Kinds[1]);
    }

    private sealed class RecordingSalesHandler : INotificationHandler<SalesChangedNotification>
    {
        public List<SalesChangeKind> Kinds { get; } = new();

        public Task Handle(SalesChangedNotification notification, CancellationToken cancellationToken)
        {
            Kinds.Add(notification.Kind);
            return Task.CompletedTask;
        }
    }

    [Fact]
    public async Task HandlerThrowing_DoesNotFailTheTriggeringSaveChanges()
    {
        await using var provider = BuildServiceProvider(services =>
            services.AddScoped<INotificationHandler<SalesChangedNotification>, ThrowingSalesHandler>());
        await using var scope = provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var channel = NewChannel(exportSales: true);
        var sales = new Sales
        {
            Id = Guid.NewGuid(),
            SalesChannelId = channel.Id,
            Status = SalesStatus.Processing,
            TenantId = TenantConstants.TestTenant1Id
        };
        context.SalesChannel.Add(channel);
        context.Sales.Add(sales);
        await context.SaveChangesAsync();

        sales.Status = SalesStatus.Cancelled;
        await context.SaveChangesAsync();

        var persistedStatus = await context.Sales
            .IgnoreQueryFilters()
            .Where(s => s.Id == sales.Id)
            .Select(s => s.Status)
            .SingleAsync();

        TestAssertions.AssertEqual(SalesStatus.Cancelled, persistedStatus);
    }

    private sealed class ThrowingSalesHandler : INotificationHandler<SalesChangedNotification>
    {
        public Task Handle(SalesChangedNotification notification, CancellationToken cancellationToken)
            => throw new InvalidOperationException("Simulated handler failure");
    }
}
