using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace asERP.Client.Controls;

/// <summary>
/// The mandatory elevated card pattern (Surface background, CornerRadius 12,
/// ThemeShadow + Translation 0,0,8) with an optional icon + title header row,
/// implemented once. Content goes below the header with the standard 16px padding.
/// Localize the header via x:Uid with a ".Header" suffix key.
/// </summary>
public partial class SectionCard : ContentControl
{
    public SectionCard()
    {
        DefaultStyleKey = typeof(SectionCard);
    }

    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        nameof(Header), typeof(string), typeof(SectionCard), new PropertyMetadata(string.Empty));

    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly DependencyProperty HeaderGlyphProperty = DependencyProperty.Register(
        nameof(HeaderGlyph), typeof(string), typeof(SectionCard), new PropertyMetadata(string.Empty));

    public string HeaderGlyph
    {
        get => (string)GetValue(HeaderGlyphProperty);
        set => SetValue(HeaderGlyphProperty, value);
    }

    public static readonly DependencyProperty HeaderGlyphBrushProperty = DependencyProperty.Register(
        nameof(HeaderGlyphBrush), typeof(Brush), typeof(SectionCard), new PropertyMetadata(null));

    public Brush? HeaderGlyphBrush
    {
        get => (Brush?)GetValue(HeaderGlyphBrushProperty);
        set => SetValue(HeaderGlyphBrushProperty, value);
    }
}
