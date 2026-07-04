using asToolkit.Client.Core.Exceptions;
using asToolkit.Client.Core.Notifications;
using asToolkit.Client.Features.Auth.Services;
using asToolkit.Client.Features.Shippings.Models;
using asToolkit.Client.Features.Shippings.Services;
using asToolkit.Client.Features.Tenants.Services;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Enums;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.Resources;

namespace asToolkit.Client.Features.Shippings.Views;

/// <summary>
/// Overlay dialog that creates a shipment for a sales order with minimal clicks:
/// in-stock lines pre-checked, last-used shipping option preselected, weight prefilled,
/// label requested by default and — when an action is remembered — executed automatically.
/// Code-behind driven; hosted as the last child of the SalesDetailPage root grid.
/// </summary>
public sealed partial class CreateShipmentDialog : UserControl
{
    /// <summary>Raised after a shipment was created (before/at close) so the host can refresh.</summary>
    public event Func<Task>? ShipmentCreated;

    private readonly ResourceLoader _resourceLoader = ResourceLoader.GetForViewIndependentUse();
    private readonly List<ShippableItemRow> _rows = new();
    private List<RateOption> _rateOptions = new();
    private Guid _salesId;
    private Guid _tenantId;
    private Guid _createdShippingId;
    private bool _weightTouched;
    private bool _suppressWeightEvent;
    private bool _busy;
    private bool _printPackingSlip;

    private static IServiceProvider? Services => (Application.Current as App)?.Host?.Services;

    public CreateShipmentDialog()
    {
        this.InitializeComponent();
    }

