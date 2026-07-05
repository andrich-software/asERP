using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Auth.Services;
using asERP.Client.Features.Shippings.Models;
using asERP.Client.Features.Shippings.Services;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Enums;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.Resources;

namespace asERP.Client.Features.Shippings.Views;

/// <summary>
/// Overlay for the batch-shipping run ("Sammelversand"): lists all orders with open lines,
/// pre-checks the shippable ones (rate resolvable, everything in stock), then creates the
/// shipments over the regular single-shipment endpoint with limited parallelism. Failures
/// skip the order and are reported per row; afterwards the labels can be printed/saved in
/// one go and a combined pick list covers the whole run.
/// Code-behind driven; hosted as the last child of the SalesListPage root grid.
/// </summary>
public sealed partial class BatchShipmentDialog : UserControl
{
    /// <summary>Raised at close when at least one shipment was created so the host can refresh.</summary>
    public event Func<Task>? RunCompleted;

    private const int PageSize = 100;
    private const int MaxCandidates = 200;
    private const int OptionsParallelism = 3;

    /// <summary>Carrier APIs are the bottleneck — more than a couple of parallel label
    /// requests only moves the queue into their rate limiter.</summary>
    private const int RunParallelism = 2;

    private readonly ResourceLoader _resourceLoader = ResourceLoader.GetForViewIndependentUse();
    private readonly List<BatchShipmentRow> _rows = new();
    private Guid _tenantId;
    private CancellationTokenSource? _runCts;
    private bool _optionsLoaded;
    private bool _running;
    private bool _finished;
    private bool _anyCreated;

    private static IServiceProvider? Services => (Application.Current as App)?.Host?.Services;

    public BatchShipmentDialog()
    {
        this.InitializeComponent();
    }

    /// <summary>Opens the overlay and loads the batch candidates plus their rate suggestions.</summary>
    public async Task OpenAsync()
    {
        if (Services is not { } services)
        {
            return;
        }

        ResetState();
        Visibility = Visibility.Visible;

        var shippingService = services.GetRequiredService<IShippingService>();
        var tokenStorage = services.GetRequiredService<ITokenStorageService>();
        _tenantId = await tokenStorage.GetCurrentTenantIdAsync() ?? Guid.Empty;

        try
        {
            var candidates = await LoadCandidatesAsync(shippingService);

            var stockWarning = _resourceLoader.GetString("BatchShipment.StockWarning");
            foreach (var candidate in candidates)
            {
                var row = new BatchShipmentRow(candidate, stockWarning);
                row.PropertyChanged += (_, _) => UpdateSelectionSummary();
                _rows.Add(row);
            }

            CandidateList.ItemsSource = _rows;

            LoadingRing.IsActive = false;
            LoadingPanel.Visibility = Visibility.Collapsed;

            if (_rows.Count == 0)
            {
                EmptyText.Visibility = Visibility.Visible;
                return;
            }

            MainPanel.Visibility = Visibility.Visible;
            UpdateSelectionSummary();

            await LoadRateSuggestionsAsync(services);
        }
        catch (ApiException ex)
        {
            ShowError(ex.CombinedMessage);
            LoadingRing.IsActive = false;
            LoadingPanel.Visibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
            LoadingRing.IsActive = false;
            LoadingPanel.Visibility = Visibility.Collapsed;
        }
    }

    /// <summary>Pages through the ready-to-ship query; the run is bounded so one morning's
    /// backlog fits but a runaway candidate list cannot freeze the dialog.</summary>
    private static async Task<List<SalesReadyToShipListDto>> LoadCandidatesAsync(IShippingService shippingService)
    {
        var candidates = new List<SalesReadyToShipListDto>();
        var pageNumber = 0;

        while (candidates.Count < MaxCandidates)
        {
            var page = await shippingService.GetReadyToShipSalesAsync(pageNumber, PageSize);
            candidates.AddRange(page.Data);

            if (page.Data.Count < PageSize || !page.HasNextPage)
            {
                break;
            }

            pageNumber++;
        }

        return candidates;
    }

