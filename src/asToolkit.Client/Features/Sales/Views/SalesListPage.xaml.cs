using asToolkit.Client.Controls;
using asToolkit.Client.Features.Saless.Models;
using asToolkit.Domain.Dtos.Sales;

namespace asToolkit.Client.Features.Saless.Views;

public sealed partial class SalesListPage : Page
{
    private bool _isInitializing = true;

    public SalesListPage()
    {
        this.InitializeComponent();
        this.Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _isInitializing = false;
    }

    private async void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox && DataContext is SalesListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
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
