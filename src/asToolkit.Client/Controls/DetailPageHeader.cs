using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace asToolkit.Client.Controls;

/// <summary>
/// Compact ERP-style detail page header: leading icon chip, title + subtitle,
/// a badges row and right-aligned actions (Edit/Delete buttons).
/// <see cref="ContentControl.Content"/> is an optional extra slot rendered below the
/// badges (e.g. a link to a related entity).
/// Title and Subtitle accept strings or arbitrary UI (e.g. a TextBlock with Runs).
/// </summary>
public partial class DetailPageHeader : ContentControl
{
    public DetailPageHeader()
    {
        DefaultStyleKey = typeof(DetailPageHeader);
    }

    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph), typeof(string), typeof(DetailPageHeader), new PropertyMetadata(string.Empty));

    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(object), typeof(DetailPageHeader), new PropertyMetadata(null));

    public object? Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty SubtitleProperty = DependencyProperty.Register(
        nameof(Subtitle), typeof(object), typeof(DetailPageHeader), new PropertyMetadata(null));

    public object? Subtitle
    {
        get => GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    public static readonly DependencyProperty BadgesProperty = DependencyProperty.Register(
        nameof(Badges), typeof(object), typeof(DetailPageHeader), new PropertyMetadata(null));

    /// <summary>Badge row, typically a horizontal StackPanel of <see cref="StatusBadge"/> elements.</summary>
    public object? Badges
    {
        get => GetValue(BadgesProperty);
        set => SetValue(BadgesProperty, value);
    }

    public static readonly DependencyProperty ActionsProperty = DependencyProperty.Register(
        nameof(Actions), typeof(object), typeof(DetailPageHeader), new PropertyMetadata(null));

    /// <summary>Right-aligned action area, typically buttons like Edit/Delete.</summary>
    public object? Actions
    {
        get => GetValue(ActionsProperty);
        set => SetValue(ActionsProperty, value);
    }
}
