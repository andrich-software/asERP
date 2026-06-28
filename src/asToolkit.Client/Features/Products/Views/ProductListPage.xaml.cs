using System.Windows.Input;
using asToolkit.Client.Core.Events;
using asToolkit.Client.Features.Products.Models;
using asToolkit.Domain.Dtos.Product;

namespace asToolkit.Client.Features.Products.Views;

public sealed partial class ProductListPage : Page
{
    private bool _isInitializing = true;
    private string _currentSortField = "Name";
    private bool _sortAscending = true;

    // Sort icon references - will be found after template is applied
    private readonly Dictionary<string, FontIcon> _sortIcons = new();

    // The model we are currently subscribed to (for empty-state updates), so we can unsubscribe.
    private ProductListModel? _subscribedModel;

    // Action behind the currently shown empty-state button.
    private ProductEmptyStateAction _emptyStateAction = ProductEmptyStateAction.None;

    // Polls for server-side (orchestrator) background imports that the client never triggered, so an
    // open product list still refreshes once such an import finishes. Only refreshes on a genuinely
    // new completed run (see ProductListModel.PollForCompletedImportAsync), not on every tick.
    private static readonly TimeSpan ImportPollInterval = TimeSpan.FromSeconds(15);
    private readonly DispatcherTimer _importPollTimer;
    private bool _isPolling;

    public ProductListPage()
    {
        this.InitializeComponent();
        this.Loaded += OnLoaded;
        this.Unloaded += OnUnloaded;
        this.DataContextChanged += OnDataContextChanged;

        _importPollTimer = new DispatcherTimer { Interval = ImportPollInterval };
        _importPollTimer.Tick += ImportPollTimer_Tick;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _isInitializing = false;

        // Cache sort icons for later updates
        CacheSortIcons();

        SubscribeModel();

        // Auto-refresh the list when an import elsewhere reports that products changed.
        AppRefreshSignals.ProductsChanged += OnProductsChangedSignal;

        // And poll for server-side background imports that emit no client-side signal.
        _importPollTimer.Start();
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        AppRefreshSignals.ProductsChanged -= OnProductsChangedSignal;
        _importPollTimer.Stop();
        if (_subscribedModel is not null)
        {
            _subscribedModel.ProductsLoaded -= OnProductsLoaded;
            _subscribedModel = null;
        }
    }

    private async void ImportPollTimer_Tick(object? sender, object e)
    {
        // Guard against overlapping polls if a slow request outlasts the interval.
        if (_isPolling || DataContext is not ProductListModel model)
        {
            return;
        }

        _isPolling = true;
        try
        {
            if (await model.PollForCompletedImportAsync() &&
                ProductsFeedView.Refresh is ICommand command &&
                command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
        finally
        {
            _isPolling = false;
        }
    }

    private void OnDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        => SubscribeModel();

    private void SubscribeModel()
    {
        if (DataContext is not ProductListModel model || ReferenceEquals(model, _subscribedModel))
        {
            return;
        }

        if (_subscribedModel is not null)
        {
            _subscribedModel.ProductsLoaded -= OnProductsLoaded;
        }

        _subscribedModel = model;
        _subscribedModel.ProductsLoaded += OnProductsLoaded;
    }

    private void OnProductsChangedSignal(object? sender, EventArgs e)
    {
        // May be raised from a background thread — marshal to the UI thread before touching the view.
        DispatcherQueue.TryEnqueue(() =>
        {
            if (ProductsFeedView.Refresh is ICommand command && command.CanExecute(null))
            {
                command.Execute(null);
            }
        });
    }

    private void OnProductsLoaded(int totalCount)
    {
        DispatcherQueue.TryEnqueue(async () =>
        {
            if (totalCount > 0)
            {
                EmptyStateOverlay.Visibility = Visibility.Collapsed;
                return;
            }

            if (DataContext is not ProductListModel model)
            {
                return;
            }

            var info = await model.GetEmptyStateAsync();

            EmptyStateIcon.Glyph = info.Glyph;
            EmptyStateTitle.Text = info.Title;
            EmptyStateMessage.Text = info.Message;
            _emptyStateAction = info.Action;

            if (info.Action != ProductEmptyStateAction.None && !string.IsNullOrEmpty(info.ActionLabel))
            {
                EmptyStateActionButton.Content = info.ActionLabel;
                EmptyStateActionButton.Visibility = Visibility.Visible;
            }
            else
            {
                EmptyStateActionButton.Visibility = Visibility.Collapsed;
            }

            EmptyStateOverlay.Visibility = Visibility.Visible;
        });
    }

    private async void EmptyStateAction_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ProductListModel model)
        {
            return;
        }

        switch (_emptyStateAction)
        {
            case ProductEmptyStateAction.OpenSalesChannels:
                await model.OpenSalesChannels();
                break;
            case ProductEmptyStateAction.Refresh:
                if (ProductsFeedView.Refresh is ICommand command && command.CanExecute(null))
                {
                    command.Execute(null);
                }
                break;
        }
    }

