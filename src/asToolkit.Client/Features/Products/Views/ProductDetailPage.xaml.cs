using asToolkit.Client.Features.Products.Models;
using asToolkit.Domain.Dtos.Product;
using Microsoft.UI.Xaml.Controls;
using Uno.Toolkit.UI;

namespace asToolkit.Client.Features.Products.Views;

public sealed partial class ProductDetailPage : Page
{
    private static readonly string[] TabPanelNames = ["OverviewTab", "DescriptionTab", "VariantsTab", "ImagesTab"];
    private const int ImagesTabIndex = 3;

    // Survives FeedView template re-realization (e.g. refresh after returning from Edit).
    private int _selectedTabIndex;
    private bool _imagesFeedRequested;

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

        if (_selectedTabIndex == ImagesTabIndex)
        {
            EnsureImagesFeedRequested();
        }
    }

    // Kick off the lazy images feed the first time the tab is opened.
    private async void EnsureImagesFeedRequested()
    {
        if (_imagesFeedRequested || DataContext is not ProductDetailModel model)
        {
            return;
        }

        _imagesFeedRequested = true;
        await model.RequestImagesTab();
    }
}
