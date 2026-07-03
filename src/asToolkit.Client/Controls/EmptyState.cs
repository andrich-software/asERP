using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace asToolkit.Client.Controls;

/// <summary>
/// Standard empty-state placeholder: centered icon, optional title, message and an optional
/// action (e.g. a "create" button). Replaces the hand-built "no items" stacks.
/// Localize via x:Uid with ".Title" / ".Message" suffix keys.
/// </summary>
public partial class EmptyState : Control
{
    public EmptyState()
    {
        DefaultStyleKey = typeof(EmptyState);
    }

    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph), typeof(string), typeof(EmptyState), new PropertyMetadata(""));

    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(EmptyState), new PropertyMetadata(string.Empty));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
        nameof(Message), typeof(string), typeof(EmptyState), new PropertyMetadata(string.Empty));

    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    public static readonly DependencyProperty ActionContentProperty = DependencyProperty.Register(
        nameof(ActionContent), typeof(object), typeof(EmptyState), new PropertyMetadata(null));

    public object? ActionContent
    {
        get => GetValue(ActionContentProperty);
        set => SetValue(ActionContentProperty, value);
    }
}
