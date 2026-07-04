using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Controls;

/// <summary>
/// Pill-shaped badge that renders any status value (SalesStatus, PaymentStatus, InvoiceStatus,
/// CustomerStatus, bool sync flag) with localized text and theme-aware semantic colors.
/// Text and color kind are resolved centrally via <see cref="StatusVisuals"/>.
/// </summary>
public partial class StatusBadge : Control
{
    public StatusBadge()
    {
        DefaultStyleKey = typeof(StatusBadge);
    }

    public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(
        nameof(Status), typeof(object), typeof(StatusBadge),
        new PropertyMetadata(null, static (d, _) => ((StatusBadge)d).OnStatusChanged()));

    public object? Status
    {
        get => GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register(
        nameof(DisplayText), typeof(string), typeof(StatusBadge), new PropertyMetadata(string.Empty));

    /// <summary>Resolved localized text; set by the control, template-bound by the style.</summary>
    public string DisplayText
    {
        get => (string)GetValue(DisplayTextProperty);
        private set => SetValue(DisplayTextProperty, value);
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        OnStatusChanged();
    }

    private void OnStatusChanged()
    {
        var (text, kind) = StatusVisuals.Resolve(Status);
        DisplayText = text;
        VisualStateManager.GoToState(this, kind.ToString(), useTransitions: false);
    }
}
