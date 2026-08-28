using asERP.Client.Controls;
using asERP.Client.Features.Saless.Models;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;

namespace asERP.Client.Features.Saless.Views;

public sealed partial class SalesListPage : Page
{
    /// <summary>
    /// Debounce for the search box: the list feed issues one request per filter change, so typing
    /// unthrottled just cancels the previous request mid-flight (TaskCanceledException per keystroke).
    /// </summary>
    private static readonly TimeSpan SearchDebounce = TimeSpan.FromMilliseconds(300);

    private CancellationTokenSource? _searchDebounceCts;
    private bool _isInitializing = true;
    private bool _initialFilterSynced;

    public SalesListPage()
    {
        this.InitializeComponent();
        this.Loaded += OnLoaded;
        this.DataContextChanged += (_, _) => TrySyncInitialFilter();

        BatchDialog.RunCompleted += () =>
        {
            SalessFeedView.Refresh?.Execute(null);
            return Task.CompletedTask;
        };
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        TrySyncInitialFilter();
        _isInitializing = false;
    }

    /// <summary>
    /// Highlights the chip of a quick filter pre-activated via navigation data. Runs from both
    /// Loaded and DataContextChanged (the DataContext may not be assigned yet at Loaded), one-shot.
    /// </summary>
    private void TrySyncInitialFilter()
    {
        if (_initialFilterSynced || DataContext is not SalesListModel model)
        {
            return;
        }

        _initialFilterSynced = true;
        if (model.InitialQuickFilter == SalesQuickFilter.All)
        {
            return;
        }

        var chip = FilterChips.Children.OfType<Button>()
            .FirstOrDefault(b => b.Tag as string == model.InitialQuickFilter.ToString());
        if (chip is not null)
        {
            HighlightFilterChip(chip);
        }
    }

    private async void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is not TextBox textBox || DataContext is not SalesListModel model)
        {
            return;
        }

        _searchDebounceCts?.Cancel();
        var cts = new CancellationTokenSource();
        _searchDebounceCts = cts;

        try
        {
            await Task.Delay(SearchDebounce, cts.Token);
            await model.SetSearch(textBox.Text, cts.Token);
        }
        catch (OperationCanceledException)
        {
            // A newer keystroke superseded this search — ignore.
        }
    }

    private async void FilterChip_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { Tag: string tag } chip &&
            Enum.TryParse<SalesQuickFilter>(tag, out var quickFilter) &&
            DataContext is SalesListModel model)
        {
            // Fold a search still waiting out its debounce into this change instead of letting it
            // re-query right after: one state update, and nothing the user typed is lost.
            _searchDebounceCts?.Cancel();

            HighlightFilterChip(chip);
            await model.SetQuickFilter(quickFilter, SearchBox.Text);
        }
    }

    /// <summary>
    /// Marks the clicked chip as active. Style switch instead of a Resources[] brush lookup:
    /// the indexer does not resolve ThemeDictionaries theme-aware, ThemeResource inside the style does.
    /// </summary>
    private void HighlightFilterChip(Button active)
    {
        foreach (var chip in FilterChips.Children.OfType<Button>())
        {
            chip.Style = (Style)Application.Current.Resources[
                chip == active ? "FilterChipButtonActiveStyle" : "FilterChipButtonStyle"];
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is SalesListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void BatchShipButton_Click(object sender, RoutedEventArgs e)
    {
        await BatchDialog.OpenAsync();
    }

    private async void NewSalesButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesListModel model)
        {
            await model.CreateSales();
        }
    }

    private async void SalesRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is SalesListDto sales &&
            DataContext is SalesListModel model)
        {
            await model.ViewSales(sales);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesListModel model)
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
            DataContext is SalesListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
