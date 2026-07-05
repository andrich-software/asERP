using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using asERP.Shipping.Orchestration;
using asERP.Shipping.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Features.Returns.Services;

/// <summary>
/// Tests for the return-label fallback queue: enqueuer coalescing and the drainer's
/// dead-letter behavior on permanent failures.
/// Customer-number range: 934–939.
/// </summary>
public class ReturnLabelOutboxTests : TenantIsolatedTestBase
{
    private ReturnLabelOutboxEnqueuer Enqueuer =>
        Scope.ServiceProvider.GetRequiredService<ReturnLabelOutboxEnqueuer>();

    private ReturnLabelOutboxDrainer Drainer =>
        Scope.ServiceProvider.GetRequiredService<ReturnLabelOutboxDrainer>();

    private async Task<ReturnShipment> SeedReturnAsync(
        int customerNumber,
        bool withProvider = true,
        ReturnShipmentStatus status = ReturnShipmentStatus.Requested)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        Domain.Entities.ShippingProvider? provider = null;
        if (withProvider)
        {
            provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        }

        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, customerNumber);
        var returnShipment = ShippingTestDataSeeder.AddReturnShipment(DbContext, sales,
            status: status,
            shippingProviderId: provider?.Id,
            items: (sales.SalesItems.First().Id, 1));

        await DbContext.SaveChangesAsync();
        return returnShipment;
    }

    private ReturnLabelOutbox AddOutboxRow(ReturnShipment returnShipment,
        ShippingOutboxStatus status = ShippingOutboxStatus.Pending, int attemptCount = 0)
    {
        var row = new ReturnLabelOutbox
        {
            Id = Guid.NewGuid(),
            ReturnShipmentId = returnShipment.Id,
            ShippingProviderId = returnShipment.ShippingProviderId ?? Guid.NewGuid(),
            IdempotencyKey = ReturnLabelOutboxEnqueuer.IdempotencyKeyFor(returnShipment.Id),
            Status = status,
            AttemptCount = attemptCount,
            NextAttemptAt = DateTime.UtcNow.AddMinutes(-1),
            TenantId = returnShipment.TenantId
        };

        DbContext.ReturnLabelOutbox.Add(row);
        return row;
    }

    [Fact]
    public async Task Enqueue_Twice_ShouldCoalesceToOneRow()
    {
        var returnShipment = await SeedReturnAsync(934);

        await Enqueuer.EnqueueAsync(returnShipment.Id, returnShipment.ShippingProviderId!.Value,
            returnShipment.TenantId, "first error");
        await Enqueuer.EnqueueAsync(returnShipment.Id, returnShipment.ShippingProviderId!.Value,
            returnShipment.TenantId, "second error");

        var rows = await DbContext.ReturnLabelOutbox
            .Where(o => o.ReturnShipmentId == returnShipment.Id)
            .ToListAsync();
        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(ShippingOutboxStatus.Pending, rows[0].Status);
        TestAssertions.AssertEqual("second error", rows[0].LastError);
    }

    [Fact]
    public async Task Enqueue_OnDeadLetterRow_ShouldResetToPending()
    {
        var returnShipment = await SeedReturnAsync(935);
        var row = AddOutboxRow(returnShipment, ShippingOutboxStatus.DeadLetter, attemptCount: 7);
        await DbContext.SaveChangesAsync();

        await Enqueuer.EnqueueAsync(returnShipment.Id, returnShipment.ShippingProviderId!.Value,
            returnShipment.TenantId, "manual retry");

        var updated = await DbContext.ReturnLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.Pending, updated.Status);
        TestAssertions.AssertEqual(0, updated.AttemptCount);
        TestAssertions.AssertNull(updated.CompletedAt);
    }

    [Fact]
    public async Task Drain_WithMissingReturnConfig_ShouldMoveRowToDeadLetter()
    {
        // Provider exists and is enabled, but has no ReturnReceiverId configured — the DHL
        // connector fails permanently without any HTTP call.
        var returnShipment = await SeedReturnAsync(936);
        var row = AddOutboxRow(returnShipment);
        await DbContext.SaveChangesAsync();

        var processed = await Drainer.DrainOnceAsync(CancellationToken.None);

        TestAssertions.AssertEqual(1, processed);
        var updated = await DbContext.ReturnLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.DeadLetter, updated.Status);
        TestAssertions.AssertNotNull(updated.LastError);
        TestAssertions.AssertTrue(updated.LastError!.Contains("ReturnReceiverId", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task Drain_OnCancelledReturn_ShouldMoveRowToDeadLetter()
    {
        var returnShipment = await SeedReturnAsync(937, status: ReturnShipmentStatus.Cancelled);
        var row = AddOutboxRow(returnShipment);
        await DbContext.SaveChangesAsync();

        var processed = await Drainer.DrainOnceAsync(CancellationToken.None);

        TestAssertions.AssertEqual(1, processed);
        var updated = await DbContext.ReturnLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.DeadLetter, updated.Status);
        TestAssertions.AssertNotNull(updated.LastError);
    }

    [Fact]
    public async Task Drain_OnReturnWithoutProvider_ShouldMoveRowToDeadLetter()
    {
        // Customer ships themselves — no provider, no label to buy.
        var returnShipment = await SeedReturnAsync(938, withProvider: false);
        var row = AddOutboxRow(returnShipment);
        await DbContext.SaveChangesAsync();

        var processed = await Drainer.DrainOnceAsync(CancellationToken.None);

        TestAssertions.AssertEqual(1, processed);
        var updated = await DbContext.ReturnLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.DeadLetter, updated.Status);
    }

    [Fact]
    public async Task Drain_WithNoDueRows_ShouldProcessNothing()
    {
        var returnShipment = await SeedReturnAsync(939);
        var row = AddOutboxRow(returnShipment);
        row.NextAttemptAt = DateTime.UtcNow.AddHours(1);
        await DbContext.SaveChangesAsync();

        var processed = await Drainer.DrainOnceAsync(CancellationToken.None);

        TestAssertions.AssertEqual(0, processed);
        var untouched = await DbContext.ReturnLabelOutbox.FirstAsync(o => o.Id == row.Id);
        TestAssertions.AssertEqual(ShippingOutboxStatus.Pending, untouched.Status);
        TestAssertions.AssertEqual(0, untouched.AttemptCount);
    }
}
