using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using asERP.Domain.Dtos.ProductAttribute;

namespace asERP.Client.Features.Products.Models;

/// <summary>
/// Selectable attribute value used inside a variant axis row.
/// </summary>
public class ProductAxisValueRow : INotifyPropertyChanged
{
    private bool _isSelected;

    public Guid Id { get; init; }
    public string Value { get; init; } = string.Empty;
    public int SortOrder { get; init; }

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

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

/// <summary>
/// A single variation axis (an attribute the parent varies by) plus the
/// available values of that attribute, each selectable for variant generation.
/// </summary>
public class ProductAxisRow : INotifyPropertyChanged
{
    private Guid _productAttributeId;

    public ObservableCollection<ProductAttributeListDto> AvailableAttributes { get; }
    public ObservableCollection<ProductAxisValueRow> Values { get; } = new();

    /// <summary>Loads the available values of an attribute. Injected by the model.</summary>
    private readonly Func<Guid, Task>? _loadValues;

    public ProductAxisRow(ObservableCollection<ProductAttributeListDto> availableAttributes, Func<Guid, Task>? loadValues = null)
    {
        AvailableAttributes = availableAttributes;
        _loadValues = loadValues;
    }

    public Guid ProductAttributeId
    {
        get => _productAttributeId;
        set
        {
            if (_productAttributeId != value)
            {
                _productAttributeId = value;
                OnPropertyChanged();
                // Only fetch values when none are present yet (i.e. a user picked an attribute).
                // When pre-populated from a DTO the values already exist, so skip the round-trip.
                if (value != Guid.Empty && _loadValues != null && Values.Count == 0)
                {
                    _ = _loadValues(value);
                }
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

/// <summary>
/// Editable row for an existing child variant of a variant parent.
/// </summary>
public class ProductVariantRow : INotifyPropertyChanged
{
    private string _sku = string.Empty;
    private string? _ean;
    private decimal _price;

    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string OptionSummary { get; init; } = string.Empty;

    /// <summary>Attribute value ids of this variant, needed when persisting it.</summary>
    public List<Guid> OptionValueIds { get; init; } = new();

    public bool IsDirty { get; private set; }

    /// <summary>Resets the dirty flag after the row has been populated from a DTO.</summary>
    public void MarkClean() => IsDirty = false;

    public string Sku
    {
        get => _sku;
        set
        {
            if (_sku != value)
            {
                _sku = value;
                IsDirty = true;
                OnPropertyChanged();
            }
        }
    }

    public string? Ean
    {
        get => _ean;
        set
        {
            if (_ean != value)
            {
                _ean = value;
                IsDirty = true;
                OnPropertyChanged();
            }
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
                IsDirty = true;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
