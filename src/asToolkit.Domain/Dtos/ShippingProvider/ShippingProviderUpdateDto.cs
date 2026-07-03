using asToolkit.Domain.Enums;
using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Dtos.ShippingProvider;

/// <summary>
/// Update payload. Empty/null credential fields (<see cref="Password"/>, <see cref="ApiKey"/>,
/// <see cref="ApiSecret"/>) mean "keep the stored secret" — secrets are never round-tripped to the client.
/// </summary>
public class ShippingProviderUpdateDto : IShippingProviderInputModel
{
    public string Name { get; set; } = string.Empty;
    public ShippingProviderType Type { get; set; }
    public bool IsEnabled { get; set; } = true;
    public bool UseSandbox { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? ApiKey { get; set; }
    public string? ApiSecret { get; set; }
    public string? AccountNumber { get; set; }
    public string? AdditionalConfigJson { get; set; }
    public int TrackingPollIntervalSeconds { get; set; } = 3600;
}
