using System.ComponentModel;
using System.Runtime.CompilerServices;
using asERP.Domain.Dtos.Sales;

namespace asERP.Client.Features.Shippings.Models;

/// <summary>
/// Row view-model of the create-shipment dialog's item list. In-stock lines are pre-checked
/// with their full open quantity; serialized lines can only be shipped as a whole line.
/// </summary>
public sealed class ShippableItemRow : INotifyPropertyChanged
{
    private readonly ShippableSalesItemDto _item;
    private bool _isSelected;
    private double _quantity;

    public ShippableItemRow(ShippableSalesItemDto item, string stockHint)
    {
        _item = item;
        _isSelected = ShipmentDraftLogic.IsInStock(item.StockAvailable, item.OpenQuantity);
        _quantity = item.OpenQuantity;
        StockHint = stockHint;
    }

    public Guid SalesItemId => _item.SalesItemId;
    public string Name => _item.Name;
    public string Sku => _item.Sku;
    public double OpenQuantity => _item.OpenQuantity;
    public double TaxRate => _item.TaxRate;

    /// <summary>Unit weight in kg — the dialog's weight prefill multiplies by quantity.</summary>
    public decimal UnitWeightKg => _item.ProductWeight;

    /// <summary>Serialized lines ship as a whole line only (the server rejects partial quantities).</summary>
    public bool QuantityEditable => !_item.HasSerialNumbers;

    public bool IsOutOfStock => !ShipmentDraftLogic.IsInStock(_item.StockAvailable, _item.OpenQuantity);

    public string StockHint { get; }

    public Visibility StockHintVisibility => IsOutOfStock ? Visibility.Visible : Visibility.Collapsed;

    public Visibility SkuVisibility => string.IsNullOrWhiteSpace(_item.Sku) ? Visibility.Collapsed : Visibility.Visible;

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
    }

    public double Quantity
    {
        get => _quantity;
        set
        {
            // NumberBox reports NaN for an emptied input — treat as 0 (row won't be shipped).
            var sanitized = double.IsNaN(value) ? 0 : value;
            if (Math.Abs(_quantity - sanitized) > double.Epsilon)
            {
                _quantity = sanitized;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
