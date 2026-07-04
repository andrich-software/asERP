using Windows.Storage;

namespace asToolkit.Client.Features.Shippings.Services;

/// <summary>LocalSettings-backed preferences (isolated storage on Desktop, localStorage on WASM).</summary>
public class ShippingPreferences : IShippingPreferences
{
    internal static string LastRateKey(Guid tenantId) => $"shipping.lastRate.{tenantId:N}";
    internal static string LabelActionKey(Guid tenantId) => $"shipping.labelAction.{tenantId:N}";

    public Guid? GetLastRateId(Guid tenantId)
    {
        var value = ApplicationData.Current.LocalSettings.Values.TryGetValue(LastRateKey(tenantId), out var raw)
            ? raw as string
            : null;
        return Guid.TryParse(value, out var id) ? id : null;
    }

    public void SetLastRateId(Guid tenantId, Guid rateId) =>
        ApplicationData.Current.LocalSettings.Values[LastRateKey(tenantId)] = rateId.ToString();

    public LabelActionPreference? GetLabelAction(Guid tenantId)
    {
        var value = ApplicationData.Current.LocalSettings.Values.TryGetValue(LabelActionKey(tenantId), out var raw)
            ? raw as string
            : null;
        return LabelActionPreference.TryParse(value);
    }

    public void SetLabelAction(Guid tenantId, LabelActionPreference? preference)
    {
        if (preference == null)
        {
            ApplicationData.Current.LocalSettings.Values.Remove(LabelActionKey(tenantId));
            return;
        }

        ApplicationData.Current.LocalSettings.Values[LabelActionKey(tenantId)] = preference.Serialize();
    }
}
