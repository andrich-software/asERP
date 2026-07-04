using asERP.Client.Features.Customers.Models;
using asERP.Domain.Dtos.Sales;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;
using Windows.ApplicationModel.Resources;

namespace asERP.Client.Features.Customers.Views;

public sealed partial class CustomerDetailPage : Page
{
    private static readonly string[] TabPanelNames = ["OverviewTab", "AddressesTab", "SalessTab"];
    private const int SalessTabIndex = 2;

    // Survives FeedView template re-realization (e.g. refresh after returning from Edit).
    private int _selectedTabIndex;
    private bool _salesFeedRequested;

    public CustomerDetailPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is CustomerDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is CustomerDetailModel model)
        {
            await model.EditCustomer();
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is CustomerDetailModel model)
        {
            var confirmed = await ShowDeleteConfirmationAsync();
            if (confirmed)
            {
                await model.DeleteCustomer(CancellationToken.None);
            }
        }
    }

    private async void SalesRow_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is CustomerDetailModel model &&
            sender is FrameworkElement { DataContext: SalesListDto sales })
        {
            await model.ViewSales(sales);
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
        for (var i = 0; i < TabPanelNames.Length; i++)
        {
            if (tabBar.FindName(TabPanelNames[i]) is UIElement panel)
            {
                panel.Visibility = i == _selectedTabIndex ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        if (_selectedTabIndex == SalessTabIndex)
        {
            EnsureSalesFeedRequested();
        }
    }

    // Kick off the lazy sales feed the first time the tab is opened.
    private async void EnsureSalesFeedRequested()
    {
        if (_salesFeedRequested || DataContext is not CustomerDetailModel model)
        {
            return;
        }

        _salesFeedRequested = true;
        await model.RequestSalesTab();
    }

    private async Task<bool> ShowDeleteConfirmationAsync()
    {
        var resourceLoader = ResourceLoader.GetForViewIndependentUse();

        var dialog = new ContentDialog
        {
            Title = resourceLoader.GetString("CustomerDetailPage.DeleteConfirmation.Title"),
            Content = resourceLoader.GetString("CustomerDetailPage.DeleteConfirmation.Message"),
            PrimaryButtonText = resourceLoader.GetString("Common.Delete"),
            CloseButtonText = resourceLoader.GetString("Common.Cancel"),
            DefaultButton = ContentDialogButton.Close,
            XamlRoot = this.XamlRoot,
            Style = Application.Current.Resources["ContentDialogStyle"] as Style
        };

        var result = await dialog.ShowAsync();
        return result == ContentDialogResult.Primary;
    }
}
