using asToolkit.Client.Core.Exceptions;
using asToolkit.Client.Core.Notifications;
using asToolkit.Client.Features.Auth.Services;
using Windows.ApplicationModel.Resources;

namespace asToolkit.Client.Features.Shippings.Services;

/// <summary>
/// Code-behind helper that runs label actions with toasts. Shared by the shipment detail
/// page, the order-detail shipments tab and the create-shipment dialog so every entry point
/// behaves identically (remembered preference first, platform default otherwise).
/// </summary>
public static class LabelActionRunner
{
    private static IServiceProvider? Services => (Application.Current as App)?.Host?.Services;

    /// <summary>
    /// One-click label action: uses the remembered tenant preference when present, otherwise
    /// the platform default (Desktop: save dialog; WASM: download; else: system default app).
    /// </summary>
    public static async Task RunQuickAsync(Guid shippingId)
    {
        if (Services is not { } services)
        {
            return;
        }

        var labelService = services.GetRequiredService<ILabelService>();
        var preferences = services.GetRequiredService<IShippingPreferences>();
        var tokenStorage = services.GetRequiredService<ITokenStorageService>();

        var tenantId = await tokenStorage.GetCurrentTenantIdAsync() ?? Guid.Empty;
        var pref = preferences.GetLabelAction(tenantId) ?? DefaultAction(labelService.Capabilities);

        await RunAsync(shippingId, pref.Action, pref.PrinterName);
    }

    /// <summary>Fetches the label and executes the given action, surfacing toasts.</summary>
    public static async Task RunAsync(Guid shippingId, LabelAction action, string? printerName)
    {
        if (Services is not { } services)
        {
            return;
        }

        var labelService = services.GetRequiredService<ILabelService>();
        var notifications = services.GetRequiredService<INotificationService>();
        var resourceLoader = ResourceLoader.GetForViewIndependentUse();

        try
        {
            var label = await labelService.FetchLabelAsync(shippingId);
            var capabilities = labelService.Capabilities;

            if (action is LabelAction.Save or LabelAction.Download
                && (capabilities.HasFlag(LabelCapabilities.Save) || capabilities.HasFlag(LabelCapabilities.Download)))
            {
                // SaveAsync reports picker cancellation — no toast in that case.
                if (await labelService.SaveAsync(label))
                {
                    notifications.Show(resourceLoader.GetString(SuccessKey(action, capabilities)), NotificationSeverity.Success);
                }
            }
            else if (action is LabelAction.Print && capabilities.HasFlag(LabelCapabilities.Print))
            {
                await labelService.PrintAsync(label, printerName);
                notifications.Show(resourceLoader.GetString("LabelAction.Printed"), NotificationSeverity.Success);
            }
            else
            {
                // Fallback: hand the label to the system default app, no toast needed.
                await labelService.OpenWithSystemDefaultAsync(label);
            }
        }
        catch (ApiException ex)
        {
            notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
        }
        catch (Exception)
        {
            notifications.Show(resourceLoader.GetString("LabelAction.Failed") ?? string.Empty, NotificationSeverity.Error);
        }
    }

    /// <summary>
    /// Windows-desktop printer picker (small ContentDialog with a ComboBox); returns the
    /// chosen printer, null for "default printer" and cancels with (false, null).
    /// </summary>
    public static async Task<(bool Confirmed, string? PrinterName)> PickPrinterAsync(XamlRoot xamlRoot)
    {
        if (Services is not { } services)
        {
            return (false, null);
        }

        var labelService = services.GetRequiredService<ILabelService>();
        var preferences = services.GetRequiredService<IShippingPreferences>();
        var tokenStorage = services.GetRequiredService<ITokenStorageService>();
        var resourceLoader = ResourceLoader.GetForViewIndependentUse();

        var printers = await labelService.GetPrinterNamesAsync();
        if (printers.Count == 0)
        {
            return (true, null);
        }

        var comboBox = new ComboBox
        {
            ItemsSource = printers,
            HorizontalAlignment = HorizontalAlignment.Stretch,
        };

        var tenantId = await tokenStorage.GetCurrentTenantIdAsync() ?? Guid.Empty;
        var remembered = preferences.GetLabelAction(tenantId)?.PrinterName;
        comboBox.SelectedIndex = remembered is not null && printers.Contains(remembered)
            ? printers.ToList().IndexOf(remembered)
            : 0;

        var dialog = new ContentDialog
        {
            Title = resourceLoader.GetString("LabelAction.PrinterLabel"),
            Content = comboBox,
            PrimaryButtonText = resourceLoader.GetString("LabelAction.Print.Content"),
            CloseButtonText = resourceLoader.GetString("Common.Cancel"),
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = xamlRoot,
            Style = Application.Current.Resources["ContentDialogStyle"] as Style,
        };

        var result = await dialog.ShowAsync();
        return result == ContentDialogResult.Primary
            ? (true, comboBox.SelectedItem as string)
            : (false, null);
    }

    /// <summary>Platform default when nothing is remembered: save dialog on Desktop,
    /// download on WASM, system default app elsewhere.</summary>
    public static LabelActionPreference DefaultAction(LabelCapabilities capabilities)
    {
        if (capabilities.HasFlag(LabelCapabilities.Save))
        {
            return new LabelActionPreference(LabelAction.Save, null);
        }

        if (capabilities.HasFlag(LabelCapabilities.Download))
        {
            return new LabelActionPreference(LabelAction.Download, null);
        }

        // ExecuteAsync falls back to OpenWithSystemDefault for missing capabilities.
        return new LabelActionPreference(LabelAction.Save, null);
    }

    private static string SuccessKey(LabelAction action, LabelCapabilities capabilities) => action switch
    {
        LabelAction.Print when capabilities.HasFlag(LabelCapabilities.Print) => "LabelAction.Printed",
        LabelAction.Download => "LabelAction.Downloaded",
        LabelAction.Save when capabilities.HasFlag(LabelCapabilities.Download) => "LabelAction.Downloaded",
        _ => "LabelAction.Saved",
    };
}
