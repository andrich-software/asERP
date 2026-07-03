using asToolkit.Client.Controls;
using asToolkit.Client.Features.Superadmin.Models;
using asToolkit.Domain.Dtos.Tenant;

namespace asToolkit.Client.Features.Superadmin.Views;

public sealed partial class SuperadminTenantListPage : Page
{
    private bool _isInitializing = true;

    public SuperadminTenantListPage()
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
        if (sender is TextBox textBox && DataContext is SuperadminTenantListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is SuperadminTenantListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SuperadminTenantListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SuperadminTenantListModel model)
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
            DataContext is SuperadminTenantListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }

    private async void TenantRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is TenantListDto tenant &&
            DataContext is SuperadminTenantListModel model)
        {
            await model.EditTenant(tenant);
        }
    }
}
