using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Returns.Services;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Enums;
using Windows.ApplicationModel.Resources;

namespace asERP.Client.Features.Returns.Views;

/// <summary>
/// Overlay dialog that records the goods receipt of a return: per-item condition, optional
/// serial-number check-off and an optional refund amount. Code-behind driven; hosted as a
/// child of the SalesDetailPage root grid (pattern: CreateShipmentDialog).
/// </summary>
public sealed partial class ReceiveReturnDialog : UserControl
{
    /// <summary>Raised after the receipt was recorded so the host can refresh.</summary>
    public event Func<Task>? ReturnReceived;

    private readonly ResourceLoader _resourceLoader = ResourceLoader.GetForViewIndependentUse();
    private readonly List<ReceiveItemRow> _rows = new();
    private Guid _returnId;
    private bool _busy;

    private static IServiceProvider? Services => (Application.Current as App)?.Host?.Services;

    public ReceiveReturnDialog()
    {
        this.InitializeComponent();
    }

    /// <summary>Opens the overlay and loads the return's items.</summary>
    public async Task OpenAsync(Guid returnId)
    {
        if (Services is not { } services)
        {
            return;
        }

        _returnId = returnId;
        _busy = false;

        ResetToLoadingState();
        Visibility = Visibility.Visible;

        var returnService = services.GetRequiredService<IReturnService>();

        try
        {
            var detail = await returnService.GetReturnAsync(returnId);
            var conditionOptions = BuildConditionOptions();

            _rows.Clear();
            foreach (var item in detail?.Items ?? new List<ReturnShipmentItemDto>())
            {
                _rows.Add(new ReceiveItemRow(item, conditionOptions,
                    string.Format(_resourceLoader.GetString("ReceiveReturnDialog.QuantityFormat"), item.Quantity)));
            }

            ItemsHost.ItemsSource = null;
            ItemsHost.ItemsSource = _rows;
            ReceiveButton.IsEnabled = _rows.Count > 0;
        }
        catch (ApiException ex)
        {
            ShowError(ex.CombinedMessage);
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
        finally
        {
            LoadingRing.IsActive = false;
            LoadingPanel.Visibility = Visibility.Collapsed;
            ContentPanel.Visibility = Visibility.Visible;
        }
    }

    private List<ConditionOption> BuildConditionOptions() =>
        Enum.GetValues<ReturnItemCondition>()
            .Select(condition =>
            {
                var text = _resourceLoader.GetString($"ReturnItemCondition.{condition}");
                return new ConditionOption(condition, string.IsNullOrEmpty(text) ? condition.ToString() : text);
            })
            .ToList();

    public void Close()
    {
        Visibility = Visibility.Collapsed;
    }

    private void ResetToLoadingState()
    {
        ErrorText.Text = string.Empty;
        ErrorText.Visibility = Visibility.Collapsed;
        NoteBox.Text = string.Empty;
        RefundBox.Value = double.NaN;

        ContentPanel.Visibility = Visibility.Collapsed;
        ReceiveButton.IsEnabled = false;
        BusyRing.IsActive = false;
        BusyRing.Visibility = Visibility.Collapsed;
        CancelButton.IsEnabled = true;

        LoadingPanel.Visibility = Visibility.Visible;
        LoadingRing.IsActive = true;
    }

    private void SetBusy(bool busy)
    {
        _busy = busy;
        BusyRing.IsActive = busy;
        BusyRing.Visibility = busy ? Visibility.Visible : Visibility.Collapsed;
        CancelButton.IsEnabled = !busy;
        ReceiveButton.IsEnabled = !busy && _rows.Count > 0;
    }

    private void ShowError(string message)
    {
        ErrorText.Text = message;
        ErrorText.Visibility = Visibility.Visible;
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void Receive_Click(object sender, RoutedEventArgs e)
    {
        if (Services is not { } services || _busy)
        {
            return;
        }

        var returnService = services.GetRequiredService<IReturnService>();

        ErrorText.Visibility = Visibility.Collapsed;
        SetBusy(true);
        try
        {
            var refund = RefundBox.Value;
            var input = new ReturnReceiveInputDto
            {
                RefundAmount = double.IsNaN(refund) || refund <= 0 ? null : (decimal)refund,
                Note = string.IsNullOrWhiteSpace(NoteBox.Text) ? null : NoteBox.Text,
                Items = _rows
                    .Select(r => new ReturnReceiveItemInputDto
                    {
                        ReturnShipmentItemId = r.ReturnShipmentItemId,
                        Condition = r.SelectedCondition?.Condition ?? ReturnItemCondition.Unknown,
                        SerialNumbers = r.Serials.Where(s => s.IsChecked).Select(s => s.Value).ToList()
                    })
                    .ToList(),
            };

            await returnService.ReceiveReturnAsync(_returnId, input);

            services.GetRequiredService<INotificationService>()
                .Show(_resourceLoader.GetString("ReceiveReturnDialog.Received"), NotificationSeverity.Success);

            if (ReturnReceived is { } handler)
            {
                await handler();
            }

            Close();
        }
        catch (ApiException ex)
        {
            ShowError(ex.CombinedMessage);
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
        finally
        {
            SetBusy(false);
        }
    }
}

/// <summary>Row view-model of the receive dialog: condition per returned line + serial check-off.</summary>
public sealed class ReceiveItemRow
{
    public ReceiveItemRow(ReturnShipmentItemDto item, IReadOnlyList<ConditionOption> conditionOptions, string quantityText)
    {
        ReturnShipmentItemId = item.Id;
        Name = item.Name;
        QuantityText = quantityText;
        ConditionOptions = conditionOptions;
        SelectedCondition = conditionOptions.FirstOrDefault(o => o.Condition == ReturnItemCondition.Resalable)
            ?? conditionOptions.FirstOrDefault();
        Serials = item.AvailableSerialNumbers
            .Select(serial => new SerialOption(serial) { IsChecked = item.SerialNumbers.Contains(serial) })
            .ToList();
    }

    public Guid ReturnShipmentItemId { get; }
    public string Name { get; }
    public string QuantityText { get; }
    public IReadOnlyList<ConditionOption> ConditionOptions { get; }
    public ConditionOption? SelectedCondition { get; set; }
    public List<SerialOption> Serials { get; }

    public Visibility SerialsVisibility => Serials.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
}

/// <summary>ComboBox item of the condition picker (localized display text).</summary>
public sealed record ConditionOption(ReturnItemCondition Condition, string DisplayText);

/// <summary>Checkbox item for one serial number of the returned order line.</summary>
public sealed class SerialOption(string value)
{
    public string Value { get; } = value;
    public bool IsChecked { get; set; }
}
