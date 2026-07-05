using System.ComponentModel;
using System.Runtime.CompilerServices;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Enums;

namespace asERP.Client.Features.Returns.Models;

/// <summary>
/// Row view-model of the create-return dialog's item list. Quantity is capped at the line's
/// returnable quantity; serialized lines can only be returned as a whole line.
/// </summary>
public sealed class ReturnableItemRow : INotifyPropertyChanged
{
    private readonly ReturnableSalesItemDto _item;
    private bool _isSelected;
    private double _quantity;
    private ReturnReasonOption? _selectedReason;

    public ReturnableItemRow(ReturnableSalesItemDto item, IReadOnlyList<ReturnReasonOption> reasonOptions)
    {
        _item = item;
        _quantity = item.ReturnableQuantity;
        ReasonOptions = reasonOptions;
        _selectedReason = reasonOptions.FirstOrDefault();
    }

    public Guid SalesItemId => _item.SalesItemId;
    public string Name => _item.Name;
    public string Sku => _item.Sku;
    public string TrackingNumber => _item.TrackingNumber;
    public double ReturnableQuantity => _item.ReturnableQuantity;

    /// <summary>Serialized lines return as a whole line only (the server rejects partial quantities).</summary>
    public bool QuantityEditable => !_item.HasSerialNumbers;

    public Visibility SkuVisibility => string.IsNullOrWhiteSpace(_item.Sku) ? Visibility.Collapsed : Visibility.Visible;

    public Visibility TrackingVisibility => string.IsNullOrWhiteSpace(_item.TrackingNumber) ? Visibility.Collapsed : Visibility.Visible;

    public IReadOnlyList<ReturnReasonOption> ReasonOptions { get; }

    public ReturnReasonOption? SelectedReason
    {
        get => _selectedReason;
        set
        {
            if (!ReferenceEquals(_selectedReason, value))
            {
                _selectedReason = value;
                OnPropertyChanged();
            }
        }
    }

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
            // NumberBox reports NaN for an emptied input — treat as 0 (row won't be returned).
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

/// <summary>ComboBox item of the return-reason picker (localized display text).</summary>
public sealed record ReturnReasonOption(ReturnReason Reason, string DisplayText);
