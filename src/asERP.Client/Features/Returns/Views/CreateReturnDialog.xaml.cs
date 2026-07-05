using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Returns.Models;
using asERP.Client.Features.Returns.Services;
using asERP.Client.Features.Shippings.Services;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Enums;
using Windows.ApplicationModel.Resources;

namespace asERP.Client.Features.Returns.Views;

/// <summary>
/// Overlay dialog that creates a customer return (RMA) for a sales order: shipped lines with
/// their remaining returnable quantity, a reason per line, an optional note and an optional
/// carrier return label. Code-behind driven; hosted as the last child of the SalesDetailPage
/// root grid (pattern: CreateShipmentDialog).
/// </summary>
public sealed partial class CreateReturnDialog : UserControl
{
    /// <summary>Raised after a return was created (before/at close) so the host can refresh.</summary>
    public event Func<Task>? ReturnCreated;

    private readonly ResourceLoader _resourceLoader = ResourceLoader.GetForViewIndependentUse();
    private readonly List<ReturnableItemRow> _rows = new();
    private List<ProviderOption> _providerOptions = new();
    private Guid _salesId;
    private Guid _createdReturnId;
    private bool _busy;

    private static IServiceProvider? Services => (Application.Current as App)?.Host?.Services;

    public CreateReturnDialog()
    {
        this.InitializeComponent();
    }

    /// <summary>Opens the overlay and loads the returnable lines + label-capable providers.</summary>
    public async Task OpenAsync(Guid salesId)
    {
        if (Services is not { } services)
        {
            return;
        }

        _salesId = salesId;
        _createdReturnId = Guid.Empty;
        _busy = false;

        ResetToLoadingState();
        Visibility = Visibility.Visible;

        var returnService = services.GetRequiredService<IReturnService>();
        var shippingService = services.GetRequiredService<IShippingService>();

        try
        {
            var itemsTask = returnService.GetReturnableItemsAsync(salesId);
            var optionsTask = shippingService.GetShippingOptionsAsync(salesId);
            await Task.WhenAll(itemsTask, optionsTask);

            var reasonOptions = BuildReasonOptions();
            _rows.Clear();
            foreach (var item in itemsTask.Result)
            {
                var row = new ReturnableItemRow(item, reasonOptions);
                row.PropertyChanged += (_, _) => UpdateCreateEnabled();
                _rows.Add(row);
            }

            ItemsHost.ItemsSource = null;
            ItemsHost.ItemsSource = _rows;
            NoItemsText.Visibility = _rows.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

            // The providers that can ship to the customer are the return-label candidates.
            _providerOptions = (optionsTask.Result.Data ?? new List<ApplicableShippingRateDto>())
                .GroupBy(rate => rate.ProviderId)
                .Select(group => new ProviderOption(group.Key, group.First().ProviderName))
                .ToList();
            ProviderCombo.ItemsSource = _providerOptions;
            if (_providerOptions.Count > 0)
            {
                ProviderCombo.SelectedIndex = 0;
            }

            UpdateCreateEnabled();
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
            Step1Panel.Visibility = Visibility.Visible;
        }
    }

    private List<ReturnReasonOption> BuildReasonOptions() =>
        Enum.GetValues<ReturnReason>()
            .Select(reason =>
            {
                var text = _resourceLoader.GetString($"ReturnReason.{reason}");
                return new ReturnReasonOption(reason, string.IsNullOrEmpty(text) ? reason.ToString() : text);
            })
            .ToList();

    /// <summary>Hides the overlay without raising <see cref="ReturnCreated"/>.</summary>
    public void Close()
    {
        Visibility = Visibility.Collapsed;
    }

