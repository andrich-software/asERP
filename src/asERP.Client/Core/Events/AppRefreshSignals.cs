namespace asERP.Client.Core.Events;

/// <summary>
/// App-wide, cross-feature refresh signals. Mirrors the static-event pattern used by
/// <c>ShellModel</c> (AuthenticationStateChanged, SalesChannelsChanged) so features can react to
/// changes raised elsewhere without taking a DI dependency on each other.
///
/// Subscribers must unsubscribe (subscribe in a view's Loaded, unsubscribe in Unloaded) to avoid
/// leaking transient view models. Handlers may run on a background thread — marshal to the UI
/// thread before touching UI.
/// </summary>
public static class AppRefreshSignals
{
    /// <summary>Raised when products may have changed (e.g. a sales-channel product import finished).</summary>
    public static event EventHandler? ProductsChanged;

    public static void RaiseProductsChanged() => ProductsChanged?.Invoke(null, EventArgs.Empty);
}
