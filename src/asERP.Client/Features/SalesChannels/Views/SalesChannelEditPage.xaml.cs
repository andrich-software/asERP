using asERP.Client.Features.SalesChannels.Models;
using asERP.Domain.Dtos.ShopDomain;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Features.SalesChannels.Views;

public sealed partial class SalesChannelEditPage : Page
{
    public SalesChannelEditPage()
    {
        this.InitializeComponent();
    }

    private async void AddShopDomainButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelEditModel model)
        {
            await model.AddShopDomainAsync();
        }
    }

    private async void DeleteShopDomainButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelEditModel model
            && sender is FrameworkElement { DataContext: ShopDomainListDto domain })
        {
            await model.DeleteShopDomainAsync(domain);
        }
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelEditModel model)
        {
            await model.CancelAsync();
        }
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelEditModel model)
        {
            await model.SaveAsync();
        }
    }

    private void SelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelEditModel model)
        {
            foreach (var warehouse in model.Warehouses)
            {
                warehouse.IsSelected = true;
            }
        }
    }

    private void SelectAllCheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelEditModel model)
        {
            foreach (var warehouse in model.Warehouses)
            {
                warehouse.IsSelected = false;
            }
        }
    }

    private async void ConnectOAuthButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelEditModel model)
        {
            await model.ConnectOAuthAsync();
        }
    }

    private async void DisconnectOAuthButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is SalesChannelEditModel model)
        {
            await model.DisconnectOAuthAsync();
        }
    }
}
