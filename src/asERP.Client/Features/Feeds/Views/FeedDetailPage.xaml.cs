using asERP.Client.Controls;
using asERP.Client.Core.Helpers;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Feeds.Models;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;
using Windows.ApplicationModel.Resources;

namespace asERP.Client.Features.Feeds.Views;

public sealed partial class FeedDetailPage : Page
{
    private static readonly string[] TabPanelNames = ["OverviewTab", "LogTab", "ProductsTab"];

    // Survives FeedView template re-realization (e.g. refresh after returning from Edit).
    private int _selectedTabIndex;

    public FeedDetailPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedDetailModel model)
        {
            await model.EditFeed();
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not FeedDetailModel model || this.XamlRoot is not { } xamlRoot)
        {
            return;
        }

        var confirmed = await ConfirmDialog.ShowAsync(
            xamlRoot,
            "FeedDetailPage.DeleteConfirmTitle",
            "FeedDetailPage.DeleteConfirmMessage",
            confirmKey: "Common.Delete");

        if (confirmed)
        {
            await model.DeleteFeed();
        }
    }

    private void CopyPublicUrl_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: string url } && !string.IsNullOrWhiteSpace(url))
        {
            var package = new Windows.ApplicationModel.DataTransfer.DataPackage();
            package.SetText(url);
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(package);

            var notifications = (Application.Current as App)?.Host?.Services?.GetService<INotificationService>();
            var message = ResourceLoader.GetForViewIndependentUse().GetString("FeedDetailPage.UrlCopied");
            if (!string.IsNullOrEmpty(message))
            {
                notifications?.Show(message, NotificationSeverity.Info);
            }
        }
    }

    private async void PreviousLogPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedDetailModel model)
        {
            await model.GoToPreviousLogPage();
        }
    }

    private async void NextLogPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedDetailModel model)
        {
            await model.GoToNextLogPage();
        }
    }

    private async void ProductSearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox && DataContext is FeedDetailModel model)
        {
            await model.SetProductSearch(textBox.Text);
        }
    }

    private async void ProductSortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is FeedDetailModel model)
        {
            await model.ToggleProductSort(field);
        }
    }

    private async void PreviousProductPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedDetailModel model)
        {
            await model.GoToPreviousProductPage();
        }
    }

    private async void NextProductPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedDetailModel model)
        {
            await model.GoToNextProductPage();
        }
    }

    private void DetailTabs_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is TabBar tabBar)
        {
            tabBar.SelectedIndex = _selectedTabIndex;
            ApplySelectedTab(tabBar);
        }
    }

    private void DetailTabs_SelectionChanged(object? sender, TabBarSelectionChangedEventArgs args)
    {
        if (sender is TabBar { SelectedIndex: >= 0 } tabBar)
        {
            _selectedTabIndex = tabBar.SelectedIndex;
            ApplySelectedTab(tabBar);
        }
    }

    private void ApplySelectedTab(TabBar tabBar)
    {
        TabPanelSwitcher.Apply(tabBar, TabPanelNames, _selectedTabIndex);

        // Gate the expensive per-tab feeds so they only query once the user opens the tab.
        if (DataContext is FeedDetailModel model)
        {
            if (_selectedTabIndex == 1)
            {
                _ = model.EnsureLogsLoaded();
            }
            else if (_selectedTabIndex == 2)
            {
                _ = model.EnsureProductsLoaded();
            }
        }
    }
}
