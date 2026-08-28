using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace asERP.Client.Features.Saless.Models;

/// <summary>
/// Row of the order items table. The product thumbnail is fetched via the authed HttpClient
/// and materialized into an ImageSource in XAML by BytesToImageSourceConverter.
/// </summary>
public class SalesItemRow : INotifyPropertyChanged
{
    private byte[]? _thumbnailBytes;

    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public string Name { get; init; } = string.Empty;

    /// <summary>SKU carried on the line itself — only set for products missing from the catalog.</summary>
    public string Sku { get; init; } = string.Empty;

    public double Quantity { get; init; }
    public decimal Price { get; init; }

    /// <summary>Primary image of the ordered product; null when the product has no images.</summary>
    public Guid? PrimaryImageId { get; init; }

    /// <summary>Line total, matching how the shipping documents compute it.</summary>
    public decimal Total => Price * (decimal)Quantity;

    public byte[]? ThumbnailBytes
    {
        get => _thumbnailBytes;
        set
        {
            _thumbnailBytes = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