    /// <summary>Opens the overlay and loads shippable items + applicable options for the order.</summary>
    public async Task OpenAsync(Guid salesId)
    {
        if (Services is not { } services)
        {
            return;
        }

        _salesId = salesId;
        _createdShippingId = Guid.Empty;
        _weightTouched = false;
        _busy = false;
        _printPackingSlip = false;

        ResetToLoadingState();
        Visibility = Visibility.Visible;

        var shippingService = services.GetRequiredService<IShippingService>();
        var preferences = services.GetRequiredService<IShippingPreferences>();
        var tokenStorage = services.GetRequiredService<ITokenStorageService>();
        _tenantId = await tokenStorage.GetCurrentTenantIdAsync() ?? Guid.Empty;

        try
        {
            var itemsTask = shippingService.GetShippableItemsAsync(salesId);
            var optionsTask = shippingService.GetShippingOptionsAsync(salesId);
            var packingSlipDefaultTask = LoadPackingSlipDefaultAsync(services);
            await Task.WhenAll(itemsTask, optionsTask, packingSlipDefaultTask);

            PrintPackingSlipCheck.IsChecked = packingSlipDefaultTask.Result;

            var stockHintFormat = _resourceLoader.GetString("CreateShipmentDialog.StockHint");
            _rows.Clear();
            foreach (var item in itemsTask.Result)
            {
                var row = new ShippableItemRow(item, string.Format(stockHintFormat, item.StockAvailable));
                row.PropertyChanged += (_, _) => OnRowChanged();
                _rows.Add(row);
            }

            ItemsHost.ItemsSource = null;
            ItemsHost.ItemsSource = _rows;

            var options = optionsTask.Result;
            _rateOptions = (options.Data ?? new List<ApplicableShippingRateDto>())
                .Select(rate => new RateOption(rate))
                .ToList();
            RateCombo.ItemsSource = _rateOptions;

            if (_rateOptions.Count == 0)
            {
                // Explain WHY there is no option (country not resolvable / no provider configured).
                NoOptionsText.Text = options.Messages is { Count: > 0 }
                    ? string.Join(Environment.NewLine, options.Messages)
                    : _resourceLoader.GetString("CreateShipmentDialog.NoOptions");
                NoOptionsText.Visibility = Visibility.Visible;
            }
            else
            {
                var defaultRateId = ShipmentDraftLogic.SelectDefaultRate(
                    _rateOptions.Select(o => o.Rate.RateId).ToList(),
                    preferences.GetLastRateId(_tenantId));
                var defaultIndex = _rateOptions.FindIndex(o => o.Rate.RateId == defaultRateId);
                RateCombo.SelectedIndex = defaultIndex >= 0 ? defaultIndex : 0;
            }

            RecomputeWeightPrefill();
            UpdateWeightWarning();
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

    /// <summary>Tenant default for "also print packing slip" — a load failure must never block the dialog.</summary>
    private async Task<bool> LoadPackingSlipDefaultAsync(IServiceProvider services)
    {
        if (_tenantId == Guid.Empty)
        {
            return false;
        }

        try
        {
            var tenant = await services.GetRequiredService<ITenantService>().GetTenantAsync(_tenantId);
            return tenant?.PackingSlipPrintByDefault ?? false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>Hides the overlay without raising <see cref="ShipmentCreated"/>.</summary>
    public void Close()
    {
        Visibility = Visibility.Collapsed;
    }

    private void ResetToLoadingState()
    {
        ErrorText.Text = string.Empty;
        ErrorText.Visibility = Visibility.Collapsed;
        NoOptionsText.Visibility = Visibility.Collapsed;
        WeightWarningText.Visibility = Visibility.Collapsed;
        RememberActionCheck.IsChecked = false;
        RequestLabelToggle.IsOn = true;
        PrintPackingSlipCheck.IsChecked = false;

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

        _suppressWeightEvent = true;
        WeightBox.Value = 0;
        _suppressWeightEvent = false;

        LoadingPanel.Visibility = Visibility.Visible;
        LoadingRing.IsActive = true;
    }

    private void OnRowChanged()
    {
        if (!_weightTouched)
        {
            RecomputeWeightPrefill();
        }

        UpdateWeightWarning();
        UpdateCreateEnabled();
    }

    private void RecomputeWeightPrefill()
    {
        var weight = ShipmentDraftLogic.CalculateWeight(
            _rows.Select(r => (r.IsSelected, r.Quantity, r.UnitWeightKg)));

        _suppressWeightEvent = true;
        WeightBox.Value = (double)weight;
        _suppressWeightEvent = false;
    }

    private double CurrentWeight()
    {
        var value = WeightBox.Value;
        return double.IsNaN(value) ? 0 : value;
    }

    private void WeightBox_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
    {
        if (_suppressWeightEvent)
        {
            return;
        }

        // Manual edit stops the automatic prefill until the dialog is reopened.
        _weightTouched = true;
        UpdateWeightWarning();
    }

    private void RateCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateWeightWarning();
        UpdateCreateEnabled();
    }

    private void UpdateWeightWarning()
    {
        var rate = (RateCombo.SelectedItem as RateOption)?.Rate;
        var showWarning = rate is not null
            && rate.MaxWeight > 0
            && (decimal)CurrentWeight() > rate.MaxWeight;

        if (showWarning)
        {
            WeightWarningText.Text = string.Format(
                _resourceLoader.GetString("CreateShipmentDialog.WeightWarning"), rate!.MaxWeight);
        }

        WeightWarningText.Visibility = showWarning ? Visibility.Visible : Visibility.Collapsed;
    }

    private void UpdateCreateEnabled()
    {
        CreateButton.IsEnabled = !_busy
            && RateCombo.SelectedItem is RateOption
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
        // Done is only visible after the shipment was created (label step skipped).
        await RaiseCreatedAndCloseAsync();
    }

    private async void Create_Click(object sender, RoutedEventArgs e)
    {
        if (Services is not { } services
            || RateCombo.SelectedItem is not RateOption option)
        {
            return;
        }

        var selectedRows = _rows.Where(r => r.IsSelected && r.Quantity > 0).ToList();
        if (selectedRows.Count == 0)
        {
            return;
        }

        var shippingService = services.GetRequiredService<IShippingService>();
        var preferences = services.GetRequiredService<IShippingPreferences>();

        ErrorText.Visibility = Visibility.Collapsed;
        SetBusy(true);
        try
        {
            var weight = CurrentWeight();
            var input = new ShippingInputDto
            {
                SalesId = _salesId,
                ShippingProviderRateId = option.Rate.RateId,
                TaxRate = selectedRows.Max(r => r.TaxRate),
                WeightKg = weight > 0 ? (decimal)weight : null,
                RequestLabel = RequestLabelToggle.IsOn,
                Items = selectedRows
                    .Select(r => new ShippingItemInputDto { SalesItemId = r.SalesItemId, Quantity = r.Quantity })
                    .ToList(),
            };

            _createdShippingId = await shippingService.CreateShippingAsync(input);
            preferences.SetLastRateId(_tenantId, option.Rate.RateId);
            _printPackingSlip = PrintPackingSlipCheck.IsChecked == true;
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
            await HandleAfterCreateAsync(services, requestLabel: RequestLabelToggle.IsOn);
        }
        catch (Exception)
        {
            // The shipment exists — never leave the host unrefreshed because of a label hiccup.
            ShowCreatedToast(services);
            await RaiseCreatedAndCloseAsync();
        }
    }

    private async Task HandleAfterCreateAsync(IServiceProvider services, bool requestLabel)
    {
        var shippingService = services.GetRequiredService<IShippingService>();
        var preferences = services.GetRequiredService<IShippingPreferences>();

        if (!requestLabel)
        {
            ShowCreatedToast(services);
            await RaiseCreatedAndCloseAsync();
            return;
        }

        var detail = await shippingService.GetShippingAsync(_createdShippingId);
        if (detail is null)
        {
            ShowCreatedToast(services);
            await RaiseCreatedAndCloseAsync();
            return;
        }

        if (detail.HasLabel)
        {
            var pref = preferences.GetLabelAction(_tenantId);
            if (pref is not null)
            {
                // Zero-click repeat: remembered action (incl. printer) runs immediately (toasts inside).
                await LabelActionRunner.RunAsync(_createdShippingId, pref.Action, pref.PrinterName);
                await RaiseCreatedAndCloseAsync();
                return;
            }

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
        // No platform capability — RunAsync falls back to the system default app.
        await RunLabelActionAsync(LabelAction.Save);

    private async Task RunLabelActionAsync(LabelAction action)
    {
        var printerName = action == LabelAction.Print && PrinterCombo.Visibility == Visibility.Visible
            ? PrinterCombo.SelectedItem as string
            : null;

        await LabelActionRunner.RunAsync(_createdShippingId, action, printerName);

        if (RememberActionCheck.IsChecked == true && Services is { } services)
        {
            services.GetRequiredService<IShippingPreferences>()
                .SetLabelAction(_tenantId, new LabelActionPreference(action, printerName));
        }

        await RaiseCreatedAndCloseAsync();
    }

    private void ShowCreatedToast(IServiceProvider services)
    {
        services.GetRequiredService<INotificationService>()
            .Show(_resourceLoader.GetString("CreateShipmentDialog.Created"), NotificationSeverity.Success);
    }

    private async Task RaiseCreatedAndCloseAsync()
    {
        // Packing slip runs after the label flow, whatever path led here (immediate,
        // remembered, queued or failed label). Reset first — idempotent on re-entry.
        if (_printPackingSlip && _createdShippingId != Guid.Empty)
        {
            _printPackingSlip = false;
            await PackingSlipActionRunner.RunAsync(_createdShippingId, XamlRoot);
        }

        if (ShipmentCreated is { } handler)
        {
            await handler();
        }

        Close();
    }
}

/// <summary>ComboBox item of the shipping-option picker.</summary>
public sealed record RateOption(ApplicableShippingRateDto Rate)
{
    public string DisplayText => $"{Rate.ProviderName} · {Rate.RateName} — {Rate.Price:C}";
}
