using System.ComponentModel;
using asERP.Client.Features.SalesChannels.Models;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for <see cref="SelectableWarehouse"/>'s change notification. The sales channel edit
/// model re-evaluates CanSave (Save button gating) from a PropertyChanged event filtered on the
/// exact name "IsSelected" — a rename or a missing/duplicate notification would silently break
/// the warehouse-required rule on every platform.
/// </summary>
public class SelectableWarehouseTests
{
    [Test]
    public void IsSelected_Change_RaisesPropertyChangedWithExactName()
    {
        var warehouse = new SelectableWarehouse { Id = Guid.NewGuid(), Name = "Main" };
        var raised = new List<string?>();
        warehouse.PropertyChanged += (_, e) => raised.Add(e.PropertyName);

        warehouse.IsSelected = true;

        Assert.That(raised, Is.EqualTo(new[] { nameof(SelectableWarehouse.IsSelected) }));
    }

    [Test]
    public void IsSelected_SameValue_DoesNotRaisePropertyChanged()
    {
        var warehouse = new SelectableWarehouse { IsSelected = true };
        var raisedCount = 0;
        warehouse.PropertyChanged += (_, _) => raisedCount++;

        warehouse.IsSelected = true;

        Assert.That(raisedCount, Is.Zero);
    }
}
