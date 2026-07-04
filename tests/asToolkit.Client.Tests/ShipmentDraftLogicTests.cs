using asToolkit.Client.Features.Shippings.Models;

namespace asToolkit.Client.Tests;

public class ShipmentDraftLogicTests
{
    [TestCase(5, 3, ExpectedResult = true)]
    [TestCase(3, 3, ExpectedResult = true)]
    [TestCase(2, 3, ExpectedResult = false)]
    [TestCase(0, 1, ExpectedResult = false)]
    public bool IsInStock_ComparesStockAgainstOpenQuantity(double stock, double open) =>
        ShipmentDraftLogic.IsInStock(stock, open);

    [Test]
    public void CalculateWeight_SumsSelectedRowsOnly()
    {
        var rows = new[]
        {
            (Selected: true, Quantity: 2d, UnitWeightKg: 0.5m),
            (Selected: false, Quantity: 10d, UnitWeightKg: 3m),
            (Selected: true, Quantity: 1d, UnitWeightKg: 1.25m),
        };

        Assert.That(ShipmentDraftLogic.CalculateWeight(rows), Is.EqualTo(2.25m));
    }

    [Test]
    public void CalculateWeight_ZeroWeightRows_ContributeNothing()
    {
        var rows = new[] { (Selected: true, Quantity: 4d, UnitWeightKg: 0m) };

        Assert.That(ShipmentDraftLogic.CalculateWeight(rows), Is.EqualTo(0m));
    }

    [Test]
    public void CalculateWeight_EmptyList_ReturnsZero()
    {
        Assert.That(ShipmentDraftLogic.CalculateWeight([]), Is.EqualTo(0m));
    }

    [Test]
    public void SelectDefaultRate_EmptyList_ReturnsNull()
    {
        Assert.That(ShipmentDraftLogic.SelectDefaultRate([], Guid.NewGuid()), Is.Null);
    }

    [Test]
    public void SelectDefaultRate_RememberedRateStillOffered_ReturnsIt()
    {
        var cheapest = Guid.NewGuid();
        var remembered = Guid.NewGuid();

        var result = ShipmentDraftLogic.SelectDefaultRate([cheapest, remembered], remembered);

        Assert.That(result, Is.EqualTo(remembered));
    }

    [Test]
    public void SelectDefaultRate_RememberedRateGone_ReturnsCheapest()
    {
        var cheapest = Guid.NewGuid();

        var result = ShipmentDraftLogic.SelectDefaultRate([cheapest, Guid.NewGuid()], Guid.NewGuid());

        Assert.That(result, Is.EqualTo(cheapest));
    }

    [Test]
    public void SelectDefaultRate_NothingRemembered_ReturnsCheapest()
    {
        var cheapest = Guid.NewGuid();

        var result = ShipmentDraftLogic.SelectDefaultRate([cheapest, Guid.NewGuid()], null);

        Assert.That(result, Is.EqualTo(cheapest));
    }
}
