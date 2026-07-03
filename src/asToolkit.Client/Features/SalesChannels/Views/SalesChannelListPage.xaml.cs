using asToolkit.Client.Controls;
using asToolkit.Client.Features.SalesChannels.Models;
using asToolkit.Domain.Dtos.SalesChannel;

namespace asToolkit.Client.Features.SalesChannels.Views;

public sealed partial class SalesChannelListPage : Page
{
    private bool _isInitializing = true;

    public SalesChannelListPage()
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
        if (sender is TextBox textBox && DataContext is SalesChannelListModel model)
        {
            // Reset to first page when search changes
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is SalesChannelListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void CreateSalesChannel_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelListModel model)
        {
            await model.CreateSalesChannel();
        }
    }

    private async void SalesChannelRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is SalesChannelListDto salesChannel &&
            DataContext is SalesChannelListModel model)
        {
            await model.ViewSalesChannel(salesChannel);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelListModel model)
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
            DataContext is SalesChannelListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
