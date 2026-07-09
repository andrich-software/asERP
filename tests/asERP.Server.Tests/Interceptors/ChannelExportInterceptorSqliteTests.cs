using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Features.Sales.Commands.SalesCancel;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Infrastructure.Logging;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Interceptors;
using asERP.Persistence.Repositories;
using asERP.SalesChannels.NotificationHandlers;
using asERP.SalesChannels.Orchestration;
using asERP.Server.Tests.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Interceptors;

/// <summary>
/// Same safety-net pipeline as <see cref="ChannelExportNotificationInterceptorTests"/>, but on a
/// real relational provider (SQLite in-memory) so transaction handling, the concurrency detector
/// and reentrant SaveChanges behave exactly as in production — the EF InMemory provider could
/// otherwise mask provider-level differences. Also exercises the full production order-cancel
/// path (real <see cref="SalesCancelCommand"/> through repositories), which historically had no
/// interceptor-inclusive coverage at all.
/// </summary>
public class ChannelExportInterceptorSqliteTests : IDisposable
{
    private readonly SqliteConnection _connection;

    public ChannelExportInterceptorSqliteTests()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
    }

    public void Dispose() => _connection.Dispose();

    private ServiceProvider BuildServiceProvider(Action<IServiceCollection>? configure = null)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddScoped<ITenantContext, TestTenantContext>();
        services.AddScoped<IMediator, CustomMediator>();
        services.AddScoped<ChannelExportNotificationInterceptor>();
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            options.UseSqlite(_connection);
            options.AddInterceptors(serviceProvider.GetRequiredService<ChannelExportNotificationInterceptor>());
        });
        services.AddScoped<ChannelExportOutboxEnqueuer>();
        services.AddScoped<INotificationHandler<SalesChangedNotification>, SalesChangedNotificationHandler>();

        configure?.Invoke(services);

        return services.BuildServiceProvider();
    }

    private static async Task<(SalesChannel Channel, Sales Sales)> SeedCancellableSaleAsync(ApplicationDbContext context)
    {
        var channel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            Type = SalesChannelType.WooCommerce,
            Name = "Sqlite Interceptor Channel",
            Url = "https://shop.example.com",
            Username = "key",
            Password = "secret",
            IsEnabled = true,
            ExportSaless = true,
            Warehouses = new List<Warehouse>(),
            TenantId = TenantConstants.TestTenant1Id
        };
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            CustomerId = 990001,
            Firstname = "Interceptor",
            Lastname = "Customer",
            TenantId = TenantConstants.TestTenant1Id
        };
        var sales = new Sales
        {
            Id = Guid.NewGuid(),
            SalesChannelId = channel.Id,
            CustomerId = customer.CustomerId,
            Status = SalesStatus.Processing,
            TenantId = TenantConstants.TestTenant1Id
        };
        context.SalesChannel.Add(channel);
        context.Customer.Add(customer);
        context.Sales.Add(sales);
        await context.SaveChangesAsync();

        // Seeding ran through the interceptor too — clear its rows before the act phase.
        var seeded = await context.ChannelExportOutbox.IgnoreQueryFilters().ToListAsync();
        context.ChannelExportOutbox.RemoveRange(seeded);
        await context.SaveChangesAsync();

        return (channel, sales);
    }

    [Fact]
    public async Task SalesStatusChange_OnSqlite_EnqueuesUpdateSalesOutboxRow()
    {
        await using var provider = BuildServiceProvider();
        await using var scope = provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.EnsureCreatedAsync();

        var (channel, sales) = await SeedCancellableSaleAsync(context);

        sales.Status = SalesStatus.Cancelled;
        await context.SaveChangesAsync();

        var rows = await context.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.AggregateId == sales.Id && o.Operation == ChannelSyncOperation.UpdateSales)
            .ToListAsync();

        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(channel.Id, rows[0].SalesChannelId);
    }

    [Fact]
    public async Task SalesCancelCommand_FullProductionPath_EnqueuesExportAndPublishesCancelledKind()
    {
        var recorder = new RecordingSalesHandler();
        await using var provider = BuildServiceProvider(services =>
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<IShippingRepository, ShippingRepository>();
            services.AddScoped<IRequestHandler<SalesCancelCommand, Result<Guid>>, SalesCancelHandler>();
            services.AddSingleton(recorder);
            services.AddScoped<INotificationHandler<SalesChangedNotification>>(sp =>
                sp.GetRequiredService<RecordingSalesHandler>());
        });
        await using var scope = provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.EnsureCreatedAsync();

        var tenantContext = scope.ServiceProvider.GetRequiredService<ITenantContext>();
        tenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);
        tenantContext.SetAssignedTenantIds(new[] { TenantConstants.TestTenant1Id });

        var (channel, sales) = await SeedCancellableSaleAsync(context);
        recorder.Kinds.Clear();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var result = await mediator.Send(new SalesCancelCommand { Id = sales.Id });

        TestAssertions.AssertTrue(result.Succeeded);

        var rows = await context.ChannelExportOutbox
            .IgnoreQueryFilters()
            .Where(o => o.AggregateId == sales.Id && o.Operation == ChannelSyncOperation.UpdateSales)
            .ToListAsync();

        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(channel.Id, rows[0].SalesChannelId);

        // A cancel is a status update, not a delete — the safety net must still publish it with
        // Cancelled kind so kind-filtering handlers (e.g. POS stock compensation) react.
        TestAssertions.AssertTrue(recorder.Kinds.Contains(SalesChangeKind.Cancelled));
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
}
