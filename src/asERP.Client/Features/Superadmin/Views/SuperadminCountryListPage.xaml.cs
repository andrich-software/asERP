using asERP.Client.Controls;
using asERP.Client.Features.Superadmin.Models;
using asERP.Domain.Dtos.Country;

namespace asERP.Client.Features.Superadmin.Views;

public sealed partial class SuperadminCountryListPage : Page
{
    private bool _isInitializing = true;

    public SuperadminCountryListPage()
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
        if (sender is TextBox textBox && DataContext is SuperadminCountryListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is SuperadminCountryListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void CreateCountry_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SuperadminCountryListModel model)
        {
            await model.NavigateToCreate();
        }
    }

    private async void CountryRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is CountryListDto country &&
            DataContext is SuperadminCountryListModel model)
        {
            await model.NavigateToEdit(country.Id);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SuperadminCountryListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SuperadminCountryListModel model)
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
            DataContext is SuperadminCountryListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
