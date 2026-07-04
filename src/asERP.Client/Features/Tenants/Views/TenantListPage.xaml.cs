using asERP.Client.Controls;
using asERP.Client.Features.Tenants.Models;
using asERP.Domain.Dtos.Tenant;

namespace asERP.Client.Features.Tenants.Views;

public sealed partial class TenantListPage : Page
{
    private bool _isInitializing = true;

    public TenantListPage()
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
        if (sender is TextBox textBox && DataContext is TenantListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is TenantListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TenantListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TenantListModel model)
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
            DataContext is TenantListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }

    private async void CreateTenant_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TenantListModel model)
        {
            await model.CreateTenant();
        }
    }

    private async void TenantRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is TenantListDto tenant &&
            DataContext is TenantListModel model)
        {
            await model.ViewTenant(tenant);
        }
    }
}
