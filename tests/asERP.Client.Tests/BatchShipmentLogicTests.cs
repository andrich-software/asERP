using asERP.Client.Features.Shippings.Models;
using asERP.Domain.Dtos.Sales;

namespace asERP.Client.Tests;

/// <summary>Verifies the pure input-building logic of the batch-shipping run.</summary>
public class BatchShipmentLogicTests
{
    private static ShippableSalesItemDto Item(
        double openQuantity = 1, decimal weight = 0m, double taxRate = 19)
    {
        return new ShippableSalesItemDto
        {
            SalesItemId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Name = "Item",
            OpenQuantity = openQuantity,
            ProductWeight = weight,
            TaxRate = taxRate,
        };
    }

    [Test]
    public void BuildInput_TakesAllOpenItemsWithFullQuantities()
    {
        var salesId = Guid.NewGuid();
        var rateId = Guid.NewGuid();
        var items = new[] { Item(openQuantity: 2), Item(openQuantity: 3) };

        var input = BatchShipmentLogic.BuildInput(salesId, rateId, items, requestLabel: true);

        Assert.That(input.SalesId, Is.EqualTo(salesId));
        Assert.That(input.ShippingProviderRateId, Is.EqualTo(rateId));
        Assert.That(input.RequestLabel, Is.True);
        Assert.That(input.Items, Has.Count.EqualTo(2));
        Assert.That(input.Items[0].SalesItemId, Is.EqualTo(items[0].SalesItemId));
        Assert.That(input.Items[0].Quantity, Is.EqualTo(2));
        Assert.That(input.Items[1].Quantity, Is.EqualTo(3));
    }

    [Test]
    public void BuildInput_PrefillsWeightFromProductWeights()
    {
        var items = new[]
        {
            Item(openQuantity: 2, weight: 0.5m),
            Item(openQuantity: 1, weight: 1.25m),
        };

        var input = BatchShipmentLogic.BuildInput(Guid.NewGuid(), Guid.NewGuid(), items, requestLabel: true);

        Assert.That(input.WeightKg, Is.EqualTo(2.25m));
    }

    [Test]
    public void BuildInput_WithoutProductWeights_LeavesWeightNull()
    {
        var items = new[] { Item(openQuantity: 2), Item() };

        var input = BatchShipmentLogic.BuildInput(Guid.NewGuid(), Guid.NewGuid(), items, requestLabel: false);

        Assert.That(input.WeightKg, Is.Null);
        Assert.That(input.RequestLabel, Is.False);
    }

    [Test]
    public void BuildInput_UsesMaxTaxRateOfTheItems()
    {
        var items = new[] { Item(taxRate: 7), Item(taxRate: 19), Item(taxRate: 7) };

        var input = BatchShipmentLogic.BuildInput(Guid.NewGuid(), Guid.NewGuid(), items, requestLabel: true);

        Assert.That(input.TaxRate, Is.EqualTo(19));
    }

    [Test]
    public void BuildInput_NoItems_ProducesEmptyItemListAndZeroTax()
    {
        var input = BatchShipmentLogic.BuildInput(
            Guid.NewGuid(), Guid.NewGuid(), Array.Empty<ShippableSalesItemDto>(), requestLabel: true);

        Assert.That(input.Items, Is.Empty);
        Assert.That(input.TaxRate, Is.Zero);
        Assert.That(input.WeightKg, Is.Null);
    }
}
