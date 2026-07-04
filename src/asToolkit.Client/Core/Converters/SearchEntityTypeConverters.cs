using asToolkit.Domain.Enums;
using Microsoft.UI.Xaml.Data;

namespace asToolkit.Client.Presentation;

/// <summary>
/// Converts a <see cref="SearchEntityType"/> to a Segoe MDL2 glyph so a quick-search
/// suggestion shows its entity type at a glance.
/// </summary>
public class SearchEntityTypeToGlyphConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is SearchEntityType type)
        {
            return type switch
            {
                SearchEntityType.Customer => "", // Contact
                SearchEntityType.Sales => "",    // Shop / cart
                SearchEntityType.Invoice => "",  // Document
                SearchEntityType.Product => "",  // Tag
                SearchEntityType.Shipping => "", // Delivery truck
                _ => ""                           // Search
            };
        }
        return "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Converts a <see cref="SearchEntityType"/> to a localized type label
/// (e.g. "Kunde", "Bestellung") shown next to each quick-search suggestion.
/// </summary>
public class SearchEntityTypeToLabelConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is SearchEntityType type)
        {
            return type switch
            {
                SearchEntityType.Customer => LocalizationHelper.GetLocalizedString("SearchType.Customer", "Customer"),
                SearchEntityType.Sales => LocalizationHelper.GetLocalizedString("SearchType.Sales", "Order"),
                SearchEntityType.Invoice => LocalizationHelper.GetLocalizedString("SearchType.Invoice", "Invoice"),
                SearchEntityType.Product => LocalizationHelper.GetLocalizedString("SearchType.Product", "Product"),
                SearchEntityType.Shipping => LocalizationHelper.GetLocalizedString("SearchType.Shipping", "Shipment"),
                _ => string.Empty
            };
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
