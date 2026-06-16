using maERP.Client.Features.Search.Models;
using maERP.Domain.Dtos.Search;

namespace maERP.Client.Features.Search.Views;

public sealed partial class SearchResultsPage : Page
{
    public SearchResultsPage()
    {
        this.InitializeComponent();
    }

    private async void Hit_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button &&
            button.DataContext is GlobalSearchHitDto hit &&
            DataContext is SearchResultsModel model)
        {
            await model.NavigateToHit(hit);
        }
    }
}
