using asERP.Domain.Dtos.Category;
using asERP.Domain.Services;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for <see cref="CategoryTreeBuilder"/> — the shared helper that turns the flat category
/// list into the indented display order of the category matrix and the product editor. Ordering
/// (SortOrder, then name), level computation, orphan handling and the search filter (matches plus
/// their ancestor chain) all drive what the user actually sees.
/// </summary>
public class CategoryTreeBuilderTests
{
    private static CategoryListDto Category(string name, Guid id, Guid? parentId = null, int sortOrder = 0) => new()
    {
        Id = id,
        Name = name,
        ParentCategoryId = parentId,
        SortOrder = sortOrder
    };

    [Test]
    public void Flatten_OrdersDepthFirstWithParentsBeforeChildren()
    {
        var rootA = Guid.NewGuid();
        var rootB = Guid.NewGuid();
        var childA1 = Guid.NewGuid();
        var categories = new[]
        {
            Category("B-Root", rootB, sortOrder: 2),
            Category("A-Child", childA1, rootA),
            Category("A-Root", rootA, sortOrder: 1),
        };

        var flattened = CategoryTreeBuilder.Flatten(categories);

        Assert.That(flattened.Select(n => n.Category.Id), Is.EqualTo(new[] { rootA, childA1, rootB }));
        Assert.That(flattened.Select(n => n.Level), Is.EqualTo(new[] { 0, 1, 0 }));
    }

    [Test]
    public void Flatten_SiblingsOrderBySortOrderThenName()
    {
        var root = Guid.NewGuid();
        var first = Guid.NewGuid();
        var second = Guid.NewGuid();
        var third = Guid.NewGuid();
        var categories = new[]
        {
            Category("Root", root),
            Category("Zebra", first, root, sortOrder: 1),
            Category("beta", third, root, sortOrder: 2),
            Category("Alpha", second, root, sortOrder: 2),
        };

        var flattened = CategoryTreeBuilder.Flatten(categories);

        Assert.That(flattened.Select(n => n.Category.Id), Is.EqualTo(new[] { root, first, second, third }));
    }

    [Test]
    public void Flatten_OrphanWithMissingParentBecomesRoot()
    {
        var orphan = Guid.NewGuid();
        var categories = new[] { Category("Orphan", orphan, parentId: Guid.NewGuid()) };

        var flattened = CategoryTreeBuilder.Flatten(categories);

        Assert.That(flattened, Has.Count.EqualTo(1));
        Assert.That(flattened[0].Level, Is.Zero);
    }

    [Test]
    public void Flatten_CycleDoesNotHangAndLosesNoNode()
    {
        var a = Guid.NewGuid();
        var b = Guid.NewGuid();
        var categories = new[]
        {
            Category("A", a, b),
            Category("B", b, a),
        };

        var flattened = CategoryTreeBuilder.Flatten(categories);

        Assert.That(flattened, Has.Count.EqualTo(2));
    }

    [Test]
    public void Filter_KeepsMatchesAndTheirAncestorChain()
    {
        var root = Guid.NewGuid();
        var child = Guid.NewGuid();
        var grandchild = Guid.NewGuid();
        var unrelated = Guid.NewGuid();
        var categories = new[]
        {
            Category("Bekleidung", root),
            Category("Schuhe", child, root),
            Category("Sneaker", grandchild, child),
            Category("Elektronik", unrelated),
        };
        var flattened = CategoryTreeBuilder.Flatten(categories);

        var filtered = CategoryTreeBuilder.Filter(flattened, "sneak");

        Assert.That(filtered.Select(n => n.Category.Id), Is.EqualTo(new[] { root, child, grandchild }));
    }

    [Test]
    public void Filter_EmptySearchReturnsInputUnchanged()
    {
        var flattened = CategoryTreeBuilder.Flatten(new[] { Category("Nur eine", Guid.NewGuid()) });

        Assert.That(CategoryTreeBuilder.Filter(flattened, "  "), Is.SameAs(flattened));
    }
}