    /// <summary>Loads the shipping options per order (limited parallelism) and applies the
    /// default-rate suggestion; orders without an applicable rate become unselectable.</summary>
    private async Task LoadRateSuggestionsAsync(IServiceProvider services)
    {
        var shippingService = services.GetRequiredService<IShippingService>();
        var preferences = services.GetRequiredService<IShippingPreferences>();
        var lastRateId = preferences.GetLastRateId(_tenantId);
        var noRateFallback = _resourceLoader.GetString("BatchShipment.NoRate");

        using var semaphore = new SemaphoreSlim(OptionsParallelism);
        var tasks = _rows.Select(async row =>
        {
            await semaphore.WaitAsync();
            try
            {
                var options = await shippingService.GetShippingOptionsAsync(row.Id);
                var rates = options.Data ?? new List<ApplicableShippingRateDto>();

                if (rates.Count == 0)
                {
                    row.SetNoRate(options.Messages is { Count: > 0 }
                        ? string.Join(Environment.NewLine, options.Messages)
                        : noRateFallback);
                    return;
                }

                var defaultRateId = ShipmentDraftLogic.SelectDefaultRate(
                    rates.Select(r => r.RateId).ToList(), lastRateId);
                var rate = rates.First(r => r.RateId == defaultRateId);
                row.SetRate(rate.RateId, $"{rate.ProviderName} · {rate.RateName} — {rate.Price:C}");
            }
            catch (ApiException ex)
            {
                row.SetNoRate(ex.CombinedMessage);
            }
            catch (Exception ex)
            {
                row.SetNoRate(ex.Message);
            }
            finally
            {
                semaphore.Release();
            }
        }).ToList();

        await Task.WhenAll(tasks);

        _optionsLoaded = true;
        UpdateSelectionSummary();
    }

    private void ResetState()
    {
        _rows.Clear();
        CandidateList.ItemsSource = null;
        _runCts = null;
        _optionsLoaded = false;
        _running = false;
        _finished = false;
        _anyCreated = false;

        ErrorText.Text = string.Empty;
        ErrorText.Visibility = Visibility.Collapsed;
        EmptyText.Visibility = Visibility.Collapsed;
        MainPanel.Visibility = Visibility.Collapsed;
        SummaryText.Visibility = Visibility.Collapsed;
        BatchActionsPanel.Visibility = Visibility.Collapsed;
        PrintAllButton.Visibility = Visibility.Collapsed;
        SaveAllButton.Visibility = Visibility.Collapsed;
        DownloadAllButton.Visibility = Visibility.Collapsed;

        SelectAllCheck.IsChecked = true;
        SelectAllCheck.IsEnabled = true;
        RequestLabelToggle.IsOn = true;
        RequestLabelToggle.IsEnabled = true;

        RunRing.IsActive = false;
        RunRing.Visibility = Visibility.Collapsed;
        ProgressText.Visibility = Visibility.Collapsed;

        CancelButton.Visibility = Visibility.Visible;
        CancelButton.IsEnabled = true;
        CloseButton.Visibility = Visibility.Collapsed;
        StartButton.Visibility = Visibility.Visible;
        StartButton.IsEnabled = false;

        LoadingPanel.Visibility = Visibility.Visible;
        LoadingRing.IsActive = true;
    }

    private void UpdateSelectionSummary()
    {
        var selected = _rows.Count(r => r.IsSelected);
        SelectionSummaryText.Text = string.Format(
            _resourceLoader.GetString("BatchShipment.SelectionSummary"), selected, _rows.Count);

        if (!_running && !_finished)
        {
            StartButton.IsEnabled = _optionsLoaded && selected > 0;
        }
    }

    private void SelectAll_Click(object sender, RoutedEventArgs e)
    {
        var check = SelectAllCheck.IsChecked == true;
        foreach (var row in _rows.Where(r => r.IsCheckable))
        {
            row.IsSelected = check;
        }
    }

    private void ShowError(string message)
    {
        ErrorText.Text = message;
        ErrorText.Visibility = Visibility.Visible;
    }

