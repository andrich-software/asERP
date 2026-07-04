namespace asERP.Domain.Dtos.ShippingProviderRate;

public class ShippingProviderRateDetailDto
{
    public Guid Id { get; set; }
    public Guid ShippingProviderId { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal MaxLength { get; set; }
    public decimal MaxWidth { get; set; }
    public decimal MaxHeight { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal Price { get; set; }
    public List<ShippingRateCountryDto> AllowedCountries { get; set; } = new();
}
