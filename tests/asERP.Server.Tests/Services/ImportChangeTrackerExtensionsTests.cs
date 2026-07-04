using asERP.Domain.Constants;
using asERP.Domain.Entities;
using asERP.SalesChannels.Repositories;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Xunit;

namespace asERP.Server.Tests.Services;

/// <summary>
/// Regression tests for <see cref="ImportChangeTrackerExtensions.DiscardPendingChanges"/>. The shared
/// sync-run context is rolled back after a failed item import; detaching an Added principal whose Added
/// dependents are still tracked must not throw the "association ... has been severed" error that would
/// otherwise leak out of the rollback and corrupt the run for every later item.
/// </summary>
public class ImportChangeTrackerExtensionsTests : TenantIsolatedTestBase
{
    [Fact]
    public void DiscardPendingChanges_DetachesAddedProductGraphWithRequiredDependents_DoesNotThrow()
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        // A new variant product with its required ProductVariantOption children — the exact Added graph
        // that crashed the rollback when the parent was detached ahead of the still-tracked children.
        var product = new Product
        {
            Sku = "VARIANT-1",
            Name = "Variant",
            TenantId = TenantConstants.TestTenant1Id,
            VariantOptions =
            [
                new ProductVariantOption { ProductAttributeValueId = Guid.NewGuid(), TenantId = TenantConstants.TestTenant1Id },
                new ProductVariantOption { ProductAttributeValueId = Guid.NewGuid(), TenantId = TenantConstants.TestTenant1Id }
            ]
        };
        DbContext.Product.Add(product);

        TestAssertions.AssertEqual(3, DbContext.ChangeTracker.Entries().Count(e => e.State == EntityState.Added));

        DbContext.DiscardPendingChanges();

