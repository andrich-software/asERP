using asERP.Domain.Dtos.ShippingProviderRate;
using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.ShippingProvider;

/// <summary>
/// Detail view. Secrets are never echoed — only the <c>Has*</c> presence flags.
/// </summary>
public class ShippingProviderDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ShippingProviderType Type { get; set; }
    public bool IsEnabled { get; set; }
    public bool UseSandbox { get; set; }
    public string Username { get; set; } = string.Empty;
    public string? AccountNumber { get; set; }
    public string? AdditionalConfigJson { get; set; }
    public int TrackingPollIntervalSeconds { get; set; }

    public bool HasPassword { get; set; }
    public bool HasApiKey { get; set; }
    public bool HasApiSecret { get; set; }

    public List<ShippingProviderRateListDto> Rates { get; set; } = new();
}