    private async void Cancel_Click(object sender, RoutedEventArgs e)
    {
        if (_running)
        {
            // Stop issuing new requests; in-flight shipments complete and stay valid.
            _runCts?.Cancel();
            CancelButton.IsEnabled = false;
            return;
        }

        await CloseAsync();
    }

    private async void Close_Click(object sender, RoutedEventArgs e)
    {
        await CloseAsync();
    }

    private async Task CloseAsync()
    {
        Visibility = Visibility.Collapsed;

        if (_anyCreated && RunCompleted is { } handler)
        {
            await handler();
        }
    }

    private async void Start_Click(object sender, RoutedEventArgs e)
    {
        if (Services is not { } services || _running)
        {
            return;
        }

        var selectedRows = _rows.Where(r => r.IsSelected && r.RateId is not null).ToList();
        if (selectedRows.Count == 0)
        {
            return;
        }

        _running = true;
        _runCts = new CancellationTokenSource();
        var requestLabel = RequestLabelToggle.IsOn;

        foreach (var row in _rows)
        {
            row.LockForRun();
        }

        SelectAllCheck.IsEnabled = false;
        RequestLabelToggle.IsEnabled = false;
        StartButton.IsEnabled = false;
        StartButton.Visibility = Visibility.Collapsed;
        ErrorText.Visibility = Visibility.Collapsed;
        RunRing.IsActive = true;
        RunRing.Visibility = Visibility.Visible;
        ProgressText.Visibility = Visibility.Visible;

        var shippingService = services.GetRequiredService<IShippingService>();
        var progressFormat = _resourceLoader.GetString("BatchShipment.Progress");
        var done = 0;
        ProgressText.Text = string.Format(progressFormat, done, selectedRows.Count);

        using var semaphore = new SemaphoreSlim(RunParallelism);
        var tasks = selectedRows.Select(async row =>
        {
            await semaphore.WaitAsync();
            try
            {
                await ProcessRowAsync(shippingService, row, requestLabel, _runCts.Token);
            }
            finally
            {
                semaphore.Release();
                done++;
                ProgressText.Text = string.Format(progressFormat, done, selectedRows.Count);
            }
        }).ToList();

        await Task.WhenAll(tasks);

        _running = false;
        _finished = true;
        RunRing.IsActive = false;
        RunRing.Visibility = Visibility.Collapsed;

        ShowRunResult(services, selectedRows);
    }

    /// <summary>One order of the run. Every failure marks the row and lets the run continue —
    /// a batch never aborts because one order misbehaves.</summary>
    private async Task ProcessRowAsync(
        IShippingService shippingService, BatchShipmentRow row, bool requestLabel, CancellationToken ct)
    {
        try
        {
            if (ct.IsCancellationRequested)
            {
                row.MarkSkipped(_resourceLoader.GetString("BatchShipment.StatusSkipped"));
                return;
            }

            row.MarkCreating(_resourceLoader.GetString("BatchShipment.StatusCreating"));

            // Re-read the open lines at execution time — another user (or an earlier,
            // interrupted run) may have shipped parts of the order in the meantime.
            var openItems = await shippingService.GetShippableItemsAsync(row.Id, ct);
            if (openItems.Count == 0)
            {
                row.MarkSkipped(_resourceLoader.GetString("BatchShipment.NothingToShip"));
                return;
            }

            var input = BatchShipmentLogic.BuildInput(row.Id, row.RateId!.Value, openItems, requestLabel);
            var shippingId = await shippingService.CreateShippingAsync(input, ct);
            _anyCreated = true;

            if (!requestLabel)
            {
                row.MarkCreated(shippingId, hasLabel: false,
                    _resourceLoader.GetString("BatchShipment.StatusCreated"));
                return;
            }

            var detail = await shippingService.GetShippingAsync(shippingId, ct);
            if (detail?.HasLabel == true)
            {
                row.MarkCreated(shippingId, hasLabel: true,
                    _resourceLoader.GetString("BatchShipment.StatusLabelReady"));
            }
            else if (detail?.LabelQueueStatus is ShippingOutboxStatus.Pending or ShippingOutboxStatus.InFlight)
            {
                // Outbox fallback caught a transient carrier error — "label follows", not a failure.
                row.MarkLabelQueued(shippingId, _resourceLoader.GetString("BatchShipment.StatusLabelQueued"));
            }
            else if (detail?.LabelQueueStatus == ShippingOutboxStatus.DeadLetter)
            {
                row.MarkLabelFailed(shippingId, string.IsNullOrWhiteSpace(detail.LabelQueueLastError)
                    ? _resourceLoader.GetString("BatchShipment.StatusLabelFailed")
                    : detail.LabelQueueLastError);
            }
            else
            {
                row.MarkCreated(shippingId, hasLabel: false,
                    _resourceLoader.GetString("BatchShipment.StatusCreated"));
            }
        }
        catch (OperationCanceledException)
        {
            row.MarkSkipped(_resourceLoader.GetString("BatchShipment.StatusSkipped"));
        }
        catch (ApiException ex)
        {
            row.MarkFailed(ex.CombinedMessage);
        }
        catch (Exception ex)
        {
            row.MarkFailed(ex.Message);
        }
    }

