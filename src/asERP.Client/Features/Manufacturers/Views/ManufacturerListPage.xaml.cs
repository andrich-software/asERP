using asERP.Client.Controls;
using asERP.Client.Features.Manufacturers.Models;
using asERP.Domain.Dtos.Manufacturer;

namespace asERP.Client.Features.Manufacturers.Views;

public sealed partial class ManufacturerListPage : Page
{
    private bool _isInitializing = true;

    public ManufacturerListPage()
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
        if (sender is TextBox textBox && DataContext is ManufacturerListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is ManufacturerListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void ManufacturerRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is ManufacturerListDto manufacturer &&
            DataContext is ManufacturerListModel model)
        {
            await model.ViewManufacturer(manufacturer);
        }
    }

    private async void CreateManufacturer_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ManufacturerListModel model)
        {
            await model.CreateManufacturer();
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ManufacturerListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ManufacturerListModel model)
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
            DataContext is ManufacturerListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
