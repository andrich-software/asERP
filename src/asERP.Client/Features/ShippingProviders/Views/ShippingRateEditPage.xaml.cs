using asERP.Client.Features.ShippingProviders.Models;

namespace asERP.Client.Features.ShippingProviders.Views;

public sealed partial class ShippingRateEditPage : Page
{
    public ShippingRateEditPage()
    {
        InitializeComponent();
    }

    private ShippingRateEditModel? Model => DataContext as ShippingRateEditModel;

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.SaveAsync();
        }
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.CancelAsync();
        }
    }

    private async void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.DeleteAsync(XamlRoot);
        }
    }

    private void SelectVisible_Click(object sender, RoutedEventArgs e)
    {
        Model?.SelectVisibleCountries();
    }

    private void DeselectVisible_Click(object sender, RoutedEventArgs e)
    {
        Model?.DeselectVisibleCountries();
    }
}
