using System.ComponentModel;
using System.Runtime.CompilerServices;
using asERP.Domain.Dtos.Sales;

namespace asERP.Client.Features.Shippings.Models;

/// <summary>Lifecycle of one order inside a batch-shipping run.</summary>
public enum BatchRowOutcome
{
    /// <summary>Not processed yet.</summary>
    Idle,

    /// <summary>Shipment request in flight.</summary>
    Creating,

    /// <summary>Shipment created; label (when requested) is available.</summary>
    Created,

    /// <summary>Shipment created; label creation queued in the outbox ("label follows").</summary>
    LabelQueued,

    /// <summary>Shipment created but the label creation dead-lettered.</summary>
    LabelFailed,

    /// <summary>Shipment creation failed — the order was skipped, the run continued.</summary>
    Failed,

    /// <summary>Order was skipped (cancelled run or nothing left to ship).</summary>
    Skipped,
}

/// <summary>
/// Row view-model of the batch-shipping dialog. Rows with a resolvable rate and full stock
/// are pre-checked; rows without an applicable rate cannot be selected at all. All mutable
/// members must be touched on the UI thread only.
/// </summary>
public sealed class BatchShipmentRow : INotifyPropertyChanged
{
    private readonly SalesReadyToShipListDto _dto;
    private bool _isSelected;
    private bool _isCheckable;
    private string _rateText = string.Empty;
    private string _problemText = string.Empty;
    private string _statusText = string.Empty;
    private BatchRowOutcome _outcome = BatchRowOutcome.Idle;

    public BatchShipmentRow(SalesReadyToShipListDto dto, string stockWarning)
    {
        _dto = dto;
        StockWarning = dto.AllItemsInStock ? string.Empty : stockWarning;
    }

    public Guid Id => _dto.Id;
    public int SalesNumber => _dto.SalesId;
    public string RecipientName => string.IsNullOrWhiteSpace(_dto.DeliveryAddressCompanyName)
        ? _dto.FullName
        : $"{_dto.FullName} · {_dto.DeliveryAddressCompanyName}";
    public string Country => _dto.DeliveryAddressCountry;
    public int OpenItemCount => _dto.OpenItemCount;
    public bool AllItemsInStock => _dto.AllItemsInStock;

    public string StockWarning { get; }
    public Visibility StockWarningVisibility =>
        StockWarning.Length > 0 ? Visibility.Visible : Visibility.Collapsed;

    /// <summary>The suggested rate (last used → cheapest); null until options are loaded
    /// or when no rate applies to the order.</summary>
    public Guid? RateId { get; private set; }

    /// <summary>The created shipment (set during the run).</summary>
    public Guid ShippingId { get; private set; }

    /// <summary>True when the created shipment has its label ready for batch actions.</summary>
    public bool HasLabel { get; private set; }

    public BatchRowOutcome Outcome => _outcome;

    public string RateText
    {
        get => _rateText;
        private set => SetField(ref _rateText, value);
    }

    public string ProblemText
    {
        get => _problemText;
        private set
        {
            if (SetField(ref _problemText, value))
            {
                OnPropertyChanged(nameof(ProblemVisibility));
            }
        }
    }

    public Visibility ProblemVisibility =>
        _problemText.Length > 0 ? Visibility.Visible : Visibility.Collapsed;

    public string StatusText
    {
        get => _statusText;
        private set
        {
            if (SetField(ref _statusText, value))
            {
                OnPropertyChanged(nameof(StatusVisibility));
            }
        }
    }

    public Visibility StatusVisibility =>
        _statusText.Length > 0 ? Visibility.Visible : Visibility.Collapsed;

    public bool IsCheckable
    {
        get => _isCheckable;
        private set => SetField(ref _isCheckable, value);
    }

    public bool IsSelected
    {
        get => _isSelected;
        set => SetField(ref _isSelected, value);
    }

    /// <summary>Options loaded and a rate applies: pre-check when everything is in stock.</summary>
    public void SetRate(Guid rateId, string rateText)
    {
        RateId = rateId;
        RateText = rateText;
        IsCheckable = true;
        IsSelected = _dto.AllItemsInStock;
    }

    /// <summary>No applicable rate — the row stays visible but cannot be selected.</summary>
    public void SetNoRate(string reason)
    {
        RateId = null;
        ProblemText = reason;
        IsCheckable = false;
        IsSelected = false;
    }

    /// <summary>Locks the checkbox for the duration of the run.</summary>
    public void LockForRun() => IsCheckable = false;

    public void MarkCreating(string statusText) => SetOutcome(BatchRowOutcome.Creating, statusText);

    public void MarkCreated(Guid shippingId, bool hasLabel, string statusText)
    {
        ShippingId = shippingId;
        HasLabel = hasLabel;
        SetOutcome(BatchRowOutcome.Created, statusText);
    }

    public void MarkLabelQueued(Guid shippingId, string statusText)
    {
        ShippingId = shippingId;
        SetOutcome(BatchRowOutcome.LabelQueued, statusText);
    }

    public void MarkLabelFailed(Guid shippingId, string statusText)
    {
        ShippingId = shippingId;
        SetOutcome(BatchRowOutcome.LabelFailed, statusText);
    }

    public void MarkFailed(string statusText) => SetOutcome(BatchRowOutcome.Failed, statusText);

    public void MarkSkipped(string statusText) => SetOutcome(BatchRowOutcome.Skipped, statusText);

    private void SetOutcome(BatchRowOutcome outcome, string statusText)
    {
        _outcome = outcome;
        StatusText = statusText;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    private void OnPropertyChanged(string? propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
