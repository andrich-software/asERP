using System.Windows.Input;
using asToolkit.Client.Controls;
using asToolkit.Client.Core.Events;
using asToolkit.Client.Features.Products.Models;

namespace asToolkit.Client.Features.Products.Views;

public sealed partial class ProductListPage : Page
{
    private bool _isInitializing = true;

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

        _importPollTimer = new DispatcherTimer { Interval = ImportPollInterval };
        _importPollTimer.Tick += ImportPollTimer_Tick;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _isInitializing = false;

        // Auto-refresh the list when an import elsewhere reports that products changed.
        AppRefreshSignals.ProductsChanged += OnProductsChangedSignal;

        // And poll for server-side background imports that emit no client-side signal.
        _importPollTimer.Start();
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        AppRefreshSignals.ProductsChanged -= OnProductsChangedSignal;
        _importPollTimer.Stop();
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

    private async void EmptyStateAction_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ProductListModel model)
        {
            return;
        }

        var info = await model.EmptyState.Value(CancellationToken.None);
        switch (info?.Action)
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
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is ProductListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void CreateProduct_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductListModel model)
        {
            await model.CreateProduct();
        }
    }

    private async void ProductRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is ProductListItemModel item &&
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
