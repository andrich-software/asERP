using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Dtos.ShippingProviderRate;

public class ShippingProviderRateUpdateDto : IShippingProviderRateInputModel
{
    public Guid ShippingProviderId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal MaxLength { get; set; }
    public decimal MaxWidth { get; set; }
    public decimal MaxHeight { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal Price { get; set; }
    public List<Guid> AllowedCountryIds { get; set; } = new();
}
