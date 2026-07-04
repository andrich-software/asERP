using asERP.Domain.Enums;
using asERP.Domain.Interfaces;

namespace asERP.Domain.Dtos.ShippingProvider;

public class ShippingProviderCreateDto : IShippingProviderInputModel
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
