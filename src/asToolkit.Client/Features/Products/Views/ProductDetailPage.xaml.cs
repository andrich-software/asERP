using asToolkit.Client.Features.Products.Models;
using asToolkit.Domain.Dtos.Product;
using Microsoft.UI.Xaml.Controls;

namespace asToolkit.Client.Features.Products.Views;

public sealed partial class ProductDetailPage : Page
{
    public ProductDetailPage()
    {
        this.InitializeComponent();
    }

    private async void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductDetailModel model)
        {
            await model.GoBack();
        }
    }

    private async void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductDetailModel model)
        {
            await model.EditProduct();
        }
    }

    private async void VariantRow_Click(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement { DataContext: ProductVariantListDto variant } &&
            DataContext is ProductDetailModel model)
        {
            await model.ViewVariant(variant);
        }
    }
}
