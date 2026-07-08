using Microsoft.UI.Xaml;
using Uno.Toolkit.UI;

namespace asERP.Client.Core.Helpers;

/// <summary>
/// Toggles the visibility of the named tab-content panels on a Header+Tabs detail page so
/// that only the panel matching the selected <see cref="TabBar"/> index stays visible.
/// </summary>
/// <remarks>
/// The panels are named siblings of the <see cref="TabBar"/> inside a <c>FeedView</c>
/// <c>DataTemplate</c>. Uno's <see cref="FrameworkElement.FindName"/> only searches an
/// element's own visual subtree, so calling it on the sibling <see cref="TabBar"/> never
/// resolves the panels and the page stays stuck on the default-visible tab. We therefore
/// walk up from the <see cref="TabBar"/> to the closest ancestor that can resolve the
/// panels (the template root) and search from there — which also keeps resolution scoped to
/// the current template instance when a <c>FeedView</c> briefly holds two during a refresh.
/// </remarks>
public static class TabPanelSwitcher
{
    public static void Apply(TabBar tabBar, IReadOnlyList<string> panelNames, int selectedIndex)
    {
        if (panelNames.Count == 0)
        {
            return;
        }

        var scope = ResolveScope(tabBar, panelNames[0]);
        for (var i = 0; i < panelNames.Count; i++)
        {
            if (scope.FindName(panelNames[i]) is UIElement panel)
            {
                panel.Visibility = i == selectedIndex ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }

    // Closest ancestor of the TabBar (including itself) whose subtree contains the panels.
    private static FrameworkElement ResolveScope(FrameworkElement start, string probeName)
    {
        FrameworkElement current = start;
        while (true)
        {
            if (current.FindName(probeName) is not null)
            {
                return current;
            }

            if (current.Parent is FrameworkElement parent)
            {
                current = parent;
            }
            else
            {
                return start;
            }
        }
    }
}
