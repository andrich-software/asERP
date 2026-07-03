using asToolkit.Client.Features.Saless.Models;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace asToolkit.Client.Features.Saless.Views;

public sealed partial class SalesDetailPage : Page
{
    private static readonly string[] TabPanelNames = ["OverviewTab", "ItemsTab", "AddressesTab", "HistoryTab"];

    // Survives FeedView template re-realization (e.g. refresh after returning from Edit).
    private int _selectedTabIndex;

    public SalesDetailPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesDetailModel model)
        {
            await model.EditSales();
        }
    }

    private async void CustomerLink_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid customerId } &&
            DataContext is SalesDetailModel model)
        {
            await model.NavigateToCustomer(customerId);
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
    }
}
