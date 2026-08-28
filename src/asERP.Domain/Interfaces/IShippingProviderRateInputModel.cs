namespace asERP.Domain.Interfaces;

public interface IShippingProviderRateInputModel
{
    Guid ShippingProviderId { get; }
    string Name { get; }
    string? Description { get; }
    bool IsActive { get; }
    int SortOrder { get; }
    string? CarrierProduct { get; }
    string? CarrierProcedure { get; }
    string? CarrierParticipation { get; }
    decimal MaxLength { get; }
    decimal MaxWidth { get; }
    decimal MaxHeight { get; }
    decimal MaxWeight { get; }
    decimal Price { get; }
    List<Guid> AllowedCountryIds { get; }
}
