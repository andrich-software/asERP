using asERP.Client.Controls;
using asERP.Client.Features.Feeds.Models;
using asERP.Domain.Dtos.Feed;

namespace asERP.Client.Features.Feeds.Views;

public sealed partial class FeedListPage : Page
{
    private bool _isInitializing = true;

    public FeedListPage()
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
        if (sender is TextBox textBox && DataContext is FeedListModel model)
        {
            await model.CurrentPage.UpdateAsync(_ => 0);
            await model.SearchQuery.UpdateAsync(_ => textBox.Text);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is FeedListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void CreateFeed_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedListModel model)
        {
            await model.CreateFeed();
        }
    }

    private async void FeedRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is FeedListDto feed &&
            DataContext is FeedListModel model)
        {
            await model.ViewFeed(feed);
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedListModel model)
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
            DataContext is FeedListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
