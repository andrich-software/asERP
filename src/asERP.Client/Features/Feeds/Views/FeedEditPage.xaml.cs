using asERP.Client.Features.Feeds.Models;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Features.Feeds.Views;

public sealed partial class FeedEditPage : Page
{
    public FeedEditPage()
    {
        this.InitializeComponent();
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedEditModel model)
        {
            await model.CancelAsync();
        }
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedEditModel model)
        {
            await model.SaveAsync();
        }
    }

    private async void SearchProducts_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedEditModel model)
        {
            await model.SearchProductsAsync();
        }
    }

    private async void PreviousProductPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedEditModel model)
        {
            await model.GoToPreviousProductPageAsync();
        }
    }

    private async void NextProductPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedEditModel model)
        {
            await model.GoToNextProductPageAsync();
        }
    }

    private void SelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedEditModel model)
        {
            model.SetAllOnCurrentPage(true);
        }
    }

    private void SelectAllCheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        if (DataContext is FeedEditModel model)
        {
            model.SetAllOnCurrentPage(false);
        }
    }
}
