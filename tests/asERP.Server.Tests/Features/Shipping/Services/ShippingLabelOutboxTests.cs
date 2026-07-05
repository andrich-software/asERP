using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using asERP.Shipping.Orchestration;
using asERP.Shipping.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Features.Shipping.Services;

/// <summary>
/// Tests for the label-creation fallback queue: enqueuer coalescing and the drainer's
/// dead-letter behavior on permanent failures.
/// </summary>
public class ShippingLabelOutboxTests : TenantIsolatedTestBase
{
    private ShippingLabelOutboxEnqueuer Enqueuer =>
        Scope.ServiceProvider.GetRequiredService<ShippingLabelOutboxEnqueuer>();

    private ShippingLabelOutboxDrainer Drainer =>
        Scope.ServiceProvider.GetRequiredService<ShippingLabelOutboxDrainer>();

    private async Task<asERP.Domain.Entities.Shipping> SeedShippingAsync(
        bool providerExists = true, bool providerEnabled = true, int customerNumber = 841)
    {
        // All data in these tests belongs to tenant 1; act as that tenant so the always-on
        // tenant query filter lets the enqueuer/drainer and the assertions see the rows.
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        asERP.Domain.Entities.ShippingProvider? provider = null;
        asERP.Domain.Entities.ShippingProviderRate? rate = null;
        if (providerExists)
        {
            provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
                isEnabled: providerEnabled);
            rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        }

        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, customerNumber);

        var shipping = new asERP.Domain.Entities.Shipping
        {
            Id = Guid.NewGuid(),
            SalesId = sales.Id,
            ShippingProviderId = provider?.Id ?? Guid.NewGuid(),
            ShippingProviderRateId = rate?.Id,
            Status = ShippingStatus.Open,
            TenantId = TenantConstants.TestTenant1Id
        };
        DbContext.Shipping.Add(shipping);

        await DbContext.SaveChangesAsync();
        return shipping;
    }

    private ShippingLabelOutbox AddOutboxRow(asERP.Domain.Entities.Shipping shipping,
        ShippingOutboxStatus status = ShippingOutboxStatus.Pending, int attemptCount = 0)
    {
        var row = new ShippingLabelOutbox
        {
            Id = Guid.NewGuid(),
            ShippingId = shipping.Id,
            ShippingProviderId = shipping.ShippingProviderId,
            IdempotencyKey = ShippingLabelOutboxEnqueuer.IdempotencyKeyFor(shipping.Id),
            Status = status,
            AttemptCount = attemptCount,
            NextAttemptAt = DateTime.UtcNow.AddMinutes(-1),
            TenantId = shipping.TenantId
        };

        DbContext.ShippingLabelOutbox.Add(row);
        return row;
    }

    [Fact]
    public async Task Enqueue_Twice_ShouldCoalesceToOneRow()
    {
        var shipping = await SeedShippingAsync();

        await Enqueuer.EnqueueAsync(shipping.Id, shipping.ShippingProviderId, shipping.TenantId, "first error");
        await Enqueuer.EnqueueAsync(shipping.Id, shipping.ShippingProviderId, shipping.TenantId, "second error");

        var rows = await DbContext.ShippingLabelOutbox
            .Where(o => o.ShippingId == shipping.Id)
            .ToListAsync();
        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(ShippingOutboxStatus.Pending, rows[0].Status);
        TestAssertions.AssertEqual("second error", rows[0].LastError);
    }

    [Fact]
    public async Task Enqueue_OnDeadLetterRow_ShouldResetToPending()
    {
        var shipping = await SeedShippingAsync();
        var row = AddOutboxRow(shipping, ShippingOutboxStatus.DeadLetter, attemptCount: 7);
        await DbContext.SaveChangesAsync();

        await Enqueuer.EnqueueAsync(shipping.Id, shipping.ShippingProviderId, shipping.TenantId, "manual retry");

        var updated = await DbContext.ShippingLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.Pending, updated.Status);
        TestAssertions.AssertEqual(0, updated.AttemptCount);
        TestAssertions.AssertNull(updated.CompletedAt);
    }

    [Fact]
    public async Task Drain_WithMissingProvider_ShouldMoveRowToDeadLetter()
    {
        var shipping = await SeedShippingAsync(providerExists: false);
        var row = AddOutboxRow(shipping);
        await DbContext.SaveChangesAsync();

        var processed = await Drainer.DrainOnceAsync(CancellationToken.None);

        TestAssertions.AssertEqual(1, processed);
        var updated = await DbContext.ShippingLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.DeadLetter, updated.Status);
        TestAssertions.AssertNotNull(updated.LastError);
    }

    [Fact]
    public async Task Drain_WithDisabledProvider_ShouldMoveRowToDeadLetter()
    {
        var shipping = await SeedShippingAsync(providerEnabled: false);
        var row = AddOutboxRow(shipping);
        await DbContext.SaveChangesAsync();

        var processed = await Drainer.DrainOnceAsync(CancellationToken.None);

        TestAssertions.AssertEqual(1, processed);
        var updated = await DbContext.ShippingLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.DeadLetter, updated.Status);
        TestAssertions.AssertNotNull(updated.LastError);
    }

    [Fact]
    public async Task Drain_WithPermanentConnectorFailure_ShouldMoveRowToDeadLetter()
    {
        // Provider exists and is enabled, but has no sender address configured — the DHL
        // connector fails permanently without any HTTP call.
        var shipping = await SeedShippingAsync();
        var row = AddOutboxRow(shipping);
        await DbContext.SaveChangesAsync();

        var processed = await Drainer.DrainOnceAsync(CancellationToken.None);

        TestAssertions.AssertEqual(1, processed);
        var updated = await DbContext.ShippingLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.DeadLetter, updated.Status);
        TestAssertions.AssertNotNull(updated.LastError);
        TestAssertions.AssertTrue(updated.LastError!.Contains("sender address", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task Drain_WithNoDueRows_ShouldProcessNothing()
    {
        var shipping = await SeedShippingAsync();
        var row = AddOutboxRow(shipping);
        row.NextAttemptAt = DateTime.UtcNow.AddHours(1);
        await DbContext.SaveChangesAsync();

        var processed = await Drainer.DrainOnceAsync(CancellationToken.None);

        TestAssertions.AssertEqual(0, processed);
        var untouched = await DbContext.ShippingLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.Pending, untouched.Status);
        TestAssertions.AssertEqual(0, untouched.AttemptCount);
    }
}