    private void ResetToLoadingState()
    {
        ErrorText.Text = string.Empty;
        ErrorText.Visibility = Visibility.Collapsed;
        NoItemsText.Visibility = Visibility.Collapsed;
        NoteBox.Text = string.Empty;
        RequestLabelCheck.IsChecked = false;
        ProviderCombo.Visibility = Visibility.Collapsed;

        Step1Panel.Visibility = Visibility.Collapsed;
        Step2Panel.Visibility = Visibility.Collapsed;
        QueuedPanel.Visibility = Visibility.Collapsed;
        DeadLetterPanel.Visibility = Visibility.Collapsed;
        PrinterCombo.Visibility = Visibility.Collapsed;
        PrinterCombo.ItemsSource = null;

        CancelButton.Visibility = Visibility.Visible;
        CancelButton.IsEnabled = true;
        CreateButton.Visibility = Visibility.Visible;
        CreateButton.IsEnabled = false;
        DoneButton.Visibility = Visibility.Collapsed;
        BusyRing.IsActive = false;
        BusyRing.Visibility = Visibility.Collapsed;

        LoadingPanel.Visibility = Visibility.Visible;
        LoadingRing.IsActive = true;
    }

    private void RequestLabelCheck_Changed(object sender, RoutedEventArgs e)
    {
        ProviderCombo.Visibility = RequestLabelCheck.IsChecked == true
            ? Visibility.Visible
            : Visibility.Collapsed;
        UpdateCreateEnabled();
    }