    private void ShowRunResult(IServiceProvider services, IReadOnlyList<BatchShipmentRow> processedRows)
    {
        var created = processedRows.Count(r => r.Outcome is BatchRowOutcome.Created);
        var queued = processedRows.Count(r => r.Outcome is BatchRowOutcome.LabelQueued);
        var failed = processedRows.Count(r =>
            r.Outcome is BatchRowOutcome.Failed or BatchRowOutcome.LabelFailed);
        var skipped = processedRows.Count(r => r.Outcome is BatchRowOutcome.Skipped);

        ProgressText.Visibility = Visibility.Collapsed;
        SummaryText.Text = string.Format(
            _resourceLoader.GetString("BatchShipment.Summary"), created + queued, queued, failed, skipped);
        SummaryText.Visibility = Visibility.Visible;

        var capabilities = services.GetRequiredService<ILabelService>().Capabilities;
        var anyLabel = processedRows.Any(r => r.HasLabel);
        var anyShipment = processedRows.Any(r => r.ShippingId != Guid.Empty);

        PrintAllButton.Visibility = anyLabel && capabilities.HasFlag(LabelCapabilities.Print)
            ? Visibility.Visible : Visibility.Collapsed;
        SaveAllButton.Visibility = anyLabel && capabilities.HasFlag(LabelCapabilities.Save)
            ? Visibility.Visible : Visibility.Collapsed;
        DownloadAllButton.Visibility = anyLabel && capabilities.HasFlag(LabelCapabilities.Download)
            ? Visibility.Visible : Visibility.Collapsed;
        PickListButton.Visibility = anyShipment ? Visibility.Visible : Visibility.Collapsed;
        BatchActionsPanel.Visibility = anyShipment ? Visibility.Visible : Visibility.Collapsed;

        CancelButton.Visibility = Visibility.Collapsed;
        CloseButton.Visibility = Visibility.Visible;
    }

    private List<BatchShipmentRow> RowsWithLabel() =>
        _rows.Where(r => r.HasLabel && r.ShippingId != Guid.Empty).ToList();

    private async void PrintAll_Click(object sender, RoutedEventArgs e)
    {
        if (Services is not { } services)
        {
            return;
        }

        var rows = RowsWithLabel();
        if (rows.Count == 0)
        {
            return;
        }

        var labelService = services.GetRequiredService<ILabelService>();
        var notifications = services.GetRequiredService<INotificationService>();

        string? printerName = null;
        if (labelService.Capabilities.HasFlag(LabelCapabilities.PickPrinter))
        {
            var (confirmed, picked) = await LabelActionRunner.PickPrinterAsync(XamlRoot);
            if (!confirmed)
            {
                return;
            }
            printerName = picked;
        }

        PrintAllButton.IsEnabled = false;
        try
        {
            foreach (var row in rows)
            {
                var label = await labelService.FetchLabelAsync(row.ShippingId);
                await labelService.PrintAsync(label, printerName);
            }

            notifications.Show(
                string.Format(_resourceLoader.GetString("BatchShipment.PrintedAll"), rows.Count),
                NotificationSeverity.Success);
        }
        catch (ApiException ex)
        {
            notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
        }
        catch (Exception)
        {
            notifications.Show(_resourceLoader.GetString("LabelAction.Failed") ?? string.Empty,
                NotificationSeverity.Error);
        }
        finally
        {
            PrintAllButton.IsEnabled = true;
        }
    }

