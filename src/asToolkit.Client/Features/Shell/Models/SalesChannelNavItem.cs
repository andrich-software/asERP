namespace asToolkit.Client.Features.Shell.Models;

/// <summary>
/// One dynamic sidebar entry for a configured sales channel. <paramref name="Tag"/>
/// encodes "SalesChannel_{id}_{typeInt}_{name}" and is parsed by the Shell's
/// navigation switch to open the matching dashboard.
/// </summary>
public sealed record SalesChannelNavItem(string Tag, string Glyph, string Name);
