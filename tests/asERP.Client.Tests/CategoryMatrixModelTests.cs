using asERP.Client.Features.Categories.Models;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for the category matrix row models: <see cref="CategoryChannelCell"/>'s change
/// notification (the list model's cascade and delta tracking filter on the exact property name
/// "IsActive") and <see cref="CategoryChannelDelta"/>'s only-genuine-diffs bookkeeping — the
/// batch payload must contain real changes only, and reverting a checkbox must drop its entry.
/// </summary>
public class CategoryMatrixModelTests
{
    [Test]
    public void CellIsActive_Change_RaisesPropertyChangedWithExactName()
    {
        var cell = new CategoryChannelCell { CategoryId = Guid.NewGuid(), SalesChannelId = Guid.NewGuid() };
        var raised = new List<string?>();
        cell.PropertyChanged += (_, e) => raised.Add(e.PropertyName);

        cell.IsActive = true;

        Assert.That(raised, Is.EqualTo(new[] { nameof(CategoryChannelCell.IsActive) }));
    }

    [Test]
    public void CellIsActive_SameValue_DoesNotRaisePropertyChanged()
    {
        var cell = new CategoryChannelCell { IsActive = true };
        var raisedCount = 0;
        cell.PropertyChanged += (_, _) => raisedCount++;

        cell.IsActive = true;

        Assert.That(raisedCount, Is.Zero);
    }

    [Test]
    public void Delta_DivergingCell_IsTracked()
    {
        var pending = new Dictionary<(Guid, Guid), bool>();
        var cell = new CategoryChannelCell
        {
            CategoryId = Guid.NewGuid(),
            SalesChannelId = Guid.NewGuid(),
            ServerIsActive = false,
            IsActive = true
        };

        CategoryChannelDelta.Apply(pending, cell);

        Assert.That(pending, Has.Count.EqualTo(1));
        Assert.That(pending[(cell.CategoryId, cell.SalesChannelId)], Is.True);
    }

    [Test]
    public void Delta_RevertedCell_IsRemoved()
    {
        var pending = new Dictionary<(Guid, Guid), bool>();
        var cell = new CategoryChannelCell
        {
            CategoryId = Guid.NewGuid(),
            SalesChannelId = Guid.NewGuid(),
            ServerIsActive = false,
            IsActive = true
        };
        CategoryChannelDelta.Apply(pending, cell);

        cell.IsActive = false;
        CategoryChannelDelta.Apply(pending, cell);

        Assert.That(pending, Is.Empty);
    }

    [Test]
    public void RowNameIndent_GrowsWithLevel()
    {
        var root = new CategoryRow { Level = 0 };
        var grandchild = new CategoryRow { Level = 2 };

        Assert.That(root.NameIndent.Left, Is.Zero);
        Assert.That(grandchild.NameIndent.Left, Is.EqualTo(40));
    }
}
