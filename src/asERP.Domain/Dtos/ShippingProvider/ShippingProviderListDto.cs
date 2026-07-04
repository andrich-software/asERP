using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.ShippingProvider;

public class ShippingProviderListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ShippingProviderType Type { get; set; }
    public bool IsEnabled { get; set; }
    public bool UseSandbox { get; set; }
    public int RateCount { get; set; }
}
