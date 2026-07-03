using asToolkit.Domain.Enums;
using Microsoft.UI.Xaml.Data;

namespace asToolkit.Client.Presentation;

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
            "SalesChannelType.Shopware6" => "Shopware 6",
            "SalesChannelType.WooCommerce" => "WooCommerce",
            "SalesChannelType.WooCommerceDatabase" => "WooCommerce (Database)",
            "SalesChannelType.eBay" => "eBay",
            "SalesChannelType.Amazon" => "Amazon",
            _ => resourceKey
        };
    }
}
