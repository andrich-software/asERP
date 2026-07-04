using System.Collections.Generic;
using System.Linq;
using asERP.Domain.Enums;
using Microsoft.UI.Xaml.Data;

namespace asERP.Client.Presentation;

/// <summary>
/// Converts a <see cref="ProductType"/> enum to localized display text.
/// </summary>
public class ProductTypeToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is ProductType type)
        {
            return type switch
            {
                ProductType.Standard => GetLocalizedString("ProductType.Standard"),
                ProductType.VariantParent => GetLocalizedString("ProductType.VariantParent"),
                ProductType.Variant => GetLocalizedString("ProductType.Variant"),
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
            "ProductType.Standard" => "Standard product",
            "ProductType.VariantParent" => "Variant product",
            "ProductType.Variant" => "Variant",
            _ => resourceKey
        };
    }
}

/// <summary>
/// Joins a list of <see cref="asERP.Domain.Dtos.Product.ProductVariantOptionDto"/> values
/// into a single readable summary like "Rot / 32".
/// </summary>
public class VariantOptionsSummaryConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is IEnumerable<asERP.Domain.Dtos.Product.ProductVariantOptionDto> options)
        {
            return string.Join(" / ", options.Select(o => o.Value));
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Returns <see cref="Visibility.Visible"/> when the bound <see cref="ProductType"/> equals the type
/// given as the converter parameter ("VariantParent", "Variant" or "Standard"); otherwise collapses.
/// </summary>
public class ProductTypeToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is ProductType type &&
            parameter is string expected &&
            Enum.TryParse<ProductType>(expected, out var target))
        {
            return type == target ? Visibility.Visible : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
