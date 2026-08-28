using asERP.Domain.Interfaces;

namespace asERP.Domain.Dtos.ShippingProviderRate;

public class ShippingProviderRateUpdateDto : IShippingProviderRateInputModel
{
    public Guid ShippingProviderId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; }
    public string? CarrierProduct { get; set; }
    public string? CarrierProcedure { get; set; }
    public string? CarrierParticipation { get; set; }
    public decimal MaxLength { get; set; }
    public decimal MaxWidth { get; set; }
    public decimal MaxHeight { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal Price { get; set; }
    public List<Guid> AllowedCountryIds { get; set; } = new();
}
