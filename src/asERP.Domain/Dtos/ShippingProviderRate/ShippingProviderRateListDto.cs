namespace asERP.Domain.Dtos.ShippingProviderRate;

public class ShippingProviderRateListDto
{
    public Guid Id { get; set; }
    public Guid ShippingProviderId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal MaxLength { get; set; }
    public decimal MaxWidth { get; set; }
    public decimal MaxHeight { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal Price { get; set; }
    public int AllowedCountryCount { get; set; }
}
