using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace asToolkit.Client.Controls;

/// <summary>
/// Cloudflare-style page header for list/overview pages: large title with an
/// optional leading icon, a gray one-to-two-line description below it, and an
/// actions slot (primary button etc.) aligned top-right.
/// Localize Title/Description via x:Uid (".Title"/".Description" suffix keys);
/// keys must exist in both de and en resw.
/// </summary>
public partial class PageHeader : ContentControl
{
    public PageHeader()
    {
        DefaultStyleKey = typeof(PageHeader);
    }

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(PageHeader), new PropertyMetadata(string.Empty));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
        nameof(Description), typeof(string), typeof(PageHeader), new PropertyMetadata(string.Empty));

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph), typeof(string), typeof(PageHeader), new PropertyMetadata(string.Empty));

    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    public static readonly DependencyProperty ActionsProperty = DependencyProperty.Register(
        nameof(Actions), typeof(object), typeof(PageHeader), new PropertyMetadata(null));

    public object? Actions
    {
        get => GetValue(ActionsProperty);
        set => SetValue(ActionsProperty, value);
    }
}
