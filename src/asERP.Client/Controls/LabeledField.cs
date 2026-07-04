using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Controls;

/// <summary>
/// Read-only field with an optional leading icon, a small label and a value.
/// Shows a localized "not available" placeholder when the value is null or empty,
/// replacing the copy-pasted icon/label/value + StringToVisibility blocks on detail pages.
/// The label property is deliberately named <see cref="Text"/> so existing
/// <c>*.Field.*.Text</c> resw keys keep working via x:Uid.
/// Use <c>LabeledFieldKeyValueStyle</c> for the label-left / value-right variant.
/// </summary>
public partial class LabeledField : Control
{
    public LabeledField()
    {
        DefaultStyleKey = typeof(LabeledField);
    }

    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph), typeof(string), typeof(LabeledField), new PropertyMetadata(string.Empty));

    /// <summary>Optional leading FontIcon glyph; hidden when empty.</summary>
    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text), typeof(string), typeof(LabeledField), new PropertyMetadata(string.Empty));

    /// <summary>The field label (localizable via x:Uid with a ".Text" suffix key).</summary>
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(Value), typeof(object), typeof(LabeledField),
        new PropertyMetadata(null, static (d, _) => ((LabeledField)d).OnValueChanged()));

    public object? Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty ValueWrapsProperty = DependencyProperty.Register(
        nameof(ValueWraps), typeof(bool), typeof(LabeledField),
        new PropertyMetadata(false, static (d, _) => ((LabeledField)d).OnValueWrapsChanged()));

    public bool ValueWraps
    {
        get => (bool)GetValue(ValueWrapsProperty);
        set => SetValue(ValueWrapsProperty, value);
    }

    public static readonly DependencyProperty DisplayValueProperty = DependencyProperty.Register(
        nameof(DisplayValue), typeof(string), typeof(LabeledField), new PropertyMetadata(string.Empty));

    /// <summary>Resolved value text (or the localized "not available" placeholder); template-bound.</summary>
    public string DisplayValue
    {
        get => (string)GetValue(DisplayValueProperty);
        private set => SetValue(DisplayValueProperty, value);
    }

    public static readonly DependencyProperty ValueWrappingProperty = DependencyProperty.Register(
        nameof(ValueWrapping), typeof(TextWrapping), typeof(LabeledField),
        new PropertyMetadata(TextWrapping.NoWrap));

    /// <summary>Derived from <see cref="ValueWraps"/>; template-bound.</summary>
    public TextWrapping ValueWrapping
    {
        get => (TextWrapping)GetValue(ValueWrappingProperty);
        private set => SetValue(ValueWrappingProperty, value);
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        OnValueChanged();
    }

    private void OnValueChanged()
    {
        var text = Value switch
        {
            null => null,
            string s => string.IsNullOrWhiteSpace(s) ? null : s,
            _ => Value.ToString(),
        };

        if (text is null)
        {
            DisplayValue = LocalizationHelper.GetLocalizedString("Common.NotAvailable", "N/A");
            VisualStateManager.GoToState(this, "ValueMissing", useTransitions: false);
        }
        else
        {
            DisplayValue = text;
            VisualStateManager.GoToState(this, "ValuePresent", useTransitions: false);
        }
    }

    private void OnValueWrapsChanged()
    {
        ValueWrapping = ValueWraps ? TextWrapping.Wrap : TextWrapping.NoWrap;
    }
}