        // All Added entries (product + both options) are detached; the tracker is clean for the next item.
        TestAssertions.AssertEqual(0, DbContext.ChangeTracker.Entries().Count());
    }

    [Fact]
    public void DiscardPendingChanges_LeavesAlreadyCommittedEntriesTracked()
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        // Work persisted by an earlier SaveChanges in the run (Unchanged) must survive the rollback,
        // while a half-applied Added entry from the failed item is detached.
        var committed = new Product { Sku = "COMMITTED", Name = "Committed", TenantId = TenantConstants.TestTenant1Id };
        DbContext.Product.Add(committed);
        DbContext.SaveChanges();

        var pending = new Product
        {
            Sku = "PENDING",
            Name = "Pending",
            TenantId = TenantConstants.TestTenant1Id,
            VariantOptions = [new ProductVariantOption { ProductAttributeValueId = Guid.NewGuid(), TenantId = TenantConstants.TestTenant1Id }]
        };
        DbContext.Product.Add(pending);

        DbContext.DiscardPendingChanges();

        var remaining = DbContext.ChangeTracker.Entries<Product>().ToList();
        TestAssertions.AssertEqual(1, remaining.Count);
        TestAssertions.AssertEqual("COMMITTED", remaining[0].Entity.Sku);
        TestAssertions.AssertEqual(EntityState.Unchanged, remaining[0].State);
    }

    [Fact]
    public void DiscardPendingChanges_RevertsModifiedEntry_ToOriginalValuesAndUnchanged()
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        var product = new Product { Sku = "MOD-1", Name = "Original", Price = 10m, TenantId = TenantConstants.TestTenant1Id };
        DbContext.Product.Add(product);
        DbContext.SaveChanges();

        // Half-applied edits from the failed item must be rolled back, not left to re-flush on the next save.
        product.Name = "Changed";
        product.Price = 99m;
        TestAssertions.AssertEqual(EntityState.Modified, DbContext.Entry(product).State);

        DbContext.DiscardPendingChanges();

        TestAssertions.AssertEqual(EntityState.Unchanged, DbContext.Entry(product).State);
        TestAssertions.AssertEqual("Original", product.Name);
        TestAssertions.AssertEqual(10m, product.Price);
    }

    [Fact]
    public void DiscardPendingChanges_RevertsDeletedEntry_ToUnchanged()
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        var product = new Product { Sku = "DEL-1", Name = "Keep", TenantId = TenantConstants.TestTenant1Id };
        DbContext.Product.Add(product);
        DbContext.SaveChanges();

        // A pending delete from the failed item is reset so the committed row survives the rollback.
        DbContext.Product.Remove(product);
        TestAssertions.AssertEqual(EntityState.Deleted, DbContext.Entry(product).State);

        DbContext.DiscardPendingChanges();

        TestAssertions.AssertEqual(EntityState.Unchanged, DbContext.Entry(product).State);
        TestAssertions.AssertEqual("Keep", product.Name);
    }

    [Fact]
    public void DiscardPendingChanges_MixedBatch_DetachesAddedRevertsModifiedKeepsUnchanged()
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        var committed = new Product { Sku = "MIX-COMMITTED", Name = "Committed", TenantId = TenantConstants.TestTenant1Id };
        var modified = new Product { Sku = "MIX-MODIFIED", Name = "Before", TenantId = TenantConstants.TestTenant1Id };
        DbContext.Product.AddRange(committed, modified);
        DbContext.SaveChanges();

        modified.Name = "After";
        var added = new Product { Sku = "MIX-ADDED", Name = "Added", TenantId = TenantConstants.TestTenant1Id };
        DbContext.Product.Add(added);

        DbContext.DiscardPendingChanges();

        TestAssertions.AssertEqual(EntityState.Detached, DbContext.Entry(added).State);
        TestAssertions.AssertEqual(EntityState.Unchanged, DbContext.Entry(modified).State);
        TestAssertions.AssertEqual("Before", modified.Name);
        TestAssertions.AssertEqual(EntityState.Unchanged, DbContext.Entry(committed).State);
    }

    [Fact]
    public void DiscardPendingChanges_EmptyChangeTracker_IsNoOp()
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        DbContext.DiscardPendingChanges();

        TestAssertions.AssertEqual(0, DbContext.ChangeTracker.Entries().Count());
    }

    [Fact]
    public void DiscardPendingChanges_RestoresCascadeTimings_OnTheSharedContext()
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        // The reset flips these to Never to defer fixup while detaching; the shared run context must be
        // handed back with the timings it had — not silently switched to Never for every later item.
        DbContext.ChangeTracker.CascadeDeleteTiming = CascadeTiming.OnSaveChanges;
        DbContext.ChangeTracker.DeleteOrphansTiming = CascadeTiming.Immediate;

        DbContext.Product.Add(new Product
        {
            Sku = "TIMING-1",
            Name = "Variant",
            TenantId = TenantConstants.TestTenant1Id,
            VariantOptions = [new ProductVariantOption { ProductAttributeValueId = Guid.NewGuid(), TenantId = TenantConstants.TestTenant1Id }]
        });

        DbContext.DiscardPendingChanges();

        TestAssertions.AssertEqual(CascadeTiming.OnSaveChanges, DbContext.ChangeTracker.CascadeDeleteTiming);
        TestAssertions.AssertEqual(CascadeTiming.Immediate, DbContext.ChangeTracker.DeleteOrphansTiming);
    }

    [Fact]
    public void DiscardPendingChanges_CalledTwice_IsSafe()
    {
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);

        DbContext.Product.Add(new Product
        {
            Sku = "TWICE-1",
            Name = "Variant",
            TenantId = TenantConstants.TestTenant1Id,
            VariantOptions = [new ProductVariantOption { ProductAttributeValueId = Guid.NewGuid(), TenantId = TenantConstants.TestTenant1Id }]
        });

        DbContext.DiscardPendingChanges();
        DbContext.DiscardPendingChanges();

        TestAssertions.AssertEqual(0, DbContext.ChangeTracker.Entries().Count());
    }
}
