using asERP.Client.Features.ShippingProviders.Models;

namespace asERP.Client.Features.ShippingProviders.Views;

public sealed partial class ShippingProviderEditPage : Page
{
    private bool _wasLoadedBefore;

    public ShippingProviderEditPage()
    {
        InitializeComponent();

        // Coming back from the rate edit page must show the changed rate list. The first Loaded
        // is covered by the model's own initialization.
        Loaded += async (_, _) =>
        {
            if (_wasLoadedBefore && Model is { IsEditMode: true } model)
            {
                await model.ReloadAsync();
            }

            _wasLoadedBefore = true;
        };
    }

    private ShippingProviderEditModel? Model => DataContext as ShippingProviderEditModel;

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

    private async void AddRate_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model)
        {
            await model.AddRateAsync();
        }
    }

    private async void RateRow_Click(object sender, RoutedEventArgs e)
    {
        if (Model is { } model && sender is FrameworkElement { DataContext: ShippingRateRow row })
        {
            await model.EditRateAsync(row);
        }
    }
}
