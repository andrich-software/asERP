using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace asERP.Client.Controls;

/// <summary>
/// Sortable table column header: label + direction chevron. The chevron shows automatically
/// when <see cref="ActiveSortField"/> equals <see cref="SortField"/>, pointing up or down per
/// <see cref="SortAscending"/> — replacing the imperative sort-icon juggling in list page
/// code-behind. Clicking raises the normal Button.Click; the page calls the model's toggle.
/// The label property is named <see cref="Text"/> so existing <c>*.Header.*.Text</c> resw
/// keys keep working via x:Uid.
/// </summary>
public partial class SortHeaderButton : Button
{
    public SortHeaderButton()
    {
        DefaultStyleKey = typeof(SortHeaderButton);
    }

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text), typeof(string), typeof(SortHeaderButton), new PropertyMetadata(string.Empty));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly DependencyProperty SortFieldProperty = DependencyProperty.Register(
        nameof(SortField), typeof(string), typeof(SortHeaderButton),
        new PropertyMetadata(string.Empty, static (d, _) => ((SortHeaderButton)d).UpdateSortState()));

    /// <summary>The field this column sorts by (e.g. "Name").</summary>
    public string SortField
    {
        get => (string)GetValue(SortFieldProperty);
        set => SetValue(SortFieldProperty, value);
    }

    public static readonly DependencyProperty ActiveSortFieldProperty = DependencyProperty.Register(
        nameof(ActiveSortField), typeof(string), typeof(SortHeaderButton),
        new PropertyMetadata(string.Empty, static (d, _) => ((SortHeaderButton)d).UpdateSortState()));

    /// <summary>The currently active sort field (bound to model state).</summary>
    public string? ActiveSortField
    {
        get => (string?)GetValue(ActiveSortFieldProperty);
        set => SetValue(ActiveSortFieldProperty, value);
    }

    public static readonly DependencyProperty SortAscendingProperty = DependencyProperty.Register(
        nameof(SortAscending), typeof(bool), typeof(SortHeaderButton),
        new PropertyMetadata(true, static (d, _) => ((SortHeaderButton)d).UpdateSortState()));

    public bool SortAscending
    {
        get => (bool)GetValue(SortAscendingProperty);
        set => SetValue(SortAscendingProperty, value);
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        UpdateSortState();
    }

    private void UpdateSortState()
    {
        var state = !string.IsNullOrEmpty(SortField) && SortField == ActiveSortField
            ? SortAscending ? "SortAscending" : "SortDescending"
            : "SortInactive";
        VisualStateManager.GoToState(this, state, useTransitions: false);
    }
}
