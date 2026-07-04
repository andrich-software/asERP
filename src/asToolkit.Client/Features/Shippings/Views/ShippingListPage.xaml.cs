using asToolkit.Client.Controls;
using asToolkit.Client.Features.Shippings.Models;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Enums;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Resources;

namespace asToolkit.Client.Features.Shippings.Views;

public sealed partial class ShippingListPage : Page
{
    private bool _isInitializing = true;

    public ShippingListPage()
    {
        this.InitializeComponent();
        BuildStatusFilterItems();
        this.Loaded += (_, _) => _isInitializing = false;
    }

    /// <summary>
    /// Populates the status ComboBox with an "all" entry plus every ShippingStatus value,
    /// using the same localized texts as the StatusBadge (StatusVisuals).
    /// </summary>
    private void BuildStatusFilterItems()
    {
        var resourceLoader = ResourceLoader.GetForViewIndependentUse();

        StatusFilterComboBox.Items.Add(new ComboBoxItem
        {
            Content = resourceLoader.GetString("ShippingListPage.StatusFilterAll"),
            Tag = 0
        });

        foreach (var status in Enum.GetValues<ShippingStatus>())
        {
            StatusFilterComboBox.Items.Add(new ComboBoxItem
            {
                Content = StatusVisuals.Resolve(status).Text,
                Tag = (int)status
            });
        }

        StatusFilterComboBox.SelectedIndex = 0;
    }

    private async void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox && DataContext is ShippingListModel model)
        {
            await model.SetSearch(textBox.Text);
        }
    }

    private async void StatusFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_isInitializing) return;

        if (sender is ComboBox { SelectedItem: ComboBoxItem { Tag: int status } } &&
            DataContext is ShippingListModel model)
        {
            await model.SetStatusFilter(status);
        }
    }

    private async void ProblemsOnlyToggle_Toggled(object sender, RoutedEventArgs e)
    {
        if (_isInitializing) return;

        if (sender is ToggleSwitch toggle && DataContext is ShippingListModel model)
        {
            await model.SetProblemsOnly(toggle.IsOn);
        }
    }

    private async void SortHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is SortHeaderButton { SortField: { Length: > 0 } field } &&
            DataContext is ShippingListModel model)
        {
            await model.ToggleSort(field);
        }
    }

    private async void ShippingRow_Click(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is ShipmentListItemDto item &&
            DataContext is ShippingListModel model)
        {
            await model.ViewShipping(item);
        }
    }

    private void CopyTracking_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { CommandParameter: string trackingNumber } &&
            !string.IsNullOrWhiteSpace(trackingNumber))
        {
            var package = new DataPackage();
            package.SetText(trackingNumber);
            Clipboard.SetContent(package);

            if (DataContext is ShippingListModel model)
            {
                model.NotifyTrackingCopied();
            }
        }
    }

    private async void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ShippingListModel model)
        {
            await model.GoToPreviousPage();
        }
    }

    private async void NextPage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ShippingListModel model)
        {
            await model.GoToNextPage();
        }
    }

    private async void PageSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_isInitializing) return;

        if (sender is ComboBox comboBox &&
            comboBox.SelectedItem is ComboBoxItem selectedItem &&
            selectedItem.Tag is string pageSizeStr &&
            int.TryParse(pageSizeStr, out var pageSize) &&
            DataContext is ShippingListModel model)
        {
            await model.SetPageSize(pageSize);
        }
    }
}
