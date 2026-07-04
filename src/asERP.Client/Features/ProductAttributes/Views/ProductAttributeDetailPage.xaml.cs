using asERP.Client.Features.ProductAttributes.Models;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Features.ProductAttributes.Views;

public sealed partial class ProductAttributeDetailPage : Page
{
    public ProductAttributeDetailPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductAttributeDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductAttributeDetailModel model)
        {
            await model.EditProductAttribute();
        }
    }
}