    private void ProviderCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateCreateEnabled();
    }

    private void UpdateCreateEnabled()
    {
        var labelOk = RequestLabelCheck.IsChecked != true || ProviderCombo.SelectedItem is ProviderOption;
        CreateButton.IsEnabled = !_busy
            && labelOk
            && _rows.Any(r => r.IsSelected && r.Quantity > 0);
    }

    private void SetBusy(bool busy)
    {
        _busy = busy;
        BusyRing.IsActive = busy;
        BusyRing.Visibility = busy ? Visibility.Visible : Visibility.Collapsed;
        CancelButton.IsEnabled = !busy;
        UpdateCreateEnabled();
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

    private async void Done_Click(object sender, RoutedEventArgs e)
    {
        await RaiseCreatedAndCloseAsync();
    }

    private async void Create_Click(object sender, RoutedEventArgs e)
    {
        if (Services is not { } services)
        {
            return;
        }

        var selectedRows = _rows.Where(r => r.IsSelected && r.Quantity > 0).ToList();
        if (selectedRows.Count == 0)
        {
            return;
        }

        var requestLabel = RequestLabelCheck.IsChecked == true;
        if (requestLabel && ProviderCombo.SelectedItem is not ProviderOption)
        {
            return;
        }

        var returnService = services.GetRequiredService<IReturnService>();

        ErrorText.Visibility = Visibility.Collapsed;
        SetBusy(true);
        try
        {
            var input = new ReturnShipmentInputDto
            {
                SalesId = _salesId,
                RequestLabel = requestLabel,
                ShippingProviderId = requestLabel ? (ProviderCombo.SelectedItem as ProviderOption)?.ProviderId : null,
                Note = string.IsNullOrWhiteSpace(NoteBox.Text) ? null : NoteBox.Text,
                Items = selectedRows
                    .Select(r => new ReturnShipmentItemInputDto
                    {
                        SalesItemId = r.SalesItemId,
                        Quantity = r.Quantity,
                        Reason = r.SelectedReason?.Reason ?? ReturnReason.Unspecified
                    })
                    .ToList(),
            };

            _createdReturnId = await returnService.CreateReturnAsync(input);
        }
        catch (ApiException ex)
        {
            ShowError(ex.CombinedMessage);
            return;
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            return;
        }
        finally
        {
            SetBusy(false);
        }

        try
        {
            await HandleAfterCreateAsync(services, requestLabel);
        }
        catch (Exception)
        {
            // The return exists — never leave the host unrefreshed because of a label hiccup.
            ShowCreatedToast(services);
            await RaiseCreatedAndCloseAsync();
        }
    }

    private async Task HandleAfterCreateAsync(IServiceProvider services, bool requestLabel)
    {
        var returnService = services.GetRequiredService<IReturnService>();

        if (!requestLabel)
        {
            ShowCreatedToast(services);
            await RaiseCreatedAndCloseAsync();
            return;
        }

        var detail = await returnService.GetReturnAsync(_createdReturnId);
        if (detail is null)
        {
            ShowCreatedToast(services);
            await RaiseCreatedAndCloseAsync();
            return;
        }

        if (detail.HasLabel)
        {
            await ShowLabelStepAsync(services.GetRequiredService<ILabelService>());
            return;
        }

        if (detail.LabelQueueStatus is ShippingOutboxStatus.Pending or ShippingOutboxStatus.InFlight)
        {
            ShowPostCreatePanel(QueuedPanel);
            return;
        }

        if (detail.LabelQueueStatus == ShippingOutboxStatus.DeadLetter)
        {
            DeadLetterErrorText.Text = string.IsNullOrWhiteSpace(detail.LabelQueueLastError)
                ? _resourceLoader.GetString("LabelAction.Failed")
                : detail.LabelQueueLastError;
            ShowPostCreatePanel(DeadLetterPanel);
            return;
        }

        ShowCreatedToast(services);
        await RaiseCreatedAndCloseAsync();
    }

    private async Task ShowLabelStepAsync(ILabelService labelService)
    {
        var capabilities = labelService.Capabilities;

        SaveLabelButton.Visibility = capabilities.HasFlag(LabelCapabilities.Save)
            ? Visibility.Visible : Visibility.Collapsed;
        DownloadLabelButton.Visibility = capabilities.HasFlag(LabelCapabilities.Download)
            ? Visibility.Visible : Visibility.Collapsed;
        PrintLabelButton.Visibility = capabilities.HasFlag(LabelCapabilities.Print)
            ? Visibility.Visible : Visibility.Collapsed;
        OpenLabelButton.Visibility = capabilities == LabelCapabilities.None
            ? Visibility.Visible : Visibility.Collapsed;

        if (capabilities.HasFlag(LabelCapabilities.PickPrinter))
        {
            var printers = await labelService.GetPrinterNamesAsync();
            if (printers.Count > 0)
            {
                PrinterCombo.Header = _resourceLoader.GetString("LabelAction.PrinterLabel");
                PrinterCombo.ItemsSource = printers;
                PrinterCombo.SelectedIndex = 0;
                PrinterCombo.Visibility = Visibility.Visible;
            }
        }

        ShowPostCreatePanel(Step2Panel);
    }

    private void ShowPostCreatePanel(UIElement panel)
    {
        Step1Panel.Visibility = Visibility.Collapsed;
        Step2Panel.Visibility = Visibility.Collapsed;
        QueuedPanel.Visibility = Visibility.Collapsed;
        DeadLetterPanel.Visibility = Visibility.Collapsed;
        panel.Visibility = Visibility.Visible;

        CreateButton.Visibility = Visibility.Collapsed;
        CancelButton.Visibility = Visibility.Collapsed;
        DoneButton.Visibility = Visibility.Visible;
    }

    private async void SaveLabel_Click(object sender, RoutedEventArgs e) =>
        await RunLabelActionAsync(LabelAction.Save);

    private async void DownloadLabel_Click(object sender, RoutedEventArgs e) =>
        await RunLabelActionAsync(LabelAction.Download);

    private async void PrintLabel_Click(object sender, RoutedEventArgs e) =>
        await RunLabelActionAsync(LabelAction.Print);

    private async void OpenLabel_Click(object sender, RoutedEventArgs e) =>
        // No platform capability — RunReturnAsync falls back to the system default app.
        await RunLabelActionAsync(LabelAction.Save);

    private async Task RunLabelActionAsync(LabelAction action)
    {
        var printerName = action == LabelAction.Print && PrinterCombo.Visibility == Visibility.Visible
            ? PrinterCombo.SelectedItem as string
            : null;

        await LabelActionRunner.RunReturnAsync(_createdReturnId, action, printerName);
        await RaiseCreatedAndCloseAsync();
    }

    private void ShowCreatedToast(IServiceProvider services)
    {
        services.GetRequiredService<INotificationService>()
            .Show(_resourceLoader.GetString("CreateReturnDialog.Created"), NotificationSeverity.Success);
    }

    private async Task RaiseCreatedAndCloseAsync()
    {
        if (ReturnCreated is { } handler)
        {
            await handler();
        }

        Close();
    }
}

/// <summary>ComboBox item of the return-label provider picker.</summary>
public sealed record ProviderOption(Guid ProviderId, string ProviderName)
{
    public string DisplayText => ProviderName;
}
