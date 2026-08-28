using asERP.Client.Features.ShippingProviders.Models;

namespace asERP.Client.Features.ShippingProviders.Views;

public sealed partial class ShippingProviderListPage : Page
{
    public ShippingProviderListPage()
    {
        InitializeComponent();
    }

    private ShippingProviderListModel? Model => DataContext as ShippingProviderListModel;

    private async void Refresh_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.RefreshAsync();
        }
    }

    private async void CreateProvider_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.CreateProviderAsync();
        }
    }

    private async void ProviderRow_Click(object sender, ItemClickEventArgs e)
    {
        if (Model is { } model && e.ClickedItem is ShippingProviderRow row)
        {
            await model.EditProviderAsync(row);
        }
    }
}
