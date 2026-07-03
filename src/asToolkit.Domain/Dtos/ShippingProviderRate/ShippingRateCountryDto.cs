namespace asToolkit.Domain.Dtos.ShippingProviderRate;

public class ShippingRateCountryDto
{
    public Guid CountryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
}
