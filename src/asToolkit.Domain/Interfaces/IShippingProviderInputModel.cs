using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Interfaces;

public interface IShippingProviderInputModel
{
    string Name { get; }
    ShippingProviderType Type { get; }
    bool IsEnabled { get; }
    bool UseSandbox { get; }
    string Username { get; }
    string Password { get; }
    string? ApiKey { get; }
    string? ApiSecret { get; }
    string? AccountNumber { get; }
    string? AdditionalConfigJson { get; }
    int TrackingPollIntervalSeconds { get; }
}
