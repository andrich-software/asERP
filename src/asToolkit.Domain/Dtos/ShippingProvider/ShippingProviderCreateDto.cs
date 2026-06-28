using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Dtos.ShippingProvider;

public class ShippingProviderCreateDto : IShippingProviderInputModel
{
    public string Name { get; set; } = string.Empty;
}