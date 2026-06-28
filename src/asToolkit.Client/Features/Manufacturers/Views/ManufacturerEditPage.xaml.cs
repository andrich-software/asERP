using asToolkit.Client.Features.Manufacturers.Models;
using Microsoft.UI.Xaml.Controls;

namespace asToolkit.Client.Features.Manufacturers.Views;

public sealed partial class ManufacturerEditPage : Page
{
    public ManufacturerEditPage()
    {
        this.InitializeComponent();
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ManufacturerEditModel model)
        {
            await model.CancelAsync();
        }
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ManufacturerEditModel model)
        {
            await model.SaveAsync();
        }
    }
}
