using System.Windows.Input;
using asERP.Client.Core.Helpers;
using asERP.Client.Features.Saless.Models;
using asERP.Client.Features.Shippings.Services;
using asERP.Domain.Dtos.Shipping;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Uno.Toolkit.UI;

namespace asERP.Client.Features.Saless.Views;

public sealed partial class SalesDetailPage : Page
{
    private static readonly string[] TabPanelNames = ["OverviewTab", "ItemsTab", "ShipmentsTab", "AddressesTab", "HistoryTab"];

    // Survives FeedView template re-realization (e.g. refresh after returning from Edit).
    private int _selectedTabIndex;

    public SalesDetailPage()
    {
        this.InitializeComponent();
        ShipmentDialog.ShipmentCreated += OnShipmentCreated;
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

    private async void ShipButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid salesId })
        {
            await ShipmentDialog.OpenAsync(salesId);
        }
    }

    private async void CancelSalesButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not SalesDetailModel model || this.XamlRoot is not { } xamlRoot)
        {
            return;
        }

        var confirmed = await ConfirmDialog.ShowAsync(
            xamlRoot,
            "SalesDetailPage.CancelSalesConfirmTitle",
            "SalesDetailPage.CancelSalesConfirmMessage",
            confirmKey: "Common.Confirm");

        if (confirmed && await model.CancelSales())
        {
            RefreshFeed();
        }
    }

    private async void ShipmentRow_Tapped(object sender, TappedRoutedEventArgs e)
    {
        if (sender is FrameworkElement { DataContext: ShippingListDto shipping } &&
            DataContext is SalesDetailModel model)
        {
            await model.NavigateToShipping(shipping.Id);
        }
    }

    private async void ShipmentTracking_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: string url } &&
            Uri.TryCreate(url, UriKind.Absolute, out var uri))
        {
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }

    private async void ShipmentLabel_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid shippingId })
        {
            // One click: remembered preference first, platform default otherwise (toasts inside).
            await LabelActionRunner.RunQuickAsync(shippingId);
        }
    }

    private async void ShipmentPackingSlip_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: Guid shippingId })
        {
            await PackingSlipActionRunner.RunAsync(shippingId, this.XamlRoot);
        }
    }

    private async void ShipmentCancel_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button { CommandParameter: Guid shippingId } ||
            DataContext is not SalesDetailModel model ||
            this.XamlRoot is not { } xamlRoot)
        {
            return;
        }

        var confirmed = await ConfirmDialog.ShowAsync(
            xamlRoot,
            "SalesDetailPage.CancelShipmentConfirmTitle",
            "SalesDetailPage.CancelShipmentConfirmMessage",
            confirmKey: "Common.Confirm");

        if (confirmed && await model.CancelShipment(shippingId))
        {
            RefreshFeed();
        }
    }

    private Task OnShipmentCreated()
    {
        // Status may have moved to PartiallyDelivered/Completed and the shipments tab gained a row.
        RefreshFeed();
        return Task.CompletedTask;
    }

    private void RefreshFeed()
    {
        if (SalesFeedView.Refresh is ICommand command && command.CanExecute(null))
        {
            command.Execute(null);
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