    private void CacheSortIcons()
    {
        // Find sort icons in the visual tree
        if (FindName("SortIconSku") is FontIcon iconSku)
            _sortIcons["Sku"] = iconSku;
        if (FindName("SortIconName") is FontIcon iconName)
            _sortIcons["Name"] = iconName;
        if (FindName("SortIconManufacturer") is FontIcon iconManufacturer)
            _sortIcons["Manufacturer"] = iconManufacturer;
        if (FindName("SortIconPrice") is FontIcon iconPrice)
            _sortIcons["Price"] = iconPrice;
        if (FindName("SortIconMsrp") is FontIcon iconMsrp)
            _sortIcons["Msrp"] = iconMsrp;
    }

    private async void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox && DataContext is ProductListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button || DataContext is not ProductListModel model)
            return;

        var sortField = button.Tag?.ToString() ?? string.Empty;
        if (string.IsNullOrEmpty(sortField))
            return;

        // Toggle direction if same field, otherwise default to ascending
        if (_currentSortField == sortField)
        {
            _sortAscending = !_sortAscending;
        }
        else
        {
            _currentSortField = sortField;
            _sortAscending = true;
        }

        // Update sort icons
        UpdateSortIcons();

        // Build sort parameter
        var sortDirection = _sortAscending ? "Ascending" : "Descending";
        var salesBy = $"{sortField} {sortDirection}";

        await model.SetSortSales(salesBy);
    }

    private void UpdateSortIcons()
    {
        // Try to re-cache if icons dictionary is empty (template might have been re-applied)
        if (_sortIcons.Count == 0)
        {
            CacheSortIcons();
        }

        foreach (var kvp in _sortIcons)
        {
            var icon = kvp.Value;
            var field = kvp.Key;

            if (field == _currentSortField)
            {
                icon.Visibility = Visibility.Visible;
                // E70D = ChevronUp (ascending), E70E = ChevronDown (descending)
                icon.Glyph = _sortAscending ? "\uE70D" : "\uE70E";
                icon.Foreground = (Microsoft.UI.Xaml.Media.Brush)Application.Current.Resources["PrimaryBrush"];
            }
            else
            {
                icon.Visibility = Visibility.Collapsed;
            }
        }
    }

    private async void CreateProduct_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductListModel model)
        {
            await model.CreateProduct();
        }
    }

    private async void ProductRow_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button &&
            button.DataContext is ProductListItemModel item &&
            DataContext is ProductListModel model)
        {
            await model.ViewProduct(item.Dto);
        }
    }

    private async void IncludeVariantsToggle_Toggled(object sender, RoutedEventArgs e)
    {
        if (_isInitializing) return;

        if (sender is ToggleSwitch toggle && DataContext is ProductListModel model)
        {
            await model.SetIncludeVariants(toggle.IsOn);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductListModel model)
        {
            await model.GoToNextPage();
        }
    }

    private async void PageSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_isInitializing) return;

        if (sender is ComboBox comboBox &&
            comboBox.SelectedItem is ComboBoxItem selectedItem &&
            selectedItem.Tag is string pageSizeStr &&
            int.TryParse(pageSizeStr, out var pageSize) &&
            DataContext is ProductListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
