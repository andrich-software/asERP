using asERP.Domain.Enums;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace asERP.Client.Presentation;

/// <summary>
/// Single source of truth for which channel types expose the import/export sync settings in the
/// UI. The internal types have none: PointOfSale does not sync at all, and asShop runs on the
/// ERP's own data so every sync direction is implicitly always on (persisted as all-true, not
/// user-editable). Used by the edit page (toggles) and the detail page (status badges).
/// </summary>
public static class SalesChannelSyncSettingsVisibility
{
    public static bool HasSyncSettings(SalesChannelType type) =>
        type is not (SalesChannelType.PointOfSale or SalesChannelType.AsShop);
}

/// <summary>
/// Converts a <see cref="SalesChannelType"/> to the visibility of the sync-settings section —
/// collapsed for the internal channel types (see <see cref="SalesChannelSyncSettingsVisibility"/>).
/// </summary>
public class SalesChannelTypeToSyncSettingsVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language) =>
        value is SalesChannelType type && SalesChannelSyncSettingsVisibility.HasSyncSettings(type)
            ? Visibility.Visible
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Converts SalesChannelType enum to localized display text.
/// </summary>
public class SalesChannelTypeToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is SalesChannelType type)
        {
            return type switch
            {
                SalesChannelType.PointOfSale => GetLocalizedString("SalesChannelType.PointOfSale"),
                SalesChannelType.AsShop => GetLocalizedString("SalesChannelType.AsShop"),
                SalesChannelType.Shopware6 => GetLocalizedString("SalesChannelType.Shopware6"),
                SalesChannelType.WooCommerce => GetLocalizedString("SalesChannelType.WooCommerce"),
                SalesChannelType.WooCommerceDatabase => GetLocalizedString("SalesChannelType.WooCommerceDatabase"),
                SalesChannelType.eBay => GetLocalizedString("SalesChannelType.eBay"),
                SalesChannelType.Amazon => GetLocalizedString("SalesChannelType.Amazon"),
                _ => type.ToString()
            };
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }

    private static string GetLocalizedString(string resourceKey)
    {
        try
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
            var result = resourceLoader.GetString(resourceKey);
            return !string.IsNullOrEmpty(result) ? result : GetFallbackString(resourceKey);
        }
        catch
        {
            return GetFallbackString(resourceKey);
        }
    }

    private static string GetFallbackString(string resourceKey)
    {
        return resourceKey switch
        {
            "SalesChannelType.PointOfSale" => "Point of Sale",
            "SalesChannelType.AsShop" => "asShop",
            "SalesChannelType.Shopware6" => "Shopware 6",
            "SalesChannelType.WooCommerce" => "WooCommerce",
            "SalesChannelType.WooCommerceDatabase" => "WooCommerce (Database)",
            "SalesChannelType.eBay" => "eBay",
            "SalesChannelType.Amazon" => "Amazon",
            _ => resourceKey
        };
    }
}
