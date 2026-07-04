using asToolkit.Client.Core.Exceptions;
using asToolkit.Client.Core.Notifications;
using asToolkit.Client.Features.Auth.Services;
using Windows.ApplicationModel.Resources;

namespace asToolkit.Client.Features.Shippings.Services;

/// <summary>
/// Code-behind helper for the packing-slip action. Deliberately ignores the remembered label
/// action — a packing slip is practically always printed, so the flow has its own fixed
/// default: printer dialog (with remembered packing-slip printer) on Desktop-Windows,
/// download on WASM, system default app elsewhere.
/// </summary>
public static class PackingSlipActionRunner
{
    private static IServiceProvider? Services => (Application.Current as App)?.Host?.Services;

    public static async Task RunAsync(Guid shippingId, XamlRoot? xamlRoot)
    {
        if (Services is not { } services)
        {
            return;
        }

        var labelService = services.GetRequiredService<ILabelService>();
        var preferences = services.GetRequiredService<IShippingPreferences>();
        var notifications = services.GetRequiredService<INotificationService>();
        var tokenStorage = services.GetRequiredService<ITokenStorageService>();
        var resourceLoader = ResourceLoader.GetForViewIndependentUse();

        var capabilities = labelService.Capabilities;

        try
        {
            if (capabilities.HasFlag(LabelCapabilities.Print)
                && capabilities.HasFlag(LabelCapabilities.PickPrinter)
                && xamlRoot is not null)
            {
                var tenantId = await tokenStorage.GetCurrentTenantIdAsync() ?? Guid.Empty;
                var (confirmed, printerName) = await LabelActionRunner.PickPrinterAsync(
                    xamlRoot, preferences.GetPackingSlipPrinter(tenantId));
                if (!confirmed)
                {
                    return;
                }

                var packingSlip = await labelService.FetchPackingSlipAsync(shippingId);
                await labelService.PrintAsync(packingSlip, printerName);
                preferences.SetPackingSlipPrinter(tenantId, printerName);
                notifications.Show(resourceLoader.GetString("PackingSlipAction.Printed"), NotificationSeverity.Success);
                return;
            }

            var file = await labelService.FetchPackingSlipAsync(shippingId);

            if (capabilities.HasFlag(LabelCapabilities.Download))
            {
                if (await labelService.SaveAsync(file))
                {
                    notifications.Show(resourceLoader.GetString("PackingSlipAction.Downloaded"), NotificationSeverity.Success);
                }
                return;
            }

            await labelService.OpenWithSystemDefaultAsync(file);
        }
        catch (ApiException ex)
        {
            notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
        }
        catch (Exception)
        {
            notifications.Show(resourceLoader.GetString("PackingSlipAction.Failed") ?? string.Empty, NotificationSeverity.Error);
        }
    }
}
