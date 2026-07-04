using Windows.ApplicationModel.Resources;

namespace asToolkit.Client.Core.Helpers;

/// <summary>Shared confirmation dialog for destructive actions (order/shipment cancel, deletes).</summary>
public static class ConfirmDialog
{
    /// <summary>Shows a confirm dialog; keys are resolved via ResourceLoader (dot-separated).
    /// Returns true when the user confirmed.</summary>
    public static async Task<bool> ShowAsync(
        XamlRoot xamlRoot,
        string titleKey,
        string messageKey,
        string confirmKey = "Common.Delete",
        string cancelKey = "Common.Cancel")
    {
        var resourceLoader = ResourceLoader.GetForViewIndependentUse();

        var dialog = new ContentDialog
        {
            Title = resourceLoader.GetString(titleKey),
            Content = resourceLoader.GetString(messageKey),
            PrimaryButtonText = resourceLoader.GetString(confirmKey),
            CloseButtonText = resourceLoader.GetString(cancelKey),
            DefaultButton = ContentDialogButton.Close,
            XamlRoot = xamlRoot,
            Style = Application.Current.Resources["ContentDialogStyle"] as Style
        };

        var result = await dialog.ShowAsync();
        return result == ContentDialogResult.Primary;
    }
}