    private async void SaveAll_Click(object sender, RoutedEventArgs e)
    {
        if (Services is not { } services || sender is not Button button)
        {
            return;
        }

        var rows = RowsWithLabel();
        if (rows.Count == 0)
        {
            return;
        }

        var labelService = services.GetRequiredService<ILabelService>();
        var notifications = services.GetRequiredService<INotificationService>();

        button.IsEnabled = false;
        try
        {
            var labels = new List<LabelFile>(rows.Count);
            foreach (var row in rows)
            {
                labels.Add(await labelService.FetchLabelAsync(row.ShippingId));
            }

            if (await labelService.SaveAllAsync(labels))
            {
                notifications.Show(
                    string.Format(_resourceLoader.GetString("BatchShipment.SavedAll"), labels.Count),
                    NotificationSeverity.Success);
            }
        }
        catch (ApiException ex)
        {
            notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
        }
        catch (Exception)
        {
            notifications.Show(_resourceLoader.GetString("LabelAction.Failed") ?? string.Empty,
                NotificationSeverity.Error);
        }
        finally
        {
            button.IsEnabled = true;
        }
    }

    /// <summary>Combined, location-sorted pick list over every shipment of the run.
    /// Same fixed default flow as the packing slip: print on Desktop-Windows (remembered
    /// packing-slip printer), download on WASM, system default app elsewhere.</summary>
    private async void PickList_Click(object sender, RoutedEventArgs e)
    {
        if (Services is not { } services)
        {
            return;
        }

        var shippingIds = _rows
            .Where(r => r.ShippingId != Guid.Empty)
            .Select(r => r.ShippingId)
            .ToList();
        if (shippingIds.Count == 0)
        {
            return;
        }

        var labelService = services.GetRequiredService<ILabelService>();
        var preferences = services.GetRequiredService<IShippingPreferences>();
        var notifications = services.GetRequiredService<INotificationService>();
        var capabilities = labelService.Capabilities;

        PickListButton.IsEnabled = false;
        try
        {
            if (capabilities.HasFlag(LabelCapabilities.Print)
                && capabilities.HasFlag(LabelCapabilities.PickPrinter))
            {
                var (confirmed, printerName) = await LabelActionRunner.PickPrinterAsync(
                    XamlRoot, preferences.GetPackingSlipPrinter(_tenantId));
                if (!confirmed)
                {
                    return;
                }

                var pickList = await labelService.FetchBatchPickListAsync(shippingIds);
                await labelService.PrintAsync(pickList, printerName);
                preferences.SetPackingSlipPrinter(_tenantId, printerName);
                notifications.Show(_resourceLoader.GetString("PackingSlipAction.Printed"),
                    NotificationSeverity.Success);
                return;
            }

            var file = await labelService.FetchBatchPickListAsync(shippingIds);

            if (capabilities.HasFlag(LabelCapabilities.Download))
            {
                if (await labelService.SaveAsync(file))
                {
                    notifications.Show(_resourceLoader.GetString("PackingSlipAction.Downloaded"),
                        NotificationSeverity.Success);
                }
                return;
            }

            await labelService.OpenWithSystemDefaultAsync(file);
        }
        catch (ApiException ex)
        {
            notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
        }
        catch (Exception)
        {
            notifications.Show(_resourceLoader.GetString("PackingSlipAction.Failed") ?? string.Empty,
                NotificationSeverity.Error);
        }
        finally
        {
            PickListButton.IsEnabled = true;
        }
    }
}
