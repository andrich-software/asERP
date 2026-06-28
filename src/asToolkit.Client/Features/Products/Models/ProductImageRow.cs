using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace asToolkit.Client.Features.Products.Models;

/// <summary>
/// Editable row for a single product image. The thumbnail bytes are fetched via the authed
/// HttpClient and materialized into an ImageSource in XAML by BytesToImageSourceConverter.
/// </summary>
public class ProductImageRow : INotifyPropertyChanged
{
    private int _sortOrder;
    private byte[]? _thumbnailBytes;

    public Guid Id { get; init; }
    public string? AltText { get; init; }
    public string? OriginalFileName { get; init; }

    public int SortOrder
    {
        get => _sortOrder;
        set
        {
            if (_sortOrder != value)
            {
                _sortOrder = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPrimary));
            }
        }
    }

    /// <summary>True for the first image in the order (the product's primary image).</summary>
    public bool IsPrimary => SortOrder == 0;

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
