using asERP.Domain.Dtos.Category;
using asERP.Domain.Services;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for <see cref="CategoryActivationRules.Expand"/> — the tree-consistency rule behind the
/// category matrix checkboxes: activating a cell pulls its ancestors in (parents first, so exports
/// see them in order), deactivating pushes all descendants out. Client and server share this
/// helper, so a bug here breaks the cascade on both sides at once.
/// </summary>
public class CategoryActivationRulesTests
{
    private static readonly Guid Root = Guid.NewGuid();
    private static readonly Guid Child = Guid.NewGuid();
    private static readonly Guid Grandchild = Guid.NewGuid();
    private static readonly Guid OtherRoot = Guid.NewGuid();
    private static readonly Guid Channel = Guid.NewGuid();

    private static readonly Dictionary<Guid, Guid?> Parents = new()
    {
        [Root] = null,
        [Child] = Root,
        [Grandchild] = Child,
        [OtherRoot] = null,
    };

    private static CategoryChannelActivationChange Change(Guid categoryId, bool isActive) => new()
    {
        CategoryId = categoryId,
        SalesChannelId = Channel,
        IsActive = isActive
    };

    [Test]
    public void Activate_Grandchild_ActivatesAncestorsRootFirst()
    {
        var expanded = CategoryActivationRules.Expand(new[] { Change(Grandchild, true) }, Parents);

        Assert.That(expanded.Select(c => c.CategoryId), Is.EqualTo(new[] { Root, Child, Grandchild }));
        Assert.That(expanded.All(c => c.IsActive), Is.True);
    }

    [Test]
    public void Deactivate_Root_DeactivatesAllDescendants()
    {
        var expanded = CategoryActivationRules.Expand(new[] { Change(Root, false) }, Parents);

        Assert.That(expanded.Select(c => c.CategoryId), Is.EquivalentTo(new[] { Root, Child, Grandchild }));
        Assert.That(expanded.All(c => !c.IsActive), Is.True);
    }

    [Test]
    public void Activate_Root_TouchesOnlyTheRootItself()
    {
        var expanded = CategoryActivationRules.Expand(new[] { Change(Root, true) }, Parents);

        Assert.That(expanded, Has.Count.EqualTo(1));
        Assert.That(expanded[0].CategoryId, Is.EqualTo(Root));
    }

    [Test]
    public void UnrelatedSubtree_IsNeverTouched()
    {
        var expanded = CategoryActivationRules.Expand(new[] { Change(Grandchild, true) }, Parents);

        Assert.That(expanded.Select(c => c.CategoryId), Does.Not.Contain(OtherRoot));
    }

    [Test]
    public void SequentialChanges_LastWriteWinsPerCell()
    {
        var expanded = CategoryActivationRules.Expand(
            new[] { Change(Grandchild, true), Change(Root, false) }, Parents);

        // The later deactivation of the root cascades over the earlier activation.
        Assert.That(expanded.All(c => !c.IsActive), Is.True);
        Assert.That(expanded.Select(c => c.CategoryId), Is.EquivalentTo(new[] { Root, Child, Grandchild }));
    }

    [Test]
    public void CyclicParentData_DoesNotHang()
    {
        var a = Guid.NewGuid();
        var b = Guid.NewGuid();
        var cyclic = new Dictionary<Guid, Guid?> { [a] = b, [b] = a };

        var expanded = CategoryActivationRules.Expand(
            new[] { new CategoryChannelActivationChange { CategoryId = a, SalesChannelId = Channel, IsActive = true } },
            cyclic);

        Assert.That(expanded, Is.Not.Empty);
    }
}
