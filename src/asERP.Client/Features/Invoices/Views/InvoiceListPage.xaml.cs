using asERP.Client.Controls;
using asERP.Client.Features.Invoices.Models;
using asERP.Domain.Dtos.Invoice;

namespace asERP.Client.Features.Invoices.Views;

public sealed partial class InvoiceListPage : Page
{
    private bool _isInitializing = true;

    public InvoiceListPage()
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
        if (sender is TextBox textBox && DataContext is InvoiceListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is InvoiceListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private void CreateInvoice_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Navigate to create invoice page when implemented
    }

    private async void InvoiceRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is InvoiceListDto invoice &&
            DataContext is InvoiceListModel model)
        {
            await model.ViewInvoice(invoice);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is InvoiceListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is InvoiceListModel model)
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
            DataContext is InvoiceListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
